using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace LifesInventory.ViewModels
{
	public class AppSettingsPageViewModel : ViewModelBase
	{
        public AppSettingsPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Settings";
        }
	}
}
