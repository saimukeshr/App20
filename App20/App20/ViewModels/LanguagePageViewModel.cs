using App20.Models;
using App20.Resx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class LanguagePageViewModel : BaseViewModel
    {
        private ObservableCollection<Languages> supportedLanguages;
        public  ObservableCollection<Languages> SupportedLanguages
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



        public Command ChangeLanguageCommand {get ; set;}

        public LanguagePageViewModel()
        {
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
            //CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.UserCustomCulture | CultureTypes.SpecificCultures);
            //var getlanguage = CultureInfo.CurrentUICulture.Name;

            LocalizationResourceManager.Current.SetCulture(CultureInfo.GetCultureInfo(SelectedLanguage.CI));
        }
    }
}
