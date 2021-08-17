using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeListMerger.Classes;
using YouTubeTools;

namespace YoutubeListMerger
{
    public partial class ResultForm : Form
    {
        [System.Runtime.InteropServices.DllImport("Shell32.dll")]
        private static extern int FindExecutable(string lpFile, string lpDirectory, StringBuilder lpResult);

        List<PlaylistAnalyzer> playlists;
        bool continueBinge = false;
        public ResultForm(IEnumerable<PlaylistAnalyzer> listsToMerge)
        {
            InitializeComponent();
            playlists = listsToMerge.ToList();
        }


        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            videoInfoBindingSource.Clear();
            if (MergeAlphabet.Checked) MergeByAlphabet();
            else if (MergeDate.Checked) MergeByDate();
            else if (MergeZip.Checked) MergeByZipping();
            else if (MergeNone.Checked) MergeByConcatinating();
            else throw new InvalidOperationException("No merge mode selected");
            listBox1_SelectedIndexChanged(this, null);
        }

        private void MergeByAlphabet()
        {
            List<VideoInfo> videos = new List<VideoInfo>();
            foreach (var playlist in playlists)
                videos.AddRange(playlist.VideoList);
            IEnumerable<VideoInfo> ordered = videos.OrderBy(x => x.Title);
            if (MergeReverse.Checked) ordered = ordered.Reverse();
            foreach (VideoInfo video in ordered)
                videoInfoBindingSource.Add(video);
        }

        private void MergeByDate()
        {
            List<VideoInfo> videos = new List<VideoInfo>();
            foreach (var playlist in playlists)
                videos.AddRange(playlist.VideoList);
            IEnumerable<VideoInfo> ordered = videos.OrderBy(x => x.PublishDate);
            if (MergeReverse.Checked) ordered = ordered.Reverse();
            foreach (VideoInfo video in ordered)
                videoInfoBindingSource.Add(video);
        }

        private void MergeByZipping()
        {
            PlaylistOrder orderDialog = new PlaylistOrder(playlists);
            bool reverseOrder = MergeReverse.Checked;

            if (orderDialog.ShowDialog(this) != DialogResult.OK) return;
            (PlaylistAnalyzer playlist, int position)[] playlistEntries = new (PlaylistAnalyzer, int)[orderDialog.playlistSource.Count];
            for (int i = 0; i < playlistEntries.Length; ++i)
            {
                PlaylistAnalyzer playlist = (PlaylistAnalyzer)orderDialog.playlistSource[i];
                playlistEntries[i] = (playlist, reverseOrder ? playlist.ItemCount - 1 : 0);
            }

            bool hasAddedItems;
            do
            {
                hasAddedItems = false;
                for (int i = 0; i < playlistEntries.Length; ++i)
                {
                    int limitPos = reverseOrder ? -1 : playlistEntries[i].playlist.ItemCount;
                    if (playlistEntries[i].position == limitPos) continue;

                    videoInfoBindingSource.Add(playlistEntries[i].playlist.VideoList[playlistEntries[i].position]);
                    if (reverseOrder)
                        --playlistEntries[i].position;
                    else
                        ++playlistEntries[i].position;
                    hasAddedItems = true;
                }
            } while (hasAddedItems);
        }

        private void MergeByConcatinating()
        {
            PlaylistOrder orderDialog = new PlaylistOrder(playlists);
            bool reverseOrder = MergeReverse.Checked;

            if (orderDialog.ShowDialog(this) != DialogResult.OK) return;

            foreach (PlaylistAnalyzer playlist in orderDialog.playlistSource)
            {
                if (reverseOrder)
                    for (int i = playlist.ItemCount - 1; i >= 0; --i)
                        videoInfoBindingSource.Add(playlist.VideoList[i]);
                else
                    for (int i = 0; i < playlist.ItemCount; ++i)
                        videoInfoBindingSource.Add(playlist.VideoList[i]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var video = (VideoInfo)videoList.SelectedItem;
            VideoPreview.UpdateDisplay(video);
            StartBingeBtn.Enabled = true;
        }

        private void StartBingeBtn_Click(object sender, EventArgs e)
        {
            continueBinge = true;
            MessageBox.Show("Make sure, your systems default browser is closed. Otherwise the process cannot be observerd properly.\r\n" +
                "Close your Browser after you're done watching the current video and it will re-open with the next video.", "How to binge watch", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var bingeTask = Task.Run(StartBingeWatch);
            MessageBox.Show(this, "Click OK to stop binging.", "Binge Watching Youtube Videos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            continueBinge = false;
        }

        private void StartBingeWatch()
        {
            int index = -1;
            Invoke((MethodInvoker)delegate { index = videoList.SelectedIndex; });
            string browserExe = GetDefaultBrowser();
            while (index < videoInfoBindingSource.Count && continueBinge)
            {
                Invoke((MethodInvoker)delegate { videoList.SelectedIndex = index; });
                VideoInfo video = (VideoInfo)videoInfoBindingSource[index];

                //IEnumerable<Process> GetBrowserProcesses() =>
                //    Process.GetProcesses().Where(x => x.StartInfo.FileName.Equals(browserExe, StringComparison.InvariantCultureIgnoreCase));

                //var browsers = GetBrowserProcesses().Select(x => x.Id);

                Process.Start(browserExe, $"https://youtu.be/{video.ID}").WaitForExit();
                //var newBrowsers = GetBrowserProcesses().Where(x => !browsers.Contains(x.Id)).ToArray();
                //if (newBrowsers.Length != 1) throw new Exception("Couldn't identify system browser");
                //newBrowsers[0].WaitForExit();

                ++index;
            }
        }

        private string GetDefaultBrowser()
        {
            StringBuilder browserName = new StringBuilder(255);
            string filePath = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "blankpage.html");
            File.WriteAllText(filePath, "", Encoding.UTF8);
            int hresult = FindExecutable(filePath, null, browserName);
            if (hresult <= 32)
                throw new Exception($"FindExecutable: hResult was {hresult}");
            return browserName.ToString();
        }

        private void ExportCSVBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

