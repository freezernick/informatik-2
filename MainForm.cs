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
    public partial class MainForm : Form
    {
        public Game PseudoGame;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {

 

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

        private void btEdit_Click(object sender, EventArgs e)
        {
            EditForm EditWindow = new EditForm();
            EditWindow.Text = "Edit Config";
            EditWindow.Show();
            this.Hide();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {

        }

        private void lErscheinungsdatum_Load(object sender, EventArgs e)
        {
            btEdit.Enabled = false;
            btStart.Enabled = false;
            PseudoGame = new Game();
            PseudoGame.Name = "TestGame";
            listBox1.Items.Add(PseudoGame);
        }
    }
}
