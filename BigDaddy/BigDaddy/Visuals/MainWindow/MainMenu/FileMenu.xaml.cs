using BigDaddy.Core;
using System.ComponentModel;
using System.Windows.Controls;

namespace BigDaddy
{
    public partial class FileMenu : MenuItem
    {
        internal FileMenu()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new FileMenuDesignModel();
            }
            else
            {
                DataContext = new FileMenuViewModel();
            }
        }
    }
}
