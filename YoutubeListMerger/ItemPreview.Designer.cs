
namespace YoutubeListMerger
{
    partial class ItemPreview
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Thumbnail = new System.Windows.Forms.PictureBox();
            this.PreviewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenPlaylistEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenChannelEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.ChannelName = new System.Windows.Forms.Label();
            this.Details = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail)).BeginInit();
            this.PreviewContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // Thumbnail
            // 
            this.Thumbnail.BackColor = System.Drawing.Color.Black;
            this.Thumbnail.Dock = System.Windows.Forms.DockStyle.Left;
            this.Thumbnail.ErrorImage = global::YoutubeListMerger.Properties.Resources.DefaultThumbnail;
            this.Thumbnail.InitialImage = global::YoutubeListMerger.Properties.Resources.DefaultThumbnail;
            this.Thumbnail.Location = new System.Drawing.Point(0, 0);
            this.Thumbnail.Name = "Thumbnail";
            this.Thumbnail.Size = new System.Drawing.Size(120, 80);
            this.Thumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Thumbnail.TabIndex = 0;
            this.Thumbnail.TabStop = false;
            this.Thumbnail.Click += new System.EventHandler(this.ItemPreview_Click);
            // 
            // PreviewContext
            // 
            this.PreviewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveEntry,
            this.OpenPlaylistEntry,
            this.OpenChannelEntry});
            this.PreviewContext.Name = "PreviewContext";
            this.PreviewContext.Size = new System.Drawing.Size(233, 70);
            // 
            // RemoveEntry
            // 
            this.RemoveEntry.Name = "RemoveEntry";
            this.RemoveEntry.Size = new System.Drawing.Size(232, 22);
            this.RemoveEntry.Text = "&Remove";
            this.RemoveEntry.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // OpenPlaylistEntry
            // 
            this.OpenPlaylistEntry.Name = "OpenPlaylistEntry";
            this.OpenPlaylistEntry.Size = new System.Drawing.Size(232, 22);
            this.OpenPlaylistEntry.Text = "Open in Webbrowser";
            this.OpenPlaylistEntry.Click += new System.EventHandler(this.ItemPreview_Click);
            // 
            // OpenChannelEntry
            // 
            this.OpenChannelEntry.Name = "OpenChannelEntry";
            this.OpenChannelEntry.Size = new System.Drawing.Size(232, 22);
            this.OpenChannelEntry.Text = "Open Channel in Webbrowser";
            this.OpenChannelEntry.Click += new System.EventHandler(this.OpenChannelEntry_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.RemoveButton.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.Location = new System.Drawing.Point(238, 33);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(34, 47);
            this.RemoveButton.TabIndex = 7;
            this.RemoveButton.Text = "";
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // Title
            // 
            this.Title.AutoEllipsis = true;
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(120, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(152, 20);
            this.Title.TabIndex = 8;
            this.Title.Text = "Title";
            this.Title.Click += new System.EventHandler(this.ItemPreview_Click);
            // 
            // ChannelName
            // 
            this.ChannelName.AutoEllipsis = true;
            this.ChannelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChannelName.Location = new System.Drawing.Point(120, 20);
            this.ChannelName.Name = "ChannelName";
            this.ChannelName.Size = new System.Drawing.Size(152, 13);
            this.ChannelName.TabIndex = 9;
            this.ChannelName.Text = "Channel";
            this.ChannelName.Click += new System.EventHandler(this.OpenChannelEntry_Click);
            // 
            // Details
            // 
            this.Details.AutoEllipsis = true;
            this.Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Details.Location = new System.Drawing.Point(120, 33);
            this.Details.Name = "Details";
            this.Details.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.Details.Size = new System.Drawing.Size(118, 47);
            this.Details.TabIndex = 12;
            this.Details.Text = "Description";
            // 
            // ItemPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.PreviewContext;
            this.Controls.Add(this.Details);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.ChannelName);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Thumbnail);
            this.Name = "ItemPreview";
            this.Size = new System.Drawing.Size(272, 80);
            this.Click += new System.EventHandler(this.ItemPreview_Click);
            ((System.ComponentModel.ISupportInitialize)(this.Thumbnail)).EndInit();
            this.PreviewContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Thumbnail;
        private System.Windows.Forms.ContextMenuStrip PreviewContext;
        private System.Windows.Forms.ToolStripMenuItem RemoveEntry;
        private System.Windows.Forms.ToolStripMenuItem OpenPlaylistEntry;
        private System.Windows.Forms.ToolStripMenuItem OpenChannelEntry;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label ChannelName;
        private System.Windows.Forms.Label Details;
    }
}
