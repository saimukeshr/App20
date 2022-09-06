﻿using App20.Views;
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
                MenuItems = new ObservableCollection<MasterPageFlyoutMenuItem>(new[]
                {
                    new MasterPageFlyoutMenuItem { Id = 1, Title = "LIST PAGE",  TargetType=typeof(ListPage) },
                    new MasterPageFlyoutMenuItem { Id = 2, Title = "CALL PAGE", TargetType=typeof(CallPage) },
                    new MasterPageFlyoutMenuItem { Id = 3, Title = "SETTINGS PAGE", TargetType=typeof(SettingsPage) },
                    
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}