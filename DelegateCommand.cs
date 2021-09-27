using System;
using System.Windows.Input;

namespace WPFPart11
{
    internal class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public DelegateCommand(Action action, Func<bool> canExecute)
        {
            _execute = action;
            _canExecute = canExecute;
        }
        public DelegateCommand(Action action):this(action,() => true)
        {
            _execute = action;
        }
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute();
        }

        void ICommand.Execute(object parameter)
        {
            _execute();
        }
    }
}