using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;

namespace GameMaster
{
    public partial class DownloadForm : GameMasterForm
    {
        private string DownloadDirectory = AppContext.BaseDirectory + @"\downloads";

        public DownloadForm() => InitializeComponent();

        private void btExit_Click(object sender, EventArgs e)
        {
            FormHandler.Get<MainForm>().Show();
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
            if (!Directory.Exists(DownloadDirectory))
            {
                rtbStatus.AppendText("Download directory doesn't exist!\n");
                rtbStatus.AppendText("Creating...\n");
                Directory.CreateDirectory(DownloadDirectory);
            }
            using (WebClient wc = new WebClient())
            {
                string DownloadUrl = tbQuelle.Text;

                // Upgrade insecure requests
                if (DownloadUrl.StartsWith("http://"))
                {
                    rtbStatus.AppendText("\nUpgrading insecure request...\n");
                    DownloadUrl.Replace("http://", "https://");
                }
                rtbStatus.AppendText("Downloading now...\n");
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                wc.DownloadFileAsync(
                    new System.Uri(DownloadUrl),
                    Path.Combine(DownloadDirectory, "Download.zip")
                );
            }
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) => pbProgress.Value = e.ProgressPercentage;

        private void wc_DownloadFileCompleted(object sender, EventArgs e)
        {
            rtbStatus.AppendText("Finished!\n");
            ZipHandling();
        }

        private void ZipHandling()
        {
            rtbStatus.AppendText("Extracting archive...\n");
            string TempDirectory = AppContext.BaseDirectory + @"\temp";
            ZipFile.ExtractToDirectory(Path.Combine(DownloadDirectory, "Download.zip"), TempDirectory);
            rtbStatus.AppendText("Done! Checking files...\n");
            string[] Files = Directory.GetFiles(TempDirectory);
            foreach (string File in Files)
            {
                if (File.Contains(".succ"))
                {
                    rtbStatus.AppendText("Found 1 ruleset!\n");
                    FileHandling(true, File);
                    return;
                }
            }
            string[] dirs = Directory.GetDirectories(TempDirectory);
            int SetCount = 0;
            foreach (string dir in dirs)
            {
                string[] substrings = dir.Split('\\');
                foreach (string File in Directory.GetFiles(Path.Combine(TempDirectory, substrings.Last())))
                {
                    if (File.Contains(".succ"))
                    {
                        SetCount++;
                        FileHandling(false, substrings.Last());
                    }
                }
            }
            rtbStatus.AppendText("Found " + SetCount.ToString() + " rulesets!\n");
        }

        /// <summary>
        /// Moves the rulesets to the proper folder
        /// </summary>
        /// <param name="isConfigInRoot">Whether the .succ is directly in the temp directory or in a subdirectory</param>
        /// <param name="Name">Either the name of the .succ or the name of the subdirectory</param>
        private void FileHandling(bool isConfigInRoot, string Name)
        {
            //if (isConfigInRoot)
            //{
            //    DataFile dataFile = new DataFile(Path.Combine(AppContext.BaseDirectory + @"\temp\") + Name);
            //    string id = dataFile.Get<string>("ID");
            //    Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory + @"\rulesets\", id));
            //    string[] files = Directory.GetFiles(AppContext.BaseDirectory + @"\temp\");
            //    foreach (string file in files)
            //    {
            //        File.Move(AppContext.BaseDirectory + @"\temp\" + file, Path.Combine(AppContext.BaseDirectory + @"\rulesets\" + Name) + file);
            //    }
            //}
            //else
            //{
            //    Directory.Move(Path.Combine(AppContext.BaseDirectory + @"\temp", Name), AppContext.BaseDirectory + @"\rulesets\" + Name);
            //}
        }
    }
}