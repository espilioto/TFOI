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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TFOIBeta.menus
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Database.SelectAll(dataGrid);
            Database.DeserializeRunsFromDB();
        }

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    System.Data.DataRowView selectedFile = (System.Data.DataRowView)dataGrid.SelectedItems[i];
                    recreateArchivedRun(selectedFile.Row.ItemArray[0].ToString());
                }
        }

        private void recreateArchivedRun(string entryId)
        {
            selectedRunBosses.Children.Clear();
            selectedRunItems.Children.Clear();

            ArchivedRun run = Database.ArchivedRuns.Find(asd => asd.Id == entryId);

            selectedRunSeed.Text = run.Seed;
            selectedRunTime.Text = run.Time;

            selectedRunCharIcon.Source = Stuff.BitmapToImageSource(run.Character.Icon);

            foreach (var item in run.Items)
            {
                var icon = new Image();
                icon.ToolTip = item.Name + Environment.NewLine + item.Text;
                icon.Stretch = Stretch.None;
                icon.Source = Stuff.BitmapToImageSource(item.Icon);

                selectedRunItems.Children.Add(icon);
            }
            foreach (var boss in run.Bosses)
            {
                var icon = new Image();
                icon.ToolTip = boss.Name;
                icon.Stretch = Stretch.None;
                icon.Source = Stuff.BitmapToImageSource(boss.Icon);

                selectedRunBosses.Children.Add(icon);
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
