using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TFOI.menus
{
    /// <summary>
    /// Interaction logic for PageOptions.xaml
    /// </summary>
    public partial class PageOptions : Page
    {
        public PageOptions()
        {
            InitializeComponent();
        }

        public bool BackupEnabled { get; set; }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;

            BackupEnabled = Properties.Settings.Default.backupEnabled;
            backupPath.Text = Properties.Settings.Default.backupPath;

            backupPath.IsEnabled = BackupEnabled;
            backupBtnBrowse.IsEnabled = BackupEnabled;
        }

        private void backupBtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowseDialog = new FolderBrowserDialog();
            folderBrowseDialog.RootFolder = Environment.SpecialFolder.UserProfile;

            folderBrowseDialog.ShowDialog();

            Properties.Settings.Default.backupPath = folderBrowseDialog.SelectedPath + "\\isaac.db"; 
            backupPath.Text = Properties.Settings.Default.backupPath;
            Properties.Settings.Default.Save();
        }

        private void back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.mainWindowFrame.GoBack();
        }
        private void back_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            back_.Visibility = Visibility.Visible;
        }
        private void back_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            back_.Visibility = Visibility.Hidden;
        }

        private void backupEnabled_Changed(object sender, RoutedEventArgs e)
        {
            if (BackupEnabled)
            {
                backupPath.IsEnabled = true;
                backupBtnBrowse.IsEnabled = true;

                Properties.Settings.Default.backupEnabled = true;
            }
            else
            {
                backupPath.IsEnabled = false;
                backupBtnBrowse.IsEnabled = false;

                Properties.Settings.Default.backupEnabled = false;
            }
        }

    }
}
