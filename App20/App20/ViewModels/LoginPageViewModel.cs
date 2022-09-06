using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public Command LoginCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(() => OnLoginCommand());
        }

        private void OnLoginCommand()
        {
            Application.Current.MainPage.Navigation.PushAsync(new MasterPage());
            Application.Current.MainPage.Navigation.RemovePage(Application.Current.MainPage.Navigation.NavigationStack[0]);
        }
    }

    
}
