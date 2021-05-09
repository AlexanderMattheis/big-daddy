using BigDaddy.Core;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BigDaddy
{
    public partial class BaseTab : TabItem
    {
        private DataTableLoadingController baseDialogController;

        internal BaseTab()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new BaseTabDesignModel();
            }
            else
            {
                DataContext = new BaseTabViewModel();
            }

            baseDialogController = new DataTableLoadingController();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SaveAsButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
