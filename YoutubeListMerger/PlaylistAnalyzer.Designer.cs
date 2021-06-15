
namespace YoutubeListMerger
{
    partial class PlaylistAnalyzer
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ListLoadProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoEllipsis = true;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(298, 13);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "ListTitle";
            // 
            // ListLoadProgress
            // 
            this.ListLoadProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListLoadProgress.Location = new System.Drawing.Point(0, 13);
            this.ListLoadProgress.MaximumSize = new System.Drawing.Size(0, 20);
            this.ListLoadProgress.Name = "ListLoadProgress";
            this.ListLoadProgress.Size = new System.Drawing.Size(298, 20);
            this.ListLoadProgress.Step = 1;
            this.ListLoadProgress.TabIndex = 1;
            this.ListLoadProgress.Value = 50;
            // 
            // PlaylistAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ListLoadProgress);
            this.Controls.Add(this.TitleLabel);
            this.MaximumSize = new System.Drawing.Size(0, 33);
            this.MinimumSize = new System.Drawing.Size(0, 33);
            this.Name = "PlaylistAnalyzer";
            this.Size = new System.Drawing.Size(298, 33);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.ProgressBar ListLoadProgress;
    }
}
