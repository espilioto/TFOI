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

namespace TFOI.menus
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

            PopulateTop20();
        }

        private void PopulateTop20()
        {
            string itemList = string.Empty;

            Database.SelectAll();

            foreach (DataRow run in Database.dataTable2.Rows)
            {
                if (!string.IsNullOrEmpty((string)run.ItemArray[4]))          //items
                    itemList += (string)run.ItemArray[4] + ',';
            }

            var top30ItemList = Stuff.SortTopItems(itemList, 30);
            foreach (var item in top30ItemList)
            {
                var icon = new Image();
                icon.Stretch = Stretch.None;
                icon.ToolTip = item.Name + Environment.NewLine + item.Text + Environment.NewLine + "Times collected: " + item.TimesCollected.ToString();
                icon.Source = Stuff.BitmapToImageSource(item.Icon);
                top30ItemsPanel.Children.Add(icon);
            }
        }

        private void icon_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            float winrate = 0;

            Image image = sender as Image;
            textItemName.Text = image.ObjectName.ToUpper();
            textItemDescription.Text = image.ObjectDescription.ToUpper();
            textItemDetails.Text = image.ObjectMisc;

            Database.SelectItem(dataGrid, image.Name.TrimStart('_'));

            foreach (DataRow run in Database.dataTable.Rows)
            {
                if ((string)run.ItemArray[8] == "VICTORY")                    //win %
                    winrate++;
            }

            itemStats.Text = "TIMES FOUND: " + Database.dataTable.Rows.Count + " WIN: " + ((winrate / Database.dataTable.Rows.Count) * 100).ToString() + "% ";

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
