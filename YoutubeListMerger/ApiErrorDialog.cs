using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeListMerger
{
    public partial class ApiErrorDialog : Form
    {
        public static void Show(string errText, string caption)
        {
            ApiErrorDialog dialog = new ApiErrorDialog();
            dialog.Text = caption;
            dialog.errorText.Text = errText;
            if (dialog.ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "notepad.exe"),
                        Path.GetFullPath(Properties.Settings.Default.ApiKeyFilePath));
            Application.Exit();
        }

        private ApiErrorDialog()
        {
            InitializeComponent();
            pictureBox1.Image = SystemIcons.Error.ToBitmap();
            SystemSounds.Hand.Play();
            Text += "YouTube Playlist Merger";
        }

        private void ApiErrorDialog_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            GetHelp();
        }

        private void ApiErrorDialog_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            GetHelp();
            e.Cancel = true;
        }

        private void documentationButton_Click(object sender, EventArgs e)
        {
            GetHelp();
        }

        private void GetHelp()
        {
            Process.Start("https://developers.google.com/youtube/v3/getting-started");
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
    }
}
