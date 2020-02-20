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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btStart = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEditProp = new System.Windows.Forms.Button();
            this.btNew = new System.Windows.Forms.Button();
            this.btEditRules = new System.Windows.Forms.Button();
            this.lName = new System.Windows.Forms.Label();
            this.lCreator = new System.Windows.Forms.Label();
            this.lLastChanged = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.lNameValue = new System.Windows.Forms.Label();
            this.lAuthorValue = new System.Windows.Forms.Label();
            this.lVersionValue = new System.Windows.Forms.Label();
            this.lLastChangedValue = new System.Windows.Forms.Label();
            this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 10);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(282, 199);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btStart);
            this.groupBox1.Controls.Add(this.btEditProp);
            this.groupBox1.Controls.Add(this.btEditRules);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(310, 124);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(272, 111);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btStart
            // 
            this.btStart.Enabled = false;
            this.btStart.Location = new System.Drawing.Point(4, 72);
            this.btStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(264, 22);
            this.btStart.TabIndex = 6;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(11, 213);
            this.btAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(175, 22);
            this.btAdd.TabIndex = 5;
            this.btAdd.Text = "Download Configurations";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEditProp
            // 
            this.btEditProp.Enabled = false;
            this.btEditProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btEditProp.Location = new System.Drawing.Point(4, 20);
            this.btEditProp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btEditProp.Name = "btEditProp";
            this.btEditProp.Size = new System.Drawing.Size(264, 22);
            this.btEditProp.TabIndex = 4;
            this.btEditProp.Text = "Edit properties";
            this.btEditProp.UseVisualStyleBackColor = true;
            this.btEditProp.Click += new System.EventHandler(this.btEditProp_Click);
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(190, 213);
            this.btNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(101, 22);
            this.btNew.TabIndex = 3;
            this.btNew.Text = "New";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // btEditRules
            // 
            this.btEditRules.Enabled = false;
            this.btEditRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btEditRules.Location = new System.Drawing.Point(4, 46);
            this.btEditRules.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btEditRules.Name = "btEditRules";
            this.btEditRules.Size = new System.Drawing.Size(264, 22);
            this.btEditRules.TabIndex = 2;
            this.btEditRules.Text = "Edit rules";
            this.btEditRules.UseVisualStyleBackColor = true;
            this.btEditRules.Click += new System.EventHandler(this.btEditRules_Click);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(307, 12);
            this.lName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(43, 13);
            this.lName.TabIndex = 2;
            this.lName.Text = "Name:";
            // 
            // lCreator
            // 
            this.lCreator.AutoSize = true;
            this.lCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lCreator.Location = new System.Drawing.Point(307, 45);
            this.lCreator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lCreator.Name = "lCreator";
            this.lCreator.Size = new System.Drawing.Size(48, 13);
            this.lCreator.TabIndex = 3;
            this.lCreator.Text = "Author:";
            // 
            // lLastChanged
            // 
            this.lLastChanged.AutoSize = true;
            this.lLastChanged.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lLastChanged.Location = new System.Drawing.Point(307, 109);
            this.lLastChanged.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lLastChanged.Name = "lLastChanged";
            this.lLastChanged.Size = new System.Drawing.Size(89, 13);
            this.lLastChanged.TabIndex = 4;
            this.lLastChanged.Text = "Last Changed:";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lVersion.Location = new System.Drawing.Point(307, 78);
            this.lVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(53, 13);
            this.lVersion.TabIndex = 5;
            this.lVersion.Text = "Version:";
            // 
            // lNameValue
            // 
            this.lNameValue.AutoSize = true;
            this.lNameValue.Location = new System.Drawing.Point(447, 12);
            this.lNameValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lNameValue.Name = "lNameValue";
            this.lNameValue.Size = new System.Drawing.Size(64, 13);
            this.lNameValue.TabIndex = 6;
            this.lNameValue.Text = "lNameValue";
            this.lNameValue.Visible = false;
            // 
            // lAuthorValue
            // 
            this.lAuthorValue.AutoSize = true;
            this.lAuthorValue.Location = new System.Drawing.Point(447, 45);
            this.lAuthorValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lAuthorValue.Name = "lAuthorValue";
            this.lAuthorValue.Size = new System.Drawing.Size(67, 13);
            this.lAuthorValue.TabIndex = 7;
            this.lAuthorValue.Text = "lAuthorValue";
            this.lAuthorValue.Visible = false;
            // 
            // lVersionValue
            // 
            this.lVersionValue.AutoSize = true;
            this.lVersionValue.Location = new System.Drawing.Point(447, 78);
            this.lVersionValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lVersionValue.Name = "lVersionValue";
            this.lVersionValue.Size = new System.Drawing.Size(71, 13);
            this.lVersionValue.TabIndex = 8;
            this.lVersionValue.Text = "lVersionValue";
            this.lVersionValue.Visible = false;
            // 
            // lLastChangedValue
            // 
            this.lLastChangedValue.AutoSize = true;
            this.lLastChangedValue.Location = new System.Drawing.Point(447, 109);
            this.lLastChangedValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lLastChangedValue.Name = "lLastChangedValue";
            this.lLastChangedValue.Size = new System.Drawing.Size(99, 13);
            this.lLastChangedValue.TabIndex = 9;
            this.lLastChangedValue.Text = "lLastChangedValue";
            this.lLastChangedValue.Visible = false;
            // 
            // Tray
            // 
            this.Tray.Text = "GameMaster";
            this.Tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Tray_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 245);
            this.Controls.Add(this.lLastChangedValue);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.lVersionValue);
            this.Controls.Add(this.lAuthorValue);
            this.Controls.Add(this.lNameValue);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.lLastChanged);
            this.Controls.Add(this.lCreator);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Game Master";
            this.Load += new System.EventHandler(this.lErscheinungsdatum_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btEditRules;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btEditProp;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lCreator;
        private System.Windows.Forms.Label lLastChanged;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label lNameValue;
        private System.Windows.Forms.Label lAuthorValue;
        private System.Windows.Forms.Label lVersionValue;
        private System.Windows.Forms.Label lLastChangedValue;
        private System.Windows.Forms.NotifyIcon Tray;
    }
}

