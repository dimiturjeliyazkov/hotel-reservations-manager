using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HotelReservationManager.Models
{
    public class UsersEditVM
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        [DisplayName("First name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}