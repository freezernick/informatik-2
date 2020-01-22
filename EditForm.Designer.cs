namespace GameMaster
{
    partial class EditForm
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
            this.lName = new System.Windows.Forms.Label();
            this.lAuthor = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.tbFriendlyVerion = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(11, 9);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(45, 17);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name";
            // 
            // lAuthor
            // 
            this.lAuthor.AutoSize = true;
            this.lAuthor.Location = new System.Drawing.Point(11, 52);
            this.lAuthor.Name = "lAuthor";
            this.lAuthor.Size = new System.Drawing.Size(50, 17);
            this.lAuthor.TabIndex = 1;
            this.lAuthor.Text = "Author";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(11, 95);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(56, 17);
            this.lVersion.TabIndex = 3;
            this.lVersion.Text = "Version";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(171, 6);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(219, 22);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbAuthor
            // 
            this.tbAuthor.Location = new System.Drawing.Point(171, 49);
            this.tbAuthor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(219, 22);
            this.tbAuthor.TabIndex = 5;
            // 
            // tbFriendlyVerion
            // 
            this.tbFriendlyVerion.Location = new System.Drawing.Point(171, 92);
            this.tbFriendlyVerion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFriendlyVerion.Name = "tbFriendlyVerion";
            this.tbFriendlyVerion.Size = new System.Drawing.Size(219, 22);
            this.tbFriendlyVerion.TabIndex = 6;
            this.tbFriendlyVerion.TextChanged += new System.EventHandler(this.tbFriendlyVerion_TextChanged);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(213, 186);
            this.btSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(177, 30);
            this.btSave.TabIndex = 8;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(13, 186);
            this.btBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(179, 30);
            this.btBack.TabIndex = 9;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 225);
            this.ControlBox = false;
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tbFriendlyVerion);
            this.Controls.Add(this.tbAuthor);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.lAuthor);
            this.Controls.Add(this.lName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lAuthor;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.TextBox tbFriendlyVerion;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btBack;
    }
}