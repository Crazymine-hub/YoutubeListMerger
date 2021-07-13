
namespace YoutubeListMerger
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Toolbox = new System.Windows.Forms.Panel();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.StartBingeBtn = new System.Windows.Forms.Button();
            this.ExportCSVBtn = new System.Windows.Forms.Button();
            this.YouTubeSaveBtn = new System.Windows.Forms.Button();
            this.MergeReverse = new System.Windows.Forms.CheckBox();
            this.ModeSelect = new System.Windows.Forms.GroupBox();
            this.MergeNone = new System.Windows.Forms.RadioButton();
            this.MergeZip = new System.Windows.Forms.RadioButton();
            this.MergeDate = new System.Windows.Forms.RadioButton();
            this.MergeAlphabet = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.videoInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VideoPreview = new YoutubeListMerger.ItemPreview();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Toolbox.SuspendLayout();
            this.ModeSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Toolbox
            // 
            this.Toolbox.Controls.Add(this.RefreshBtn);
            this.Toolbox.Controls.Add(this.StartBingeBtn);
            this.Toolbox.Controls.Add(this.ExportCSVBtn);
            this.Toolbox.Controls.Add(this.YouTubeSaveBtn);
            this.Toolbox.Controls.Add(this.MergeReverse);
            this.Toolbox.Controls.Add(this.ModeSelect);
            this.Toolbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.Toolbox.Location = new System.Drawing.Point(0, 0);
            this.Toolbox.Name = "Toolbox";
            this.Toolbox.Size = new System.Drawing.Size(200, 521);
            this.Toolbox.TabIndex = 0;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.RefreshBtn.Location = new System.Drawing.Point(0, 104);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(200, 23);
            this.RefreshBtn.TabIndex = 2;
            this.RefreshBtn.Text = "Merge";
            this.toolTip1.SetToolTip(this.RefreshBtn, "Apply the current settings");
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // StartBingeBtn
            // 
            this.StartBingeBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartBingeBtn.Enabled = false;
            this.StartBingeBtn.Location = new System.Drawing.Point(0, 434);
            this.StartBingeBtn.Name = "StartBingeBtn";
            this.StartBingeBtn.Size = new System.Drawing.Size(200, 23);
            this.StartBingeBtn.TabIndex = 5;
            this.StartBingeBtn.Text = "Start binge watch";
            this.toolTip1.SetToolTip(this.StartBingeBtn, "Start binge watching in your Browser");
            this.StartBingeBtn.UseVisualStyleBackColor = true;
            // 
            // ExportCSVBtn
            // 
            this.ExportCSVBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ExportCSVBtn.Enabled = false;
            this.ExportCSVBtn.Location = new System.Drawing.Point(0, 457);
            this.ExportCSVBtn.Name = "ExportCSVBtn";
            this.ExportCSVBtn.Size = new System.Drawing.Size(200, 23);
            this.ExportCSVBtn.TabIndex = 3;
            this.ExportCSVBtn.Text = "Save to File";
            this.toolTip1.SetToolTip(this.ExportCSVBtn, "Save your Playlist to a local File, you can open later");
            this.ExportCSVBtn.UseVisualStyleBackColor = true;
            // 
            // YouTubeSaveBtn
            // 
            this.YouTubeSaveBtn.AutoSize = true;
            this.YouTubeSaveBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YouTubeSaveBtn.Enabled = false;
            this.YouTubeSaveBtn.Location = new System.Drawing.Point(0, 480);
            this.YouTubeSaveBtn.Name = "YouTubeSaveBtn";
            this.YouTubeSaveBtn.Size = new System.Drawing.Size(200, 41);
            this.YouTubeSaveBtn.TabIndex = 4;
            this.YouTubeSaveBtn.Text = "Save to YouTube Playlist\r\n(Login Required)";
            this.toolTip1.SetToolTip(this.YouTubeSaveBtn, "Login to YouTube and Create a new Playlist");
            this.YouTubeSaveBtn.UseVisualStyleBackColor = true;
            // 
            // MergeReverse
            // 
            this.MergeReverse.AutoSize = true;
            this.MergeReverse.Dock = System.Windows.Forms.DockStyle.Top;
            this.MergeReverse.Location = new System.Drawing.Point(0, 87);
            this.MergeReverse.Name = "MergeReverse";
            this.MergeReverse.Size = new System.Drawing.Size(200, 17);
            this.MergeReverse.TabIndex = 1;
            this.MergeReverse.Text = "Reverse Video order";
            this.toolTip1.SetToolTip(this.MergeReverse, "Reverse the order of the Videos");
            this.MergeReverse.UseVisualStyleBackColor = true;
            // 
            // ModeSelect
            // 
            this.ModeSelect.AutoSize = true;
            this.ModeSelect.Controls.Add(this.MergeNone);
            this.ModeSelect.Controls.Add(this.MergeZip);
            this.ModeSelect.Controls.Add(this.MergeDate);
            this.ModeSelect.Controls.Add(this.MergeAlphabet);
            this.ModeSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModeSelect.Location = new System.Drawing.Point(0, 0);
            this.ModeSelect.Name = "ModeSelect";
            this.ModeSelect.Size = new System.Drawing.Size(200, 87);
            this.ModeSelect.TabIndex = 0;
            this.ModeSelect.TabStop = false;
            this.ModeSelect.Text = "Merge mode";
            // 
            // MergeNone
            // 
            this.MergeNone.AutoSize = true;
            this.MergeNone.Dock = System.Windows.Forms.DockStyle.Top;
            this.MergeNone.Location = new System.Drawing.Point(3, 67);
            this.MergeNone.Name = "MergeNone";
            this.MergeNone.Size = new System.Drawing.Size(194, 17);
            this.MergeNone.TabIndex = 3;
            this.MergeNone.Text = "Concatenate";
            this.toolTip1.SetToolTip(this.MergeNone, "Simply concats the Playlists");
            this.MergeNone.UseVisualStyleBackColor = true;
            // 
            // MergeZip
            // 
            this.MergeZip.AutoSize = true;
            this.MergeZip.Dock = System.Windows.Forms.DockStyle.Top;
            this.MergeZip.Location = new System.Drawing.Point(3, 50);
            this.MergeZip.Name = "MergeZip";
            this.MergeZip.Size = new System.Drawing.Size(194, 17);
            this.MergeZip.TabIndex = 2;
            this.MergeZip.Text = "Zip";
            this.toolTip1.SetToolTip(this.MergeZip, "Cycles throgh the playlists and adds one video until all videos are added.\r\nJust " +
        "like a Zipper.");
            this.MergeZip.UseVisualStyleBackColor = true;
            // 
            // MergeDate
            // 
            this.MergeDate.AutoSize = true;
            this.MergeDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.MergeDate.Location = new System.Drawing.Point(3, 33);
            this.MergeDate.Name = "MergeDate";
            this.MergeDate.Size = new System.Drawing.Size(194, 17);
            this.MergeDate.TabIndex = 1;
            this.MergeDate.Text = "Date";
            this.toolTip1.SetToolTip(this.MergeDate, "Merges the Videos by their Upload Date");
            this.MergeDate.UseVisualStyleBackColor = true;
            // 
            // MergeAlphabet
            // 
            this.MergeAlphabet.AutoSize = true;
            this.MergeAlphabet.Checked = true;
            this.MergeAlphabet.Dock = System.Windows.Forms.DockStyle.Top;
            this.MergeAlphabet.Location = new System.Drawing.Point(3, 16);
            this.MergeAlphabet.Name = "MergeAlphabet";
            this.MergeAlphabet.Size = new System.Drawing.Size(194, 17);
            this.MergeAlphabet.TabIndex = 0;
            this.MergeAlphabet.TabStop = true;
            this.MergeAlphabet.Text = "Alphabetical";
            this.toolTip1.SetToolTip(this.MergeAlphabet, "Merges the Videos by their Name");
            this.MergeAlphabet.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(200, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.VideoPreview);
            this.splitContainer1.Panel2MinSize = 80;
            this.splitContainer1.Size = new System.Drawing.Size(464, 521);
            this.splitContainer1.SplitterDistance = 431;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.videoInfoBindingSource;
            this.listBox1.DisplayMember = "Title";
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(464, 431);
            this.listBox1.TabIndex = 0;
            this.listBox1.ValueMember = "ID";
            // 
            // videoInfoBindingSource
            // 
            this.videoInfoBindingSource.DataSource = typeof(YoutubeListMerger.Classes.VideoInfo);
            // 
            // VideoPreview
            // 
            this.VideoPreview.BackColor = System.Drawing.SystemColors.Control;
            this.VideoPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoPreview.Location = new System.Drawing.Point(0, 0);
            this.VideoPreview.Name = "VideoPreview";
            this.VideoPreview.Size = new System.Drawing.Size(464, 80);
            this.VideoPreview.TabIndex = 0;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 521);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Toolbox);
            this.MinimumSize = new System.Drawing.Size(680, 560);
            this.Name = "ResultForm";
            this.Text = "Merge Result";
            this.Toolbox.ResumeLayout(false);
            this.Toolbox.PerformLayout();
            this.ModeSelect.ResumeLayout(false);
            this.ModeSelect.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.videoInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Toolbox;
        private System.Windows.Forms.CheckBox MergeReverse;
        private System.Windows.Forms.GroupBox ModeSelect;
        private System.Windows.Forms.RadioButton MergeNone;
        private System.Windows.Forms.RadioButton MergeZip;
        private System.Windows.Forms.RadioButton MergeDate;
        private System.Windows.Forms.RadioButton MergeAlphabet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.BindingSource videoInfoBindingSource;
        private System.Windows.Forms.Button ExportCSVBtn;
        private System.Windows.Forms.Button YouTubeSaveBtn;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button StartBingeBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private ItemPreview VideoPreview;
    }
}