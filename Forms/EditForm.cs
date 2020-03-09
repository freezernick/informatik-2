using GameMaster.Ruleset;
using System;
using System.Windows.Forms;
using GameMaster.Ruleset.Templates;
using GameMaster.Ruleset.Types;

namespace GameMaster
{
    public partial class EditForm : GameMasterForm
    {
        private Configuration currentGame;

        public EditForm()
        {
            InitializeComponent();
            foreach (Template template in TemplateHelper.GetTemplateList())
            {
                comboBox1.Items.Add(template);
            }
            currentGame = FormHandler.Get<MainForm>().SelectedRuleset;
            //Text = "Edit " + currentGame.Name;
            tbName.Text = currentGame.Name;
            tbStartAction.Text = currentGame.Executable;
            comboBox1.SelectedIndex = comboBox1.FindString(currentGame.GetTemplate().ToString());
            textBox1.Text = currentGame.ID;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
            FormHandler.Get<EditorForm>().Show();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            currentGame.ID = textBox1.Text;
            currentGame.Name = tbName.Text;
            currentGame.Executable = tbStartAction.Text;
            currentGame.SetTemplate((Template)comboBox1.SelectedItem);
            Configuration.Save(currentGame);
            if(!FormHandler.Get<MainForm>().Games.Contains(currentGame))
            {
                FormHandler.Get<MainForm>().Games.Add(currentGame);
                FormHandler.Get<MainForm>().UpdateList();
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}