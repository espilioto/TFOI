using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Media.Effects;
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

        DropShadowEffect glowSelected;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            glowSelected = new DropShadowEffect();
            glowSelected.ShadowDepth = 0;
            glowSelected.BlurRadius = 15;
            glowSelected.Color = Colors.Red;

            foreach (var item in Items.List)
            {
                var icon = new Image();
                icon.Name = "_" + item.Id;
                icon.ObjectName = item.Name;
                icon.ObjectDescription = item.Text;
                icon.ObjectMisc = item.DetailsString;
                icon.Stretch = Stretch.None;
                icon.Source = Stuff.BitmapToImageSource(item.Icon);

                itemPanel.Children.Add(icon);
                icon.MouseLeftButtonDown += new MouseButtonEventHandler(icon_MouseLeftButtonDown);
            }
        }

        private void icon_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            string s = string.Empty;
            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

            Image image = sender as Image;
            textItemName.Text = image.ObjectName.ToUpper();
            textItemDescription.Text = image.ObjectDescription.ToUpper();
            textItemStats.Text = image.ObjectMisc;

            Database.SelectItem(dataGrid, image.Name.TrimStart('_'));


            //todo fix font 
            foreach (DataRow run in Database.dataTable.Rows)
            {

            }

            foreach (Image item in itemPanel.Children)
                item.Effect = null;
            image.Effect = glowSelected;
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
