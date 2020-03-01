using HotelReservationManager.Models.Filters;
using HotelReservationManager.Models.Rooms;
using HotelReservationsManager;
using HotelReservationsManager.Entities;
using HotelReservationsManager.Models;
using HotelReservationsManager.Models.Rooms;
using HotelReservationsManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReservationManager.Controllers
{
    public class RoomsController: Controller
    {
        private readonly RoomRepository _userRepository;

        public RoomsController()
        {
            this._userRepository = new RoomRepository(new HotelReservationManagerDb());
        }
        public ActionResult RoomIndex(RoomIndexVM model)
        {
            model.Pager = model.Pager ?? new PagerVM();
            model.Pager.Page = model.Pager.Page <= 0 ? 1 : model.Pager.Page;
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0 ? 10 : model.Pager.ItemsPerPage;

            model.Filter = model.Filter ?? new RoomsFilter();

            bool emptyCapacity = model.Filter.Capacity.Equals(null);
            bool emptyroomType = model.Filter.roomType.Equals(null);
            bool emptyIsFree = model.Filter.IsFree.Equals(null);
            

            IQueryable<Room> query = this._userRepository.GetAll(u =>
                (emptyCapacity || u.Capacity.Equals(model.Filter.Capacity)) &&
                (emptyroomType || u.Type.Equals(model.Filter.roomType)) &&
                (emptyIsFree || u.IsFree.Equals(model.Filter.IsFree)));

            model.Pager.PagesCount = (int)Math.Ceiling(query.Count() / (double)model.Pager.ItemsPerPage);

            query = query.OrderBy(u => u.Id).Skip((model.Pager.Page - 1) * model.Pager.ItemsPerPage).Take(model.Pager.ItemsPerPage);

            model.Items = query.Select(u => new RoomsVM
            {
                Id = u.Id,
                Capacity = u.Capacity,
                Type  = u.Type,
                IsFree = u.IsFree,
                PriceForAdult = u.PriceForAdult,
                PriceForChild = u.PriceForChild 
            }).ToList();

            return View(model);
        }
    }
}