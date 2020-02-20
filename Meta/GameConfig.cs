using GameMaster.Templates;
using SUCC;
using System;
using System.IO;

namespace GameMaster.Config
{
    public class Game
    {
        public Game()
        {
        }

        public String Name;
        public String StartAction;
        public Template Template;
        private DataFile AssociatedConfig;

        /// <summary>
        /// Populates the member variables of a specified game with values of the specified config file
        /// </summary>
        /// <param name="GameObject">The game object that should be populated</param>
        /// <param name="config">The config file holding the values</param>
        /// <returns>The populated game object</returns>
        public static Game ConfigToGame(Game GameObject, DataFile config)
        {
            GameObject.Name = config.Get<string>("Name");
            GameObject.StartAction = config.Get<string>("StartAction", "");
            GameObject.Template = (Template) Activator.CreateInstance(Type.GetType(config.Get<string>("Template", "")));
            GameObject.AssociatedConfig = config;
            return GameObject;
        }

        /// <summary>
        /// Saves the member variables of the game to the associated config file
        /// </summary>
        public void Save()
        {
            AssociatedConfig.Set<string>("Name", Name);
            AssociatedConfig.Set<string>("StartAction", StartAction);
            AssociatedConfig.Set<string>("Template", Template.ToString());
            AssociatedConfig.SaveAllData();
        }

        /// <summary>
        /// Creates a new config file for the specified ID
        /// </summary>
        public void CreateNew()
        {
            AssociatedConfig = new DataFile(Path.Combine(AppContext.BaseDirectory + @"\rulesets\", Name.ToLower()) + @"\ruleset");
            Save();
        }

        /// <summary>
        /// Checks if the executable specified in the StartAction property is valid
        /// </summary>
        /// <returns>Whether the start action is valid or not</returns>
        public bool ValidAction()
        {
            if (File.Exists(StartAction) && StartAction.EndsWith(".exe"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes the associated ruleset of the game
        /// </summary>
        public void Delete()
        {
            Directory.Delete(AssociatedConfig.FilePath.Replace("ruleset.succ", ""), true);
        }
    }
}