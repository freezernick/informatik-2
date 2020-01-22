using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            /* Kontrolle, ob das ruleset-Directory existiert */
            if (!Directory.Exists(AppContext.BaseDirectory + @"\rulesets\"))
            {
                Directory.CreateDirectory(AppContext.BaseDirectory + @"\rulesets\");
            }
            /* Kontrolle, ob das ruleset-Directory Dateien hat */
            if (Directory.GetFiles(AppContext.BaseDirectory + @"\rulesets\").Length == 0)
            {
                return;
            }
            /* Zumindest btStart sollte langfristig in die IndexChanged, damit wir da kontrollieren, ob ein Start denkbar ist */
            btEditProp.Enabled = true;
            btEditRules.Enabled = true;
            btStart.Enabled = true;


            PseudoGame = new Game(); // @F2P: Remove
            PseudoGame.Name = "TestGame";   // @F2P: Remove
            PseudoGame.FriendlyVersion = "1.0"; // @F2P: Remove
            PseudoGame.LastChanged = new DateTime(2020,1,15); // @F2P: Remove
            PseudoGame.Author = "Jakob"; // @F2P: Remove
            listBox1.Items.Add(PseudoGame); // @F2P: Remove
            listBox1.SetSelected(0,true); // @F2P: Remove
        }
    }
}
