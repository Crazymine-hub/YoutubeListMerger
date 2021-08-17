using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeTools
{
    public class YouTubeThumbnailHelper
    {
        public static string GetBestResolution(ThumbnailDetails thumbnail)
        {
            if (thumbnail == null) return null;
            if (thumbnail.Maxres != null && thumbnail.Maxres.Url != null)
                return thumbnail.Maxres.Url;
            if (thumbnail.Standard != null && thumbnail.Standard.Url != null)
                return thumbnail.Standard.Url;
            if (thumbnail.High != null && thumbnail.High.Url != null)
                return thumbnail.High.Url;
            if (thumbnail.Medium != null && thumbnail.Medium.Url != null)
                return thumbnail.Medium.Url;
            if (thumbnail.Default__ != null && thumbnail.Default__.Url != null)
                return thumbnail.Default__.Url;
            return null;
        }
    }
}
