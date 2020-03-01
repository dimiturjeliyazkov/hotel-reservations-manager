using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationsManager.Models.Clients
{
    public class ClientsEditVM
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public bool IsAdult { get; set; }
    }
}