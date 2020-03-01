using HotelReservationsManager.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationsManager.Models.Rooms
{
    public class RoomsEditVM
    {
        public int Capacity { get; set; }
        public RoomTypeEnum Type { get; set; }
        public bool IsFree { get; set; }
        public decimal PriceForAdult { get; set; }
        public decimal PriceForChild { get; set; }
        public int Id { get; set; }
    }
}