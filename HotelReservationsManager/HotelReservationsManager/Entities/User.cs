using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManager.Entities
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsActiveAccount { get; set; }
        public DateTime DateOfDismissal { get; set; }
    }
}
