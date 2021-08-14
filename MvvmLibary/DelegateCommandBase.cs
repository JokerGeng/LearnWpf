using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLibary
{
    public abstract class DelegateCommandBase : ICommand
    {
        SynchronizationContext _synchronizationContext;

        public virtual event EventHandler CanExecuteChanged;

        protected DelegateCommandBase()
        {
            _synchronizationContext = SynchronizationContext.Current;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            Execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

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
