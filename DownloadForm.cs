using System;
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
            if (Uri.IsWellFormedUriString(tbQuelle.Text, UriKind.Absolute))
            {
                btStart.Enabled = true;
            }
            else
            {
                btStart.Enabled = false;
            }
        }


        private void pbProgress_Click(object sender, EventArgs e)
        {

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
            if (pbProgress.Value == 100)
            {
                ZipHandling();
            }
        }

        private void ZipHandling()
        {
            string TempDirectory = AppContext.BaseDirectory + @"\temp";
            ZipFile.ExtractToDirectory(Path.Combine(DownloadDirectory, "Download.zip"),TempDirectory);
            string[] Files = Directory.GetFiles(TempDirectory);
            foreach (string File in Files)
            {
                if (File.Contains(".txt"))
                {
                    //loading
                    return;
                }
            }
            string[] dirs = Directory.GetDirectories(TempDirectory);
            string[] substrings = dirs[0].Split('\\');
            TempDirectory += substrings.Last();
        }
    }
}
