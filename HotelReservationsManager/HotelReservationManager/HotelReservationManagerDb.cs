using HotelReservationsManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationsManager
{
    public class HotelReservationsManagerDb:DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarsManagerDb;");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
