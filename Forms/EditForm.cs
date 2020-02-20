using GameMaster.Templates;
using GameMaster.Config;
using System;
using System.Windows.Forms;

namespace GameMaster
{
    public partial class EditForm : Form
    {
        private bool Editing;
        private Game currentGame;

        public EditForm()
        {
            InitializeComponent();
        }

        public void SetEditMode(bool EditMode)
        {
            Editing = EditMode;
            if (Editing)
            {
                currentGame = FormHandler.MainForm().SelectedGame;
                tbName.Text = currentGame.Name;
                return;
            }
            currentGame = new Game();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            FormHandler.MainForm().Show();
            Hide();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            currentGame.Name = tbName.Text;
            currentGame.StartAction = tbStartAction.Text;
            currentGame.Template = (Template)comboBox1.SelectedItem;
            if (Editing)
            {
                currentGame.Save();
            }
            else
            {
                currentGame.CreateNew();
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            foreach (Template template in TemplateHelper.GetTemplateList())
            {
                comboBox1.Items.Add(template);
            }
        }
    }
}