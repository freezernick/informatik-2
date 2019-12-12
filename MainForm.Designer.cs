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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btNew = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.lName = new System.Windows.Forms.Label();
            this.lCreator = new System.Windows.Forms.Label();
            this.lLastChanged = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 10);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(282, 342);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btAdd);
            this.groupBox1.Controls.Add(this.btEdit);
            this.groupBox1.Controls.Add(this.btNew);
            this.groupBox1.Controls.Add(this.btStart);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(306, 271);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(276, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(4, 50);
            this.btAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(130, 22);
            this.btAdd.TabIndex = 5;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Location = new System.Drawing.Point(142, 19);
            this.btEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(125, 22);
            this.btEdit.TabIndex = 4;
            this.btEdit.Text = "Edit";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(4, 19);
            this.btNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(130, 22);
            this.btNew.TabIndex = 3;
            this.btNew.Text = "New";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(142, 50);
            this.btStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(128, 22);
            this.btStart.TabIndex = 2;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(307, 12);
            this.lName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 2;
            this.lName.Text = "Name";
            // 
            // lCreator
            // 
            this.lCreator.AutoSize = true;
            this.lCreator.Location = new System.Drawing.Point(307, 45);
            this.lCreator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lCreator.Name = "lCreator";
            this.lCreator.Size = new System.Drawing.Size(41, 13);
            this.lCreator.TabIndex = 3;
            this.lCreator.Text = "Creator";
            // 
            // lLastChanged
            // 
            this.lLastChanged.AutoSize = true;
            this.lLastChanged.Location = new System.Drawing.Point(307, 109);
            this.lLastChanged.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lLastChanged.Name = "lLastChanged";
            this.lLastChanged.Size = new System.Drawing.Size(73, 13);
            this.lLastChanged.TabIndex = 4;
            this.lLastChanged.Text = "Last Changed";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(307, 78);
            this.lVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(42, 13);
            this.lVersion.TabIndex = 5;
            this.lVersion.Text = "Version";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.lLastChanged);
            this.Controls.Add(this.lCreator);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lCreator;
        private System.Windows.Forms.Label lLastChanged;
        private System.Windows.Forms.Label lVersion;
    }
}

