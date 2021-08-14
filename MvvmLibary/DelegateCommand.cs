using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLibary
{
    public class DelegateCommand : ICommand
    {
        private Action _executeMethod = null;
        Func<object, bool> _canExecuteMethod = null;
        private SynchronizationContext _synchronizationContext;
        public DelegateCommand(Action execute)
        {
            _executeMethod = execute;
            _synchronizationContext = SynchronizationContext.Current;
        }

        public DelegateCommand(Action execute, Func<object, bool> canExecute)
        {
            _executeMethod = execute;
            _canExecuteMethod = canExecute;
            _synchronizationContext = SynchronizationContext.Current;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(_canExecuteMethod!=null)
            {
                return _canExecuteMethod(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _executeMethod?.Invoke();
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                if (_synchronizationContext != null && _synchronizationContext != SynchronizationContext.Current)
                    _synchronizationContext.Post((o) => handler.Invoke(this, EventArgs.Empty), null);
                else
                    handler.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
