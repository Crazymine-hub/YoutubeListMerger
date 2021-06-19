using Google.Apis.YouTube.v3.Data;
using System;
using System.Drawing;

namespace YoutubeListMerger.Classes
{
    public struct VideoInfo
    {
        public string ID { get; }
        public string Title { get; }
        public string Descrition { get; }
        public string Channel { get; }
        public Image Thumbnail { get; }
        public DateTime PublishedAt { get; }

        public VideoInfo(PlaylistItem playlistItem)
        {
            ID = playlistItem.ContentDetails.VideoId;
            Title = playlistItem.Snippet.Title;
            Descrition = playlistItem.Snippet.Description;
            Channel = playlistItem.Snippet.VideoOwnerChannelTitle;
            PublishedAt = playlistItem.Snippet.PublishedAt ?? DateTime.MinValue;
            Thumbnail = OnlineImage.GetBestResolution(playlistItem.Snippet.Thumbnails);
        }
    }
}