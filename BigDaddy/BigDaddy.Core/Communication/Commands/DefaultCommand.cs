using System;
using System.Windows.Input;

namespace BigDaddy.Core
{
    internal class DefaultCommand : ICommand
    {
        private readonly Action mAction;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public DefaultCommand(Action action)
        {
            mAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
