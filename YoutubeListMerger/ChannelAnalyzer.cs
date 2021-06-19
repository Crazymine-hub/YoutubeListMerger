using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;

namespace YoutubeListMerger
{
    public partial class ChannelAnalyzer : Form
    {
        public string ChannelId { get; internal set; }
        private Uri channelUri;
        public ChannelAnalyzer(Uri ytChannelUri)
        {
            InitializeComponent();
            Load += ChannelAnalyzer_Load;
            channelUri = ytChannelUri;
            channelUrlLabel.Text = channelUri.ToString();
        }

        private void ChannelAnalyzer_Load(object sender, EventArgs e)
        {
            Task.Run(Analyze);
        }

        private void Analyze()
        {
            WebRequest channelPage = WebRequest.Create(channelUri);
            var response = channelPage.GetResponse();
            var contentReader = new StreamReader(response.GetResponseStream());
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(contentReader.ReadToEnd());
            Uri channelCleanUri = new Uri(doc.DocumentNode.SelectNodes("/html/body/span[@itemprop='author']/link[@itemprop='url']")[0].Attributes["href"].Value);
            var path = channelCleanUri.LocalPath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            if (path.Length == 2 && path[0] == "channel")
                ChannelId = path[1];
            else
                throw new Exception("No valid Channel URL found.");
            Invoke((MethodInvoker)Close);
        }
    }
}
