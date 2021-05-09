using System.Windows;
using System.Windows.Controls;

namespace BigDaddy
{
    public partial class LoadingButton : Button
    {
        public LoadingButton()
        {
            IsEnabledProperty.OverrideMetadata(typeof(LoadingButton),
            new FrameworkPropertyMetadata(true,
                new PropertyChangedCallback(IsEnabledPropertyChanged),
                new CoerceValueCallback(CoerceIsEnabled)));

            InitializeComponent();
        }

        private static void IsEnabledPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs args) { }

        private static object CoerceIsEnabled(DependencyObject source, object value)
        {
            return value;
        }
    }
}
