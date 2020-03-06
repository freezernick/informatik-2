using GameMaster.Ruleset;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GameMaster.Ruleset.Abstracts;

namespace GameMaster.Forms.Editor
{
    public partial class EventList : GameMaster.EditorWindow
    {
        private List<Event> AllEvents = new List<Event>();

        public EventList(Configuration gameReference = null)
        {
            InitializeComponent();
            game = gameReference;
        }

        private void EventList_Load(object sender, EventArgs e)
        {
            var derived_types = new List<Type>();
            foreach (var domain_assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var assembly_types = domain_assembly.GetTypes()
                  .Where(type => type.IsSubclassOf(typeof(Event)) && !type.IsAbstract);

                derived_types.AddRange(assembly_types);
            }

            foreach (Type type in derived_types)
            {
                Event currentEvent = (Event)Activator.CreateInstance(type);
                AllEvents.Add(currentEvent);
                listBox1.Items.Add(currentEvent.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                game.LeftSideObjects.Add(AllEvents[listBox1.SelectedIndex]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomEvent customEvent = new CustomEvent();
            customEvent.FormClosed += customEventClosed;
            customEvent.Show();
            Hide();
        }

        private void customEventClosed(object sender, EventArgs e)
        {
            Show();
        }
    }
}