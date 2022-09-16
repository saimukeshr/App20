using App20.Helpers;
using App20.Interfaces;
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

        private readonly AuthService _authService;
        private readonly SimpleGraphService _simpleGraphService;

        public bool IsSignedIn { get; set; }
        public bool IsSigningIn { get; set; }
        public string Name { get; set; }

       


        public LoginPageViewModel()
        {
            _authService = new AuthService();
            _simpleGraphService = new SimpleGraphService();

            LoginCommand = new Command(() => OnLoginCommandAsync());
        }

        private async Task OnLoginCommandAsync()
        {
           await Application.Current.MainPage.Navigation.PushAsync(new MasterPage());
            //IsSigningIn = true;

            //if (await _authService.SignInAsync())
            //{
            //    Name = await _simpleGraphService.GetNameAsync();
            //    await Application.Current.MainPage.Navigation.PushAsync(new MasterPage());
            //    IsSignedIn = true;
            //}

            //IsSigningIn = false;
        }

        // Application.Current.MainPage.Navigation.PushAsync(new MasterPage());
        //Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[0]);


    }


}

    

