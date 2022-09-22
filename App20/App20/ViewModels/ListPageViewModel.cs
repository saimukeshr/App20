using App20.Helpers;
using App20.Interfaces;
using App20.Models;
using App20.Services;
using App20.Views;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class ListPageViewModel : BaseViewModel
    {
        #region variables
        private readonly ApiService apiService = new ApiService();
        private readonly JsonServices jsonServices = new JsonServices();
        public DialogueService DisplayBox;
        public readonly Interfaces.ILogger logger = DependencyService.Get<ILogManager>().GetLog();
        #endregion

        #region Porperties
        private List<Details> info;
        public List<Details> Info
        {
            get
            {
                return info;
            }
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }

        private List<Details> result;
        public List<Details> Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }

        private List<Details> result1;
        public List<Details> Result1
        {
            get
            {
                return result1;
            }
            set
            {
                result1 = value;
                OnPropertyChanged("Result1");
            }
        }

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

        private List<Details> searchResults;
       

        public List<Details> SearchResults
        {
            get
            {
                return searchResults;
            }
            set
            {
                searchResults = value;
                OnPropertyChanged();
            }
        }

        public List<Details> DetailsList { get; set; }

        private List<Details> Sortedlist { get; set; }
        public List<Details> SortedList
        {
            get { return Sortedlist; }
            set
            {
                if (Sortedlist != value)
                {
                    Sortedlist = value;
                }
                OnPropertyChanged("SortedList");
            }
        }

        public Command DeleteItemCommand { get; set; }

        public Command UpdateItemCommand { get; set; }

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
        #endregion

        #region OnTapped Property
        // Display Alert on Tapping the List
        private Details tappedOrder;
        public Details TappedOrder
        {
            get { return tappedOrder; }
            set
            {
                try
                {
                    if (value != null)
                    {
                        DisplayBox.DialogueBox("Selected Order", "Order ID: " + value.OrderID + "    " + "Customer ID: " + value.CustomerID + "   " + "ShippingCountry: " + value.ShipCountry, "Ok");
                        value = null;
                    }
                    tappedOrder = value;
                    OnPropertyChanged();
                    SelectedItem = null;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }
        #endregion

       public Command SearchCommand { get; set; }
       

        // Constructor
        public ListPageViewModel()
        {
            Result = new List<Details>();
            Result1 = new List<Details>();
            SearchCommand = new Command(() => SearchFilterCommand());
            DisplayBox = new DialogueService();
            var task1 = Task.Factory.StartNew(() => GetDataFromApi());
            var task2 = Task.Factory.StartNew(() => GetDataFromjson());
            Task.WaitAll(task1, task2);
            SortedList = new List<Details>();

            Interfaces.ILogger logger = DependencyService.Get<ILogManager>().GetLog();
            
           
        }

        #region Methods
        // method to call api call to get data
        public async Task GetDataFromApi()
        {

            string weburl = ApiHelper.listviewurl;
            Info = await apiService.GetDataAsync(weburl);
            Info.AddRange(Result1);
            //result = info.tolist() == null ? alert() : info;
            Result = Info.ToList();


            logger.Info("Api method inititated");

        }

        //private List<Details> Alert()
        //{
        //    DisplayBox.DialogueBox("Error", "There was error loading the data", "Ok");
        //    throw new NotImplementedException();
        //}

        // Method to call local Json File
        public async Task GetDataFromjson()
        {
            string jsonfile = "OrderDetailsData2.json";
           // Result1 = await jsonServices.CallJsonDataAsync() == null ? Result : Alert();
            Result1 = await jsonServices.CallJsonDataAsync(jsonfile);
            logger.Info("Json Method Inititated");
        }

        
        // Search Command method
        private void SearchFilterCommand()
        {
            Result = string.IsNullOrEmpty(SearchText)
                    ? Info.ToList()
                    : (from order in Info
                       where order.ShipCountry == SearchText
                       select order).ToList();

            //Interfaces.ILogger logger = DependencyService.Get<ILogManager>().GetLog();
            logger.Info("Search Filter Method Inititated");
            
        }
        #endregion
    }
}
