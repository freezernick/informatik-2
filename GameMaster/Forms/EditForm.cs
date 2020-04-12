﻿using GameMaster.Ruleset;
using System;
using System.Windows.Forms;

namespace GameMaster
{
    public partial class EditForm : Form
    {
        private Configuration currentGame;

        public EditForm()
        {
            InitializeComponent();
            currentGame = MainFormHelper.Get().SelectedRuleset;
            //Text = "Edit " + currentGame.Name;
            tbName.Text = currentGame.Name;
            tbStartAction.Text = currentGame.Executable;
        }

        private void btBack_Click(object sender, EventArgs e) => Close();

        private void btSave_Click(object sender, EventArgs e)
        {
            currentGame.Name = tbName.Text;
            currentGame.Executable = tbStartAction.Text;
            Configuration.Save(currentGame);
            if (!MainFormHelper.Get().Games.Contains(currentGame))
            {
                MainFormHelper.Get().Games.Add(currentGame);
                MainFormHelper.Get().UpdateList();
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.FileOk += fileSelected;
        }

        private void fileSelected(object sender, EventArgs e)
        {
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Executables|*.exe";
            openFileDialog1.InitialDirectory = AppContext.BaseDirectory;
        }
    }
}