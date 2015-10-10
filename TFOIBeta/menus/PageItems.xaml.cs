using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class PageItems : Page
    {
        public PageItems()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Items.List)
            {
                var icon = new System.Windows.Controls.Image();
                icon.Stretch = Stretch.None;

                icon.ToolTip = item.Name + Environment.NewLine + item.Text; ;
                //Maybe TODO: display rest stats

                icon.Source = Stuff.BitmapToImageSource(item.Icon);
                itemPanel.Children.Add(icon);
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
