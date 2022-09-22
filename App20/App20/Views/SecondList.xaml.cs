using App20.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App20.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondList : ContentPage
    {
        SecondListViewModel viewmodel = new SecondListViewModel();
        public SecondList()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await viewmodel.GetDataFromApiAsync();
            
        }
    }

}