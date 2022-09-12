using App20.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public Command LoginCommand { get; set; }

        private readonly AuthenticationHelper _authService;
        private readonly SimpleGraphService _simpleGraphService;

        public bool IsSignedIn { get; set; }
        public bool IsSigningIn { get; set; }
        public string Name { get; set; }

       

        public LoginPageViewModel()
        {
            _authService = new AuthenticationHelper();
            _simpleGraphService = new SimpleGraphService();

            LoginCommand = new Command(() => OnLoginCommandAsync());
        }

        private async Task OnLoginCommandAsync()
        {

            Application.Current.MainPage.Navigation.PushAsync(new MasterPage());
            //Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[0]);

            //IsSigningIn = true;

            //if (await _authService.SignInAsync())
            //{
            //    await Application.Current.MainPage.Navigation.PushAsync(new MasterPage());
            //    IsSignedIn = true;
            //}

            //IsSigningIn = false;


        }


    }

    
}
