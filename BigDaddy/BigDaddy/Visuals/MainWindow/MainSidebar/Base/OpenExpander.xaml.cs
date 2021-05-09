using BigDaddy.Core;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BigDaddy
{
    public partial class OpenExpander : Expander
    {
        internal OpenExpander()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new OpenExpanderDesignModel();
            }
            else
            {
                DataContext = new OpenExpanderViewModel();
            }
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            OpenExpanderViewModel viewModel = (OpenExpanderViewModel) DataContext;
            var dataTableLoadingController = ((MainWindow)Application.Current.MainWindow).DataTableLoadingController;

            if (viewModel.IsImporting)
            {
                dataTableLoadingController.Cancel();
            }
            else
            {
                dataTableLoadingController.StartOpenFileDialog(viewModel);
            }
        }

        private void ReimportButton_Click(object sender, RoutedEventArgs e)
        {
            var dataTableLoadingController = ((MainWindow)Application.Current.MainWindow).DataTableLoadingController;
            dataTableLoadingController.OpenLastFile(null);
        }
    }
}
