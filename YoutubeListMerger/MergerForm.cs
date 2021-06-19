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
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeListMerger.Classes;

namespace YoutubeListMerger
{
    public partial class MergerForm : Form
    {
        private YouTubeService youTube = new YouTubeService(new BaseClientService.Initializer() { ApiKey = File.ReadAllText("./API.key") });
        public List<PlaylistAnalyzer> Playlists { get; private set; }
        public Random random = new Random();

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
            if (playlist == null || !playlist.IsCustom && !playlist.WorkerTask.IsCompleted)
                return;


            foreach (var vid in playlist.VideoList)
                videoInfoBindingSource.Add(vid);
        }
    }
}
