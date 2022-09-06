using App20.Models;
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
    public partial class DetailInfoPage : ContentPage
    {
        //  Details detail;

        public DetailInfoPage()
        {
        }

        public DetailInfoPage(Details detail)
        {
            InitializeComponent();
        }
    }
}