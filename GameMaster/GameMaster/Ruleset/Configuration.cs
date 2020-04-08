using GameMaster.Ruleset.Abstracts;
using GameMaster.Ruleset.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GameMaster.Ruleset
{
    [XmlRoot("configuration")]
    [XmlInclude(typeof(Templates.Template2D))]
    [XmlInclude(typeof(Templates.Platformer))]
    [XmlInclude(typeof(Events.CustomEvent))]
    [XmlInclude(typeof(Events.StartupEvent))]
    [XmlInclude(typeof(Events.ShutdownRequestEvent))]
    [XmlInclude(typeof(Events.KeyPressEvent))]
    [XmlInclude(typeof(Events.TickEvent))]
    [XmlInclude(typeof(Actions.Avoid))]
    [XmlInclude(typeof(Actions.Click))]
    [XmlInclude(typeof(Actions.ExecuteCustomEvent))]
    [XmlInclude(typeof(Actions.Log))]
    [XmlInclude(typeof(Actions.Move))]
    [XmlInclude(typeof(Actions.OverlayLog))]
    [XmlInclude(typeof(Worlds.GameWorld))]
    [XmlInclude(typeof(Worlds.StartupWorld))]
    public class Configuration
    {
        public Configuration()
        {
            Name = "Default Name";
            ID = "defaultid";
            Executable = "";
            Template = new Platformer();
            CustomEvents = new List<Event>();
            LeftSideObjects = new List<LeftSide>();
        }

        public String Name;
        public String ID;
        public String Executable;
        public Template Template;
        public List<Event> CustomEvents;
        public List<LeftSide> LeftSideObjects;

        [XmlIgnore]
        public string Folder;

        /// <summary>
        /// Saves the specified ruleset as an XML to the specified path
        /// </summary>
        /// <param name="ruleset">The ruleset to be saved</param>
        /// <param name="path">The path of the XML</param>
        public static void Save(Configuration ruleset)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            TextWriter writer = new StreamWriter(Path.Combine(Utility.RulesetDirectory + ruleset.Folder) + "config.xml");
            serializer.Serialize(writer, ruleset);
            writer.Flush();
            writer.Close();
        }

        /// <summary>
        /// Deletes a ruleset
        /// </summary>
        public void Delete()
        {
            MainForm Main = FormHandler.Get<MainForm>();
            Main.Games.Remove(this);
            Main.UpdateList();
            Directory.Delete(Path.Combine(Utility.RulesetDirectory, Folder), true);
        }

        /// <summary>
        /// Checks if the executable specified in the StartAction property is valid
        /// </summary>
        /// <returns>Whether the start action is valid or not</returns>
        public bool ValidAction()
        {
            if (File.Exists(Executable) && Executable.EndsWith(".exe"))
                return true;
            return false;
        }

        /// <summary>
        /// Loops over every folder inside the ruleset directory and looks for valid config.xml files. Valid configurations are added to the list of the  main form.
        /// </summary>
        public static void DiscoverRulesets()
        {
            if (!Directory.Exists(Utility.RulesetDirectory))
            {
                Directory.CreateDirectory(Utility.RulesetDirectory);
                return;
            }

            foreach (string directory in Directory.GetDirectories(Utility.RulesetDirectory))
            {
                string file = directory + "\\config.xml";
                if (!File.Exists(file))
                    continue;

                XmlSerializer deserializer = new XmlSerializer(typeof(Configuration));
                TextReader reader = new StreamReader(file);
                try
                {
                    object obj = deserializer.Deserialize(reader);
                    Configuration ruleset = (Configuration)obj;
                    reader.Close();
                    string[] pathElements = directory.Split('\\');
                    ruleset.Folder = pathElements[pathElements.Length - 1];
                    FormHandler.Get<MainForm>().Games.Add(ruleset);
                }
                catch
                {
                    reader.Close();
                    continue;
                }
            }
        }
    }
}