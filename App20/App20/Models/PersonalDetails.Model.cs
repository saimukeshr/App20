using System;
using System.Collections.Generic;
using System.Text;

namespace App20.Models
{
    public class PersonalDetailsModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public PersonalDetailsModel (int id, string firstName)
        {
            Id = id;
            FirstName = firstName;
        }

        public PersonalDetailsModel()
        {
        }
    }
}
