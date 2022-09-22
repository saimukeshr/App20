﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App20.Models
{
    public class Details
    {
        [PrimaryKey][AutoIncrement]
        public int Id { get; set; }

        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
    }

        

    public partial class OrderObject
    {
        public List<Details> Info { get; set; }
    }
}
