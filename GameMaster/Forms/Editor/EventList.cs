using GameMaster.Ruleset;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Events;
using System.Reflection;

namespace GameMaster.Forms.Editor
{
    public partial class EventList : EditorWindow
    {
        private readonly List<Event> AllEvents = new List<Event>();
        public EventList()
        {
            InitializeComponent();
            game = EditorHelper._editor.game;
        }

        private void EventList_Load(object sender, EventArgs e)
        {
            Type parentType = typeof(Event);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> subclasses = types.Where(t => t.BaseType == parentType);
            
            foreach (Type type in subclasses)
            {
                Event currentEvent = (Event)Activator.CreateInstance(type);
                if (currentEvent is CustomEvent)
                {
                    continue;
                }
                AllEvents.Add(currentEvent);
                listBox1.Items.Add(type.Name);
            }
        }

        private void Button2_Click(object sender, EventArgs e) => Close();

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                game.LeftSideObjects.Add(AllEvents[listBox1.SelectedIndex]);
                Close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            CustomEvent customEvent = new CustomEvent { Alias = textBox1.Text };
            AllEvents.Add(customEvent);
            listBox1.Items.Add(customEvent.Alias);
            game.CustomEvents.Add(customEvent);
        }

        private void Button4_Click(object sender, EventArgs e)
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