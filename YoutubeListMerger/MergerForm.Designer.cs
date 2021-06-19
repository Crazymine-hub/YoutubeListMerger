
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
            this.Workspace = new System.Windows.Forms.SplitContainer();
            this.PlaylistList = new System.Windows.Forms.ListBox();
            this.playlistAnalyzerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PlaylistTitleLabel = new System.Windows.Forms.Label();
            this.VideoList = new System.Windows.Forms.ListBox();
            this.VideoListLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.videoInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Workspace)).BeginInit();
            this.Workspace.Panel1.SuspendLayout();
            this.Workspace.Panel2.SuspendLayout();
            this.Workspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playlistAnalyzerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Workspace
            // 
            this.Workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Workspace.IsSplitterFixed = true;
            this.Workspace.Location = new System.Drawing.Point(0, 23);
            this.Workspace.Name = "Workspace";
            // 
            // Workspace.Panel1
            // 
            this.Workspace.Panel1.AutoScroll = true;
            this.Workspace.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Workspace.Panel1.Controls.Add(this.PlaylistList);
            this.Workspace.Panel1.Controls.Add(this.PlaylistTitleLabel);
            // 
            // Workspace.Panel2
            // 
            this.Workspace.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Workspace.Panel2.Controls.Add(this.VideoList);
            this.Workspace.Panel2.Controls.Add(this.VideoListLabel);
            this.Workspace.Size = new System.Drawing.Size(584, 438);
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
            this.PlaylistList.Size = new System.Drawing.Size(272, 413);
            this.PlaylistList.TabIndex = 4;
            this.PlaylistList.ValueMember = "ID";
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
            this.PlaylistTitleLabel.Text = "Playlists";
            // 
            // VideoList
            // 
            this.VideoList.DataSource = this.videoInfoBindingSource;
            this.VideoList.DisplayMember = "Title";
            this.VideoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoList.HorizontalScrollbar = true;
            this.VideoList.Location = new System.Drawing.Point(0, 25);
            this.VideoList.Name = "VideoList";
            this.VideoList.Size = new System.Drawing.Size(262, 413);
            this.VideoList.TabIndex = 3;
            this.VideoList.ValueMember = "ID";
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
            this.VideoListLabel.Text = "Videos";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(584, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // videoInfoBindingSource
            // 
            this.videoInfoBindingSource.DataSource = typeof(YoutubeListMerger.Classes.VideoInfo);
            // 
            // MergerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.Workspace);
            this.Controls.Add(this.button1);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Workspace;
        private System.Windows.Forms.Label PlaylistTitleLabel;
        private System.Windows.Forms.ListBox PlaylistList;
        private System.Windows.Forms.ListBox VideoList;
        private System.Windows.Forms.Label VideoListLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource playlistAnalyzerBindingSource;
        private System.Windows.Forms.BindingSource videoInfoBindingSource;
    }
}

