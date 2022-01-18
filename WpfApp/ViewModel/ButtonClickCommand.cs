using System;
using System.Windows.Input;

namespace WpfApp.ViewModel
{
    public class ButtonClickCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<object, bool> _canExecute;
        
        public ButtonClickCommand(Action execute, Func<object, bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }
        
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute();
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}