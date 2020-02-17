using System;
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
    public partial class EditForm : Form
    {
        public Game SelectedGame;
        private bool Editing;
        public EditForm()
        {
            InitializeComponent();
        }

        public void SetEditMode(bool EditMode)
        {
            Editing = EditMode;
            if (Editing)
            {
                tbName.Text = SelectedGame.Name;
                tbAuthor.Text = SelectedGame.Author;
                tbFriendlyVerion.Text = SelectedGame.FriendlyVersion;
                return;
            }
            SelectedGame = new Game();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            FormHandler.MainForm().Show();
            Hide();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SelectedGame.FriendlyVersion = tbFriendlyVerion.Text;
            SelectedGame.Author = tbAuthor.Text;
            SelectedGame.Name = tbName.Text;
            SelectedGame.LastChanged = DateTime.Now;
            SelectedGame.StartAction = tbStartAction.Text;
            if (Editing)
            {
                SelectedGame.Save();
            }
            else
            {
                SelectedGame.ID = "newgame";
                SelectedGame.Categories = new string[] {"default"};
                SelectedGame.CreateNew();
            }
        }
    }
}
