using BigDaddy.Core;
using System.ComponentModel;
using System.Windows.Controls;

namespace BigDaddy
{
    public partial class EditMenu : MenuItem
    {
        internal EditMenu()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new EditMenuDesignModel();
            }
            else
            {
                DataContext = new EditMenuViewModel();
            }
        }
    }
}
