using PropertyChanged;
using System.ComponentModel;

namespace BigDaddy.Core
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
