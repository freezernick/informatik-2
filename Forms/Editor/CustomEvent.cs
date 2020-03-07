using System;
using System.Windows.Forms;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Events;

namespace GameMaster.Forms.Editor
{
    public partial class CustomEvent : Form
    {
        public CustomEvent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Event customEvent;
            if (comboBox1.SelectedItem.ToString() == "World")
            {
                customEvent = new CustomWorldEvent();
                customEvent.Name = textBox1.Text;
            }
            else
            {
                customEvent = new CustomGlobalEvent();
                customEvent.Name = textBox1.Text;
            }
            FormHandler.EditorForm().game.CustomEvents.Add(customEvent);
        }
    }
}