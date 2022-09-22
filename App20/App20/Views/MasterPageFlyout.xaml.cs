using App20.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App20
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPageFlyout : ContentPage
    {
        public ListView ListView;

        public MasterPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MasterPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MasterPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterPageFlyoutMenuItem> MenuItems { get; set; }

            public MasterPageFlyoutViewModel()
            {
                if(Device.RuntimePlatform == Device.Android)
                MenuItems = new ObservableCollection<MasterPageFlyoutMenuItem>(new[]
                {
                    new MasterPageFlyoutMenuItem { Id = 1, Title = "ORDERS PAGE",  TargetType=typeof(ListPage) },
                    new MasterPageFlyoutMenuItem { Id = 2, Title = "ID LIST PAGE", TargetType=typeof(SecondList) },
                    new MasterPageFlyoutMenuItem { Id = 3, Title = "CALL PAGE", TargetType=typeof(CallPage) },
                    new MasterPageFlyoutMenuItem { Id = 5, Title = "UI PAGE", TargetType=typeof(UI_Page) },
                    new MasterPageFlyoutMenuItem { Id = 5, Title = "SETTINGS PAGE", TargetType=typeof(SettingsPage) },
                     
                }
                    
                );

                else
                    MenuItems = new ObservableCollection<MasterPageFlyoutMenuItem>(new[]
                 {
                    new MasterPageFlyoutMenuItem { Id = 1, Title = "ORDERS PAGE",  TargetType=typeof(ListPage) },
                    new MasterPageFlyoutMenuItem { Id = 2, Title = "ID LIST PAGE", TargetType=typeof(SecondList) },
                    new MasterPageFlyoutMenuItem { Id = 5, Title = "UI PAGE", TargetType=typeof(UI_Page) },
                    new MasterPageFlyoutMenuItem { Id = 4, Title = "SETTINGS PAGE", TargetType=typeof(SettingsPage) },
                }
                );
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;

            #endregion
        }
    }
}