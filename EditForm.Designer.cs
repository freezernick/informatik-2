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
            this.tbID = new System.Windows.Forms.TextBox();
            this.lID = new System.Windows.Forms.Label();
            this.tbStartAction = new System.Windows.Forms.TextBox();
            this.lStartAction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(11, 12);
            this.lName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name";
            // 
            // lAuthor
            // 
            this.lAuthor.AutoSize = true;
            this.lAuthor.Location = new System.Drawing.Point(11, 81);
            this.lAuthor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lAuthor.Name = "lAuthor";
            this.lAuthor.Size = new System.Drawing.Size(38, 13);
            this.lAuthor.TabIndex = 1;
            this.lAuthor.Text = "Author";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(11, 113);
            this.lVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(42, 13);
            this.lVersion.TabIndex = 3;
            this.lVersion.Text = "Version";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(318, 5);
            this.tbName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(300, 20);
            this.tbName.TabIndex = 4;
            // 
            // tbAuthor
            // 
            this.tbAuthor.Location = new System.Drawing.Point(318, 74);
            this.tbAuthor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(300, 20);
            this.tbAuthor.TabIndex = 5;
            // 
            // tbFriendlyVerion
            // 
            this.tbFriendlyVerion.Location = new System.Drawing.Point(318, 106);
            this.tbFriendlyVerion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbFriendlyVerion.Name = "tbFriendlyVerion";
            this.tbFriendlyVerion.Size = new System.Drawing.Size(300, 20);
            this.tbFriendlyVerion.TabIndex = 6;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(318, 426);
            this.btSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(300, 24);
            this.btSave.TabIndex = 8;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(11, 426);
            this.btBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(300, 24);
            this.btBack.TabIndex = 9;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(318, 39);
            this.tbID.Margin = new System.Windows.Forms.Padding(2);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(300, 20);
            this.tbID.TabIndex = 11;
            // 
            // lID
            // 
            this.lID.AutoSize = true;
            this.lID.Location = new System.Drawing.Point(11, 46);
            this.lID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lID.Name = "lID";
            this.lID.Size = new System.Drawing.Size(18, 13);
            this.lID.TabIndex = 10;
            this.lID.Text = "ID";
            // 
            // tbStartAction
            // 
            this.tbStartAction.Location = new System.Drawing.Point(318, 143);
            this.tbStartAction.Margin = new System.Windows.Forms.Padding(2);
            this.tbStartAction.Name = "tbStartAction";
            this.tbStartAction.Size = new System.Drawing.Size(300, 20);
            this.tbStartAction.TabIndex = 12;
            // 
            // lStartAction
            // 
            this.lStartAction.AutoSize = true;
            this.lStartAction.Location = new System.Drawing.Point(11, 150);
            this.lStartAction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lStartAction.Name = "lStartAction";
            this.lStartAction.Size = new System.Drawing.Size(42, 13);
            this.lStartAction.TabIndex = 13;
            this.lStartAction.Text = "Version";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 461);
            this.ControlBox = false;
            this.Controls.Add(this.lStartAction);
            this.Controls.Add(this.tbStartAction);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.lID);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.tbFriendlyVerion);
            this.Controls.Add(this.tbAuthor);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.lAuthor);
            this.Controls.Add(this.lName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
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
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lID;
        private System.Windows.Forms.TextBox tbStartAction;
        private System.Windows.Forms.Label lStartAction;
    }
}