using GameMaster.Templates;
using GameMaster.Config;
using System;
using System.Windows.Forms;

namespace GameMaster
{
    public partial class EditForm : Form
    {
        private Game currentGame;

        public EditForm()
        {
            InitializeComponent();
            currentGame = FormHandler.MainForm().SelectedGame;
            Text = "Edit " + currentGame.Name;
            tbName.Text = currentGame.Name;
            tbStartAction.Text = currentGame.StartAction;
            comboBox1.SelectedItem = currentGame.Template;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            FormHandler.EditorForm().Show();
            Hide();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            currentGame.Name = tbName.Text;
            currentGame.StartAction = tbStartAction.Text;
            currentGame.Template = (Template) comboBox1.SelectedItem;
            currentGame.Save();
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
