using GameMaster.Ruleset;
using GameMaster.Ruleset.Templates;
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
            foreach (Template template in TemplateHelper.GetTemplateList())
            {
                comboBox1.Items.Add(template);
            }
            currentGame = FormHandler.MainForm().SelectedGame;
            Text = "Edit " + currentGame.Name;
            tbName.Text = currentGame.Name;
            tbStartAction.Text = currentGame.StartAction;
            comboBox1.SelectedIndex = comboBox1.FindString(currentGame.Template.ToString());
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
            FormHandler.EditorForm().Show();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            currentGame.Name = tbName.Text;
            currentGame.StartAction = tbStartAction.Text;
            currentGame.Template = (Template)comboBox1.SelectedItem;
            currentGame.Save();
        }
    }
}