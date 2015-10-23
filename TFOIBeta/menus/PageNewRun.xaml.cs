﻿using System;
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
        string line = "";

        Timer timer = new Timer(100);
        Run run;

        public PageNewRun()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Elapsed += ReadLog;

            Run.Initialise();

            stream = File.Open(Log.path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            streamReader = new StreamReader(stream);

            timer.Enabled = true;
            timer.Start();
        }

        private void ReadLog(object sender, ElapsedEventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName("isaac-ng").Length > 0)
            {
                Dispatcher.Invoke(new Action(() => txtIsRunning.Foreground = Brushes.ForestGreen));
                Dispatcher.Invoke(new Action(() => txtIsRunning.Text = "GAME IS RUNNING"));

                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.StartsWith("RNG Start Seed:"))
                    {
                        if (run != null)
                        {
                            run.Dispose();
                        }
                        run = new Run();

                        Dispatcher.Invoke(new Action(() => itemPanel.Children.Clear()));
                        Dispatcher.Invoke(new Action(() => bossPanel.Children.Clear()));

                        Dispatcher.Invoke(new Action(() => txtRIP.Visibility = Visibility.Hidden));

                        Dispatcher.Invoke(new Action(() => run.Seed = Regex.Match(line, @" (\w{4} \w{4}) ").Groups[1].Value)); ////regex seed
                        Dispatcher.Invoke(new Action(() => txtSeed.Text = run.Seed));
                    }
                    if (line.StartsWith("Initialized player with"))
                    {
                        var character = Characters.getCharFromId(Regex.Match(line, @"Subtype (\d)").Groups[1].Value);

                        Dispatcher.Invoke(new Action(() => charIcon.ToolTip = character.Name));
                        Dispatcher.Invoke(new Action(() => charIcon.Source = Stuff.BitmapToImageSource(character.Icon)));
                    }
                    if (line.StartsWith("Adding collectible "))
                    {
                        var item = Items.getItemFromName(Regex.Match(line, @"\(([^)]*)\)").Groups[1].Value);

                        if (item != null)               //can't be too careful
                        {
                            if (run.AddItem(item))
                            {
                                Application.Current.Dispatcher.Invoke((Action)delegate
                                {
                                    Image icon = new Image();
                                    icon.Stretch = Stretch.None;
                                    icon.ToolTip = item.Name + Environment.NewLine + item.Text;
                                    icon.Source = Stuff.BitmapToImageSource(item.Icon);

                                    itemPanel.Children.Add(icon);
                                });
                            }
                        }
                        //Regex.Match(line, @"(\d+)").Groups[1].Value  //regex item id
                        //Regex.Match(line, @"\(([^)]*)\)").Groups[1].Value  //regex item name
                    }
                    if (line.StartsWith("Game Over"))
                    {
                        Dispatcher.Invoke(new Action(() => txtRIP.Visibility = Visibility.Visible));
                        Dispatcher.Invoke(new Action(() => txtRIP.Foreground = Brushes.DarkRed));
                        Dispatcher.Invoke(new Action(() => txtRIP.Text = "RIP IN PEPPERONNIS M8"));

                        if (run != null)
                        {
                            run.Dispose();
                        }

                    }
                    if (line.StartsWith("playing cutscene"))
                    {
                        if (line.StartsWith("playing cutscene 1 (Intro).")) //don't match the intro cutscene that plays on every launch
                        {
                            ; ;
                        }
                        else
                        {
                            Dispatcher.Invoke(new Action(() => txtRIP.Visibility = Visibility.Hidden));
                            Dispatcher.Invoke(new Action(() => txtRIP.Foreground = Brushes.DarkRed));
                            Dispatcher.Invoke(new Action(() => txtRIP.Text = "VICTORY!"));

                            if (run != null)
                            {
                                run.Dispose();
                            }
                            //txtScan.AppendText("--: " + ("Victory!" + Environment.NewLine));
                            //gotta figure out what to do here aswell
                        }
                    }
                    if (Regex.Match(line, (@"Room \d\.\d{4}")).Success) //regex boss name
                    {
                        var boss = Bosses.getBossFromName(Regex.Match(line, @"\(([^\)]+)\)").Groups[1].Value); //if miniboss or dual boss, var boss will remain null

                        if (boss == null)
                        {
                            boss = Bosses.getBossFromName(Regex.Match(line, @"\((\w+)").Groups[1].Value);  //regex dual boss
                        }

                        if (boss != null)           //so let's check that over here, even though AddBoss checks if the boss exists in the main boss list
                        {
                            Application.Current.Dispatcher.Invoke((Action)delegate
                            {
                                if (run.AddBoss(boss))
                                {
                                    Image icon = new Image();
                                    icon.Stretch = Stretch.None;
                                    icon.ToolTip = boss.Name;
                                    icon.Source = Stuff.BitmapToImageSource(boss.Icon);

                                    Dispatcher.Invoke(new Action(() => bossPanel.Children.Add(icon)));
                                }
                            });
                        }
                    }
                    if (line.StartsWith("deathspawn_boss"))
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            //mark boss as defeated in the object and maybe add a visual marker

                            //Image icon = new Image();
                            //icon.Stretch = Stretch.None;

                            //icon.Source = Stuff.BitmapToImageSource(Properties.Resources.BossDefeated);
                            //bossDefeatedPanel.Children.Add(icon);
                        });
                    }
                    if (line.StartsWith("Mom clear time"))
                    {
                        var time = Double.Parse(Regex.Match(line, @"\d+").Groups[1].Value); //regex framecounter (30/sec. why not 60? no idea)
                        time /= 30;                                                         //get seconds
                        time /= 60;                                                         //get minutes

                        run.Time = time;
                    }
                }
            }
            else
            {
                Dispatcher.Invoke(new Action(() => txtIsRunning.Foreground = Brushes.DarkRed));
                Dispatcher.Invoke(new Action(() => txtIsRunning.Text = "GAME IS NOT RUNNING"));
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
