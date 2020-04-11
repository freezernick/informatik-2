using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameMaster.Ruleset.Abstracts;

namespace GameMaster.Forms.Editor
{
    public partial class WorldList : EditorWindow
    {
        private readonly List<World> AllWorlds = new List<World>();

        public WorldList()
        {
            InitializeComponent();
            game = EditorHelper._editor.game;
        }

        private void WorldList_Load(object sender, EventArgs e)
        {
            Type parentType = typeof(World);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> subclasses = types.Where(t => t.BaseType == parentType);

            foreach (Type type in subclasses)
            {
                World currentWorld = (World)Activator.CreateInstance(type);
                AllWorlds.Add(currentWorld);
                listBox1.Items.Add(type.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e) => Close();

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                game.LeftSideObjects.Add(AllWorlds[listBox1.SelectedIndex]);
                Close();
            }
        }
    }
}
