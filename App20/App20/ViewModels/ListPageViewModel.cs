﻿using App20.Helpers;
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
        Interfaces.ILogger logger = DependencyService.Get<ILogManager>().GetLog();
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

        private List<Details> searchResults;
        private readonly Details details;

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

        #endregion

        #region OnTapped Property
        // Display Alert on Tapping the List
        //private Details tappedOrder;
        //public Details TappedOrder
        //{
        //    get { return tappedOrder; }
        //    set
        //    {
        //        try
        //        {
        //            if (value != null)
        //            {
        //                DisplayBox.DialogueBox("Selected Order", "Order ID: " + value.OrderID + "    " + "Customer ID: " + value.CustomerID + "   " + "ShippingCountry: " + value.ShipCountry, "Ok");
        //                value = null;
        //            }
        //            tappedOrder = value;
        //            OnPropertyChanged();
        //        }
        //        catch (Exception ex)
        //        {
        //            ex.ToString();
        //        }
        //    }
        //}
        #endregion

        public Command SearchCommand { get; set; }
        public Command<object> TapCommand { get; set; }

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
            Interfaces.ILogger logger = DependencyService.Get<ILogManager>().GetLog();

            TapCommand = new Command<object>(OnItemtapped);
        }

        private void OnItemtapped(object obj)
        {
            var detailinfopage = new DetailInfoPage(details);
            detailinfopage.BindingContext = obj as Details;
            App.Current.MainPage.Navigation.PushAsync(detailinfopage);
            
        }

        #region Methods
        // Method to call API Call  to get Data
        public async Task GetDataFromApi()
        {
           
            string webURL = ApiHelper.listviewurl;
            Info = await apiService.GetDataAsync(webURL);
            Info.AddRange(Result1);
            //Result = Info.ToList() == null ? Alert() : Info;
            Result = Info.ToList();


            logger.Info("Api Method Inititated");
            
        }

        private List<Details> Alert()
        {
            DisplayBox.DialogueBox("Error", "There was error loading the data", "Ok");
            throw new NotImplementedException();
        }



        // Method to call local Json File
        public async Task GetDataFromjson()
        {
           // Result1 = await jsonServices.CallJsonDataAsync() == null ? Result : Alert();
            Result1 = await jsonServices.CallJsonDataAsync();

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
