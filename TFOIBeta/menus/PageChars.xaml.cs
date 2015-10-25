﻿using System;
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