﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.IO.Compression;
namespace GameMaster
{
    public partial class DownloadForm : Form
    {
        private MainForm MainForm;
        private string DownloadDirectory = AppContext.BaseDirectory + @"\downloads";
        public DownloadForm(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
        }


        private void btExit_Click(object sender, EventArgs e)
        {
            MainForm.Show();
            this.Close();
        }

        private void tbQuelle_TextChanged(object sender, EventArgs e)
        {
            if(!ValidateUrl(tbQuelle.Text))
            {
                btStart.Enabled = false;
                return;
            }
            btStart.Enabled = true;
        }
        /**
         * Checks if the given string is a valid URL
         * Also ensures it's a .zip
         * @return Whether it's valid or not
         */
        private bool ValidateUrl(string Url)
        {
            /* Is using http / https */
            if(!Url.StartsWith("http://") && !Url.StartsWith("https://"))
            {
                rtbStatus.Text += "1";
                return false;
            }

            /* Target is a .zip archive */
            if(!Url.EndsWith(".zip"))
            {
                rtbStatus.Text += "2";
                return false;
            }

            string[] substrings = Url.Split('/');

            /**
             * Target archive has a name
             * (Checks if there are characters between the last '/' and the .zip
             */
            if(substrings.Last() == ".zip")
            {
                return false;
            }
            return true;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(DownloadDirectory))
            {
                Directory.CreateDirectory(DownloadDirectory);
            }
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    new System.Uri(tbQuelle.Text),
                    Path.Combine(DownloadDirectory, "Download.zip")
                );
            }
            
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pbProgress.Value = e.ProgressPercentage;
        }

        private void ZipHandling()
        {
            ZipFile.ExtractToDirectory(Path.Combine(DownloadDirectory, "Download.zip"),AppContext.BaseDirectory + @"\rulesets");
        }
    }
}
