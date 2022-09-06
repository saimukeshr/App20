using App20.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App20.Services
{
    public class DialogueService : IDialogueService
    {
        public void DialogueBox(string title, string message, string buttonText)
        {
            Application.Current.MainPage.DisplayAlert(title, message, buttonText);
        }
    }
}
