using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManager.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public virtual Room ReservedRoom { get; set; }
        public virtual User ReservationMaker { get; set; }
        public virtual List<Client> ClientsInTheRoom { get; set; }
        public virtual DateTime DateОfАccommodation { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual bool IsbreakfastIncluded { get; set; }
        public virtual bool AllInclusive { get; set; }
        public virtual decimal DueAmount { get; set; }

    }
}
