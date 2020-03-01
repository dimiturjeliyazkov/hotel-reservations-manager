using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationsManager.Models.Filters
{
    public class ClientsFilter
    { 
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public bool IsAdult { get; set; }
    }
}