using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using YoutubeListMerger.Classes;
using YT = Google.Apis.YouTube.v3;

namespace YoutubeListMerger
{
    public partial class PlaylistAnalyzer : UserControl
    {
        private YT.YouTubeService youTube;

        public string ID { get; }
        public bool IsChannelPlaylist { get; }
        public Task WorkerTask { get; private set; }
        public List<VideoInfo> VideoList { get; private set; } = new List<VideoInfo>();
        public bool IsCustom { get; }

        public string Description { get; private set; } = "Custom Playlist";
        public Image Thumbnail { get; private set; }
        public DateTime PublishDate { get; private set; } = DateTime.Now;

        public PlaylistAnalyzer(string id, bool isChannel, YT.YouTubeService youTubeService)
        {
            InitializeComponent();
            ID = id;
            IsChannelPlaylist = isChannel;
            youTube = youTubeService;
            WorkerTask = new Task(ListVideos);
        }

        public PlaylistAnalyzer(string customTitle)
        {
            IsCustom = true;
            TitleLabel.Text = customTitle;
        }

        private void ListVideos()
        {
            if (IsCustom) throw new InvalidOperationException("Custom Playlists cannot be scanned.");
            if (IsChannelPlaylist)
                AnalyzeChannel();
            else
                AnalyzePlaylist();
        }

        private void AnalyzePlaylist()
        {
            var listDetails = new YT.PlaylistsResource.ListRequest(youTube, new string[] { "snippet", "contentDetails" }) { Id = ID }.Execute().Items[0];
            TitleLabel.Text = listDetails.Snippet.Title;
            ListLoadProgress.Maximum = (int)(listDetails.ContentDetails.ItemCount ?? 0) + 1;
            Description = listDetails.Snippet.Description;
            PublishDate = listDetails.Snippet.PublishedAt ?? DateTime.Now;

            Thumbnail = OnlineImage.GetImageFromUrl(listDetails.Snippet.Thumbnails.Maxres.Url);

            ListLoadProgress.PerformStep();
            ListLoadProgress.Style = ProgressBarStyle.Continuous;

            var listQuery = new YT.PlaylistItemsResource.ListRequest(youTube, new string[] { "contentDetails", "snippet" }) { PlaylistId = ID };
            do
            {
                var queryResult = listQuery.Execute();
                listQuery.PageToken = queryResult.NextPageToken;

                foreach (var playlistItem in queryResult.Items)
                {
                    VideoList.Add(new VideoInfo(playlistItem));
                    ListLoadProgress.PerformStep();
                }
            } while (listQuery.PageToken != null);
        }

        private void AnalyzeChannel()
        {
            throw new NotImplementedException();
        }
    }
}
