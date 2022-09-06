using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App20
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPageDetail : ContentPage
    {
        public MasterPageDetail()
        {
            if (Device.RuntimePlatform == Device.UWP)
            NavigationPage.SetHasNavigationBar(this, false);
            else
               NavigationPage.SetHasNavigationBar(this, true);

            InitializeComponent();
            
        }
    }
}