using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagement.ViewModels
{
    public class DelegateCommand : ICommand
    {

        private readonly Action<object> _executionAction;
        private readonly Predicate<object> _canExecutionAction;

        public DelegateCommand(Action<object> executionAction, Predicate<object> canExecutionAction)
        {
            _executionAction = executionAction;
            _canExecutionAction = canExecutionAction;
        }
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<object> executionAction)
        {
            _executionAction = executionAction;
            _canExecutionAction = null ;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecutionAction == null? true : _canExecutionAction(parameter);
        }

        public void Execute(object? parameter)
        {
            _executionAction(parameter);
        }
    }
}
