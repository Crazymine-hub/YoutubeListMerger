using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeListMerger.Classes
{
    class OnlineImage: YouTubeTools.YouTubeThumbnailHelper
    {
        public static Image GetImageFromUrl(ThumbnailDetails thumbnail)
        {
            string url = GetBestResolution(thumbnail);
            if (string.IsNullOrWhiteSpace(url))
                return Properties.Resources.DefaultThumbnail;
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.AllowAutoRedirect = true;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    return Properties.Resources.DefaultThumbnail;
                using (var content = response.GetResponseStream())
                    return Image.FromStream(content);
            }
        }
    }
}
