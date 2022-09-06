using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace App20.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        private string networkState { get; set; }
        public string NetworkState
        {
            get { return networkState; }
            set
            {
                if (networkState != value)
                {
                    networkState = value;
                }
                OnPropertyChanged("NetworkState");
            }
        }
        public SettingsPageViewModel()
        {
            
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            var profiles = Connectivity.ConnectionProfiles;
            if (current == NetworkAccess.Internet)
            {
                NetworkState = "Network is Available";
            }
            else
            {
                NetworkState = "Network is Not Available";
            }

            if (profiles.Contains(ConnectionProfile.WiFi))
            {
                NetworkState = profiles.FirstOrDefault().ToString();
            }
            else
            {
                NetworkState = profiles.FirstOrDefault().ToString();
            }

            Connectivity.ConnectivityChanged += ConnectivityChangedHandler;
        }

        private void ConnectivityChangedHandler(object sender, ConnectivityChangedEventArgs e)
        {

            NetworkState = e.NetworkAccess.ToString();

        }
    }
}
