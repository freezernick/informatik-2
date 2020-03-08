using GameMaster.Ruleset.Abstracts;
using System;
using System.Windows.Forms;

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
            Event customEvent = new Ruleset.Events.CustomEvent();
            customEvent.Name = textBox1.Text;
            FormHandler.EditorForm().game.CustomEvents.Add(customEvent);
        }
    }
}