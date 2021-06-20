using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeListMerger.Classes;

namespace YoutubeListMerger
{
    public partial class MergerForm : Form
    {
        private YouTubeService youTube = new YouTubeService(new BaseClientService.Initializer() { ApiKey = File.ReadAllText("./API.key") });
        private PlaylistAnalyzer videoPlaylist;
        private Stack<Task> scheduledAnalyzes = new Stack<Task>();
        private List<Task> activeAnalyzes = new List<Task>();
        private const int veryMaxConcurrentAnalyzes = 10;
        private int MaxConcurrentAnalyzes => Properties.Settings.Default.MaxConcurrentAnalyzes > veryMaxConcurrentAnalyzes ?
            veryMaxConcurrentAnalyzes :
            Properties.Settings.Default.MaxConcurrentAnalyzes;

        public MergerForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PlaylistList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            ListBox list = (ListBox)sender;
            PlaylistAnalyzer playlist = (PlaylistAnalyzer)list.Items[e.Index];

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.
            Brush textBrush = Brushes.Black;
            Brush textBrushHighlight = Brushes.White;


            RectangleF bar = new RectangleF(e.Bounds.X + 2, e.Bounds.Y + 1, e.Bounds.Width * playlist.Progress - 2, e.Bounds.Height - 2);
            RectangleF unusedBar = new RectangleF(e.Bounds.X + bar.Width, e.Bounds.Y + 1, e.Bounds.Width - bar.Width, e.Bounds.Height - 2);
            if (playlist.Progress < 1)
                e.Graphics.FillRectangle(Brushes.Green, bar);
            else
                e.Graphics.FillRectangle(Brushes.DarkGreen, bar);
            if (!e.State.HasFlag(DrawItemState.Selected) && playlist.Progress < 1)
                e.Graphics.FillRectangle(Brushes.LightGray, unusedBar);

            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            var alignment = new StringFormat(StringFormat.GenericDefault) { LineAlignment = StringAlignment.Center };
            e.Graphics.IntersectClip(bar);
            e.Graphics.DrawString(playlist.ToString(), e.Font, textBrushHighlight, e.Bounds, alignment);

            e.Graphics.ResetClip();
            e.Graphics.ExcludeClip(new Region(bar));
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            if (e.State.HasFlag(DrawItemState.Selected))
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            e.Graphics.DrawString(playlist.ToString(), e.Font, textBrush, e.Bounds, alignment);


