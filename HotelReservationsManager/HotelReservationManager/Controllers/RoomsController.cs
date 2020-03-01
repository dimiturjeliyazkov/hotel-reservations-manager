using HotelReservationsManager.Models.Filters;
using HotelReservationsManager.Models.Rooms;
using HotelReservationsManager.Entities;
using HotelReservationsManager.Models;
using HotelReservationsManager.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace HotelReservationsManager.Controllers
{
    public class RoomsController: Controller
    {
        private readonly RoomRepository _roomRepository;

        public RoomsController()
        {
            this._roomRepository = new RoomRepository(new HotelReservationsManagerDb());
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
            

            IQueryable<Room> query = this._roomRepository.GetAll();

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
        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int? id)
        {
            RoomsEditVM item;

            if (id == null)
            {
                item = new RoomsEditVM();
            }
            else
            {
                Room room = this._roomRepository.GetOne(id.Value);

                item = new RoomsEditVM
                {
                    Id = id.Value,
                    Capacity = room.Capacity,
                    Type = room.Type,
                    IsFree =room.IsFree,
                    PriceForAdult =room.PriceForAdult,
                    PriceForChild = room.PriceForChild
                };
            }

            HotelReservationsManagerDb context = new HotelReservationsManagerDb();

            context.Dispose();

            return View(item);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Edit(RoomsEditVM model)
        {
            Room room = new Room
            {
                Id = model.Id,
                Capacity = model.Capacity,
                Type = model.Type,
                IsFree = model.IsFree,
                PriceForAdult = model.PriceForAdult,
                PriceForChild = model.PriceForChild
            };

            if (room.Id > 0)
                this._roomRepository.Update(room);
            else this._roomRepository.Add(room);

            return RedirectToAction("RoomIndex");
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Delete(int id)
        {
            Room room = this._roomRepository.GetOne(id);
            this._roomRepository.Remove(room);

            return RedirectToAction("RoomIndex");
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Add()
        {
            RoomsEditVM item;
                item = new RoomsEditVM();
            

            HotelReservationsManagerDb context = new HotelReservationsManagerDb();

            context.Dispose();

            return View(item);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Add(RoomsEditVM model)
        {
            Room room = new Room
            {
                Id = model.Id,
                Capacity = model.Capacity,
                Type = model.Type,
                IsFree = model.IsFree,
                PriceForAdult = model.PriceForAdult,
                PriceForChild = model.PriceForChild
            };

             this._roomRepository.Add(room);

            return RedirectToAction("RoomIndex");
        }
    }
}
    