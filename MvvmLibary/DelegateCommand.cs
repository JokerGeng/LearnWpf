using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLibary
{
    public class DelegateCommand : DelegateCommandBase
    {
        Action _executeMethod;
        Func<bool> _canExecuteMethod;

        public DelegateCommand(Action execute) : this(execute, () => true)
        {

        }

        public DelegateCommand(Action execute,Func<bool> canExecute):base()
        {
            if (execute == null || canExecute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            _executeMethod = execute;
            _canExecuteMethod = canExecute;
        }

        protected override bool CanExecute(object parameter)
        {
            return _canExecuteMethod();
        }

        protected override void Execute(object parameter)
        {
            _executeMethod();
        }

        public bool CanExecute()
        {
            return _canExecuteMethod();
        }

        public void Execute()
        {
            _executeMethod();
        }
    }
}
