using System;
using System.Windows.Input;

namespace TextChecker.CommandsBase
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _action;
        private readonly Predicate<T> _canExecute;

        public event EventHandler CanExecuteChanged = (s, e) => { };

        public RelayCommand(Action<T> action)
        {
            _action = action;
        }

        public RelayCommand(Action<T> action, Predicate<T> canExecute) : this(action)
        {
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_canExecute((T)parameter))
            {
                _action((T)parameter);
            }
        }
    }
}
