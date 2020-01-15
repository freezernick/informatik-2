﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameMaster
{
    public partial class MainForm : Form
    {
        public Game PseudoGame;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            EditorForm Newwindow = new EditorForm();
            //NewWindow.Text =
            Newwindow.Show();
            this.Hide();
 

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btNew_Click(object sender, EventArgs e)
        {
            EditForm NewWindow = new EditForm();
            NewWindow.Text = "New Config";
            NewWindow.Show();
            this.Hide();
        }

        private void btEditprop_Click(object sender, EventArgs e)
        {
            EditForm EditWindow = new EditForm();
            EditWindow.Show();
            this.Hide();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            DownloadForm DownloadWindow = new DownloadForm();
            DownloadWindow.Show();
            this.Hide();
        }

        private void lErscheinungsdatum_Load(object sender, EventArgs e)
        {
            btEditprop.Enabled = true;
            btEditrules.Enabled = true;
            PseudoGame = new Game();
            PseudoGame.Name = "TestGame";
            listBox1.Items.Add(PseudoGame);
        }
    }
}
