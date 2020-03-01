using HotelReservationManager.Models.Clients;
using HotelReservationManager.Models.Filters;
using HotelReservationManager.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationsManager.Models.Clients
{
    public class ClientsIndexVM
    {
        public PagerVM Pager { get; set; }
        public List<ClientsVM> Items { get; set; }

        public ClientsFilter Filter { get; set; }
    }
}