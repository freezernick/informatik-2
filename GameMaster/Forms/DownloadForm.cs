﻿using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using GameMaster.Ruleset;

namespace GameMaster
{
    public partial class DownloadForm : Form
    {
        string DownloadDirectory = Utility.DownloadDirectory;
        string RulesetDirectory = Utility.RulesetDirectory;
        string TempDirectory = Utility.TempDirectory;

        public DownloadForm() => InitializeComponent();

        private void btExit_Click(object sender, EventArgs e)
        {
            MainFormHelper.Show();
            Close();
        }

        private void tbQuelle_TextChanged(object sender, EventArgs e)
        {
            if (!ValidateUrl(tbQuelle.Text))
            {
                btStart.Enabled = false;
                return;
            }
            btStart.Enabled = true;
        }

        /// <summary>
        /// Checks if the given string is a valid URL.
        /// Also ensures it's a .zip
        /// </summary>
        /// <param name="Url">The string to be checked</param>
        /// <returns>Whether it's valid or not</returns>
        private bool ValidateUrl(string Url)
        {
            // Is using http / https
            if (!Url.StartsWith("http://") && !Url.StartsWith("https://"))
            {
                return false;
            }

            // Target is a .zip archive
            if (!Url.EndsWith(".zip"))
            {
                return false;
            }

            string[] substrings = Url.Split('/');

            /// Target archive has a name
            /// (Checks if there are characters between the last '/' and the .zip)
            if (substrings.Last() == ".zip")
            {
                return false;
            }
            return true;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(TempDirectory))
                Directory.Delete(TempDirectory, true);

            if (!Directory.Exists(DownloadDirectory))
                Directory.CreateDirectory(DownloadDirectory);

            using (WebClient wc = new WebClient())
            {
                rtbStatus.AppendText("Downloading now...\n");
                wc.DownloadProgressChanged += WC_DownloadProgressChanged;
                wc.DownloadFileCompleted += WC_DownloadFileCompleted;
                wc.DownloadFileAsync(
                    new System.Uri(tbQuelle.Text),
                    Path.Combine(DownloadDirectory, "Download.zip")
                );
            }
        }

        private void WC_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) => pbProgress.Value = e.ProgressPercentage;

        private void WC_DownloadFileCompleted(object sender, EventArgs e)
        {
            rtbStatus.AppendText("Finished!\n");
            ZipHandling();
        }

        /// <summary>
        /// Unzips the archive
        /// </summary>
        private void ZipHandling()
        {
            rtbStatus.AppendText("Extracting archive...\n");
            ZipFile.ExtractToDirectory(Path.Combine(DownloadDirectory, "Download.zip"), TempDirectory);
            
            rtbStatus.AppendText("Done! Checking files...\n");
            string[] dirs = Directory.GetDirectories(TempDirectory);
            int SetCount = 0;
            foreach (string dir in dirs)
            {
                foreach (string File in Directory.GetFiles(dir))
                {
                    if (File.Contains("config.xml"))
                    {
                        if (FileHandling(dir))
                            SetCount++;
                    }
                }
            }
            rtbStatus.AppendText("Found " + SetCount.ToString() + " valid rulesets!\n");
        }

        /// <summary>
        /// Moves the rulesets to the proper folder
        /// </summary>
        /// <param name="Name">The folder name</param>
        private bool FileHandling(string folder)
        {
            Configuration ruleset = Configuration.TryLoadConfig(folder);
            if (ruleset == null)
                return false;

            string[] pathElements = folder.Split('\\');

            Directory.Move(Path.Combine(TempDirectory, pathElements[pathElements.Length - 1]), Path.Combine(RulesetDirectory, pathElements[pathElements.Length - 1]));
            MainFormHelper.Get().Games.Add(ruleset);
            MainFormHelper.Get().UpdateList();

            return true;
        }
    }
}