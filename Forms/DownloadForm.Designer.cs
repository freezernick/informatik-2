namespace GameMaster
{
    partial class DownloadForm
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
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.tbQuelle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(10, 232);
            this.pbProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(435, 24);
            this.pbProgress.TabIndex = 0;
            // 
            // rtbStatus
            // 
            this.rtbStatus.Enabled = false;
            this.rtbStatus.Location = new System.Drawing.Point(10, 87);
            this.rtbStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(435, 136);
            this.rtbStatus.TabIndex = 1;
            this.rtbStatus.Text = "";
            // 
            // btStart
            // 
            this.btStart.Enabled = false;
            this.btStart.Location = new System.Drawing.Point(227, 50);
            this.btStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(218, 26);
            this.btStart.TabIndex = 2;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(10, 50);
            this.btExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(212, 26);
            this.btExit.TabIndex = 3;
            this.btExit.Text = "Back";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // tbQuelle
            // 
            this.tbQuelle.Location = new System.Drawing.Point(10, 20);
            this.tbQuelle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbQuelle.Name = "tbQuelle";
            this.tbQuelle.Size = new System.Drawing.Size(434, 20);
            this.tbQuelle.TabIndex = 4;
            this.tbQuelle.TextChanged += new System.EventHandler(this.tbQuelle_TextChanged);
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 272);
            this.ControlBox = false;
            this.Controls.Add(this.tbQuelle);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.rtbStatus);
            this.Controls.Add(this.pbProgress);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DownloadForm";
            this.Text = "Download";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.TextBox tbQuelle;
    }
}