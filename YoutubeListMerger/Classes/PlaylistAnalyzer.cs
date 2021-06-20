using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YT = Google.Apis.YouTube.v3;

namespace YoutubeListMerger.Classes
{
    public class PlaylistAnalyzer : YoutubeItemDetail, IDisposable
    {
        public delegate void SimpleCallback();

        private YT.YouTubeService youTube;
        private List<VideoInfo> videoList = new List<VideoInfo>();

        public string ID { get; }
        public string UniqueId { get => (IsChannelPlaylist ? "C_" : "L_") + Title; }
        public string Title { get; private set; } = "<To be analyzed>";
        public string Description { get; private set; } = "<This Playlist hasn't been analyzed yet>";
        public DateTime PublishDate { get; private set; } = DateTime.Now;
        public YT.Data.ThumbnailDetails Thumbnails { get; private set; }
        public string Channel { get; private set; } = "<Youtube PlaylistMerger>";
        public int InaccessibleVideoCount { get; private set; }
        public Image Thumbnail { get; set; }

        public string ChannelId { get; private set; }
        public string ItemId { get; private set; }
        public bool IsVideo => false;
        public int ItemCount => videoList.Count;

        public IReadOnlyList<VideoInfo> VideoList => videoList.AsReadOnly();
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
                    progress = videoList.Count / Convert.ToSingle(TotalVideos - InaccessibleVideoCount);
                return progress;
            }
        }
        private SimpleCallback redrawCallback;
        private EventHandler finishedCallback;
        private bool isDisposed = false;
        CancellationTokenSource tokenSource = new CancellationTokenSource();

        public PlaylistAnalyzer(string customTitle, string customDecription, YT.YouTubeService youTubeService)
        {
            IsCustom = true;
            youTube = youTubeService;
            Description = customDecription;
            WorkerTask = Task.CompletedTask;
            Title = customTitle;
        }

        public PlaylistAnalyzer(string id, bool isChannel, YT.YouTubeService youTubeService, SimpleCallback redraw, EventHandler finished)
        {
            ID = id;
            IsChannelPlaylist = isChannel;
            youTube = youTubeService;
            WorkerTask = new Task(ListVideos, tokenSource.Token);
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
            Thumbnails = listDetails.Snippet.Thumbnails;
            ChannelId = listDetails.Snippet.ChannelId;
            ItemId = ID;
            Channel = listDetails.Snippet.ChannelTitle;

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
            Thumbnails = channelDetails.Snippet.Thumbnails;
            ItemId = channelDetails.ContentDetails.RelatedPlaylists.Uploads;
            ChannelId = ID;
            Channel = channelDetails.Snippet.Title;

            ListPlaylistItems(ItemId);
        }

        private void ListPlaylistItems(string id)
        {
            var listQuery = new YT.PlaylistItemsResource.ListRequest(youTube, new string[] { "contentDetails", "snippet" }) { PlaylistId = id };
            var pageCnt = 0;
            var waitTask = Task.CompletedTask;
            do
            {
                var queryResult = listQuery.Execute();
                listQuery.PageToken = queryResult.NextPageToken;
                TotalVideos = queryResult.PageInfo.TotalResults ?? 0;

                if (++pageCnt % Properties.Settings.Default.AnalyzePauseInterval == 0)
                    waitTask = Task.Delay(Properties.Settings.Default.AnalyzeDelay);

                foreach (var playlistItem in queryResult.Items)
                {
                    var video = VideoInfo.GetVideo(playlistItem);
                    if (video.Channel != null)
                        videoList.Add(video);
                    else
                        ++InaccessibleVideoCount;
                }
                redrawCallback?.Invoke();
                waitTask.Wait();
                if (tokenSource.IsCancellationRequested) return;
            } while (listQuery.PageToken != null);
        }

        public override string ToString()
        {
            string result = Title;
            if (WorkerTask.IsCompleted)
            {
                if (!IsCustom)
                    result += " ✔DONE";
            }
            else
                result += $" {(Progress * 100):0}%";
            return result;
        }

        public void AddVideo(string videoId)
        {
            if (!IsCustom) throw new InvalidOperationException("Only custom Playlists can be modified");
            var videoQuery = new YT.VideosResource.ListRequest(youTube, new string[] { "id", "snippet", "contentDetails" }) { Id = videoId };
            var queryResult = videoQuery.Execute();
            videoList.Add(VideoInfo.GetVideo(queryResult.Items[0]));
        }

        public void RemoveVideo(VideoInfo videoInfo)
        {
            if (!IsCustom) throw new InvalidOperationException("Only custom Playlists can be modified");
            videoList.Remove(videoInfo);
        }

        public void Dispose()
        {
            tokenSource.Cancel();
            youTube = null;
            Thumbnails = null;
            Thumbnail?.Dispose();
            Thumbnail = null;
            WorkerTask = null;
            foreach (VideoInfo video in videoList)
                VideoInfo.DereferenceVideo(video);
            isDisposed = true;
        }

        ~PlaylistAnalyzer()
        {
            if(!isDisposed) Dispose();
        }
    }
}
