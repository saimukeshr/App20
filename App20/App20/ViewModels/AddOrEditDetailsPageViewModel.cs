using App20.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class AddOrEditDetailsPageViewModel : BaseViewModel
    {
        private PersonalDetailsModel details;
        public PersonalDetailsModel Details
        {
            get { return details; }
            set { details = value; OnPropertyChanged(); }
        }

        public Command SaveItemCommand { get; set; }

        public AddOrEditDetailsPageViewModel()
        {
            Details = new PersonalDetailsModel();

            SaveItemCommand = new Command(() => SaveCommnadAsync());

        }

        private async Task SaveCommnadAsync()
        {
            PersonalDetailsModel details = Details;
            
            if (await IsInValid())
                return;

            MessagingCenter.Send(this, "AddorEditDetails", details);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async Task<bool> IsInValid()
        {
            if (string.IsNullOrEmpty(details.FirstName))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Pleae Enter Name", "Ok");
                return true;
            }

            return false;
        }
    }
}
