using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLibary
{
    public class DelegateCommand<T> : ICommand
    {
        private Action<T> _executeMethod = null;
        Func<T, bool> _canExecuteMethod = null;
        private SynchronizationContext _synchronizationContext;
        public DelegateCommand(Action<T> execute)
        {
            _executeMethod = execute;
            _synchronizationContext = SynchronizationContext.Current;
        }
        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute)
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
                return _canExecuteMethod((T)parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            if(CanExecute(parameter))
            {
                _executeMethod?.Invoke((T)parameter);
            }
        }
        public void Execute(T parameter)
        {
            _executeMethod(parameter);
        }

        public bool CanExecute(T parameter)
        {
            return _canExecuteMethod(parameter);
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
