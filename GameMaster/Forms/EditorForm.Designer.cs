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
            this.button4 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.RulesetStuff = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lStartAction = new System.Windows.Forms.Label();
            this.tbStartAction = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.eventStuff = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.StartActionSelector = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.RulesetStuff.SuspendLayout();
            this.eventStuff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btTriggerDelete
            // 
            this.btTriggerDelete.Location = new System.Drawing.Point(132, 27);
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(72, 27);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 24);
            this.button4.TabIndex = 18;
            this.button4.Text = "+ Event";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // treeView1
            // 
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
            this.RulesetStuff.Controls.Add(this.eventStuff);
            this.RulesetStuff.Location = new System.Drawing.Point(3, 3);
            this.RulesetStuff.Name = "RulesetStuff";
            this.RulesetStuff.Size = new System.Drawing.Size(406, 399);
            this.RulesetStuff.TabIndex = 21;
            this.RulesetStuff.TabStop = false;
            this.RulesetStuff.Text = "Ruleset Properties";
            this.RulesetStuff.Enter += new System.EventHandler(this.RulesetStuff_Enter);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(360, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
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
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(104, 18);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(291, 20);
            this.tbName.TabIndex = 3;
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
            // eventStuff
            // 
            this.eventStuff.Controls.Add(this.label1);
            this.eventStuff.Controls.Add(this.button2);
            this.eventStuff.Controls.Add(this.numericUpDown1);
            this.eventStuff.Controls.Add(this.textBox1);
            this.eventStuff.Location = new System.Drawing.Point(1, 0);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.RulesetStuff);
            this.panel1.Location = new System.Drawing.Point(394, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 405);
            this.panel1.TabIndex = 22;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 473);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button4);
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
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btTriggerDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Button button4;
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
        private System.Windows.Forms.Panel panel1;
    }
}