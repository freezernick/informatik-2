using GameMaster.Ruleset.Abstracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GameMaster.Ruleset
{
    [XmlRoot("configuration")]
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
            Executable = "";
            CustomEvents = new List<Events.CustomEvent>();
            LeftSideObjects = new List<LeftSide>();
        }

        public String Name;
        public String Executable;
        public List<Events.CustomEvent> CustomEvents;
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
            if (ruleset.Folder == null)
            {
                ruleset.Folder = Path.Combine(Utility.RulesetDirectory, Utility.GenerateSlug(ruleset.Name));
                if (!Directory.Exists(ruleset.Folder))
                    Directory.CreateDirectory(ruleset.Folder);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            TextWriter writer = new StreamWriter(Path.Combine(ruleset.Folder, "config.xml"));
            serializer.Serialize(writer, ruleset);
            writer.Flush();
            writer.Close();
            if (!MainFormHelper.Get().Games.Contains(ruleset))
            {
                MainFormHelper.Get().Games.Add(ruleset);
                MainFormHelper.Get().UpdateList();
            }
        }

        /// <summary>
        /// Deletes a ruleset
        /// </summary>
        public void Delete()
        {
            MainForm Main = MainFormHelper.Get();
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

                Configuration config = Configuration.TryLoadConfig(directory);
                if (config == null)
                    continue;

                MainFormHelper.Get().Games.Add(config);
            }
        }

        public static Configuration TryLoadConfig(string folder)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Configuration));
            TextReader reader = new StreamReader(Path.Combine(folder, "config.xml"));
            try
            {
                object obj = deserializer.Deserialize(reader);
                Configuration ruleset = (Configuration)obj;
                reader.Close();
                ruleset.Folder = folder;
                return ruleset;
            }
            catch
            {
                reader.Close();
                return null;
            }
        }
    }
}