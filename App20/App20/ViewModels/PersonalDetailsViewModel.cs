using App20.Helpers;
using App20.Models;
using App20.Services;
using App20.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class PersonalDetailsViewModel : BaseViewModel
    {
        const int pageSize = 10;
        public List<EntryModel> DetailsList { get; set; }
        EntrylistApiService apiService = new EntrylistApiService();

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


        private Command loadMoreDataCommand;

        public Command LoadMoreDataCommand
        {
            get
            {
                if (loadMoreDataCommand == null)
                {
                    loadMoreDataCommand = new Command(LoadMoreData);
                }

                return loadMoreDataCommand;
            }
        }

        public ObservableCollection<EntryModel> FinalList { get; set; }

  
        public Details SelectedItem { get; set; }

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

        public bool IsBusy { get; private set; }

        public PersonalDetailsViewModel()
        {
            LoadMoreDataCommand();
        }

        public async Task GetDatailsAsync()
        {
            string weburl = ApiHelper.entrylisturl;
            Results = await apiService.GetDataAsync(weburl);

        }


        private void LoadMoreData()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            // load the next page
            var page = Results.Count / pageSize;

            //calling api
            var Result = GetDatailsAsync(pageSize, page);

            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    Results.AddRange((IEnumerable<EntryModel>)Result);
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }
    }
}
