﻿using System;
using System.Windows.Forms;

namespace GameMaster
{
    public partial class EditorForm : Form
    {
        private bool unsavedChanges;

        public EditorForm()
        {
            InitializeComponent();
        }

        private void btActionDelete_Click(object sender, EventArgs e)
        {
        }

        private void ObjectListForm_Load(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            FormHandler.MainForm().Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormHandler.EditForm().Show();
            Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormHandler.MainForm().Show();
        }
    }
}