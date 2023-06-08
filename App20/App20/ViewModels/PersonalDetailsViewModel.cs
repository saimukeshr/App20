using App20.Helpers;
using App20.Models;
using App20.Services;
using App20.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class PersonalDetailsViewModel : BaseViewModel
    {       
        EntrylistApiService apiService = new EntrylistApiService();
        int _offset = 0;
        private int totalItems = 0;
        public bool IsBusy { get;  set; }
        public List<EntryModel> Results { get; set; }

        ObservableCollection<EntryModel> _listData;
        public ObservableCollection<EntryModel> ListData
        {
            get { return _listData; }
            set
            {
                _listData = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<EntryModel> data;
        public ObservableCollection<EntryModel> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        private IList<EntryModel> items;
        public IList<EntryModel> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public Command<object> LoadMoreItemsCommand { get; set; }
        public ICommand LoadMoreCommand { get; set; }
        public PersonalDetailsViewModel()
        {
            ListData = new ObservableCollection<EntryModel>();
            GetDatailsAsync();
            LoadMoreItems();
        }


        public async Task GetDatailsAsync()
        {
            string weburl = $"https://jsonplaceholder.typicode.com/photos?limit=50,&offset=100";
            Results = await apiService.GetDataAsync(weburl);
            ListData = new ObservableCollection<EntryModel>(Results);
            totalItems = ListData.Count;
        }

        //public async Task LoadMoreItems(EntryModel currentItem)
        //{
        //    int itemIndex = ListData.IndexOf(currentItem);

        //    _offset = ListData.Count;

        //    if (ListData.Count - 3 == itemIndex)
        //    {
        //        string weburl = $"https://jsonplaceholder.typicode.com/photos?limit=50,&offset=100"; 
        //        List<EntryModel> data = await apiService.GetDataAsync(weburl);
        //        foreach (EntryModel item in data)
        //        {
        //            Device.BeginInvokeOnMainThread(() =>
        //            {
        //                ListData.Add(item);
        //            });
        //        }
        //    }
        //}

        public void LoadMoreItems()
        {
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems, CanLoadMoreItems);
        }

        private bool CanLoadMoreItems(object obj)
        {
            if (Items.Count >= totalItems)
                return false;
            return true;
        }

        private async void LoadMoreItems(object obj)
        {  
            try
            {
                await Task.Delay(1000);
                var index = Items.Count;
                var count = index + 3 >= totalItems ? totalItems - index : 3;
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
                Items.Add(ListData[i]);
            }
        }
    }
}
