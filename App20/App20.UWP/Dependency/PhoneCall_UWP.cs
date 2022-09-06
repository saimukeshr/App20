using App20.Interfaces;
using App20.UWP.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCall_UWP))]
namespace App20.UWP.Dependency
{
    public class PhoneCall_UWP : IPhoneCall
    {
        public void MakePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
                PhoneCallManager.ShowPhoneCallUI(number, "DialerName");
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
           
        }
            
    }
}
