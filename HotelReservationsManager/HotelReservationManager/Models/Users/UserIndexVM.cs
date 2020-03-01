
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationsManager.Models
{
    public class UsersIndexVM
    {
        public PagerVM Pager { get; set; }
        public List<UsersVM> Items { get; set; }

        public UsersFilter Filter { get; set; }
    }
}