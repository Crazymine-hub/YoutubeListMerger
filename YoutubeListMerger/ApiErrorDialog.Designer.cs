
namespace YoutubeListMerger
{
    partial class ApiErrorDialog
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorText = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.documentationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // errorText
            // 
            this.errorText.AutoEllipsis = true;
            this.errorText.Location = new System.Drawing.Point(68, 12);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(454, 50);
            this.errorText.TabIndex = 2;
            this.errorText.Text = "label1";
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(71, 68);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(102, 23);
            this.editBtn.TabIndex = 3;
            this.editBtn.Text = "Open API.key file";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // abortButton
            // 
            this.abortButton.Location = new System.Drawing.Point(450, 68);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(72, 23);
            this.abortButton.TabIndex = 4;
            this.abortButton.Text = "Close";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // documentationButton
            // 
            this.documentationButton.Location = new System.Drawing.Point(190, 68);
            this.documentationButton.Name = "documentationButton";
            this.documentationButton.Size = new System.Drawing.Size(134, 23);
            this.documentationButton.TabIndex = 5;
            this.documentationButton.Text = "Where do i get one?";
            this.documentationButton.UseVisualStyleBackColor = true;
            this.documentationButton.Click += new System.EventHandler(this.documentationButton_Click);
            // 
            // ApiErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 96);
            this.Controls.Add(this.documentationButton);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.errorText);
            this.Controls.Add(this.pictureBox1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ApiErrorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApiError";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ApiErrorDialog_HelpButtonClicked);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.ApiErrorDialog_HelpRequested);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label errorText;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.Button documentationButton;
    }
}