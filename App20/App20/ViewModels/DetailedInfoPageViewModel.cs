using App20.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App20.ViewModels
{
    public class DetailedInfoPageViewModel : BaseViewModel
    {
        public List<Details> Info { get; }

        public DetailedInfoPageViewModel()
        {
            
        }

        public DetailedInfoPageViewModel(List<Details> Users)
        {
            
            Info = Users;

        }
    }
}
