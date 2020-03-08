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

        /// <summary>
        /// Saves the specified ruleset as an XML to the specified path
        /// </summary>
        /// <param name="ruleset">The ruleset to be saved</param>
        /// <param name="path">The path of the XML</param>
        public static void Save(Configuration ruleset)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            TextWriter writer = new StreamWriter(AppContext.BaseDirectory + @"\rulesets\" + ruleset.ID + ".xml");
            serializer.Serialize(writer, ruleset);
            writer.Flush();
            writer.Close();
        }

        public void SetTemplate(Template template)
        {
            Template = template;
        }

        public Template GetTemplate()
        {
            return Template;
        }

        /// <summary>
        /// Creates an Ruleset object from an XML at the specified path
        /// </summary>
        /// <param name="path">The path to the XML</param>
        /// <returns>The newly created Ruleset object</returns>
        public static Configuration Load(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Configuration));
            TextReader reader = new StreamReader(path);
            object obj = deserializer.Deserialize(reader);
            Configuration ruleset = (Configuration)obj;
            reader.Close();
            return ruleset;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void Delete()
        {
        }

        /// <summary>
        /// Checks if the executable specified in the StartAction property is valid
        /// </summary>
        /// <returns>Whether the start action is valid or not</returns>
        public bool ValidAction()
        {
            if (File.Exists(Executable) && Executable.EndsWith(".exe"))
            {
                return true;
            }
            return false;
        }
    }
}