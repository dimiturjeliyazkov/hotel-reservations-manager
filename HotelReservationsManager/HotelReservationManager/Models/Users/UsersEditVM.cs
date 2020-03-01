using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HotelReservationsManager.Models
{
    public class UsersEditVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsActiveAccount { get; set; }
        public DateTime DateOfDismissal { get; set; }
    }
}
