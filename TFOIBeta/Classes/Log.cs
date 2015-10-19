using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace TFOIBeta
{
    class Log
    {
        public static string path = "";
        
        /// <summary>
        /// Checks if the log path is available in the "path" setting.
        /// </summary>
        public static void LoadPathFromSettings()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.LogPath)) //this should be null the first time you run TFOI
            {
                if (File.Exists(Environment.ExpandEnvironmentVariables("%userprofile%") + @"\Documents\My Games\Binding of Isaac Rebirth\log.txt"))
                {
                    path = Properties.Settings.Default.LogPath = Environment.ExpandEnvironmentVariables("%userprofile%") + @"\Documents\My Games\Binding of Isaac Rebirth\log.txt";
                }
                else if (File.Exists("C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Binding of Isaac Rebirth\\Documents\\My Games\\Binding of Isaac Rebirth\\log.txt"))
                {
                    path = Properties.Settings.Default.LogPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\The Binding of Isaac Rebirth\\Documents\\My Games\\Binding of Isaac Rebirth\\log.txt";
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
            else
            {
                if (File.Exists(Properties.Settings.Default.LogPath))
                {
                    path = Properties.Settings.Default.LogPath;
                }
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

    }
}
