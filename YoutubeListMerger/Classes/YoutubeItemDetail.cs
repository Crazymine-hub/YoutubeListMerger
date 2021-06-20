using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeListMerger.Classes
{
    public interface YoutubeItemDetail
    {
        string ID { get; }
        string Title { get; }
        string Description { get; }
        string Channel { get; }
        Google.Apis.YouTube.v3.Data.ThumbnailDetails Thumbnails { get; }
        DateTime PublishDate { get; }
        Image Thumbnail { get; set; }
        string ChannelId { get; }
        string ItemId { get; }
        bool IsVideo { get; }
        int ItemCount { get; }
    }
}
