using System;
using System.Windows.Input;

namespace GCProject.Commands
{
    public class RelayCommand : ICommand
    {
        //private Predicate<object> _canExecute;
        private Action _execute;

        public RelayCommand(Action execute)
        {
            //this._canExecute = canExecute;
            this._execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            // always execute i dont care \0/
            return true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
