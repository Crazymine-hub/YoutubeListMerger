using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YT = Google.Apis.YouTube.v3;

namespace YoutubeListMerger.Classes
{
    public class PlaylistAnalyzer
    {
        private YT.YouTubeService youTube;
        public delegate void SimpleCallback();

        public string ID { get; }
        public string UniqueId { get => (IsChannelPlaylist ? "C_" : "L_") + Title; }
        public string Title { get; private set; } = "<To be analyzed>";
        public string Description { get; private set; } = "<This Playlist hasn't been analyzed yet>";
        public DateTime PublishDate { get; private set; } = DateTime.Now;
        public string ThumbnailUrl { get; private set; }
        public string Channel { get; private set; } = "<Youtube PlaylistMerger>";
        public int InaccessibleVideoCount { get; private set; }
        public string ChannelUploadPlaylistID { get; private set; }


        public List<VideoInfo> VideoList { get; private set; } = new List<VideoInfo>();
        public long TotalVideos { get; private set; }
        public bool IsChannelPlaylist { get; }
        public Task WorkerTask { get; private set; }
        public bool IsCustom { get; }
        public float Progress
        {
            get
            {
                float progress = 0;
                if (TotalVideos - InaccessibleVideoCount > 0)
                    progress = VideoList.Count / Convert.ToSingle(TotalVideos - InaccessibleVideoCount);
                return progress;
            }
        }
        private SimpleCallback redrawCallback;
        private EventHandler finishedCallback;

        public PlaylistAnalyzer(string id, bool isChannel, YT.YouTubeService youTubeService, SimpleCallback redraw, EventHandler finished)
        {
            ID = id;
            IsChannelPlaylist = isChannel;
            youTube = youTubeService;
            WorkerTask = new Task(ListVideos);
            redrawCallback = redraw;
            finishedCallback = finished;
        }

        private void ListVideos()
        {
            if (IsCustom) throw new InvalidOperationException("Custom Playlists cannot be scanned.");
            if (IsChannelPlaylist)
                AnalyzeChannel();
            else
                AnalyzePlaylist();

            finishedCallback?.Invoke(this, new EventArgs());
        }

        private void AnalyzePlaylist()
        {
            var listDetails = new YT.PlaylistsResource.ListRequest(youTube, new string[] { "snippet", "contentDetails" }) { Id = ID }.Execute().Items[0];
            Title = listDetails.Snippet.Title;
            Description = listDetails.Snippet.Description;
            PublishDate = listDetails.Snippet.PublishedAt ?? DateTime.Now;
            TotalVideos = listDetails.ContentDetails.ItemCount ?? 0;
            ThumbnailUrl = OnlineImage.GetBestResolution(listDetails.Snippet.Thumbnails);

            ListPlaylistItems(ID);
        }

        private void AnalyzeChannel()
        {
            var query = new YT.ChannelsResource.ListRequest(youTube, new string[] { "snippet", "contentDetails" }) { Id = ID };

            var result = query.Execute();
            var channelDetails = result.Items[0];

            Title = channelDetails.Snippet.Title;
            Description = channelDetails.Snippet.Description;
            PublishDate = channelDetails.Snippet.PublishedAt ?? DateTime.Now;
            ThumbnailUrl = OnlineImage.GetBestResolution(channelDetails.Snippet.Thumbnails);
            ChannelUploadPlaylistID = channelDetails.ContentDetails.RelatedPlaylists.Uploads;

            ListPlaylistItems(ChannelUploadPlaylistID);
        }

        private void ListPlaylistItems(string id)
        {
            var listQuery = new YT.PlaylistItemsResource.ListRequest(youTube, new string[] { "contentDetails", "snippet" }) { PlaylistId = id };
            do
            {
                var queryResult = listQuery.Execute();
                listQuery.PageToken = queryResult.NextPageToken;
                TotalVideos = queryResult.PageInfo.TotalResults ?? 0;

                foreach (var playlistItem in queryResult.Items)
                {
                    var video = new VideoInfo(playlistItem);
                    if (video.Channel != null)
                        VideoList.Add(video);
                    else
                        ++InaccessibleVideoCount;
                    redrawCallback?.Invoke();
                }
            } while (listQuery.PageToken != null);
        }

        public override string ToString()
        {
            string result = Title;
            if (WorkerTask.IsCompleted)
                result += " ✔DONE";
            else
                result += $" {(Progress * 100):0}%";
            return result;
        }
    }
}
