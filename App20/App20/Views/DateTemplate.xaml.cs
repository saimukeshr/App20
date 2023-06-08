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
    public partial class DateTemplate : ContentPage
    {
        public DateTemplate()
        {
            InitializeComponent();

            var Works = new List<Items>
            {
                new Items {Name = "Plan" },

                new Items { DateofBirth = new DateTime( 2022 , 10, 20)},

                new Items {Details = new List<string>{"Selection1","Selection2" } },

                new Items {DateofBirth = new DateTime( 2022 , 11, 20)},

                new Items { Details = new List<string>{"ItemA","ItemB" } },

                new Items {Name = "Schedule" }
            };

            listView.ItemsSource = Works;
        }
    }
}