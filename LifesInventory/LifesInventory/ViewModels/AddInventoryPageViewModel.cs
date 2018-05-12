using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using LifesInventory.Models;
using LifesInventory.Services;
using Prism.Navigation;
using Prism.Services;
using Unity.ObjectBuilder.Policies;

namespace LifesInventory.ViewModels
{
	public class AddInventoryPageViewModel : ViewModelBase
	{

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                UpdateNewItem();
            }
        }

	    private string _price;
	    public string Price
	    {
	        get => _price;
	        set
	        {
                SetProperty(ref _price, value);
	            UpdateNewItem();
            }
	    }

	    public bool HasCompletedEntry { get; set; } = false;

	    private InventoryAsset _newItem;
        public InventoryAsset NewItem
        {
            get => _newItem;
            set => SetProperty(ref _newItem, value);
        }

	    public DelegateCommand<InventoryAsset> AddToInventoryCommand =>
	        new DelegateCommand<InventoryAsset>
	            (AddToInventory).ObservesCanExecute(()=>HasCompletedEntry);

	    private void UpdateNewItem()
	    {
	        float.TryParse(Price, out var price);
	        NewItem = new InventoryAsset()
	        {
                Name = _name,
                Price = price
	        };

	        var hasName = !string.IsNullOrWhiteSpace(NewItem.Name);
	        var hasPrice = NewItem.Price > 0;

	        if (hasName && hasPrice)
	            HasCompletedEntry = true;
	        else
	            HasCompletedEntry = false;
	    }

	    private readonly INavigationService _navigation;
	    private readonly IPageDialogService _dialog;
	    private readonly IInventoryService _inventory;
        public AddInventoryPageViewModel(
            INavigationService navigationService, 
            IPageDialogService pageDialogService,
            IInventoryService inventoryService) 
            : base(navigationService)
        {
            Title = "Add Inventory";
            _navigation = navigationService;
            _dialog = pageDialogService;
            _inventory = inventoryService;
        }


	    private async void AddToInventory(InventoryAsset item)
	    {
	        var rows = await _inventory.AddInventoryItemAsync(item);

	        if (rows > 0)
	        {
	            var choice = await _dialog.DisplayActionSheetAsync(
	                title: "Success",
	                cancelButton: null,
                    destroyButton: null,
	                otherButtons: new string[] { "Add Another" , "Finish" }
	            );

	            if (choice == "Add Another")
	            {
	                Price = "";
	                Name = "";
	            }
                else if (choice == "Finish")
	            {
	                await _navigation.GoBackAsync();
	            }
	        }
	        else
	        {
	            await _dialog.DisplayAlertAsync(
	                "Failure",
	                "Oops something went wrong",
	                "Okay");
	        }
	    }
	}
}
