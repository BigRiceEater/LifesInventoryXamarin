using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace LifesInventory.ViewModels
{
	public class WishListPageViewModel : ViewModelBase
	{
        public WishListPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Wish List";
        }
	}
}
