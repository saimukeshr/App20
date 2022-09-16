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
    public partial class AddOrEditDetailsPage : ContentPage
    {
       public AddOrEditDetailsPage(PersonalDetailsModel SelectedDetails = null )
       {
            InitializeComponent();

            if (SelectedDetails != null)
            {
                ((AddOrEditDetailsPageViewModel)BindingContext).Details = SelectedDetails;
            }
        }

        
    }
}