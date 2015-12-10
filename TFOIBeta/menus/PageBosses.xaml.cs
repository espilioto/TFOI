using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for PageBosses.xaml
    /// </summary>
    public partial class PageBosses : Page
    {
        public PageBosses()
        {
            InitializeComponent();
        }

        string selectedBoss;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var boss in Bosses.List)
            {
                var icon = new Image();
                icon.ToolTip = boss.Name + Environment.NewLine + boss.Text;
                icon.Name = "_" + boss.Id;
                icon.Tag = "HP: " + boss.HP;
                icon.Stretch = Stretch.None;
                icon.Source = Stuff.BitmapToImageSource(boss.Icon);

                bossPanel.Children.Add(icon);
                icon.MouseLeftButtonDown += new MouseButtonEventHandler(icon_MouseLeftButtonDown);
            }

            PopulateStats();        //query the db every time to refresh the stats
        }

        private void icon_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            int timesDefeatedByBoss = 0;

            System.Windows.Controls.Image image = sender as System.Windows.Controls.Image;      //boss logo stuff
            textBossInfo.Text = image.Tag.ToString();
            bossNameLogo.Source = Stuff.BitmapToImageSource(Bosses.List.Find(x => x.Id == image.Name.TrimStart('_')).NameLogo);

            selectedBoss = image.Name.TrimStart('_');                               //get the boss id
            Database.SelectBoss(dataGrid, selectedBoss);                            //and run the query with it

            if (Database.dataTable.Rows.Count == 1)
                timesFought.Text = "FOUGHT " + Database.dataTable.Rows.Count.ToString() + " TIME";
            else
                timesFought.Text = "FOUGHT " + Database.dataTable.Rows.Count.ToString() + " TIMES";

            foreach (DataRow value in Database.dataTable2.Rows)                     ////////// THIS IS THE UTILITY DATATABLE ////////// 
            {
                if (value != null)                                                      //shit happens
                    if (!string.IsNullOrEmpty((string)value.ItemArray[6]))              //KilledBy
                        if ((string)value.ItemArray[6] == selectedBoss)                 //defeated by the selected boss in that run?
                            timesDefeatedByBoss++;
            }

            if (timesDefeatedByBoss == 0 && Database.dataTable.Rows.Count > 0)
                winRate.Text = "100% WINRATE!";
            else if (Database.dataTable.Rows.Count == 0)
                winRate.Text = string.Empty;
            else
                winRate.Text = (((float)(Database.dataTable.Rows.Count - timesDefeatedByBoss) / Database.dataTable.Rows.Count) * 100).ToString("0") + "% WIN RATE"; //(encounters-defeats=wins)/encounters=win rate
        }

        private void PopulateStats()
        {
            string s = string.Empty;
            string bossListDefeated = string.Empty;
            string bossListNemeses = string.Empty;
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

            Database.SelectAll();

            foreach (DataRow value in Database.dataTable.Rows)
            {
                if (!string.IsNullOrEmpty((string)value.ItemArray[6]))          //bosses
                    s += (string)value.ItemArray[5] + ',';
            }

        }

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
    }
}