            if (e.State.HasFlag(DrawItemState.Focus))
            {
                Rectangle focusRect = new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width, e.Bounds.Height - 2);
                e.Graphics.DrawRectangle(new Pen(Brushes.Black, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash }, focusRect);
            }
        }

        private void PlaylistList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((Action<object, EventArgs>)PlaylistList_SelectedIndexChanged, sender, e);
                return;
            }
            videoInfoBindingSource.Clear();
            var playlist = (PlaylistAnalyzer)PlaylistList.SelectedItem;
            ListPreview.UpdateDisplay(playlist);
            if (playlist == null || !playlist.IsCustom && playlist.Progress < 1)
                return;

            VideoPreview.AllowVideoRemove = playlist == videoPlaylist;

            foreach (var vid in playlist.VideoList)
                videoInfoBindingSource.Add(vid);
        }

        private void VideoList_SelectedValueChanged(object sender, EventArgs e)
        {
            var video = (VideoInfo)VideoList.SelectedItem;
            VideoPreview.UpdateDisplay(video);
        }

        private void AddEntryBtn_Click(object sender, EventArgs e)
        {
            UrlErrorProvider.Clear();
            try
            {
                ProcessUrl(YouTubeUrlInput.Text);
            }
            catch (DuplicateListException)
            {
                UrlErrorProvider.Icon = Properties.Resources.Warning;
                UrlErrorProvider.SetError(UrlEnterLabel, "This Entry already Exists");
            }
            catch
            {
                UrlErrorProvider.Icon = Properties.Resources.Error;
                UrlErrorProvider.SetError(UrlEnterLabel, "This is not a valid YouTube URL");
            }
            finally
            {
                if (string.IsNullOrWhiteSpace(UrlErrorProvider.GetError(UrlEnterLabel)))
                    YouTubeUrlInput.Clear();
            }
        }

        private void ProcessUrl(string inputUrl)
        {
            if (!inputUrl.StartsWith("http"))
                inputUrl = "https://" + inputUrl;
            Uri uri = new Uri(inputUrl);
            if (uri.Host == "youtu.be")
            {
                AddVideo(uri.AbsolutePath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                return;
            }

            if (!Regex.IsMatch(uri.Host, @"(?:www.)?youtube.com")) throw new ArgumentException("Not a YouTube URL.");

            var paras = uri.Query.TrimStart('?').Split('&').Select(x => x.Split('=')).ToList();
            bool QueryAdd(string parameterName, Action<string> successAction, bool throwOnFail = true)
            {
                string[] para = paras.SingleOrDefault(x => x[0] == parameterName);
                if (para != null)
                {
                    successAction(para[1]);
                    return true;
                }
                else
                    if (throwOnFail) throw new ArgumentException("No  Valid Parameter found");
                return false;
            }

            var path = uri.AbsolutePath.Trim('/').Split('/');
            switch (path[0])
            {
                case "watch":
                    if (!QueryAdd("list", AddPlaylist, false)) QueryAdd("v", AddVideo);
                    break;

                case "playlist":
                    QueryAdd("list", AddPlaylist);
                    break;
                case "channel":
                    AddChannel(path[1]);
                    break;
                case "user":
                    var cAnalyzer = new ChannelAnalyzer(uri);
                    cAnalyzer.ShowDialog();
                    AddChannel(cAnalyzer.ChannelId);
                    break;
                case "c":
                    cAnalyzer = new ChannelAnalyzer(uri);
                    cAnalyzer.ShowDialog();
                    AddChannel(cAnalyzer.ChannelId);
                    break;

                default: throw new ArgumentException("Not a known YouTube Page");
            }
        }

        private void AddEntryBtn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) OpenBatchButton.PerformClick();
        }

        private void AddVideo(string videoId)
        {
            if (videoPlaylist == null)
            {
                videoPlaylist = new PlaylistAnalyzer("<Your Videos>", "<Contains Videos, you added manually.>", youTube);
                playlistAnalyzerBindingSource.Add(videoPlaylist);
            }
            if (VideoInfo.VideoExists(videoId)) throw new DuplicateListException();
            videoPlaylist.AddVideo(videoId);
        }

        private void AddPlaylist(string listId)
        {
            if (playlistAnalyzerBindingSource.Cast<PlaylistAnalyzer>().FirstOrDefault(x => x.ID == listId) != null)
                throw new DuplicateListException();
            PlaylistAnalyzer analyzer = new PlaylistAnalyzer(listId, false, youTube, PlaylistList.Invalidate, TaskFinished);
            playlistAnalyzerBindingSource.Add(analyzer);
            scheduledAnalyzes.Push(analyzer.WorkerTask);
            StartNextAnalyze();
        }

        private void AddChannel(string channelId)
        {
            if (playlistAnalyzerBindingSource.Cast<PlaylistAnalyzer>().FirstOrDefault(x => x.ID == channelId) != null)
                throw new DuplicateListException();
            PlaylistAnalyzer analyzer = new PlaylistAnalyzer(channelId, true, youTube, PlaylistList.Invalidate, TaskFinished);
            playlistAnalyzerBindingSource.Add(analyzer);
            scheduledAnalyzes.Push(analyzer.WorkerTask);
            StartNextAnalyze();
        }

        private void StartNextAnalyze()
        {
            if (activeAnalyzes.Count < MaxConcurrentAnalyzes && scheduledAnalyzes.Count > 0)
            {
                Task nextTask = scheduledAnalyzes.Pop();
                activeAnalyzes.Add(nextTask);
                nextTask.Start();
            }
        }

        private void TaskFinished(object sender, EventArgs e)
        {
            PlaylistAnalyzer finished = (PlaylistAnalyzer)sender;
            activeAnalyzes.Remove(finished.WorkerTask);
            StartNextAnalyze();
            PlaylistList_SelectedIndexChanged(sender, e);
        }

        private void YouTubeUrlInput_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) AddEntryBtn.PerformClick();
        }

        private void OpenBatchButton_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;
            Enabled = false;
            if (BatchFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder errorLines = new StringBuilder("The Following URLs could not be processed:");
                errorLines.AppendLine();
                errorLines.AppendLine();
                bool hasError = false;
                int duplicateCount = 0;
                StreamReader reader = new StreamReader(BatchFileDialog.OpenFile());
                while (!reader.EndOfStream)
                {
                    string url = reader.ReadLine();
                    try
                    {
                        ProcessUrl(url);
                    }
                    catch (DuplicateListException)
                    {
                        //Ignore them, they are already being processed.
                        ++duplicateCount;
                    }
                    catch
                    {
                        hasError = true;
                        errorLines.AppendLine(url);
                    }
                }
                if (hasError)
                    MessageBox.Show(errorLines.ToString(), "Invalid URLs skipped", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(duplicateCount > 0)
                    MessageBox.Show($"Skipped {duplicateCount} duplicate(s).", "Duplicates skipped", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UseWaitCursor = false;
            Enabled = true;
        }

        private void ListPreview_RemoveButtonClicked(object sender, EventArgs e)
        {
            PlaylistAnalyzer analyzer = (PlaylistAnalyzer)PlaylistList.SelectedItem;
            playlistAnalyzerBindingSource.Remove(analyzer);
            analyzer.Dispose();
            analyzer = null;
            PlaylistList_SelectedIndexChanged(sender, e);
        }

        private void VideoPreview_RemoveButtonClicked(object sender, EventArgs e)
        {
            if (PlaylistList.SelectedItem != videoPlaylist) return;
            VideoInfo video = (VideoInfo)VideoList.SelectedItem;
            videoPlaylist.RemoveVideo(video);
            PlaylistList_SelectedIndexChanged(sender, e);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            if (scheduledAnalyzes.Count + activeAnalyzes.Count > 0) return;

        }
    }
}
