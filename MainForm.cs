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

        public Game SelectedGame;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btEditRules_Click(object sender, EventArgs e)
        {
            EditorForm Newwindow = new EditorForm();
            Newwindow.Text = "Edit " + SelectedGame.Name;
            Newwindow.Show();
            this.Hide();
 

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedGame = (Game) listBox1.SelectedItem;
            lNameValue.Text = SelectedGame.Name;
            lAuthorValue.Text = SelectedGame.Author;
            lVersionValue.Text = SelectedGame.FriendlyVersion;
            lLastChangedValue.Text = SelectedGame.LastChanged.ToString();
       
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            EditForm NewWindow = new EditForm(false,this);
            NewWindow.Text = "New Config";
            NewWindow.Show();
            this.Hide();
        }

        private void btEditProp_Click(object sender, EventArgs e)
        {
            EditForm EditWindow = new EditForm(true,this);
            EditWindow.SelectedGame = PseudoGame;
            EditWindow.Text = "Edit " + SelectedGame.Name;
            EditWindow.Show();
            this.Hide();      
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            DownloadForm DownloadWindow = new DownloadForm(this);
            DownloadWindow.Show();
            this.Hide();
        }

        private void lErscheinungsdatum_Load(object sender, EventArgs e)
        {
            btEditProp.Enabled = true;
            btEditRules.Enabled = true;
            PseudoGame = new Game();
            PseudoGame.Name = "TestGame";
            PseudoGame.FriendlyVersion = "1.0";
            PseudoGame.LastChanged = new DateTime(2020,1,15);
            PseudoGame.Author = "Jakob";
            listBox1.Items.Add(PseudoGame);
            listBox1.SetSelected(0,true);
        }
    }
}
