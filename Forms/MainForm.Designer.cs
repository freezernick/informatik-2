namespace GameMaster
{
    partial class MainForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btDownload = new System.Windows.Forms.Button();
            this.btNew = new System.Windows.Forms.Button();
            this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.btStart = new System.Windows.Forms.Button();
            this.btEditProp = new System.Windows.Forms.Button();
            this.btEditRules = new System.Windows.Forms.Button();
            this.SourceCodeLink = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.WebsiteLink = new System.Windows.Forms.LinkLabel();
            this.btDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 10);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(282, 199);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btDownload
            // 
            this.btDownload.Location = new System.Drawing.Point(103, 213);
            this.btDownload.Margin = new System.Windows.Forms.Padding(2);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(108, 22);
            this.btDownload.TabIndex = 5;
            this.btDownload.Text = "Download";
            this.btDownload.UseVisualStyleBackColor = true;
            this.btDownload.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(9, 213);
            this.btNew.Margin = new System.Windows.Forms.Padding(2);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(90, 22);
            this.btNew.TabIndex = 3;
            this.btNew.Text = "New";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // Tray
            // 
            this.Tray.Text = "GameMaster";
            this.Tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Tray_MouseDoubleClick);
            // 
            // btStart
            // 
            this.btStart.Enabled = false;
            this.btStart.Location = new System.Drawing.Point(310, 63);
            this.btStart.Margin = new System.Windows.Forms.Padding(2);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(279, 22);
            this.btStart.TabIndex = 12;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            // 
            // btEditProp
            // 
            this.btEditProp.Enabled = false;
            this.btEditProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btEditProp.Location = new System.Drawing.Point(310, 11);
            this.btEditProp.Margin = new System.Windows.Forms.Padding(2);
            this.btEditProp.Name = "btEditProp";
            this.btEditProp.Size = new System.Drawing.Size(279, 22);
            this.btEditProp.TabIndex = 11;
            this.btEditProp.Text = "Edit Properties";
            this.btEditProp.UseVisualStyleBackColor = true;
            // 
            // btEditRules
            // 
            this.btEditRules.Enabled = false;
            this.btEditRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btEditRules.Location = new System.Drawing.Point(310, 37);
            this.btEditRules.Margin = new System.Windows.Forms.Padding(2);
            this.btEditRules.Name = "btEditRules";
            this.btEditRules.Size = new System.Drawing.Size(279, 22);
            this.btEditRules.TabIndex = 10;
            this.btEditRules.Text = "Edit Rules";
            this.btEditRules.UseVisualStyleBackColor = true;
            // 
            // SourceCodeLink
            // 
            this.SourceCodeLink.AutoSize = true;
            this.SourceCodeLink.Location = new System.Drawing.Point(519, 222);
            this.SourceCodeLink.Name = "SourceCodeLink";
            this.SourceCodeLink.Size = new System.Drawing.Size(69, 13);
            this.SourceCodeLink.TabIndex = 14;
            this.SourceCodeLink.TabStop = true;
            this.SourceCodeLink.Text = "Source Code";
            this.SourceCodeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SourceCodeLink_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Made with ♥️ and OpenCV";
            // 
            // WebsiteLink
            // 
            this.WebsiteLink.AutoSize = true;
            this.WebsiteLink.Location = new System.Drawing.Point(458, 222);
            this.WebsiteLink.Name = "WebsiteLink";
            this.WebsiteLink.Size = new System.Drawing.Size(46, 13);
            this.WebsiteLink.TabIndex = 16;
            this.WebsiteLink.TabStop = true;
            this.WebsiteLink.Text = "Website";
            // 
            // btDelete
            // 
            this.btDelete.Enabled = false;
            this.btDelete.Location = new System.Drawing.Point(216, 212);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 17;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 245);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.WebsiteLink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SourceCodeLink);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btEditProp);
            this.Controls.Add(this.btEditRules);
            this.Controls.Add(this.btDownload);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Game Master";
            this.Load += new System.EventHandler(this.lErscheinungsdatum_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btDownload;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.NotifyIcon Tray;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btEditProp;
        private System.Windows.Forms.Button btEditRules;
        private System.Windows.Forms.LinkLabel SourceCodeLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel WebsiteLink;
        private System.Windows.Forms.Button btDelete;
    }
}

