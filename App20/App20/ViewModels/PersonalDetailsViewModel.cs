using App20.Models;
using App20.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App20.ViewModels
{
    public class PersonalDetailsViewModel : BaseViewModel
    {
        public ObservableCollection<PersonalDetailsModel> DetailsList { get; set; }

        private List<PersonalDetailsModel> sortedList { get; set; }
        public List<PersonalDetailsModel> SortedList
        {
            get { return sortedList; }
            set
            {
                if (sortedList != value)
                {
                    sortedList = value;
                }
                OnPropertyChanged("SortedList");
            }
        }

        public Command AddItemCommand { get; set; }

        public Command DeleteItemCommand { get; set; }

        public Command UpdateItemCommand { get; set; }

        public PersonalDetailsModel SelectedItem { get; set; }

        //bool isMenuItemEnabled = true;
        //public bool IsMenuItemEnabled
        //{
        //    get { return isMenuItemEnabled; }
        //    set
        //    {
        //        isMenuItemEnabled = value;
        //        DeleteItemCommand.ChangeCanExecute();
        //    }
        //}

        private string firstName { get; set; }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                }
                OnPropertyChanged("FirstName");
            }
        }

        public PersonalDetailsViewModel()
        {
            AddItemCommand = new Command(() => AddCommand());

            DeleteItemCommand = new Command(() => DeleteCommand());

            UpdateItemCommand = new Command(() => UpdateCommand());

            SortedList = new List<PersonalDetailsModel>();

            DetailsList = new ObservableCollection<PersonalDetailsModel>();
            DetailsList.Add(new PersonalDetailsModel() { Id = 1, FirstName = "JOHN"});
            DetailsList.Add(new PersonalDetailsModel() { Id = 2, FirstName = "BILL" });
            DetailsList.Add(new PersonalDetailsModel() { Id = 3, FirstName = "KEN" });

            MessagingCenter.Subscribe<AddOrEditDetailsPageViewModel, PersonalDetailsModel>(this, "AddorEditDetails", (page, details) =>
            {
                if (details.Id == 0)
                {
                    details.Id = DetailsList.Count + 1;
                    DetailsList.Add(details);
                }
                else
                {
                    PersonalDetailsModel EditedDetails = DetailsList.Where(det => det.Id == details.Id).FirstOrDefault();

                    //int newIndex = DetailsList.IndexOf(EditedDetails);
                    DetailsList.Remove(EditedDetails);

                    DetailsList.Add(EditedDetails);
                    //int oldIndex = DetailsList.IndexOf(EditedDetails);

                    //DetailsList.Move(oldIndex, newIndex);
                }

                SortedList = DetailsList.OrderBy(x => x.FirstName).ToList();
            });

            SortedList = DetailsList.OrderBy(x => x.FirstName).ToList();

        }

        private void UpdateCommand()
        {

            PersonalDetailsModel Details = DetailsList.Where(det => det.Id == SelectedItem.Id).FirstOrDefault();
            App.Current.MainPage.Navigation.PushAsync(new AddOrEditDetailsPage(Details));
           
        }

        private void DeleteCommand()
        {
            DetailsList.Remove(SelectedItem);
        }

        private void AddCommand()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddOrEditDetailsPage());
;       }
    }
}
