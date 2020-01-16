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
          
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            if (Editing)
            {
                textBox1.Text = SelectedGame.Name;
                textBox2.Text = SelectedGame.Author;
                textBox3.Text = SelectedGame.FriendlyVersion;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
