using GameMaster.Ruleset;
using GameMaster.Ruleset.Templates;
using System;

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
            currentGame = MainFormHelper.Get().SelectedRuleset;
            //Text = "Edit " + currentGame.Name;
            tbName.Text = currentGame.Name;
            tbStartAction.Text = currentGame.Executable;
            comboBox1.SelectedIndex = comboBox1.FindString(currentGame.Template.ToString());
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
            currentGame.Template = ((Template)comboBox1.SelectedItem);
            Configuration.Save(currentGame);
            if (!MainFormHelper.Get().Games.Contains(currentGame))
            {
                MainFormHelper.Get().Games.Add(currentGame);
                MainFormHelper.Get().UpdateList();
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.FileOk += fileSelected;
        }

        private void fileSelected(object sender, EventArgs e)
        {
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Executables|*.exe";
            openFileDialog1.InitialDirectory = AppContext.BaseDirectory;
        }
    }
}