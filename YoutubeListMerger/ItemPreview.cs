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
            RemoveButton.Visible = !item.IsVideo;
            RemoveEntry.Enabled = !item.IsVideo;
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
            if (item == null) return;
            var settings = Properties.Settings.Default;
            System.Diagnostics.Process.Start(settings.YouTubeDefaultUrl + (item.IsVideo ? settings.YouTubeVideoPath : settings.YouTubePlaylistPath) + item.ItemId);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveButtonClicked?.Invoke(this, e);
        }

        private void OpenChannelEntry_Click(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            System.Diagnostics.Process.Start(settings.YouTubeDefaultUrl + settings.YouTubeChannelPath + item.ChannelId);
        }
    }
}
