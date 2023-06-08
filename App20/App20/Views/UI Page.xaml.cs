using App20.Models;
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
    public partial class UI_Page : ContentPage
    {
       
        public UI_Page()
        {
            InitializeComponent();

            BindingContext = new PersonalDetailsViewModel();
        }

        private void listView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            //(BindingContext as PersonalDetailsViewModel).LoadMoreItems(e.Item as EntryModel);
            (BindingContext as PersonalDetailsViewModel).LoadMoreItems();
        }
    }
}   