using BigDaddy.Core;
using System.ComponentModel;
using System.Windows;

namespace BigDaddy
{
    public partial class MainWindow : Window
    {
        internal DataGridViewModel TableModel { get; set; }

        internal MainStatusBarViewModel StatusBarModel { get; set; }

        internal DataTableLoadingController DataTableLoadingController { get; set; }

        internal MainWindow()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new MainWindowDesignModel();
            }
            else
            {
                DataContext = new MainWindowViewModel();
            }

            InitTableViewModel();
            InitStatusBarViewModel();

            DataTableLoadingController = new DataTableLoadingController();
        }

        public void InitTableViewModel()
        {
            if (TableModel != null)
            {
                return;
            }

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                TableModel = new DataGridDesignModel();
            }
            else
            {
                TableModel = new DataGridViewModel();
            }
        }

        public void InitStatusBarViewModel()
        {
            if (StatusBarModel != null)
            {
                return;
            }

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                StatusBarModel = new MainStatusBarDesignModel();
            }
            else
            {
                StatusBarModel = new MainStatusBarViewModel();
            }
        }
    }
}
