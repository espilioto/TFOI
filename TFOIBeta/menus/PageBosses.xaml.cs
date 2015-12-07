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

            PopulateStats();
        }

        private void icon_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            string s = string.Empty;
            string bossList = string.Empty;

            //var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

            System.Windows.Controls.Image image = sender as System.Windows.Controls.Image;      //boss logo stuff
            textBossInfo.Text = image.Tag.ToString();
            bossNameLogo.Source = Stuff.BitmapToImageSource(Bosses.List.Find(x => x.Id == image.Name.TrimStart('_')).NameLogo);

            //words.Clear();

            Database.SelectBoss(dataGrid, image.Name.TrimStart('_'));

            if (Database.dataTable.Rows.Count == 1)
                timesFought.Text = "FOUGHT " + Database.dataTable.Rows.Count.ToString() + " TIME";
            else
                timesFought.Text = "FOUGHT " + Database.dataTable.Rows.Count.ToString() + " TIMES";
        }

        private void PopulateStats()
        {
            float winrate = 0;
            string bossListDefeated = string.Empty;
            string bossListNemeses = string.Empty;

            Database.SelectAll();

            foreach (DataRow value in Database.dataTable.Rows)  //TODO calculate win% and top5
            {

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
