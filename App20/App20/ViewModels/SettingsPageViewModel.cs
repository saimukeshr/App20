using App20.Models;
using App20.Resx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        private string Networkstate { get; set; }
        public string NetworkState
        {
            get { return Networkstate; }
            set
            {
                if (Networkstate != value)
                {
                    Networkstate = value;
                }
                OnPropertyChanged("NetworkState");
            }
        }

        private ObservableCollection<Languages> supportedLanguages;
        public ObservableCollection<Languages> SupportedLanguages
        {
            get
            {
                return supportedLanguages;
            }
            set
            {
                supportedLanguages = value;
                OnPropertyChanged();
            }
        }

        private Languages selectedLanguage;
        public Languages SelectedLanguage
        {
            get
            {
                return selectedLanguage;
            }
            set
            {
                selectedLanguage = value;
                OnPropertyChanged();
            }
        }


        
        public Command ChangeLanguageCommand { get; set; }

        
        public SettingsPageViewModel()
        {
            
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            ChangeLanguageCommand = new Command(() => LanguageChangeCommand());

            SupportedLanguages = new ObservableCollection<Languages>()
            {
                new Languages{Name = AppResources.English, CI = "en"},
                new Languages{Name = AppResources.French, CI = "fr"},

            };

            SelectedLanguage = SupportedLanguages.FirstOrDefault(pro => pro.CI == LocalizationResourceManager.Current.CurrentCulture.TwoLetterISOLanguageName);
        }

        
        private void LanguageChangeCommand()
        {            
            LocalizationResourceManager.Current.CurrentCulture = new CultureInfo(SelectedLanguage.CI);
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
