using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YT = Google.Apis.YouTube.v3.Data;

namespace YoutubeListMerger.Classes
{
    static class OnlineImage
    {
        public static Image GetImageFromUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);
            using (var response = request.GetResponse())
            {
                using (var content = response.GetResponseStream())
                    return Image.FromStream(content);
            }
        }

        public static string GetBestResolution(YT.ThumbnailDetails thumbnail)
        {
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
