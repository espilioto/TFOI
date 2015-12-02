using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    /// Interaction logic for PageChars.xaml
    /// </summary>
    public partial class PageChars : Page
    {
        public PageChars()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var character in Characters.List)
            {
                var icon = new Image();
                icon.ToolTip = character.Name;
                icon.Stretch = Stretch.None;

                icon.Source = Stuff.BitmapToImageSource(character.Icon);
                charPanel.Children.Add(icon);
                icon.MouseLeftButtonDown += Icon_MouseLeftButtonDown;
            }
        }

        private void Icon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            float winrate = 0;
            string s = string.Empty;
            TimeSpan averageRunTime = TimeSpan.Zero;
            List<Items> top10Items = new List<Items>();
            List<Bosses> top10Bosses = new List<Bosses>();

            charStats.Text = string.Empty;

            Image image = sender as Image;
            Database.SelectChar(dataGrid, image.ToolTip.ToString().ToUpper());

            foreach (DataRow value in Database.dataTable.Rows)
            {
                //if (!string.IsNullOrEmpty((string)value.ItemArray[4]))          //items
                //{
                //    s = (string)value.ItemArray[4];

                //    foreach (var item in s.Split(','))
                //    {
                //        top10Items.Add(Items.GetItemFromId(item));
                //    }
                //}

                if (!string.IsNullOrEmpty((string)value.ItemArray[7]))          //run time
                {
                    s = (string)value.ItemArray[7];
                    s.Substring(8);
                    averageRunTime += TimeSpan.ParseExact(s, @"hh\:mm\:ss", CultureInfo.DefaultThreadCurrentUICulture);
                }

                if ((string)value.ItemArray[8] == "VICTORY")                    //win %
                    winrate++;
            }

            if (winrate > 0)
                winrate = Database.dataTable.Rows.Count / winrate;
            if (averageRunTime.Ticks > 0)
                averageRunTime = TimeSpan.FromTicks(averageRunTime.Ticks / Database.dataTable.Rows.Count);

            charStats.Text += "WIN: " + winrate.ToString() + "% ";
            charStats.Text += "AVG RUN DURATION: " + averageRunTime.ToString(@"hh\:mm\:ss");
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
