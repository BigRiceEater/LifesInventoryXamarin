using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using LifesInventory.Enums;
using LifesInventory.Models;
using LifesInventory.Services;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace LifesInventory.ViewModels
{
	public class InventoryPageViewModel : ViewModelBase
	{
	    private readonly INavigationService _navigation;
	    private readonly IPageDialogService _dialog;
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

        private InventoryAsset _selectedInventoryItem;
        public InventoryAsset SelectedInventoryItem
        {
            get => _selectedInventoryItem;
            set => SetProperty(ref _selectedInventoryItem , value);
        }

        public DelegateCommand AddNewInventoryCommand => 
            new DelegateCommand( async () => await _navigation.NavigateAsync("AddInventory") );

        public DelegateCommand SortByNameCommand =>
            new DelegateCommand(async () => InventoryItems = InventoryItems.OrderBy(_ => _.Name).ToList());

        public DelegateCommand SortByPriceCommand =>
            new DelegateCommand(async ()=> InventoryItems = InventoryItems.OrderByDescending(_=>_.Price).ToList());

	    public DelegateCommand DeleteItemCommand =>
	        new DelegateCommand(async () =>
	        {
	            await _inventory.AddInventoryItemAsync(SelectedInventoryItem);
	            SelectedInventoryItem = null;
	        }, 
	            new Func<bool>( () => SelectedInventoryItem != null)
	        ).ObservesProperty(() => SelectedInventoryItem);


	    public InventoryPageViewModel(
            INavigationService navigationService,
            IInventoryService inventoryService,
            IPageDialogService dialogService) 
            : base (navigationService)
        {
            Title = "Inventory";

            _navigation = navigationService;
            _dialog = dialogService;
            _inventory = inventoryService;
        }

	    public override async void OnNavigatedTo(NavigationParameters parameters)
	    {
	        base.OnNavigatedTo(parameters);
	        var list = await _inventory.GetInventoryListAsync("");
	        list = list.OrderBy(_ => _.Name).ToList();

	        InventoryItems = list;

	        var total = InventoryItems.Sum(item => item.Price);
            TotalAsset = total.ToString("C0", new CultureInfo("zh-HK"));

        }
	}
}
