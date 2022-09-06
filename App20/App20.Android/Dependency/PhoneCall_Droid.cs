using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App20.Droid;
using App20.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCall_Droid))]
namespace App20.Droid
{
    public class PhoneCall_Droid : IPhoneCall
    {
        public void MakePhoneCall(string number)
        {

            PhoneDialer.Open(number);

        }
    }
}

