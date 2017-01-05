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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TFOI.menus
{
    /// <summary>
    /// Interaction logic for PageNewRun.xaml
    /// </summary>
    public partial class PageNewRun : Page
    {
        DropShadowEffect glowActiveItem, glowFlyLord, glowGuppy, glowSuperBum, glowMom, glowBob, glowShrooms, glowCthulhu, glowTumor, glowDrugs, glowAngel, glowPoop;
        Image icon;

        Stream stream;
        StreamReader streamReader;
        string line = string.Empty;

        Timer runTimer = new Timer(1000);
        Timer timer = new Timer(Properties.Settings.Default.timerRefreshSpeed);

        Run run;

        public PageNewRun()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GlowStuff();
            Run.Initialise();

            stream = File.Open(Log.path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            streamReader = new StreamReader(stream);

            runTimer.Elapsed += RunTimer_Elapsed;

            timer.Elapsed += ReadLog;
            timer.Enabled = true;
            timer.Start();
        }

        private void ReadLog(object sender, ElapsedEventArgs e)
        {
            //if (true)                                                                               //just for testing purposes
            if (System.Diagnostics.Process.GetProcessesByName("isaac-ng").Length > 0)
            {
                Dispatcher.Invoke(new Action(() => txtIsRunning.Foreground = Brushes.ForestGreen));
                Dispatcher.Invoke(new Action(() => txtIsRunning.Text = "GAME IS RUNNING"));

                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.StartsWith("[INFO] - RNG Start Seed:"))
                    {
                        run = new Run();

                        Dispatcher.Invoke(new Action(() => itemPanel.Children.Clear()));
                        Dispatcher.Invoke(new Action(() => bossPanel.Children.Clear()));
                        Dispatcher.Invoke(new Action(() => bossDefeatedPanel.Children.Clear()));
                        Dispatcher.Invoke(new Action(() => floorPanel.Source = null));
                        Dispatcher.Invoke(new Action(() => txtTime.Text = "TIME:"));
                        Dispatcher.Invoke(new Action(() => txtCurse.Text = ""));

                        Dispatcher.Invoke(new Action(() => txtRIP.Visibility = Visibility.Hidden));

                        Dispatcher.Invoke(new Action(() => run.Seed = Regex.Match(line, @"(\w{4} \w{4}) ").Value)); //regex seed
                        Dispatcher.Invoke(new Action(() => txtSeed.Text = run.Seed));
                    }
                    else if (line.StartsWith("[INFO] - Initialized player with"))
                    {
                        var character = Characters.GetCharFromId(Regex.Match(line, @"Subtype (\d+)").Groups[1].Value); //regex character ID
                        run.AddCharacter(character);

                        Dispatcher.Invoke(new Action(() => charIcon.ToolTip = character.Name));
                        Dispatcher.Invoke(new Action(() => charIcon.Source = Stuff.BitmapToImageSource(character.Icon)));
                    }
                    else if (line.StartsWith("[INFO] - Level::Init"))
                    {
                        Dispatcher.Invoke(new Action(() => curseIcon.Visibility = Visibility.Hidden));      //we don't know if the new floor is gonna have a curse
                        Dispatcher.Invoke(new Action(() => txtCurse.Visibility = Visibility.Hidden));       //so let's hide the curse stuff for now

                        var stage = Regex.Match(line, @"m_Stage (\d+)").Groups[1].Value;            //regex stage id
                        var altStage = Regex.Match(line, @"m_StageType (\d+)").Groups[1].Value;      //regex alt stage id

                        if (altStage == null)
                        {
                            altStage = Regex.Match(line, @"m_AltStage (\d+)").Groups[1].Value;      //floor detection fix for Rebirth
                        }

                        var floor = Floors.GetFloorFromStageCodes(stage, altStage);

                        if (floor != null)
                        {
                            run.AddFloor(floor);

                            Dispatcher.Invoke(new Action(() => floorPanel.ToolTip = run.RunFloors.Last().Name));
                            Dispatcher.Invoke(new Action(() => floorPanel.Source = Stuff.BitmapToImageSource(run.RunFloors.Last().Icon)));
                        }

                        runTimer.Start();        //delay the timer as long as possible
                    }
                    else if (line.StartsWith("[INFO] - Curse of"))
                    {
                        string curse = string.Empty;

                        if (line.Contains("Maze"))
                        {
                            curse = "Curse of the Maze";
                            run.RunFloors.Last().Curse = curse;
                        }
                        else if (line.Contains("Blind"))
                        {
                            curse = "Curse of the Blind";
                            run.RunFloors.Last().Curse = curse;
                        }
                        else if (line.Contains("Lost"))
                        {
                            curse = "Curse of the Lost!";
                            run.RunFloors.Last().Curse = curse;
                        }
                        else if (line.Contains("Unknown"))
                        {
                            curse = "Curse of the Unknown";
                            run.RunFloors.Last().Curse = curse;
                        }
                        else if (line.Contains("Darkness"))
                        {
                            curse = "Curse of Darkness";
                            run.RunFloors.Last().Curse = curse;
                        }
                        else if (line.Contains("Labyrinth"))                                        //if it's an XL floor
                        {
                            curse = "Curse of the Labyrinth";

                            run.AddFloor(Floors.ConvertFloorToXL(run.RunFloors.Last()));            //add the equivalent XL floor to the list
                            run.RunFloors[run.RunFloors.Count - 1].Curse = curse;                   //add the curse to the new floor
                            run.RunFloors.RemoveAt(run.RunFloors.Count - 2);                        //and remove the old "regular" one from the list

                            Dispatcher.Invoke(new Action(() => floorPanel.ToolTip = run.RunFloors.Last().Name)); //update the tooltip
                        }

                        if (string.IsNullOrWhiteSpace(curse))
                        {
                            Dispatcher.Invoke(new Action(() => curseIcon.Visibility = Visibility.Hidden));
                            Dispatcher.Invoke(new Action(() => txtCurse.Visibility = Visibility.Hidden));
                        }
                        else
                        {
                            Dispatcher.Invoke(new Action(() => txtCurse.Text = curse.ToUpper()));

                            Dispatcher.Invoke(new Action(() => curseIcon.Visibility = Visibility.Visible));
                            Dispatcher.Invoke(new Action(() => txtCurse.Visibility = Visibility.Visible));
                        }


                        curse = string.Empty;                                           //empty the string so it doesnt trigger when you go to the next floor
                    }
                    else if (line.StartsWith("[INFO] - Adding collectible "))
                    {
                        var item = Items.GetItemFromId(Regex.Match(line, @"(\d+)").Groups[1].Value); //regex item id

                        if (item != null && run.RunFloors != null)      //#noshorthands         //can't be too careful
                        {
                            item.FloorPickedUp = run.RunFloors.LastOrDefault();

                            if (run.AddItem(item))      //if this item hasn't been picked up before
                            {
                                Application.Current.Dispatcher.Invoke((Action)delegate
                                {
                                    icon = new Image();
                                    icon.Name = "_" + run.RunItems.Last().Id;
                                    icon.Stretch = Stretch.None;
                                    icon.ToolTip = run.RunItems.Last().Name + Environment.NewLine + run.RunItems.Last().Text;
                                    icon.Source = Stuff.BitmapToImageSource(run.RunItems.Last().Icon);

                                    itemPanel.Children.Add(icon);

                                    if (item.Space)
                                    {
                                        foreach (var child in itemPanel.Children.OfType<Image>())
                                        {
                                            if ((string)child.Tag == "space")
                                            {
                                                child.Effect = null;
                                            }
                                        }
                                    }
                                    if (item.Tform == "Guppy")
                                    {
                                        icon.Effect = glowGuppy;
                                        icon.Tag2 = "Guppy";
                                    }
                                    else if (item.Tform == "FlyLord")
                                    {
                                        icon.Effect = glowFlyLord;
                                        icon.Tag2 = "FlyLord";
                                    }
                                    else if (item.Tform == "SuperBum")
                                    {
                                        icon.Effect = glowSuperBum;
                                        icon.Tag2 = "SuperBum";
                                    }
                                    else if (item.Tform == "Mom")
                                    {
                                        icon.Effect = glowMom;
                                        icon.Tag2 = "Mom";
                                    }
                                    else if (item.Tform == "Bob")
                                    {
                                        icon.Effect = glowBob;
                                        icon.Tag2 = "Bob";
                                    }
                                    else if (item.Tform == "Shrooms")
                                    {
                                        icon.Effect = glowShrooms;
                                        icon.Tag2 = "Shrooms";
                                    }
                                    else if (item.Tform == "Cthulhu")
                                    {
                                        icon.Effect = glowCthulhu;
                                        icon.Tag2 = "Cthulhu";
                                    }
                                    else if (item.Tform == "Tumor")
                                    {
                                        icon.Effect = glowTumor;
                                        icon.Tag2 = "Tumor";
                                    }
                                    else if (item.Tform == "Drugs")
                                    {
                                        icon.Effect = glowDrugs;
                                        icon.Tag2 = "Drugs";
                                    }
                                    else if (item.Tform == "Angel")
                                    {
                                        icon.Effect = glowAngel;
                                        icon.Tag2 = "Angel";
                                    }
                                    else if (item.Tform == "Poop")
                                    {
                                        icon.Effect = glowPoop;
                                        icon.Tag2 = "Poop";
                                    }

                                    if (item.Space)
                                    {
                                        icon.Effect = glowActiveItem;
                                        icon.Tag = "space";
                                    }

                                });
                            }
                            else
                            {
                                if (item.Space)
                                {
                                    Application.Current.Dispatcher.Invoke((Action)delegate
                                    {
                                        foreach (var child in itemPanel.Children.OfType<Image>())
                                        {
                                            if ((string)child.Tag == "space")
                                                child.Effect = null;
                                            if (child.Tag2 == "Guppy")
                                                child.Effect = glowGuppy;
                                            else if (child.Tag2 == "FlyLord")
                                                child.Effect = glowFlyLord;
                                            else if (child.Tag2 == "SuperBum")
                                                child.Effect = glowSuperBum;
                                            else if (child.Tag2 == "Mom")
                                                child.Effect = glowMom;
                                            else if (child.Tag2 == "Bob")
                                                child.Effect = glowBob;
                                            else if (child.Tag2 == "Shrooms")
                                                child.Effect = glowShrooms;
                                            else if (child.Tag2 == "Cthulhu")
                                                child.Effect = glowCthulhu;
                                            else if (child.Tag2 == "Tumor")
                                                child.Effect = glowTumor;
                                            else if (child.Tag2 == "Drugs")
                                                child.Effect = glowDrugs;
                                            else if (child.Tag2 == "Angel")
                                                child.Effect = glowAngel;
                                            else if (child.Tag2 == "Poop")
                                                child.Effect = glowPoop;

                                            if (child.Name.Contains(item.Id))
                                            {
                                                child.Effect = glowActiveItem;
                                            }
                                        }
                                    });
                                }
                            }
                        }
                    }
                    else if (line.StartsWith("[INFO] - Game Over"))
                    {
                        runTimer.Stop();
                        runTimer.Enabled = false;

                        run.GameOver = true;

                        Dispatcher.Invoke(new Action(() => txtRIP.Visibility = Visibility.Visible));
                        Dispatcher.Invoke(new Action(() => txtRIP.Foreground = Brushes.DarkRed));
                        Dispatcher.Invoke(new Action(() => txtRIP.Text = "RIP IN PEACE M8"));

                        if (run.PlayerFightingBoss)
                        {
                            run.RunKilledByBoss = run.RunBosses.Last();          //if the player dies while fighting a boss, rip m8
                        }

                        if (run != null)
                        {
                            run.SubmitRunToDB();
                            Database.Backup();
                        }

                    }
                    else if (line.StartsWith("[INFO] - playing cutscene"))
                    {
                        if (line.StartsWith("[INFO] - playing cutscene 1 (Intro).")) //don't match the intro cutscene that plays on every launch
                        {
                            ; ;
                        }
                        else
                        {
                            runTimer.Stop();
                            runTimer.Enabled = false;

                            run.Victory = true;

                            if (run.PlayerFightingBoss)
                            {
                                run.RunBosses.Last().KilledByPlayer = true;
                            }
                            Dispatcher.Invoke(new Action(() => txtRIP.Visibility = Visibility.Visible));
                            Dispatcher.Invoke(new Action(() => txtRIP.Foreground = Brushes.Goldenrod));
                            Dispatcher.Invoke(new Action(() => txtRIP.Text = "VICTORY :D"));

                            if (run != null)
                            {
                                run.SubmitRunToDB();
                                Database.Backup();
                            }
                        }
                    }
                    else if (Regex.Match(line, (@"Room \d\.\d{4}")).Success) //regex boss room
                    {
                        var derp = Regex.Match(line, @"\(([^(()]+)[^ ]").Groups[1].Value.TrimEnd(' ');            //regex result tester
                        var boss = Bosses.GetBossFromName(derp);                                    //if miniboss, var boss will remain null

                        if (boss != null)           //safety net, boss name may be triggered by miniboss fight
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

                                    run.PlayerFightingBoss = true;
                                }
                            });
                        }
                    }
                    else if (line.StartsWith("[INFO] - deathspawn_boss") || line.StartsWith("[INFO] - TriggerBossDeath")) //boss died
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            if (run.PlayerFightingBoss)         //check if a bossfight is in progress, event may fire when defeating a miniboss or sth
                            {
                                run.RunBosses.Last().KilledByPlayer = true;         //if the boss dies while fighting the player, good job!

                                Image icon = new Image();
                                icon.Width = bossPanel.Children[bossPanel.Children.Count - 1].RenderSize.Width;
                                icon.Height = bossPanel.Children[bossPanel.Children.Count - 1].RenderSize.Height;
                                icon.ToolTip = run.RunBosses.Last().Name + " - Defeated";
                                icon.Stretch = Stretch.Uniform;

                                icon.Source = Stuff.BitmapToImageSource(Properties.Resources.BossDefeated);
                                bossDefeatedPanel.Children.Add(icon);
                            }

                            run.PlayerFightingBoss = false;
                        });
                    }
                    if (line != null)
                    {
                        if (line.StartsWith("[INFO] - Total entity spawn time"))
                        {
                            runTimer.Stop();
                        }
                        else
                        {
                            runTimer.Start();
                        }
                    }
                }
            }
            else
            {
                Dispatcher.Invoke(new Action(() => txtIsRunning.Foreground = Brushes.DarkRed));
                Dispatcher.Invoke(new Action(() => txtIsRunning.Text = "GAME IS NOT RUNNING"));
            }
        }

        private void RunTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (run != null)
            {
                run.Time = run.Time.Add(TimeSpan.FromSeconds(1));
                Dispatcher.Invoke(new Action(() => txtTime.Text = "TIME: " + run.Time.ToString(@"hh\:mm\:ss")));

                if (run.Time < TimeSpan.FromMinutes(20))                         //bossrush
                {
                    Dispatcher.Invoke(new Action(() => txtTime.Effect = glowCthulhu));
                }
                else if (run.Time < TimeSpan.FromMinutes(30))                   //hush
                {
                    Dispatcher.Invoke(new Action(() => txtTime.Effect = glowFlyLord));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() => txtTime.Effect = null));
                }
            }
        }

        private void GlowStuff()
        {
            glowActiveItem = new DropShadowEffect();
            glowGuppy = new DropShadowEffect();
            glowFlyLord = new DropShadowEffect();   //new
            glowSuperBum = new DropShadowEffect();
            glowMom = new DropShadowEffect();
            glowBob = new DropShadowEffect();
            glowShrooms = new DropShadowEffect();
            glowCthulhu = new DropShadowEffect();
            glowTumor = new DropShadowEffect();
            glowDrugs = new DropShadowEffect();
            glowAngel = new DropShadowEffect();
            glowPoop = new DropShadowEffect();

            glowActiveItem.ShadowDepth = 0;
            glowGuppy.ShadowDepth = 0;
            glowFlyLord.ShadowDepth = 0;
            glowSuperBum.ShadowDepth = 0;       //new
            glowMom.ShadowDepth = 0;
            glowBob.ShadowDepth = 0;
            glowShrooms.ShadowDepth = 0;
            glowCthulhu.ShadowDepth = 0;
            glowTumor.ShadowDepth = 0;
            glowDrugs.ShadowDepth = 0;
            glowAngel.ShadowDepth = 0;
            glowPoop.ShadowDepth = 0;

            glowActiveItem.BlurRadius = 15;
            glowGuppy.BlurRadius = 15;
            glowFlyLord.BlurRadius = 15;
            glowSuperBum.BlurRadius = 15;      //new
            glowMom.BlurRadius = 15;
            glowBob.BlurRadius = 15;
            glowShrooms.BlurRadius = 15;
            glowCthulhu.BlurRadius = 15;
            glowTumor.BlurRadius = 15;
            glowDrugs.BlurRadius = 15;
            glowAngel.BlurRadius = 15;
            glowPoop.BlurRadius = 15;

            glowActiveItem.Color = Colors.Aqua;
            glowGuppy.Color = Colors.Black;
            glowFlyLord.Color = Colors.Blue;
            glowSuperBum.Color = Colors.Yellow; //new 
            glowMom.Color = Colors.DeepPink;
            glowBob.Color = Colors.Green;
            glowShrooms.Color = Colors.Orange;
            glowCthulhu.Color = Colors.Red;
            glowTumor.Color = Colors.MediumSpringGreen;
            glowDrugs.Color = Colors.DeepSkyBlue;
            glowAngel.Color = Colors.Gold;
            glowPoop.Color = Colors.Brown;

            Label activeItem = new Label();
            activeItem.Content = "Active item";
            activeItem.Effect = glowActiveItem;
            Label guppy = new Label();
            guppy.Effect = glowGuppy;
            guppy.Content = "Guppy";
            Label flyLord = new Label();
            flyLord.Effect = glowFlyLord;
            flyLord.Content = "Lord of the Flies";
            Label superBum = new Label();
            superBum.Effect = glowSuperBum;
            superBum.Content = "Super Bum";
            Label mom = new Label();
            mom.Effect = glowMom;
            mom.Content = "Mom";
            Label bob = new Label();
            bob.Effect = glowBob;
            bob.Content = "Bob";
            Label shrooms = new Label();
            shrooms.Effect = glowShrooms;
            shrooms.Content = "Mushroom";
            Label cthulhu = new Label();
            cthulhu.Effect = glowCthulhu;
            cthulhu.Content = "Evil Angel";
            Label tumor = new Label();
            tumor.Effect = glowTumor;
            tumor.Content = "Tumor";
            Label angel = new Label();
            angel.Effect = glowAngel;
            angel.Content = "Angel";
            Label drugs = new Label();
            drugs.Effect = glowDrugs;
            drugs.Content = "Drugs";
            Label poop = new Label();
            poop.Effect = glowPoop;
            poop.Content = "Poop";

            txtHelp.Children.Add(activeItem);
            txtHelp.Children.Add(guppy);
            txtHelp.Children.Add(flyLord);
            txtHelp.Children.Add(superBum);
            txtHelp.Children.Add(mom);
            txtHelp.Children.Add(bob);
            txtHelp.Children.Add(shrooms);
            txtHelp.Children.Add(cthulhu);
            txtHelp.Children.Add(tumor);
            txtHelp.Children.Add(angel);
            txtHelp.Children.Add(drugs);
            txtHelp.Children.Add(poop);
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

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            txtHelp.Visibility = Visibility.Hidden;
        }
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            txtHelp.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
