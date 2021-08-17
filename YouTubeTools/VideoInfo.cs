using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace YouTubeTools
{
    public class VideoInfo : YoutubeItemDetail, IEquatable<VideoInfo>
    {
        private static ConcurrentBag<VideoInfo> requestedVideos = new ConcurrentBag<VideoInfo>();

        public string ID { get; }
        public string Title { get; }
        public string Description { get; }
        public string Channel { get; }
        public ThumbnailDetails Thumbnails { get; }
        public DateTime PublishDate { get; }
        public Image Thumbnail { get; set; }

        public string ChannelId { get; private set; }
        public string ItemId => ID;
        public bool IsVideo => true;
        public int ItemCount => 0;

        private int References { get; set; }

        private VideoInfo(PlaylistItem playlistItem)
        {
            ID = playlistItem.ContentDetails.VideoId;
            Title = playlistItem.Snippet.Title;
            Description = playlistItem.Snippet.Description;
            Channel = playlistItem.Snippet.VideoOwnerChannelTitle;
            PublishDate = playlistItem.Snippet.PublishedAt ?? DateTime.MinValue;
            Thumbnails = playlistItem.Snippet.Thumbnails;
            ChannelId = playlistItem.Snippet.VideoOwnerChannelId;
        }

        private VideoInfo(Video video)
        {
            ID = video.Id;
            Title = video.Snippet.Title;
            Description = video.Snippet.Description;
            Channel = video.Snippet.ChannelTitle;
            PublishDate = video.Snippet.PublishedAt ?? DateTime.MinValue;
            Thumbnails = video.Snippet.Thumbnails;
            ChannelId = video.Snippet.ChannelId;
        }

        public static bool VideoExists(string videoId)
        {
            var video = requestedVideos.FirstOrDefault(x => x.ID == videoId);
            return video != null && video.References > 0;
        }

        public static VideoInfo GetVideo(PlaylistItem playlistItem)
        {
            VideoInfo result = requestedVideos.SingleOrDefault(x => playlistItem.ContentDetails.VideoId == x.ID);
            if (result == null)
            {
                result = new VideoInfo(playlistItem);
                requestedVideos.Add(result);
            }
            ++result.References;
            return result;
        }

        public static VideoInfo GetVideo(Video video)
        {
            VideoInfo result = requestedVideos.SingleOrDefault(x => video.Id == x.ID);
            if (result == null)
            {
                result = new VideoInfo(video);
                requestedVideos.Add(result);
            }
            ++result.References;
            return result;
        }

        public static void DereferenceVideo(VideoInfo video)
        {
            if (--video.References <= 0)
            {
                video.Thumbnail?.Dispose();
                video.Thumbnail = null;
            }
        }

        public bool Equals(VideoInfo other)
        {
            return ID == other.ID;
        }
    }
}