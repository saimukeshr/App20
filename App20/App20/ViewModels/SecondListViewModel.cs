using App20.Helpers;
using App20.Models;
using App20.Services;
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

        private string searchText { get; set; }
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                }
                OnPropertyChanged("SearchText");
            }
        }
        private ObservableCollection<EntryModel> results;
        public ObservableCollection<EntryModel> Results
        {
            get { return results; }
            set { results = value; 
                OnPropertyChanged("Results"); }
        }


        public Command LoadMoreItemsCommand { get; set; }


        public Command<object> SearchCommand { get; set; }

        public ObservableCollection<EntryModel> Products { get; set; }

        public DataSource ListDataSource { get; set; }

        public SecondListViewModel()
        {
            Results = new ObservableCollection<EntryModel>();
            GetDataFromApiAsync();
            ListDataSource = new DataSource();
            SearchCommand = new Command<object>(OnSearchCommand);
            Products = new ObservableCollection<EntryModel>();

            LoadMoreItemsCommand = new Command<ItemVisibilityEventArgs>(
            execute: async (ItemVisibilityEventArgs args) =>
            {
                if ((args.Item as EntryModel).id >= Results[Results.Count - 1].id)
                {
                    IsBusy = true;

                    for (int i = 0; i < 10; i++)
                    {
                        Results.Add(new EntryModel()
                        {
                            id = Results.Count + 1,
                            title = Results[i].title
                        });
                    }
                    await Task.Delay(200); 
                    IsBusy = false;
                }
            });
        }

        private void OnSearchCommand(object obj)
        {
            SearchText = obj as string;
            if (this.ListDataSource != null)
            {
                this.ListDataSource.Filter = FilterContacts;
                this.ListDataSource.RefreshFilter();
            }
        }

        private bool FilterContacts(object obj)
        {
            if (string.IsNullOrEmpty(SearchText))
                return true;

            var entrylist = obj as EntryModel;
            if (entrylist.id.ToString().Contains(SearchText.ToLower())
                    || entrylist.title.ToLower().Contains(SearchText.ToLower()))
                return true;
            else
                return false;
        }


        public async Task GetDataFromApiAsync()
        {
            try
            {
                string webURL = ApiHelper.entrylisturl;
                Results = await apiService.GetDataAsync(webURL);

            }
            catch (Exception)
            { }
        }
      
    }
}
