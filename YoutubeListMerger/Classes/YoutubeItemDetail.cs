using System;
using System.Collections.Generic;
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
        string ThumbnailUrl { get; }
        DateTime PublishDate { get; }
    }
}
