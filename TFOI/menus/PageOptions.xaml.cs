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
using System.Windows.Media.Effects;
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
        DropShadowEffect glowSelected;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            glowSelected = new DropShadowEffect();
            glowSelected.ShadowDepth = 0;
            glowSelected.BlurRadius = 15;
            glowSelected.Color = Colors.Red;

            this.DataContext = this;

            BackupEnabled = Properties.Settings.Default.backupEnabled;
            backupPath.Text = Properties.Settings.Default.backupPath;

            backupPath.IsEnabled = BackupEnabled;
            btnBrowse.IsEnabled = BackupEnabled;

            slider.Value = Properties.Settings.Default.timerRefreshSpeed;
            txtSaved.Visibility = Visibility.Hidden;
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowseDialog = new FolderBrowserDialog();
            folderBrowseDialog.RootFolder = Environment.SpecialFolder.Desktop;

            if (folderBrowseDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.backupPath = folderBrowseDialog.SelectedPath + "\\isaac.db";
            }
            backupPath.Text = Properties.Settings.Default.backupPath;
            Properties.Settings.Default.Save();
        }

        private void backupEnabled_Changed(object sender, RoutedEventArgs e)
        {
            if (BackupEnabled)
            {
                backupPath.IsEnabled = true;
                btnBrowse.IsEnabled = true;

                Properties.Settings.Default.backupEnabled = true;
            }
            else
            {
                backupPath.IsEnabled = false;
                btnBrowse.IsEnabled = false;

                Properties.Settings.Default.backupEnabled = false;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.timerRefreshSpeed = slider.Value;
            Properties.Settings.Default.Save();

            txtSaved.Visibility = Visibility.Visible;
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
        private void btnSave_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnSave.Effect = glowSelected;
        }
        private void btnSave_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnSave.Effect = null;
        }
        private void btnBrowse_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnBrowse.Effect = glowSelected;
        }
        private void btnBrowse_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnBrowse.Effect = null;
        }
    }
}
