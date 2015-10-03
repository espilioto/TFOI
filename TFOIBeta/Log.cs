using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace TFOIBeta
{
    class Log
    {
        private static string path = "";
        private BackgroundWorker bgw = new BackgroundWorker();

        /// <summary>
        /// Checks if a path is available in the "path" setting.
        /// </summary>
        public static void LoadPathFromSettings()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.LogPath))
            {
                Locate();
            }
            else
            {
                path = Properties.Settings.Default.LogPath;
            }
        }

        /// <summary>
        /// Checks the default locations for the log. If it can't be found show a browse dialog and then save the path.
        /// </summary>
        private static void Locate()
        {
            if (File.Exists(Environment.ExpandEnvironmentVariables("%userprofile%") + @"\Documents\My Games\Binding of Isaac Rebirth\log.txt"))
            {
                Properties.Settings.Default.LogPath = Environment.ExpandEnvironmentVariables("%userprofile%") + @"\Documents\My Games\Binding of Isaac Rebirth\log.txt";
            }
            else if (File.Exists("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Binding of Isaac Rebirth\\Documents\\My Games\\Binding of Isaac Rebirth\\log.txt"))
            {
                Properties.Settings.Default.LogPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Binding of Isaac Rebirth\\Documents\\My Games\\Binding of Isaac Rebirth\\log.txt";
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = "log";
                openFileDialog.Filter = "Isaac log file | *.txt";
                openFileDialog.ShowDialog();
                path = openFileDialog.FileName;
                Properties.Settings.Default.LogPath = path;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Start reading the log every second.
        /// </summary>
        public static void Read()
        {
            Timer timer = new Timer(Tick, null, 0, 16);

        }

        private static void Tick(Object O)
        {
            //MessageBox.Show("derp");
        }

    }
}
