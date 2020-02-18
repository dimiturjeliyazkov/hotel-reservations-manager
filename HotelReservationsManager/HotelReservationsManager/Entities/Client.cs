using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManager.Entities
{
    public class Client
    {
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public bool IsAdult { get; set; }
    }
}
