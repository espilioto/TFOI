using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TFOIBeta.menus
{
    /// <summary>
    /// Interaction logic for PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();   
        }

        #region main menu stuff
        private void exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.Close();
        }
        private void exit_MouseEnter(object sender, MouseEventArgs e)
        {
            exit_.Visibility = Visibility.Visible;
        }
        private void exit_MouseLeave(object sender, MouseEventArgs e)
        {
            exit_.Visibility = Visibility.Hidden;
        }
        private void newrun_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.mainWindowFrame.NavigationService.Navigate(new menus.PageNewRun());
        }
        private void newrun_MouseEnter(object sender, MouseEventArgs e)
        {
            newrun_.Visibility = Visibility.Visible;
        }
        private void newrun_MouseLeave(object sender, MouseEventArgs e)
        {
            newrun_.Visibility = Visibility.Hidden;
        }
        private void runs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.mainWindowFrame.NavigationService.Navigate(new menus.PageRuns());
        }
        private void runs_MouseEnter(object sender, MouseEventArgs e)
        {
            runs_.Visibility = Visibility.Visible;
        }
        private void runs_MouseLeave(object sender, MouseEventArgs e)
        {
            runs_.Visibility = Visibility.Hidden;
        }
        private void chars_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.mainWindowFrame.NavigationService.Navigate(new menus.PageChars());
        }
        private void chars_MouseEnter(object sender, MouseEventArgs e)
        {
            chars_.Visibility = Visibility.Visible;
        }
        private void chars_MouseLeave(object sender, MouseEventArgs e)
        {
            chars_.Visibility = Visibility.Hidden;
        }
        private void items_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.mainWindowFrame.NavigationService.Navigate(new menus.PageItems());
        }
        private void items_MouseEnter(object sender, MouseEventArgs e)
        {
            items_.Visibility = Visibility.Visible;
        }
        private void items_MouseLeave(object sender, MouseEventArgs e)
        {
            items_.Visibility = Visibility.Hidden;
        }
        private void bosses_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.mainWindowFrame.NavigationService.Navigate(new menus.PageBosses());
        }
        private void bosses_MouseEnter(object sender, MouseEventArgs e)
        {
            bosses_.Visibility = Visibility.Visible;
        }
        private void bosses_MouseLeave(object sender, MouseEventArgs e)
        {
            bosses_.Visibility = Visibility.Hidden;
        }
        private void options_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.mainWindowFrame.NavigationService.Navigate(new menus.PageOptions());
        }
        private void options_MouseEnter(object sender, MouseEventArgs e)
        {
            options_.Visibility = Visibility.Visible;
        }
        private void options_MouseLeave(object sender, MouseEventArgs e)
        {
            options_.Visibility = Visibility.Hidden;
        }
        #endregion
    }
}
