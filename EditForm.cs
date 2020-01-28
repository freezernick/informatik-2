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
        private MainForm MainForm;
        public EditForm(bool EditMode,MainForm MainWindow)
        {
            InitializeComponent();
            Editing = EditMode;
            MainForm = MainWindow;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            MainForm.Show();
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SelectedGame.FriendlyVersion = tbFriendlyVerion.Text;
            SelectedGame.Author = tbAuthor.Text;
            SelectedGame.Name = tbName.Text;
            SelectedGame.LastChanged = DateTime.Now;
            SelectedGame.Save();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            if (Editing)
            {
                tbName.Text = SelectedGame.Name;
                tbAuthor.Text = SelectedGame.Author;
                tbFriendlyVerion.Text = SelectedGame.FriendlyVersion;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbFriendlyVerion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
