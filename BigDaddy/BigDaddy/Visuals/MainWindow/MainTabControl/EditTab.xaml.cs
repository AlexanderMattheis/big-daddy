using BigDaddy.Core;
using System.ComponentModel;
using System.Windows.Controls;

namespace BigDaddy
{
    public partial class EditTab : TabItem
    {
        internal EditTab()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new EditTabDesignModel();
            }
            else
            {
                DataContext = new EditTabViewModel();
            }
        }
    }
}
