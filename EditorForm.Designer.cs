namespace GameMaster
{
    partial class EditorForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btTriggerDelete = new System.Windows.Forms.Button();
            this.btTriggerAdd = new System.Windows.Forms.Button();
            this.btActionDelete = new System.Windows.Forms.Button();
            this.btActionAdd = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 63);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(353, 340);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(402, 63);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(353, 340);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // btTriggerDelete
            // 
            this.btTriggerDelete.Location = new System.Drawing.Point(12, 418);
            this.btTriggerDelete.Name = "btTriggerDelete";
            this.btTriggerDelete.Size = new System.Drawing.Size(165, 30);
            this.btTriggerDelete.TabIndex = 2;
            this.btTriggerDelete.Text = "Delete";
            this.btTriggerDelete.UseVisualStyleBackColor = true;
            // 
            // btTriggerAdd
            // 
            this.btTriggerAdd.Location = new System.Drawing.Point(200, 418);
            this.btTriggerAdd.Name = "btTriggerAdd";
            this.btTriggerAdd.Size = new System.Drawing.Size(165, 30);
            this.btTriggerAdd.TabIndex = 3;
            this.btTriggerAdd.Text = "Add";
            this.btTriggerAdd.UseVisualStyleBackColor = true;
            // 
            // btActionDelete
            // 
            this.btActionDelete.Location = new System.Drawing.Point(402, 418);
            this.btActionDelete.Name = "btActionDelete";
            this.btActionDelete.Size = new System.Drawing.Size(165, 30);
            this.btActionDelete.TabIndex = 4;
            this.btActionDelete.Text = "Delete";
            this.btActionDelete.UseVisualStyleBackColor = true;
            this.btActionDelete.Click += new System.EventHandler(this.btActionDelete_Click);
            // 
            // btActionAdd
            // 
            this.btActionAdd.Location = new System.Drawing.Point(590, 418);
            this.btActionAdd.Name = "btActionAdd";
            this.btActionAdd.Size = new System.Drawing.Size(165, 30);
            this.btActionAdd.TabIndex = 5;
            this.btActionAdd.Text = "Add";
            this.btActionAdd.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(499, 12);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(161, 37);
            this.btSave.TabIndex = 6;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(108, 12);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(161, 37);
            this.btExit.TabIndex = 7;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // ObjectListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 460);
            this.ControlBox = false;
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btActionAdd);
            this.Controls.Add(this.btActionDelete);
            this.Controls.Add(this.btTriggerAdd);
            this.Controls.Add(this.btTriggerDelete);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "ObjectListForm";
            this.Text = "ObjectList";
            this.Load += new System.EventHandler(this.ObjectListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btTriggerDelete;
        private System.Windows.Forms.Button btTriggerAdd;
        private System.Windows.Forms.Button btActionDelete;
        private System.Windows.Forms.Button btActionAdd;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btExit;
    }
}