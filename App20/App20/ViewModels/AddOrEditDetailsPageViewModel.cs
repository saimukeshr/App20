using App20.Models;
using App20.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class AddOrEditDetailsPageViewModel : BaseViewModel
    {
        EntrylistApiService apiservice = new EntrylistApiService();

        private EntryModel orderDetails;
        public EntryModel OrderDetails
        {
            get { return orderDetails; }
            set { orderDetails = value; OnPropertyChanged(); }
        }

        public Command SaveItemCommand { get; set; }

        public Command UpdateItemCommand { get; set; }

        public AddOrEditDetailsPageViewModel()
        {
            OrderDetails = new EntryModel();

            SaveItemCommand = new Command(async () => await SaveCommnadAsync());

            UpdateItemCommand = new Command(async () => await UpdateCommandAsync());
        }

        private async Task UpdateCommandAsync()
        {
            EntryModel orderdetails = OrderDetails;

            if (await IsInValid())
                return;

            await apiservice.UpdateDataAsync(orderdetails);

            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async Task SaveCommnadAsync()
        {
            EntryModel orderdetails = OrderDetails;
            
            if (await IsInValid())
                return;

            await apiservice.PostDataAsync(orderdetails);

            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async Task<bool> IsInValid()
        {
            if (string.IsNullOrEmpty(orderDetails.AlbumId.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Pleae Enter OrderID", "Ok");
                return true;
            }
            else if (string.IsNullOrEmpty(orderDetails.Title))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Pleae Enter CustomerID", "Ok");
                return true;
            }
            //else if (string.IsNullOrEmpty(orderDetails.ShipCountry))
            //{
            //    await App.Current.MainPage.DisplayAlert("Error", "Pleae Enter ShipCountry", "Ok");
            //    return true;
            //}

            return false;
        }

       

        private bool myBooleanValue;

        public bool MyBooleanValue { get => myBooleanValue; set { myBooleanValue = value; OnPropertyChanged(nameof(MyBooleanValue)); } }
    }
}
