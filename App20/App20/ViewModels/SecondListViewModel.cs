using App20.Helpers;
using App20.Models;
using App20.Services;
using App20.Views;
using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class SecondListViewModel : BaseViewModel
    {
        public DialogueService DisplayBox;
        private readonly EntrylistApiService apiService = new EntrylistApiService();

        private string Searchtext { get; set; }
        public string SearchText
        {
            get { return Searchtext; }
            set
            {
                if (Searchtext != value)
                {
                    Searchtext = value;
                }
                OnPropertyChanged("SearchText");
            }
        }

        private string Orderid { get; set; }
        public string OrderID
        {
            get { return Orderid; }
            set
            {
                if (Orderid != value)
                {
                    Orderid = value;
                }
                OnPropertyChanged("OrderID");
            }
        }

        private List<EntryModel> results;
        public List<EntryModel> Results
        {
            get { return results; }
            set
            {
                results = value;
                OnPropertyChanged("Results");
            }
        }

        public ObservableCollection<EntryModel> SortedList { get; set; }

        public Command AddItemCommand { get; set; }

        public Command DeleteItemCommand { get; set; }

        public Command UpdateItemCommand { get; set; }

        public EntryModel SelectedItem { get; set; }

        public SecondListViewModel()
        {
            Results = new List<EntryModel>();
            SortedList = new ObservableCollection<EntryModel>();
            var Task = GetDataFromApiAsync();
            DisplayBox = new DialogueService();
            AddItemCommand = new Command(() => AddCommand());
            DeleteItemCommand = new Command(async () => await DeleteCommandAsync());
            UpdateItemCommand = new Command(() => UpdateCommand());
           
        }

        private void UpdateCommand()
        {
            EntryModel Details = Results.FirstOrDefault(det => det.AlbumId == SelectedItem.AlbumId);
            Application.Current.MainPage.Navigation.PushAsync(new AddOrEditDetailsPage("Update",Details));
        }

        private async Task DeleteCommandAsync()
        {
            bool Decision = await App.Current.MainPage.DisplayAlert("Alert", "Do you wish to Delete the item", "Yes", "No");

            if (Decision)
            {
                EntryModel details = Results.FirstOrDefault(det => det.AlbumId == SelectedItem.AlbumId);
               
                await apiService.DeleteDataAsync(details.AlbumId);
            }
        }

        private void AddCommand()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddOrEditDetailsPage("Add"));
        }

        public async Task<List<EntryModel>> GetDataFromApiAsync()
        {
            try
            {
                string weburl = ApiHelper.localhosturl;
                Results = await apiService.GetDataAsync(weburl);
                               
            }
            catch (Exception)
            { }
            return Results;
        }
      
    }
}
