using GameMaster.Ruleset;
using System;
using System.Windows.Forms;
using GameMaster.Ruleset.Templates;
using GameMaster.Ruleset.Types;

namespace GameMaster
{
    public partial class EditForm : Form
    {
        private Configuration currentGame;

        public EditForm()
        {
            InitializeComponent();
            foreach (Template template in TemplateHelper.GetTemplateList())
            {
                comboBox1.Items.Add(template);
            }
            currentGame = FormHandler.MainForm().SelectedRuleset;
            //Text = "Edit " + currentGame.Name;
            tbName.Text = currentGame.Name;
            tbStartAction.Text = currentGame.Executable;
            comboBox1.SelectedIndex = comboBox1.FindString(currentGame.GetTemplate().ToString());
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
            FormHandler.EditorForm().Show();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            currentGame.Name = tbName.Text;
            currentGame.Executable = tbStartAction.Text;
            currentGame.SetTemplate((Template)comboBox1.SelectedItem);
            Configuration.Save(currentGame);
        }
    }
}