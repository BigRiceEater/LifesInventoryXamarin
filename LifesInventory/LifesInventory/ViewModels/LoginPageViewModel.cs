using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifesInventory.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public DelegateCommand LoginCommand { get; set; }

        public LoginPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Login Page";
            LoginCommand = new DelegateCommand(async () =>
            {
                await NavigationService.NavigateAsync("/Root/Nav/Inventory");
            });
        }
    }
}
