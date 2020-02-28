using HotelReservationsManager.Entities;
using HotelReservationsManager.Repository;

namespace HotelReservationsManager.Services
{
    public class AuthenticationService
    {
        public User LoggedUser { get; private set; }
        public void AuthenticateUser(string username, string password)
        {
            UserRepository userRepo = new UserRepository(new HotelReservationManagerDb());
            this.LoggedUser = userRepo.GetOne(u => u.UserName == username && u.Password == password);
        }
    }
}
