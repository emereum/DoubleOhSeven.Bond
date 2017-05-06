using System;
using System.Windows.Input;

namespace DoubleOhSeven
{
    internal class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action action;

        public Command(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => action.Invoke();
    }
}
