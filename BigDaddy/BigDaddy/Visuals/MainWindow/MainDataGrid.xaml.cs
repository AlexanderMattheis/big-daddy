using BigDaddy.Core;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace BigDaddy
{
    public partial class MainDataGrid : DataGrid
    {
        private DataTableClipboardController tableClipboardController;

        private ControlTemplate defaultRowControlTemplate;
        private ControlTemplate loadRowsControlTemplate;

        internal MainDataGrid()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new CombinedDataGridModel()
                {
                    MainGridModel = new MainDataGridDesignModel(),
                    GridModel = new DataGridDesignModel()
                };
            }
            else
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.InitTableViewModel();

                DataContext = new CombinedDataGridModel()
                {
                    MainGridModel = new MainDataGridViewModel(),
                    GridModel = mainWindow.TableModel
                };
            }

            tableClipboardController = new DataTableClipboardController();
        }

        private void CopyRowMenuItem_Click(object sender, RoutedEventArgs e)
        {
            tableClipboardController.CopyRows(MainGrid.SelectedItems);
        }

        private void CutRowMenuItem_Click(object sender, RoutedEventArgs e)
        {
            tableClipboardController.CutRows(MainGrid.SelectedItems);
        }

        private void PasteBeforeRowMenuItem_Click(object sender, RoutedEventArgs e)
        {
            tableClipboardController.PasteRows(MainGrid.SelectedIndex, ((CombinedDataGridModel)DataContext).GridModel);
        }

        private void PasteAfterRowMenuItem_Click(object sender, RoutedEventArgs e)
        {
            tableClipboardController.PasteRows(MainGrid.SelectedIndex + 1, ((CombinedDataGridModel)DataContext).GridModel);
        }

        private void MainGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (defaultRowControlTemplate == null)
            {
                defaultRowControlTemplate = e.Row.Template;
            }

            if (loadRowsControlTemplate == null)
            {
                loadRowsControlTemplate = FindResource("LoadRows_ControlTemplate") as ControlTemplate;
            }

            if (e.Row.Item == CollectionView.NewItemPlaceholder)
            {
                e.Row.Template = loadRowsControlTemplate;
                e.Row.UpdateLayout();
            }
        }

        private void MainGrid_UnloadingRow(object sender, DataGridRowEventArgs e)
        {
            if (e.Row.Item == CollectionView.NewItemPlaceholder && e.Row.Template != defaultRowControlTemplate)
            {
                e.Row.Template = defaultRowControlTemplate;
                e.Row.UpdateLayout();
            }
        }

        private void MainGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            IEditableCollectionView iecv = CollectionViewSource.GetDefaultView((sender as DataGrid).ItemsSource) as IEditableCollectionView;

            if (iecv.IsAddingNew)
            {
                Dispatcher.Invoke(new DispatcherOperationCallback(ResetNewItemTemplate), DispatcherPriority.ApplicationIdle, MainGrid);
            }
        }

        private object ResetNewItemTemplate(object arg)
        {
            DataGridRow row = DataGridHelper.GetRow(MainGrid, MainGrid.Items.Count - 1);

            if (row.Template != loadRowsControlTemplate)
            {
                row.Template = loadRowsControlTemplate;
                row.UpdateLayout();
            }

            return null;
        }

        private void LastRow_LoadMore(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            if (row.Item == CollectionView.NewItemPlaceholder && row.Template == loadRowsControlTemplate)
            {
                var dataTableLoadingController = ((MainWindow)Application.Current.MainWindow).DataTableLoadingController;
                dataTableLoadingController.OpenLastFile(Config.Get<int>("MainDataGrid.LoadingMoreNumber"));
            }
        }

        public class CombinedDataGridModel
        {
            public MainDataGridViewModel MainGridModel { get; set; }
            public DataGridViewModel GridModel { get; set; }
        }
    }
}
