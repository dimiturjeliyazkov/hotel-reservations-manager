using HotelReservationsManager.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationsManager.Models.Filters
{
    public class RoomsFilter
    {
        public int Capacity { get; set; }

        public RoomTypeEnum roomType { get; set; }

        public bool IsFree { get; set; }
    }
}