using BigDaddy.Core;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace BigDaddy
{
    public partial class MainStatusBar : StatusBar
    {
        internal MainStatusBar()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new MainStatusBarDesignModel();
            }
            else
            {
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.InitStatusBarViewModel();

                DataContext = mainWindow.StatusBarModel;
            }
        }
    }
}
