using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App20.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            if (current == NetworkAccess.Internet)
            {
                networkState.Text = "Network is Available";
            }
            else
            {
                networkState.Text = "Network is Not Available";
            }

            if (profiles.Contains(ConnectionProfile.WiFi))
            {
                networkState.Text = profiles.FirstOrDefault().ToString();
            }
            else
            {
                networkState.Text = profiles.FirstOrDefault().ToString();
            }

            Connectivity.ConnectivityChanged += ConnectivityChangedHandler;
        }

        private void ConnectivityChangedHandler(object sender, ConnectivityChangedEventArgs e)
        {

            networkState.Text = e.NetworkAccess.ToString();

        }
    }
    }
