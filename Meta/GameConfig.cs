﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SUCC;

namespace GameMaster
{
    public class Game
    {
        public Game()
        {
            Version = 1;
        }

        /// <summary>
        /// Populates the member variables of a specified game with values of the specified config file
        /// </summary>
        /// <param name="GameObject">The game object that should be populated</param>
        /// <param name="config">The config file holding the values</param>
        /// <returns>The populated game object</returns>
        public static Game ConfigToGame(Game GameObject, DataFile config)
        {
            GameObject.Name = config.Get<string>("Name");
            GameObject.ID = config.Get<string>("ID");
            GameObject.Categories = config.Get<string[]>("Categories");
            GameObject.StartAction = config.Get<string>("StartAction", "");
            GameObject.Author = config.Get<string>("Author", "");
            GameObject.LastChanged = config.Get<DateTime>("LastChanged");
            GameObject.FriendlyVersion = config.Get<string>("FriendlyVersion", "");
            GameObject.Version = config.Get<int>("Version", 1);
            GameObject.AssociatedConfig = config;
            return GameObject;
        }

        /// <summary>
        /// Saves the member variables of the game to the associated config file
        /// </summary>
        public void Save()
        {
            AssociatedConfig.Set<string>("Name", Name);
            AssociatedConfig.Set<string>("ID", ID);
            AssociatedConfig.Set<string[]>("Categories", Categories);
            AssociatedConfig.Set<string>("StartAction", StartAction);
            AssociatedConfig.Set<string>("Author", Author);
            AssociatedConfig.Set<DateTime>("LastChanged", LastChanged);
            AssociatedConfig.Set<string>("FriendlyVersion", FriendlyVersion);
            AssociatedConfig.Set<int>("Version", Version);
            AssociatedConfig.SaveAllData();
        }

        /// <summary>
        /// Creates a new config file for the specified ID
        /// </summary>
        public void CreateNew()
        {
            AssociatedConfig = new DataFile(Path.Combine(AppContext.BaseDirectory + @"\rulesets\", ID) + @"\ruleset");
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

        public String Name;
        public String ID;
        public String[] Categories;
        public String StartAction;
        public String Author;
        public DateTime LastChanged;
        public String FriendlyVersion;
        private int Version;
        private DataFile AssociatedConfig;
        public bool Start()
        {
            return true;
        }
    }
}