using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepButtonPressed.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        private readonly IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        private DelegateCommand<string> _menuCommand;
        public DelegateCommand<string> MenuCommand =>
            _menuCommand ?? (_menuCommand = new DelegateCommand<string>(ExecuteMenuCommand));

        void ExecuteMenuCommand(string parameter)
        {
            Navigate(parameter);
        }

        //在该页面回车后将执行此命令
        private DelegateCommand _defaultCommand;
        public DelegateCommand DefaultCommand =>
            _defaultCommand ?? (_defaultCommand = new DelegateCommand(ExecuteDefaultCommand));

        void ExecuteDefaultCommand()
        {
            
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("MainRegion", navigatePath);
        }
    }
}
