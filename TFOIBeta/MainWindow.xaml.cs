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

            mainWindowFrame.Navigate(new menus.PageMain());

            Items.ParseJsonItemList();
            Bosses.ParseJsonBossList();
            Characters.ParseJsonCharList();
            
            
            var player = new Player();
        }

        #region main menu stuff
        private void exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void exit_MouseEnter(object sender, MouseEventArgs e)
        {
            exit_.Visibility = Visibility.Visible;
        }
        private void exit_MouseLeave(object sender, MouseEventArgs e)
        {
            exit_.Visibility = Visibility.Hidden;
        }
        private void newrun_MouseEnter(object sender, MouseEventArgs e)
        {
            newrun_.Visibility = Visibility.Visible;
        }
        private void newrun_MouseLeave(object sender, MouseEventArgs e)
        {
            newrun_.Visibility = Visibility.Hidden;
        }
        private void runs_MouseEnter(object sender, MouseEventArgs e)
        {
            runs_.Visibility = Visibility.Visible;
        }
        private void runs_MouseLeave(object sender, MouseEventArgs e)
        {
            runs_.Visibility = Visibility.Hidden;
        }
        private void chars_MouseEnter(object sender, MouseEventArgs e)
        {
            chars_.Visibility = Visibility.Visible;
        }
        private void chars_MouseLeave(object sender, MouseEventArgs e)
        {
            chars_.Visibility = Visibility.Hidden;
        }
        private void items_MouseEnter(object sender, MouseEventArgs e)
        {
            items_.Visibility = Visibility.Visible;
        }
        private void items_MouseLeave(object sender, MouseEventArgs e)
        {
            items_.Visibility = Visibility.Hidden;
        }
        private void bosses_MouseEnter(object sender, MouseEventArgs e)
        {
            bosses_.Visibility = Visibility.Visible;
        }
        private void bosses_MouseLeave(object sender, MouseEventArgs e)
        {
            bosses_.Visibility = Visibility.Hidden;
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
