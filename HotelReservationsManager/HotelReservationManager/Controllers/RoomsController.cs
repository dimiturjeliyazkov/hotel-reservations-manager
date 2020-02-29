using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationManager.Controllers
{
    public class RoomsController: Controller
    {
        public ActionResult RoomIndex()
        {
            return View();
        }
    }
}