using App20.Helpers;
using App20.Models;
using App20.Services;
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
        private IList<dynamic> items;
      
        private int totalItems = 20;

        public IList<dynamic> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public Command<object> LoadMoreItemsCommand { get; set; }

        public List<EntryModel> Results { get; set; }

         private readonly EntrylistApiService apiService = new EntrylistApiService();

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public SecondListViewModel()
        {
            Results = new List<EntryModel>();
           // IsBusy = true;
            Items = new ObservableCollection<dynamic>();
            GetDataFromApiAsync();
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems, CanLoadMoreItems);
        }


        public async Task GetDataFromApiAsync()
        {
            try
            {
                string webURL = ApiHelper.entrylisturl;
                Results = await apiService.GetDataAsync(webURL);
               // Results = Info.ToList();
                totalItems = Results.Count;

            }
            catch (Exception)
            { }
        }

        private bool CanLoadMoreItems(object obj)
        {
            if (Items.Count >= totalItems)
                return false;
            return true;
        }

        private async void LoadMoreItems(object obj)
        {
            var listview = obj as SfListView;
            try
            {
                IsBusy = true;
                await Task.Delay(1000);
                var index = Items.Count;
                var count = index + 5 >= totalItems ? totalItems - index : 5;
                AddProducts(index, count);
            }
            catch
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        private void AddProducts(int index, int count)
        {
            for (int i = index; i < index + count; i++)
            {
                Items.Add(Results[i]);
            }
        }
    }
}
