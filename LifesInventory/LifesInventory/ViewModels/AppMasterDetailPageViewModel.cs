using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace LifesInventory.ViewModels
{
	public class AppMasterDetailPageViewModel : ViewModelBase
	{
	    public DelegateCommand<string> NavigateCommand { get; set; }

        public AppMasterDetailPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            NavigateCommand = new DelegateCommand<string>(async (path) =>
            {
                await NavigationService.NavigateAsync(path);
            });
        }
	}
}
