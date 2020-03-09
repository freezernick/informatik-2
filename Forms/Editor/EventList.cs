using GameMaster.Ruleset;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Events;

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
                if(currentEvent is CustomEvent)
                {
                    continue;
                }
                AllEvents.Add(currentEvent);
                listBox1.Items.Add(type.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                game.LeftSideObjects.Add(AllEvents[listBox1.SelectedIndex]);
            }
        }

        private void customEventClosed(object sender, EventArgs e)
        {
            Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomEvent customEvent = new CustomEvent();
            customEvent.Alias = textBox1.Text;
            AllEvents.Add(customEvent);
            listBox1.Items.Add(customEvent.Alias);
            game.CustomEvents.Add(customEvent);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(AllEvents[listBox1.SelectedIndex] is CustomEvent)
            {
                CustomEvent customEvent = (CustomEvent)AllEvents[listBox1.SelectedIndex];
                game.CustomEvents.Remove(customEvent);
                listBox1.Items.Remove(customEvent.Alias);
                game.LeftSideObjects.Remove(customEvent);
                foreach (LeftSide leftSide in game.LeftSideObjects)
                {
                    if(leftSide is World)
                    {
                        World world = (World)leftSide;
                        foreach(Event @event in world.WorldEvents)
                        {
                            if(@event == customEvent)
                            {
                                world.WorldEvents.Remove(customEvent);
                            }
                        }
                    }
                }
            }
        }
    }
}