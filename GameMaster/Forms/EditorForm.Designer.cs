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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.btTriggerDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.RulesetStuff = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lStartAction = new System.Windows.Forms.Label();
            this.tbStartAction = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EventName = new System.Windows.Forms.TextBox();
            this.eventStuff = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.StartActionSelector = new System.Windows.Forms.OpenFileDialog();
            this.button5 = new System.Windows.Forms.Button();
            this.EventList = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.WorldProperties = new System.Windows.Forms.GroupBox();
            this.Bt_WorldChange = new System.Windows.Forms.Button();
            this.Bt_WorldClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.RulesetStuff.SuspendLayout();
            this.eventStuff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.EventList.SuspendLayout();
            this.WorldProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btTriggerDelete
            // 
            this.btTriggerDelete.Location = new System.Drawing.Point(133, 27);
            this.btTriggerDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btTriggerDelete.Name = "btTriggerDelete";
            this.btTriggerDelete.Size = new System.Drawing.Size(39, 24);
            this.btTriggerDelete.TabIndex = 2;
            this.btTriggerDelete.Text = "-";
            this.btTriggerDelete.UseVisualStyleBackColor = true;
            this.btTriggerDelete.Click += new System.EventHandler(this.BtTriggerDelete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "+ World";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(806, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(35, 22);
            this.toolStripButton2.Text = "Save";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(30, 22);
            this.toolStripButton3.Text = "Exit";
            this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // treeView1
            // 
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(12, 56);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(376, 405);
            this.treeView1.TabIndex = 19;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // RulesetStuff
            // 
            this.RulesetStuff.Controls.Add(this.button3);
            this.RulesetStuff.Controls.Add(this.lStartAction);
            this.RulesetStuff.Controls.Add(this.tbStartAction);
            this.RulesetStuff.Controls.Add(this.tbName);
            this.RulesetStuff.Controls.Add(this.lName);
            this.RulesetStuff.Location = new System.Drawing.Point(398, 62);
            this.RulesetStuff.Name = "RulesetStuff";
            this.RulesetStuff.Size = new System.Drawing.Size(406, 399);
            this.RulesetStuff.TabIndex = 21;
            this.RulesetStuff.TabStop = false;
            this.RulesetStuff.Text = "Ruleset Properties";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(360, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lStartAction
            // 
            this.lStartAction.AutoSize = true;
            this.lStartAction.Location = new System.Drawing.Point(8, 45);
            this.lStartAction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lStartAction.Name = "lStartAction";
            this.lStartAction.Size = new System.Drawing.Size(48, 13);
            this.lStartAction.TabIndex = 23;
            this.lStartAction.Text = "File Path";
            // 
            // tbStartAction
            // 
            this.tbStartAction.Location = new System.Drawing.Point(104, 42);
            this.tbStartAction.Margin = new System.Windows.Forms.Padding(2);
            this.tbStartAction.Name = "tbStartAction";
            this.tbStartAction.Size = new System.Drawing.Size(251, 20);
            this.tbStartAction.TabIndex = 22;
            this.tbStartAction.TextChanged += new System.EventHandler(this.tbStartAction_TextChanged);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(104, 18);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(291, 20);
            this.tbName.TabIndex = 3;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(8, 21);
            this.lName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 2;
            this.lName.Text = "Name";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(9, 141);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(175, 23);
            this.button8.TabIndex = 4;
            this.button8.Text = "Cancel";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(190, 141);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(179, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "Create and Add";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // EventName
            // 
            this.EventName.Location = new System.Drawing.Point(190, 115);
            this.EventName.Name = "EventName";
            this.EventName.Size = new System.Drawing.Size(179, 20);
            this.EventName.TabIndex = 0;
            // 
            // eventStuff
            // 
            this.eventStuff.Controls.Add(this.label1);
            this.eventStuff.Controls.Add(this.button2);
            this.eventStuff.Controls.Add(this.numericUpDown1);
            this.eventStuff.Controls.Add(this.textBox1);
            this.eventStuff.Location = new System.Drawing.Point(401, 62);
            this.eventStuff.Name = "eventStuff";
            this.eventStuff.Size = new System.Drawing.Size(405, 399);
            this.eventStuff.TabIndex = 2;
            this.eventStuff.TabStop = false;
            this.eventStuff.Text = "Event Properties";
            this.eventStuff.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Triggered";
            this.toolTip1.SetToolTip(this.label1, "0 = Automatically (Internal), 1 = Manually (through actions), 2 = Automatically (" +
        "through image recognition)");
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(319, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Change";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(356, 41);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(32, 20);
            this.numericUpDown1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.numericUpDown1, "0 = Automatically (Internal), 1 = Manually (through actions), 2 = Automatically (" +
        "through image recognition)");
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(307, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // StartActionSelector
            // 
            this.StartActionSelector.Filter = "Executable|*.exe";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(73, 27);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 23);
            this.button5.TabIndex = 23;
            this.button5.Text = "+ Event";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // EventList
            // 
            this.EventList.Controls.Add(this.button4);
            this.EventList.Controls.Add(this.button6);
            this.EventList.Controls.Add(this.button8);
            this.EventList.Controls.Add(this.label5);
            this.EventList.Controls.Add(this.label4);
            this.EventList.Controls.Add(this.label3);
            this.EventList.Controls.Add(this.comboBox1);
            this.EventList.Controls.Add(this.EventName);
            this.EventList.Controls.Add(this.label2);
            this.EventList.Location = new System.Drawing.Point(400, 62);
            this.EventList.Name = "EventList";
            this.EventList.Size = new System.Drawing.Size(406, 399);
            this.EventList.TabIndex = 26;
            this.EventList.TabStop = false;
            this.EventList.Text = "Event List";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(190, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(179, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Create a custom event";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "----------- or -----------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Select an existing custom event";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // WorldProperties
            // 
            this.WorldProperties.Controls.Add(this.Bt_WorldChange);
            this.WorldProperties.Controls.Add(this.Bt_WorldClear);
            this.WorldProperties.Controls.Add(this.pictureBox1);
            this.WorldProperties.Controls.Add(this.label7);
            this.WorldProperties.Controls.Add(this.textBox2);
            this.WorldProperties.Controls.Add(this.label6);
            this.WorldProperties.Location = new System.Drawing.Point(398, 61);
            this.WorldProperties.Name = "WorldProperties";
            this.WorldProperties.Size = new System.Drawing.Size(408, 400);
            this.WorldProperties.TabIndex = 27;
            this.WorldProperties.TabStop = false;
            this.WorldProperties.Text = "World Properties";
            // 
            // Bt_WorldChange
            // 
            this.Bt_WorldChange.Location = new System.Drawing.Point(210, 217);
            this.Bt_WorldChange.Name = "Bt_WorldChange";
            this.Bt_WorldChange.Size = new System.Drawing.Size(186, 23);
            this.Bt_WorldChange.TabIndex = 5;
            this.Bt_WorldChange.Text = "Change";
            this.Bt_WorldChange.UseVisualStyleBackColor = true;
            this.Bt_WorldChange.Click += new System.EventHandler(this.Bt_WorldChange_Click);
            // 
            // Bt_WorldClear
            // 
            this.Bt_WorldClear.Location = new System.Drawing.Point(12, 217);
            this.Bt_WorldClear.Name = "Bt_WorldClear";
            this.Bt_WorldClear.Size = new System.Drawing.Size(192, 23);
            this.Bt_WorldClear.TabIndex = 4;
            this.Bt_WorldClear.Text = "Clear";
            this.Bt_WorldClear.UseVisualStyleBackColor = true;
            this.Bt_WorldClear.Click += new System.EventHandler(this.Bt_WorldClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(385, 129);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Reference";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(176, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(226, 20);
            this.textBox2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Name";
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 473);
            this.ControlBox = false;
            this.Controls.Add(this.WorldProperties);
            this.Controls.Add(this.EventList);
            this.Controls.Add(this.eventStuff);
            this.Controls.Add(this.RulesetStuff);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btTriggerDelete);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditorForm";
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.RulesetStuff.ResumeLayout(false);
            this.RulesetStuff.PerformLayout();
            this.eventStuff.ResumeLayout(false);
            this.eventStuff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.EventList.ResumeLayout(false);
            this.EventList.PerformLayout();
            this.WorldProperties.ResumeLayout(false);
            this.WorldProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btTriggerDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox RulesetStuff;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox eventStuff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lStartAction;
        private System.Windows.Forms.TextBox tbStartAction;
        private System.Windows.Forms.OpenFileDialog StartActionSelector;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EventName;
        private System.Windows.Forms.GroupBox EventList;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox WorldProperties;
        private System.Windows.Forms.Button Bt_WorldChange;
        private System.Windows.Forms.Button Bt_WorldClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
    }
}