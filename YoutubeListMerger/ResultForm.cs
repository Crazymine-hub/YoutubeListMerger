using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeListMerger.Classes;

namespace YoutubeListMerger
{
    public partial class ResultForm : Form
    {
        List<PlaylistAnalyzer> playlists;
        public ResultForm(IEnumerable<PlaylistAnalyzer> listsToMerge)
        {
            InitializeComponent();
            playlists = listsToMerge.ToList();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            if (MergeAlphabet.Checked) MergeByAlphabet();
            else if (MergeDate.Checked) MergeByDate();
            else if (MergeZip.Checked) MergeByZipping();
            else if (MergeNone.Checked) MergeByConcatinating();
            else throw new InvalidOperationException("No merge mode selected");
        }

        private void MergeByAlphabet()
        {
            List<VideoInfo> videos = new List<VideoInfo>();
            foreach (var playlist in playlists)
                videos.AddRange(playlist.VideoList);
            videos.OrderBy(x => x.Title);
            if (MergeReverse.Checked) videos.Reverse();
            foreach (VideoInfo video in videos)
                videoInfoBindingSource.Add(videos);
        }

        private void MergeByDate()
        {
            List<VideoInfo> videos = new List<VideoInfo>();
            foreach (var playlist in playlists)
                videos.AddRange(playlist.VideoList);
            videos.OrderBy(x => x.PublishDate);
            if (MergeReverse.Checked) videos.Reverse();
            foreach (VideoInfo video in videos)
                videoInfoBindingSource.Add(videos);
        }

        private void MergeByZipping()
        {
            PlaylistOrder orderDialog = new PlaylistOrder(playlists);
            bool reverseOrder = MergeReverse.Checked;

            if (orderDialog.ShowDialog() != DialogResult.OK) return;
            (PlaylistAnalyzer playlist, int position)[] playlistEntries = new (PlaylistAnalyzer, int)[orderDialog.playlistSource.Count];
            for (int i = 0; i < playlistEntries.Length; ++i)
            {
                PlaylistAnalyzer playlist = (PlaylistAnalyzer)orderDialog.playlistSource[i];
                playlistEntries[i] = (playlist, reverseOrder ? playlist.ItemCount - 1 : 0);
            }

            bool hasAddedItems = false;
            do
            {
                hasAddedItems = false;
                for (int i = 0; i < playlistEntries.Length; ++i)
                {
                    int limitPos = reverseOrder ? 0 : playlistEntries[i].playlist.ItemCount - 1;
                    if (playlistEntries[i].position == limitPos) continue;

                    videoInfoBindingSource.Add(playlistEntries[i].playlist.VideoList[playlistEntries[i].position]);
                    if (reverseOrder)
                        --playlistEntries[i].position;
                    else
                        ++playlistEntries[i].position;
                    hasAddedItems = true;
                }
            } while (hasAddedItems);
        }

        private void MergeByConcatinating()
        {
            PlaylistOrder orderDialog = new PlaylistOrder(playlists);
            bool reverseOrder = MergeReverse.Checked;

            if (orderDialog.ShowDialog() != DialogResult.OK) return;

            foreach(PlaylistAnalyzer playlist in orderDialog.playlistSource)
            {
                if (reverseOrder)
                    for (int i = playlist.ItemCount - 1; i >= 0; --i)
                        videoInfoBindingSource.Add(playlist.VideoList[i]);
                else
                    for (int i = 01; i < playlist.ItemCount; ++i)
                        videoInfoBindingSource.Add(playlist.VideoList[i]);
            }
        }
    }
}
