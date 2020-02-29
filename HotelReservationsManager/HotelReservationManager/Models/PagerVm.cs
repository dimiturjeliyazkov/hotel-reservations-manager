using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationsManager.Models
{
    public class PagerVM
    {
        public int PagesCount { get; set; }

        public int Page { get; set; }

        public int ItemsPerPage { get; set; }
    }
}