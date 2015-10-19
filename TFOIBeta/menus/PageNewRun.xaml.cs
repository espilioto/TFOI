using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TFOIBeta.menus
{
    /// <summary>
    /// Interaction logic for PageNewRun.xaml
    /// </summary>
    public partial class PageNewRun : Page
    {

        Stream stream;
        StreamReader streamReader;
        Timer timer = new Timer(16);
        string line = "";
        Run run;

        public PageNewRun()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            timer.Elapsed += ReadLog;

            Run.Initialise();

            stream = File.Open(Log.path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            streamReader = new StreamReader(stream);

            run = new Run();
            timer.Start();
        }

        private void ReadLog(object sender, ElapsedEventArgs e)
        {
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.StartsWith("RNG Start Seed:")) //regex returns the seed in this form: ((a-Z 0-9)x4)space((a-Z 0-9)x4)
                {
                    run.Seed = Regex.Match(line, @" (\w{4} \w{4}) ").Groups[1].Value;
                    txtSeed.Text = run.Seed;
                }
                if (line.StartsWith("Adding collectible "))
                {
                    var item = Items.getItemFromId(Regex.Match(line, @"(\d+)").Groups[1].Value);  //regex item id
                    if (run.AddItem(item))
                    {
                        Image icon = new Image();
                        icon.Source = Stuff.BitmapToImageSource(item.Icon);
                        itemPanel.Children.Add(icon);
                    }
                    //Regex.Match(line, @"\(([^)]*)\)").Groups[1].Value  //regex item name
                }
                if (line.StartsWith("Game Over"))
                {
                    //txtScan.AppendText("--: " + ("Game over :<") + Environment.NewLine);
                    //gotta figure out what to do here
                }
                if (line.StartsWith("playing cutscene"))
                {
                    if (line.StartsWith("playing cutscene 1 (Intro).")) //don't match the intro cutscene that plays on every launch
                    {
                        ; ;
                    }
                    else
                    {
                        //txtScan.AppendText("--: " + ("Victory!" + Environment.NewLine));
                        //gotta figure out what to do here aswell
                    }
                }
                if (Regex.Match(line, (@"Room \d\.\d{4}\(")).Success) //regex boss name
                {
                    var boss = Bosses.getBossFromName(Regex.Match(line, @"\(([^(]+)").Groups[1].Value);
                    if (run.AddBoss(boss))
                    {
                        Image icon = new Image();
                        icon.Source = Stuff.BitmapToImageSource(boss.Icon);
                        bossPanel.Children.Add(icon);
                    }

                }
            }
        }

        /// <summary>
        /// Let's hope it is.
        /// </summary>
        private bool IsaacIsRunning()
        {
            if (System.Diagnostics.Process.GetProcessesByName("isaac-ng").Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            //try { System.Diagnostics.Process.GetProcessesByName("isaac-ng"); }
            //catch (InvalidOperationException) { return false; }
            //catch (ArgumentException) { return false; }
            //return true;
        }

        #region menu stuff
        private void back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.mainWindowFrame.GoBack();
        }
        private void back_MouseEnter(object sender, MouseEventArgs e)
        {
            back_.Visibility = Visibility.Visible;
        }
        private void back_MouseLeave(object sender, MouseEventArgs e)
        {
            back_.Visibility = Visibility.Hidden;
        }
        #endregion
    }
}
