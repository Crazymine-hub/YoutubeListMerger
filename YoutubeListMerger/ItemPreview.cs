using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeListMerger.Classes;

namespace YoutubeListMerger
{
    public partial class ItemPreview : UserControl
    {
        public event EventHandler RemoveButtonClicked;
        private YoutubeItemDetail item;

        [DefaultValue(true)]
        public bool ResizeThumbnail { get; set; } = true;
        [DefaultValue(false)]
        public bool AllowVideoRemove { get; set; }

        public ItemPreview()
        {
            InitializeComponent();
            ResetDisplay();
        }

        public void UpdateDisplay(YoutubeItemDetail youtubeItem)
        {
            item = youtubeItem;
            if (item == null)
            {
                ResetDisplay();
                return;
            }
            PreviewContext.Enabled = true;
            if (item.Thumbnail == null)
                item.Thumbnail = OnlineImage.GetBestResolution(item.Thumbnails);
            Thumbnail.Image = item.Thumbnail;
            Title.Text = item.Title;
            if (item.ItemCount > 0)
                Title.Text += $" ({item.ItemCount} Video(s))";
            ChannelName.Text = item.Channel + $" ({item.PublishDate:d})";
            Details.Text = item.Description;
            RemoveButton.Visible = !item.IsVideo || AllowVideoRemove;
            RemoveEntry.Enabled = !item.IsVideo || AllowVideoRemove;
            OpenChannelEntry.Enabled = item.ChannelId != null;
            OpenPlaylistEntry.Enabled = item.ItemId != null;
        }

        public void ResetDisplay()
        {
            item = null;
            PreviewContext.Enabled = false;
            RemoveButton.Visible = false;
            Thumbnail.Image = null;
            Title.Text = "<Nothing Selected>";
            ChannelName.Text = "<Youtube PlaylistMerger>";
            Details.Text = "<You didn't select an Item.>";
        }

        private void ItemPreview_Click(object sender, EventArgs e)
        {
            if (item == null || item.ItemId == null) return;
            var settings = Properties.Settings.Default;
            System.Diagnostics.Process.Start(settings.YouTubeDefaultUrl + (item.IsVideo ? settings.YouTubeVideoPath : settings.YouTubePlaylistPath) + item.ItemId);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveButtonClicked?.Invoke(this, e);
        }

        private void OpenChannelEntry_Click(object sender, EventArgs e)
        {
            if (item == null || item.ChannelId == null) return;
            var settings = Properties.Settings.Default;
            System.Diagnostics.Process.Start(settings.YouTubeDefaultUrl + settings.YouTubeChannelPath + item.ChannelId);
        }

        private void ItemPreview_Resize(object sender, EventArgs e)
        {
            if (!ResizeThumbnail) return;
            Thumbnail.Width = Convert.ToInt32(Math.Round(Width * 0.22 + 60, MidpointRounding.AwayFromZero));
        }
    }
}
