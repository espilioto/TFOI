using System;
using System.Collections.Generic;
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
                var icon = new System.Windows.Controls.Image();
                icon.ToolTip = boss.Name + Environment.NewLine + boss.Text; ;
                icon.Tag = "HP: " + boss.HP;
                icon.Stretch = Stretch.None;
                icon.Source = Stuff.BitmapToImageSource(boss.Icon);


                bossPanel.Children.Add(icon);
                icon.MouseLeftButtonDown += new MouseButtonEventHandler(icon_MouseLeftButtonDown);
            }
        }

        private void icon_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Image image = sender as System.Windows.Controls.Image;
            textBossInfo.Text = image.Tag.ToString();
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
