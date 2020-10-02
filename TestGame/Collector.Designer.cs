namespace TestGame
{
    partial class Collector
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
            this.PlayerPanel = new System.Windows.Forms.Panel();
            this.ObstaclePanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.GoalPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PlayerPanel
            // 
            this.PlayerPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PlayerPanel.Location = new System.Drawing.Point(150, 162);
            this.PlayerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.PlayerPanel.Name = "PlayerPanel";
            this.PlayerPanel.Size = new System.Drawing.Size(30, 32);
            this.PlayerPanel.TabIndex = 0;
            // 
            // ObstaclePanel
            // 
            this.ObstaclePanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ObstaclePanel.Location = new System.Drawing.Point(268, 101);
            this.ObstaclePanel.Margin = new System.Windows.Forms.Padding(2);
            this.ObstaclePanel.Name = "ObstaclePanel";
            this.ObstaclePanel.Size = new System.Drawing.Size(78, 199);
            this.ObstaclePanel.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // GoalPanel
            // 
            this.GoalPanel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.GoalPanel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.GoalPanel.Location = new System.Drawing.Point(482, 162);
            this.GoalPanel.Margin = new System.Windows.Forms.Padding(2);
            this.GoalPanel.Name = "GoalPanel";
            this.GoalPanel.Size = new System.Drawing.Size(15, 16);
            this.GoalPanel.TabIndex = 0;
            // 
            // Collector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(586, 449);
            this.ControlBox = false;
            this.Controls.Add(this.GoalPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ObstaclePanel);
            this.Controls.Add(this.PlayerPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Collector";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlayerPanel;
        private System.Windows.Forms.Panel ObstaclePanel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel GoalPanel;
    }
}