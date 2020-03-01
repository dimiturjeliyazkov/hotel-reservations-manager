using HotelReservationsManager.Models.Filters;
using HotelReservationsManager.Models.Rooms;
using System.Collections.Generic;

namespace HotelReservationsManager.Models.Rooms
{
    public class RoomIndexVM
    {
        public PagerVM Pager { get; set; }
        public List<RoomsVM> Items { get; set; }

        public RoomsFilter Filter { get; set; }
    }
}