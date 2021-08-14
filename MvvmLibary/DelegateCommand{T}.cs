using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLibary
{
    public class DelegateCommand<T> : DelegateCommandBase
    {
        private Action<T> _executeMethod = null;
        Func<T, bool> _canExecuteMethod = null;
        public DelegateCommand(Action<T> execute):this(execute, (o)=>true)
        {
        }
        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute):base()
        {
            if (execute == null || canExecute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            _executeMethod = execute;
            _canExecuteMethod = canExecute;
        }

        public void Execute(T parameter)
        {
            _executeMethod(parameter);
        }

        public bool CanExecute(T parameter)
        {
            return _canExecuteMethod(parameter);
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecuteMethod((T)parameter);
        }

        public override void Execute(object parameter)
        {
            _executeMethod((T)parameter);
        }
    }
}
