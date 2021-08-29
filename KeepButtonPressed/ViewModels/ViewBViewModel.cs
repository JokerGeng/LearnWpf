using KeepButtonPressed.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepButtonPressed.ViewModels
{
    class ViewBViewModel : BindableBase, INavigationAware
    {
        private readonly IDialogService _dialogService;
        private readonly IEventAggregator _eventAggregator;
        public ViewBViewModel(IDialogService dialogService, IEventAggregator eventAggregator)
        {
            _dialogService = dialogService;
            _eventAggregator = eventAggregator;
        }
        private DelegateCommand _showDialogCommand;

        public DelegateCommand ShowDialogCommand =>
            _showDialogCommand ?? (_showDialogCommand = new DelegateCommand(ExecuteShowDialogCommand));


        void ExecuteShowDialogCommand()
        {
            _dialogService.ShowDialog("ViewDialog");
            _eventAggregator.GetEvent<ButtonSelectedEvent>().Publish("ViewB");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
