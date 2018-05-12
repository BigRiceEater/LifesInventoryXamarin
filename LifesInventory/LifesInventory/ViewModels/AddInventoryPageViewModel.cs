using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace LifesInventory.ViewModels
{
	public class AddInventoryPageViewModel : ViewModelBase
	{
        public AddInventoryPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Title = "Add Inventory";
        }
	}
}
