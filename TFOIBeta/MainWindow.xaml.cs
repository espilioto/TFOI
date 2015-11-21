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
using System.IO;
using System.Drawing;
using System.Reflection;
using Microsoft.CSharp.RuntimeBinder;

namespace TFOIBeta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static MainWindow mainWindow;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainWindow = this;
            mainWindowFrame.NavigationService.Navigate(new menus.PageMain());

            Database.CreateFloorsColumn();      // create a Floors column in the database if it doesn't exist.

            Items.ParseJsonItemList();
            Bosses.ParseJsonBossList();
            Characters.ParseJsonCharList();
            Floors.ParseJsonFloorList();
        }

        


    }
}
