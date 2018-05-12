using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using LifesInventory.Enums;
using LifesInventory.Models;
using LifesInventory.Services;
using Prism.Navigation;

namespace LifesInventory.ViewModels
{
	public class InventoryPageViewModel : ViewModelBase
	{
	    private readonly INavigationService _navigation;
	    private readonly IInventoryService _inventory;

	    private List<InventoryAsset> _inventoryItems;

	    public List<InventoryAsset> InventoryItems
	    {
	        get => _inventoryItems;
	        set => SetProperty(ref _inventoryItems, value);
	    }

        private string _totalAsset;

        public string TotalAsset
        {
            get { return _totalAsset; }
            set { SetProperty(ref _totalAsset, value); }
        }


        public DelegateCommand AddNewInventoryCommand => 
            new DelegateCommand( async () => await _navigation.NavigateAsync("AddInventory") );

        public InventoryPageViewModel(
            INavigationService navigationService,
            IInventoryService inventoryService) 
            : base (navigationService)
        {
            Title = "Inventory";

            _navigation = navigationService;
            _inventory = inventoryService;
        }

	    public override async void OnNavigatedTo(NavigationParameters parameters)
	    {
	        base.OnNavigatedTo(parameters);
	        InventoryItems = await _inventory.GetInventoryListAsync("");

	        var total = InventoryItems.Sum(item => item.Price);
            TotalAsset = total.ToString("C0", new CultureInfo("zh-HK"));

        }
	}
}
