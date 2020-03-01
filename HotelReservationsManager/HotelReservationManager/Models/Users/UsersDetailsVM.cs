using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationsManager.Models
{
    public class UsersDetailsVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsActiveAccount { get; set; }
        public DateTime DateOfDismissal { get; set; }
    }
}