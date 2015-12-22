using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// Interaction logic for PageRuns.xaml
    /// </summary>
    public partial class PageRuns : Page
    {
        public PageRuns()
        {
            InitializeComponent();
        }

        DropShadowEffect glowSelected;
        string selectedRunId = string.Empty;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            glowSelected = new DropShadowEffect();
            glowSelected.ShadowDepth = 0;
            glowSelected.BlurRadius = 15;
            glowSelected.Color = Colors.Red;

            Database.SelectAll(dataGrid);
            Database.DeserializeRunsFromDB();

            totalRuns.Text = "Total runs: " + Database.dataTable.Rows.Count.ToString();

            dataGrid.SelectedIndex = 0;
        }

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    System.Data.DataRowView selectedFile = (System.Data.DataRowView)dataGrid.SelectedItems[i];
                    selectedRunId = selectedFile.Row.ItemArray[0].ToString();

                    recreateArchivedRun(selectedRunId);
                }
        }

        private void recreateArchivedRun(string entryId)
        {
            selectedRunFloors.Children.Clear();
            selectedRunItems.Children.Clear();
            selectedRunBosses.Children.Clear();

            ArchivedRun run = Database.ArchivedRuns.Find(asd => asd.Id == entryId);

            selectedRunSeed.Text = run.Seed;
            selectedRunTime.Text = run.Time;

            if (run.Result == "Victory")
                selectedRunResult.Foreground = Brushes.Gold;
            else
                selectedRunResult.Foreground = Brushes.DarkRed;

            selectedRunResult.Text = run.Result;

            selectedRunCharIcon.ToolTip = run.Character.Name;
            selectedRunCharIcon.Source = Stuff.BitmapToImageSource(run.Character.Icon);

            foreach (var floor in run.Floors)
            {
                if (floor != null)      //gotta check because an old TFOI version entry without floors might exist in the db
                {
                    var icon = new Image();

                    if (!string.IsNullOrEmpty(floor.Curse))
                        icon.ToolTip = floor.Name + Environment.NewLine + floor.Curse;
                    else
                        icon.ToolTip = floor.Name;

                    icon.Height = 35;
                    icon.Stretch = Stretch.Uniform;
                    icon.Source = Stuff.BitmapToImageSource(floor.Icon);

                    selectedRunFloors.Children.Add(icon);
                }
            }
            foreach (var item in run.Items)
            {
                if (item != null)
                {
                    var icon = new Image();
                    icon.ToolTip = item.Name + Environment.NewLine + item.Text;
                    icon.Stretch = Stretch.None;
                    icon.Source = Stuff.BitmapToImageSource(item.Icon);

                    selectedRunItems.Children.Add(icon);
                }
            }
            foreach (var boss in run.Bosses)
            {
                if (boss != null)
                {
                    var icon = new Image();
                    icon.ToolTip = boss.Name;
                    icon.Stretch = Stretch.None;
                    icon.Source = Stuff.BitmapToImageSource(boss.Icon);

                    selectedRunBosses.Children.Add(icon);
                }
            }


        }

        #region button stuff
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
        private void btnDeleteRun_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this run entry?", "You want me to die?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Database.DeleteRun(selectedRunId);      //delete the run
                Database.SelectAll(dataGrid);           //refresh the grid

                selectedRunFloors.Children.Clear();     //flush the ui
                selectedRunItems.Children.Clear();
                selectedRunBosses.Children.Clear();
                selectedRunCharIcon.Source = null;

                Database.Backup();
            }

        }
        private void btnDeleteRun_MouseEnter(object sender, MouseEventArgs e)
        {
            btnDeleteRun.Effect = glowSelected;
        }
        private void btnDeleteRun_MouseLeave(object sender, MouseEventArgs e)
        {
            btnDeleteRun.Effect = null;
        }
        #endregion
    }
}
