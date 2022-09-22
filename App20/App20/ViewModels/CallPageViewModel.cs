using App20.Interfaces;
using App20.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class CallPageViewModel : BaseViewModel
    {
        #region Properties
        public DialogueService DisplayBox;

        private string Displaytext { get; set; }
        public string DisplayText
        {
            get { return Displaytext; }
            set
            {
                if (Displaytext != value)
                {
                    Displaytext = value;
                }
                OnPropertyChanged();
                DelCharCommand.ChangeCanExecute();
            }
        }

        public Command CallCommand { get; set; }
        public Command AddCharCommand { get; set; }
        public Command DelCharCommand { get; set; }

        #endregion

        // Constructor
        public CallPageViewModel()
        {
            DisplayBox = new DialogueService();
            CallCommand = new Command(() => CallbuttonCommand());
            try
            {
                // Add Character method
                AddCharCommand = new Command<string>((key) =>
                {
                    DisplayText += key;
                });

                //Deleter Char Method
                DelCharCommand = new Command(() =>
                {
                    DisplayText = DisplayText.Substring(0, DisplayText.Length - 1);
                }
                );
            }
            catch (Exception)
            {
            }
        }

        #region Methods

        // Method to call Dependency service  for enabling call function
        private void CallbuttonCommand()
        {
            if (string.IsNullOrEmpty(DisplayText) || DisplayText.Length <= 5)
                DisplayBox.DialogueBox("Alert", "Please Enter a Valid Number", "Ok");
            else
            DependencyService.Get<IPhoneCall>().MakePhoneCall(DisplayText);

            Interfaces.ILogger logger = DependencyService.Get<ILogManager>().GetLog();
            logger.Info("Call Method Inititated");
        }

        #endregion
    }
}
