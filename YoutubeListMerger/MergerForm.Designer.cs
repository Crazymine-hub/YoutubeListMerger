
namespace YoutubeListMerger
{
    partial class MergerForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergerForm));
            this.Workspace = new System.Windows.Forms.SplitContainer();
            this.PlaylistList = new System.Windows.Forms.ListBox();
            this.playlistAnalyzerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PlaylistTitleLabel = new System.Windows.Forms.Label();
            this.ListPreview = new YoutubeListMerger.ItemPreview();
            this.VideoList = new System.Windows.Forms.ListBox();
            this.videoInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VideoPreview = new YoutubeListMerger.ItemPreview();
            this.VideoListLabel = new System.Windows.Forms.Label();
            this.AddressSpace = new System.Windows.Forms.Panel();
            this.AddEntryBtn = new System.Windows.Forms.Button();
            this.YouTubeUrlInput = new System.Windows.Forms.TextBox();
            this.OpenBatchButton = new System.Windows.Forms.Button();
            this.UrlEnterLabel = new System.Windows.Forms.Label();
            this.UrlErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.BatchFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.MergeButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Workspace)).BeginInit();
            this.Workspace.Panel1.SuspendLayout();
            this.Workspace.Panel2.SuspendLayout();
            this.Workspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playlistAnalyzerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoInfoBindingSource)).BeginInit();
            this.AddressSpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UrlErrorProvider)).BeginInit();
            this.FooterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Workspace
            // 
            this.Workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Workspace.IsSplitterFixed = true;
            this.Workspace.Location = new System.Drawing.Point(0, 37);
            this.Workspace.Name = "Workspace";
            // 
            // Workspace.Panel1
            // 
            this.Workspace.Panel1.AutoScroll = true;
            this.Workspace.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Workspace.Panel1.Controls.Add(this.PlaylistList);
            this.Workspace.Panel1.Controls.Add(this.PlaylistTitleLabel);
            this.Workspace.Panel1.Controls.Add(this.ListPreview);
            // 
            // Workspace.Panel2
            // 
            this.Workspace.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Workspace.Panel2.Controls.Add(this.VideoList);
            this.Workspace.Panel2.Controls.Add(this.VideoPreview);
            this.Workspace.Panel2.Controls.Add(this.VideoListLabel);
            this.Workspace.Size = new System.Drawing.Size(584, 424);
            this.Workspace.SplitterDistance = 272;
            this.Workspace.SplitterWidth = 50;
            this.Workspace.TabIndex = 0;
            // 
            // PlaylistList
            // 
            this.PlaylistList.DataSource = this.playlistAnalyzerBindingSource;
            this.PlaylistList.DisplayMember = "Title";
            this.PlaylistList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaylistList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PlaylistList.HorizontalScrollbar = true;
            this.PlaylistList.ItemHeight = 18;
            this.PlaylistList.Location = new System.Drawing.Point(0, 25);
            this.PlaylistList.Name = "PlaylistList";
            this.PlaylistList.Size = new System.Drawing.Size(272, 319);
            this.PlaylistList.TabIndex = 2;
            this.PlaylistList.ValueMember = "UniqueId";
            this.PlaylistList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.PlaylistList_DrawItem);
            this.PlaylistList.SelectedIndexChanged += new System.EventHandler(this.PlaylistList_SelectedIndexChanged);
            // 
            // playlistAnalyzerBindingSource
            // 
            this.playlistAnalyzerBindingSource.DataSource = typeof(YoutubeListMerger.Classes.PlaylistAnalyzer);
            // 
            // PlaylistTitleLabel
            // 
            this.PlaylistTitleLabel.BackColor = System.Drawing.SystemColors.Control;
            this.PlaylistTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlaylistTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaylistTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.PlaylistTitleLabel.Name = "PlaylistTitleLabel";
            this.PlaylistTitleLabel.Size = new System.Drawing.Size(272, 25);
            this.PlaylistTitleLabel.TabIndex = 0;
            this.PlaylistTitleLabel.Text = "Play&lists";
            // 
            // ListPreview
            // 
            this.ListPreview.AutoScroll = true;
            this.ListPreview.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.ListPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ListPreview.Location = new System.Drawing.Point(0, 344);
            this.ListPreview.Name = "ListPreview";
            this.ListPreview.Size = new System.Drawing.Size(272, 80);
            this.ListPreview.TabIndex = 3;
            this.ListPreview.RemoveButtonClicked += new System.EventHandler(this.ListPreview_RemoveButtonClicked);
            // 
            // VideoList
            // 
            this.VideoList.DataSource = this.videoInfoBindingSource;
            this.VideoList.DisplayMember = "Title";
            this.VideoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoList.HorizontalScrollbar = true;
            this.VideoList.Location = new System.Drawing.Point(0, 25);
            this.VideoList.Name = "VideoList";
            this.VideoList.Size = new System.Drawing.Size(262, 319);
            this.VideoList.TabIndex = 1;
            this.VideoList.ValueMember = "ID";
            this.VideoList.SelectedValueChanged += new System.EventHandler(this.VideoList_SelectedValueChanged);
            // 
            // videoInfoBindingSource
            // 
            this.videoInfoBindingSource.DataSource = typeof(YoutubeListMerger.Classes.VideoInfo);
            // 
            // VideoPreview
            // 
            this.VideoPreview.AutoScroll = true;
            this.VideoPreview.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.VideoPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.VideoPreview.Location = new System.Drawing.Point(0, 344);
            this.VideoPreview.Name = "VideoPreview";
            this.VideoPreview.Size = new System.Drawing.Size(262, 80);
            this.VideoPreview.TabIndex = 4;
            this.VideoPreview.RemoveButtonClicked += new System.EventHandler(this.VideoPreview_RemoveButtonClicked);
            // 
            // VideoListLabel
            // 
            this.VideoListLabel.BackColor = System.Drawing.SystemColors.Control;
            this.VideoListLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.VideoListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VideoListLabel.Location = new System.Drawing.Point(0, 0);
            this.VideoListLabel.Name = "VideoListLabel";
            this.VideoListLabel.Size = new System.Drawing.Size(262, 25);
            this.VideoListLabel.TabIndex = 2;
            this.VideoListLabel.Text = "&Videos";
            // 
            // AddressSpace
            // 
            this.AddressSpace.Controls.Add(this.AddEntryBtn);
            this.AddressSpace.Controls.Add(this.YouTubeUrlInput);
            this.AddressSpace.Controls.Add(this.OpenBatchButton);
            this.AddressSpace.Controls.Add(this.UrlEnterLabel);
            this.AddressSpace.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddressSpace.Location = new System.Drawing.Point(0, 0);
            this.AddressSpace.Name = "AddressSpace";
            this.AddressSpace.Size = new System.Drawing.Size(584, 37);
            this.AddressSpace.TabIndex = 5;
            // 
            // AddEntryBtn
            // 
            this.AddEntryBtn.AutoSize = true;
            this.AddEntryBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddEntryBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddEntryBtn.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEntryBtn.Location = new System.Drawing.Point(532, 16);
            this.AddEntryBtn.Name = "AddEntryBtn";
            this.AddEntryBtn.Size = new System.Drawing.Size(26, 21);
            this.AddEntryBtn.TabIndex = 3;
            this.AddEntryBtn.Text = "";
            this.AddEntryBtn.UseVisualStyleBackColor = true;
            this.AddEntryBtn.Click += new System.EventHandler(this.AddEntryBtn_Click);
            // 
            // YouTubeUrlInput
            // 
            this.YouTubeUrlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YouTubeUrlInput.Location = new System.Drawing.Point(0, 16);
            this.YouTubeUrlInput.Name = "YouTubeUrlInput";
            this.YouTubeUrlInput.Size = new System.Drawing.Size(558, 20);
            this.YouTubeUrlInput.TabIndex = 1;
            this.YouTubeUrlInput.WordWrap = false;
            this.YouTubeUrlInput.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.YouTubeUrlInput_PreviewKeyDown);
            // 
            // OpenBatchButton
            // 
            this.OpenBatchButton.AutoSize = true;
            this.OpenBatchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.OpenBatchButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.OpenBatchButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenBatchButton.Location = new System.Drawing.Point(558, 16);
            this.OpenBatchButton.Name = "OpenBatchButton";
            this.OpenBatchButton.Size = new System.Drawing.Size(26, 21);
            this.OpenBatchButton.TabIndex = 2;
            this.OpenBatchButton.Text = "";
            this.OpenBatchButton.UseVisualStyleBackColor = true;
            this.OpenBatchButton.Click += new System.EventHandler(this.OpenBatchButton_Click);
            this.OpenBatchButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.AddEntryBtn_PreviewKeyDown);
            // 
            // UrlEnterLabel
            // 
            this.UrlEnterLabel.AutoSize = true;
            this.UrlEnterLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UrlEnterLabel.Location = new System.Drawing.Point(0, 0);
            this.UrlEnterLabel.Name = "UrlEnterLabel";
            this.UrlEnterLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.UrlEnterLabel.Size = new System.Drawing.Size(114, 16);
            this.UrlEnterLabel.TabIndex = 0;
            this.UrlEnterLabel.Text = "Enter &YouTube Adress";
            // 
            // UrlErrorProvider
            // 
            this.UrlErrorProvider.ContainerControl = this;
            this.UrlErrorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("UrlErrorProvider.Icon")));
            // 
            // BatchFileDialog
            // 
            this.BatchFileDialog.DefaultExt = "txt";
            this.BatchFileDialog.Filter = "Textdateien|*.txt";
            // 
            // FooterPanel
            // 
            this.FooterPanel.Controls.Add(this.ResetButton);
            this.FooterPanel.Controls.Add(this.MergeButton);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPanel.Location = new System.Drawing.Point(0, 432);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(584, 29);
            this.FooterPanel.TabIndex = 6;
            // 
            // MergeButton
            // 
            this.MergeButton.AutoSize = true;
            this.MergeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MergeButton.Location = new System.Drawing.Point(502, 0);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(82, 29);
            this.MergeButton.TabIndex = 0;
            this.MergeButton.Text = "Merge Videos";
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.AutoSize = true;
            this.ResetButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ResetButton.Location = new System.Drawing.Point(420, 0);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(82, 29);
            this.ResetButton.TabIndex = 1;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // MergerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.FooterPanel);
            this.Controls.Add(this.Workspace);
            this.Controls.Add(this.AddressSpace);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MergerForm";
            this.Text = "PlaylistMerger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Workspace.Panel1.ResumeLayout(false);
            this.Workspace.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Workspace)).EndInit();
            this.Workspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playlistAnalyzerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoInfoBindingSource)).EndInit();
            this.AddressSpace.ResumeLayout(false);
            this.AddressSpace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UrlErrorProvider)).EndInit();
            this.FooterPanel.ResumeLayout(false);
            this.FooterPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Workspace;
        private System.Windows.Forms.Label PlaylistTitleLabel;
        private System.Windows.Forms.ListBox PlaylistList;
        private System.Windows.Forms.ListBox VideoList;
        private System.Windows.Forms.Label VideoListLabel;
        private System.Windows.Forms.BindingSource videoInfoBindingSource;
        private System.Windows.Forms.BindingSource playlistAnalyzerBindingSource;
        private System.Windows.Forms.Panel AddressSpace;
        private System.Windows.Forms.TextBox YouTubeUrlInput;
        private System.Windows.Forms.Button OpenBatchButton;
        private System.Windows.Forms.Label UrlEnterLabel;
        private System.Windows.Forms.ErrorProvider UrlErrorProvider;
        private ItemPreview ListPreview;
        private ItemPreview VideoPreview;
        private System.Windows.Forms.Button AddEntryBtn;
        private System.Windows.Forms.OpenFileDialog BatchFileDialog;
        private System.Windows.Forms.Panel FooterPanel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button MergeButton;
    }
}

