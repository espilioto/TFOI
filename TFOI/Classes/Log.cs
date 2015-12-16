using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace TFOI
{
    class Log
    {
        public static string path = string.Empty;

        /// <summary>
        /// Tries to locate the log in the default dirs, Afterbirth having priority over Rebirth (why even have separate directories, no idea. I blame Ed.).
        /// </summary>
        public static void LocateLogs()
        {

            if (File.Exists(Environment.ExpandEnvironmentVariables("%userprofile%") + @"\Documents\My Games\Binding of Isaac Afterbirth\log.txt"))
            {
                path = Environment.ExpandEnvironmentVariables("%userprofile%") + @"\Documents\My Games\Binding of Isaac Afterbirth\log.txt";
            }
            else if (File.Exists(Environment.ExpandEnvironmentVariables("%userprofile%") + @"\Documents\My Games\Binding of Isaac Rebirth\log.txt"))
            {
                path = Environment.ExpandEnvironmentVariables("%userprofile%") + @"\Documents\My Games\Binding of Isaac Rebirth\log.txt";
            }
            else if (File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\The Binding of Isaac Rebirth\Documents\My Games\Binding of Isaac Afterbirth\log.txt"))
            {
                path = @"C:\Program Files (x86)\Steam\steamapps\common\The Binding of Isaac Rebirth\Documents\My Games\Binding of Isaac Afterbirth\log.txt";
            }
            else if (File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\The Binding of Isaac Rebirth\Documents\My Games\Binding of Isaac Rebirth\log.txt"))
            {
                path = @"C:\Program Files (x86)\Steam\steamapps\common\The Binding of Isaac Rebirth\Documents\My Games\Binding of Isaac Rebirth\log.txt";
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = "log";
                openFileDialog.Filter = "Isaac log file | *.txt";
                openFileDialog.ShowDialog();
                path = openFileDialog.FileName;
            }
        }
    }

}
