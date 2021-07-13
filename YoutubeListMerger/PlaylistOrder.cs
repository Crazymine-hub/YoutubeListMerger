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
    public partial class PlaylistOrder : Form
    {
        public PlaylistOrder(IEnumerable<PlaylistAnalyzer> playlists)
        {
            InitializeComponent();
            foreach (var playlist in playlists)
                playlistSource.Add(playlist);
            DialogResult = DialogResult.Cancel;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            moveUpButton.Enabled = orderList.SelectedIndex > 0;
            moveDownButton.Enabled = orderList.SelectedIndex < playlistSource.Count - 1;
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int index = orderList.SelectedIndex;
            object item = playlistSource[index];
            playlistSource.RemoveAt(index);
            playlistSource.Insert(--index, item);
            orderList.SelectedIndex = index;
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            int index = orderList.SelectedIndex;
            object item = playlistSource[index];
            playlistSource.RemoveAt(index);
            playlistSource.Insert(++index, item);
            orderList.SelectedIndex = index;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
