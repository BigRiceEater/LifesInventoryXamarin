using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LifesInventory.Enums;
using LifesInventory.Models;
using Prism.Navigation;

namespace LifesInventory.ViewModels
{
	public class InventoryPageViewModel : ViewModelBase
	{

	    public ObservableCollection<InventoryAsset> InventoryItems { get; private set; }
        public InventoryPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Inventory";
            InventoryItems = new ObservableCollection<InventoryAsset>()
            {
                new InventoryAsset()
                {
                    Name = "Iron",
                    Price = 10.0f,
                    Currency = Currency.AmericanDollar
                },
                new InventoryAsset()
                {
                    Name = "Toaster",
                    Price = 20.0f,
                    Currency = Currency.HongKongDollar
                }
            };
        }
	}
}
