using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManager.Entities
{
    public class Reservation
    {
        public Room ReservedRoom { get; set; }
        public User ReservationMaker { get; set; }
        public List<Client> ClientsInTheRoom { get; set; }
        public DateTime DateОfАccommodation { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsbreakfastIncluded { get; set; }
        public bool AllInclusive { get; set; }
        public decimal DueAmount { get; set; }

    }
}
