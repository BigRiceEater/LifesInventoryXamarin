using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using LifesInventory.Models;
using Prism.Navigation;
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

	    private bool _hasCompletedEntry = false;
	    public bool HasCompletedEntry
	    {
	        get => _hasCompletedEntry;
	        set => SetProperty(ref _hasCompletedEntry, value);
	    }

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

        public AddInventoryPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Title = "Add Inventory";
        }


	    private void AddToInventory(InventoryAsset item)
	    {

	    }
	}
}
