using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using GameMaster.Ruleset.Templates;
using GameMaster.Ruleset.Abstracts;

namespace GameMaster.Ruleset
{
    [XmlRoot("configuration")]
    [XmlInclude(typeof(GameMaster.Ruleset.Templates.Template2D))]
    [XmlInclude(typeof(GameMaster.Ruleset.Templates.Platformer))]
    [XmlInclude(typeof(GameMaster.Ruleset.Events.CustomGlobalEvent))]
    [XmlInclude(typeof(GameMaster.Ruleset.Events.CustomWorldEvent))]
    [XmlInclude(typeof(GameMaster.Ruleset.Events.WorldShutdownRequestEvent))]
    [XmlInclude(typeof(GameMaster.Ruleset.Events.GlobalShutdownRequestEvent))]
    [XmlInclude(typeof(GameMaster.Ruleset.Events.TickEvent))]
    [XmlInclude(typeof(GameMaster.Ruleset.Events.WorldStartupEvent))]
    [XmlInclude(typeof(GameMaster.Ruleset.Actions.Avoid))]
    [XmlInclude(typeof(GameMaster.Ruleset.Actions.Click))]
    [XmlInclude(typeof(GameMaster.Ruleset.Actions.ExecuteCustomEvent))]
    [XmlInclude(typeof(GameMaster.Ruleset.Actions.Log))]
    [XmlInclude(typeof(GameMaster.Ruleset.Actions.Move))]
    [XmlInclude(typeof(GameMaster.Ruleset.Actions.OverlayLog))]
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