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

        public static Image GetBestResolution(YT.ThumbnailDetails thumbnail)
        {
            if(thumbnail == null) return Properties.Resources.DefaultThumbnail;
            if (thumbnail.Maxres != null && thumbnail.Maxres.Url != null)
                try { return GetImageFromUrl(thumbnail.Maxres.Url); } catch { }
            if (thumbnail.Standard != null && thumbnail.Standard.Url != null)
                try { return GetImageFromUrl(thumbnail.Standard.Url); } catch { }
            if (thumbnail.High != null && thumbnail.High.Url != null)
                try { return GetImageFromUrl(thumbnail.High.Url); } catch { }
            if (thumbnail.Medium != null && thumbnail.Medium.Url != null)
                try { return GetImageFromUrl(thumbnail.Medium.Url); } catch { }
            if (thumbnail.Default__ != null && thumbnail.Default__.Url != null)
                try { return GetImageFromUrl(thumbnail.Default__.Url); } catch { }
            return Properties.Resources.DefaultThumbnail;
        }
    }
}
