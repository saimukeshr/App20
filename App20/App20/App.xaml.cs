using App20.Helpers;
using App20.Resx;
using App20.Views;
using System;
using System.IO;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App20
{
    public partial class App : Application
    {
        public static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "App20.db3"));
                }
                return database;
            }
        }

        public static new string Id;
        public static string OrderID;
        public static string CustomerID;
        public static string ShipCountry;

        public App()
        {
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);
            InitializeComponent();
            
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
