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

namespace TFOIBeta.menus
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
        string line = "";

        Timer timer = new Timer(100);

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

            timer.Elapsed += ReadLog;
            timer.Enabled = true;
            timer.Start();
        }


        private void ReadLog(object sender, ElapsedEventArgs e)
        {
            if (true)
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
                        Dispatcher.Invoke(new Action(() => bossDefeatedPanel.Children.Clear()));
                        Dispatcher.Invoke(new Action(() => txtTime.Text = "TIME:"));
                        Dispatcher.Invoke(new Action(() => txtCurse.Text = ""));

                        Dispatcher.Invoke(new Action(() => txtRIP.Visibility = Visibility.Hidden));

                        Dispatcher.Invoke(new Action(() => run.Seed = Regex.Match(line, @"(\w{4} \w{4}) ").Value)); //regex seed
                        Dispatcher.Invoke(new Action(() => txtSeed.Text = run.Seed));
                    }
                    if (line.StartsWith("Initialized player with"))
                    {
                        var character = Characters.GetCharFromId(Regex.Match(line, @"Subtype (\d)").Groups[1].Value); //regex character ID
                        run.AddCharacter(character);

                        Dispatcher.Invoke(new Action(() => charIcon.ToolTip = character.Name));
                        Dispatcher.Invoke(new Action(() => charIcon.Source = Stuff.BitmapToImageSource(character.Icon)));
                    }
                    if (line.StartsWith("Adding collectible "))
                    {
                        var item = Items.GetItemFromId(Regex.Match(line, @"(\d+)").Groups[1].Value); //regex item id

                        if (item != null)               //can't be too careful
                        {
                            if (run.AddItem(item))
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
                                        icon.Tag = "space";

                                        foreach (var child in itemPanel.Children.OfType<Image>())
                                        {
                                            if ((string)child.Tag == "space")
                                            {
                                                child.Effect = null;
                                            }
                                        }

                                        icon.Effect = glowActiveItem;
                                    }
                                    else if (item.TformGuppy)
                                    {
                                        icon.Effect = glowGuppy;
                                    }
                                    else if (item.TformFlyLord)
                                    {
                                        icon.Effect = glowFlyLord;
                                    }
                                    else if (item.TformSuperBum)        //new
                                    {
                                        icon.Effect = glowSuperBum;
                                    }
                                    else if (item.TformMom)
                                    {
                                        icon.Effect = glowMom;
                                    }
                                    else if (item.TformBob)
                                    {
                                        icon.Effect = glowBob;
                                    }
                                    else if (item.TformShrooms)
                                    {
                                        icon.Effect = glowShrooms;
                                    }
                                    else if (item.TformCthulhu)
                                    {
                                        icon.Effect = glowCthulhu;
                                    }
                                    else if (item.TformTumor)
                                    {
                                        icon.Effect = glowTumor;
                                    }
                                    else if (item.TformDrugs)
                                    {
                                        icon.Effect = glowDrugs;
                                    }
                                    else if (item.TformAngel)
                                    {
                                        icon.Effect = glowAngel;
                                    }
                                    else if (item.TformPoop)
                                    {
                                        icon.Effect = glowPoop;
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
                                            if (child.Effect != null)
                                            {
                                                child.Effect = null;
                                            }
                                        }

                                        foreach (var child in itemPanel.Children.OfType<Image>())
                                        {
                                            if ((child.Name.TrimStart('_') == item.Id))
                                            {
                                                child.Effect = glowActiveItem;
                                            }
                                        }
                                    });
                                }
                            }
                        }
                    }
                    if (line.StartsWith("Game Over"))
                    {
                        run.GameOver = true;

                        Dispatcher.Invoke(new Action(() => txtRIP.Visibility = Visibility.Visible));
                        Dispatcher.Invoke(new Action(() => txtRIP.Foreground = Brushes.DarkRed));
                        Dispatcher.Invoke(new Action(() => txtRIP.Text = "RIP IN PEPPERONNIS M8"));

                        if (run.PlayerFightingBoss)
                        {
                            run.RunKilledByBoss = run.RunBosses.Last();          //if the player dies while fighting a boss, rip m8
                        }

                        if (run != null)
                        {
                            run.SubmitRunToDB();
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
                                run.Dispose();
                            }
                        }
                    }
                    if (line.StartsWith("Level::Init"))
                    {
                        var stage = Regex.Match(line, @"m_Stage (\d+)").Groups[1].Value;            //regex stage id
                        var altStage = Regex.Match(line, @"m_AltStage (\d+)").Groups[1].Value;      //regex alt stage id

                        var floor = Floors.GetFloorFromId(stage, altStage);

                        if (floor != null)
                        {
                            run.AddFloor(floor);
                            Dispatcher.Invoke(new Action(() => txtFloor.Text = floor.Name.ToUpper()));
                        }
                    }
                    if (line.StartsWith("Curse of"))
                    {
                        if (line == "Curse of the Labyrinth!")                                      //if it's an XL floor
                        {
                            run.AddFloor(Floors.ConvertFloorToXL(run.RunFloors.Last()));            //add the equivalent XL floor to the list
                            run.RunFloors[run.RunFloors.Count - 1].Curse = line;                                      //add the curse to the new floor
                            run.RunFloors.RemoveAt(run.RunFloors.Count - 2);                        //and remove the old "regular" one from the list

                            Dispatcher.Invoke(new Action(() => txtFloor.Text = run.RunFloors.Last().Name.ToUpper()));
                        }
                        else
                        {
                            run.RunFloors[run.RunFloors.Count - 1].Curse = line;
                        }

                        Dispatcher.Invoke(new Action(() => txtCurse.Text = run.RunFloors.Last().Curse.ToUpper()));
                    }
                    if (Regex.Match(line, (@"Room \d\.\d{4}")).Success) //regex boss room
                    {
                        var derp = Regex.Match(line, @"\(([^(()]+)[^ ]").Groups[1].Value.TrimEnd(' ');            //regex result tester
                        var boss = Bosses.GetBossFromName(derp);                //if miniboss, var boss will remain null

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
                    if (line.StartsWith("deathspawn_boss") || line.StartsWith("TriggerBossDeath"))
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
                    if (line.StartsWith("Mom clear time"))
                    {
                        var time = float.Parse(Regex.Match(line, @"\d+").Value);           //regex framecounter (30/sec. why not 60? no idea)
                        TimeSpan timeSpan = TimeSpan.FromSeconds(time / 30);                   //get seconds
                        string str = timeSpan.ToString(@"hh\:mm\:ss");

                        run.Time = str;
                        Dispatcher.Invoke(new Action(() => txtTime.Text = "TIME: " + str));

                        if (time < 36000)
                        {
                            Dispatcher.Invoke(new Action(() => txtTime.Effect = glowActiveItem));
                        }
                        else
                        {
                            Dispatcher.Invoke(new Action(() => txtTime.Effect = null));
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

            glowActiveItem.BlurRadius = 10;
            glowGuppy.BlurRadius = 10;
            glowFlyLord.BlurRadius = 10;
            glowSuperBum.BlurRadius = 10;      //new
            glowMom.BlurRadius = 10;
            glowBob.BlurRadius = 10;
            glowShrooms.BlurRadius = 10;
            glowCthulhu.BlurRadius = 10;
            glowTumor.BlurRadius = 10;
            glowDrugs.BlurRadius = 10;
            glowAngel.BlurRadius = 10;
            glowPoop.BlurRadius = 10;

            glowActiveItem.Color = Colors.Red;
            glowGuppy.Color = Colors.Black;
            glowFlyLord.Color = Colors.Blue;
            glowSuperBum.Color = Colors.Yellow; //new
            glowMom.Color = Colors.Pink;
            glowBob.Color = Colors.Green;
            glowShrooms.Color = Colors.Orange;
            glowCthulhu.Color = Colors.Purple;
            glowTumor.Color = Colors.BurlyWood;
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
            cthulhu.Content = "Cthulhu";
            Label tumor = new Label();
            tumor.Effect = glowTumor;
            tumor.Content = "Tumor";
            Label angel = new Label();
            angel.Effect = glowAngel;
            angel.Content = "Angel";
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
