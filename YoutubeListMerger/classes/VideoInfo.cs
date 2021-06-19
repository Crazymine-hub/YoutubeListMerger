using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace YoutubeListMerger.Classes
{
    public class VideoInfo : YoutubeItemDetail, IEquatable<VideoInfo>
    {
        private static ConcurrentBag<VideoInfo> requestedVideos = new ConcurrentBag<VideoInfo>();

        public string ID { get; }
        public string Title { get; }
        public string Description { get; }
        public string Channel { get; }
        public string ThumbnailUrl { get; }
        public DateTime PublishDate { get; }

        private VideoInfo(PlaylistItem playlistItem)
        {
            ID = playlistItem.ContentDetails.VideoId;
            Title = playlistItem.Snippet.Title;
            Description = playlistItem.Snippet.Description;
            Channel = playlistItem.Snippet.VideoOwnerChannelTitle;
            PublishDate = playlistItem.Snippet.PublishedAt ?? DateTime.MinValue;
            ThumbnailUrl = OnlineImage.GetBestResolution(playlistItem.Snippet.Thumbnails);
        }

        private VideoInfo(Video video)
        {
            ID = video.Id;
            Title = video.Snippet.Title;
            Description = video.Snippet.Description;
            Channel = video.Snippet.ChannelTitle;
            PublishDate = video.Snippet.PublishedAt ?? DateTime.MinValue;
            ThumbnailUrl = OnlineImage.GetBestResolution(video.Snippet.Thumbnails);
        }

        public static bool VideoExists(string videoId)
        {
            return requestedVideos.FirstOrDefault(x => x.ID == videoId) != null;
        }

        public static VideoInfo GetVideo(PlaylistItem playlistItem)
        {
            VideoInfo video = requestedVideos.SingleOrDefault(x => playlistItem.ContentDetails.VideoId == x.ID);
            if (video == null)
            {
                video = new VideoInfo(playlistItem);
                requestedVideos.Add(video);
            }
            return video;
        }

        public static VideoInfo GetVideo(Video video)
        {
            VideoInfo result = requestedVideos.SingleOrDefault(x => video.Id == x.ID);
            if (video == null)
            {
                result = new VideoInfo(video);
                requestedVideos.Add(result);
            }
            return result;
        }

        public bool Equals(VideoInfo other)
        {
            return ID == other.ID;
        }
    }
}