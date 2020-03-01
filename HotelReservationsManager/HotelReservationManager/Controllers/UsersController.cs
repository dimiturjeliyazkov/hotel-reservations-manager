using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using HotelReservationManager.Data;
using HotelReservationManager.Models;
using HotelReservationsManager;
using HotelReservationsManager.Entities;
using HotelReservationsManager.Models;
using HotelReservationsManager.Repository;

namespace HotelReservationManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserRepository _userRepository;

        public UsersController()
        {
            this._userRepository = new UserRepository(new HotelReservationManagerDb());
        }

        public ActionResult AdminIndex(UsersIndexVM model)
        {
          //  if (HotelReservationsManager.Models.AuthenticationManager.LoggedUser == null)
             //   return RedirectToAction("Login", "Home");

            model.Pager = model.Pager ?? new PagerVM();
            model.Pager.Page = model.Pager.Page <= 0 ? 1 : model.Pager.Page;
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0 ? 10 : model.Pager.ItemsPerPage;

            model.Filter = model.Filter ?? new UsersFilter();

            bool emptyUsername = string.IsNullOrWhiteSpace(model.Filter.Username);
            bool emptyForeName = string.IsNullOrWhiteSpace(model.Filter.FirstName);
            bool emptyLastName = string.IsNullOrWhiteSpace(model.Filter.LastName);
            bool emptyEmailName = string.IsNullOrWhiteSpace(model.Filter.Email);
           
            IQueryable<User> query = this._userRepository.GetAll(u =>
                (emptyUsername || u.UserName.Contains(model.Filter.Username)) &&
                (emptyForeName || u.Forename.Contains(model.Filter.FirstName)) &&
                (emptyLastName || u.SurName.Contains(model.Filter.LastName)) &&
                (emptyEmailName || u.Email.Contains(model.Filter.Email)));

            model.Pager.PagesCount = (int)Math.Ceiling(query.Count() / (double)model.Pager.ItemsPerPage);

            query = query.OrderBy(u => u.Id).Skip((model.Pager.Page - 1) * model.Pager.ItemsPerPage).Take(model.Pager.ItemsPerPage);

            model.Items = query.Select(u => new UsersVM
            {
                Id = u.Id,
                Username = u.UserName,
                FirstName = u.Forename,
                LastName = u.SurName,
                Email = u.Email
            }).ToList();

            return View(model);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int? id)
        {
            UsersEditVM item;

            if (id == null)
            {
                item = new UsersEditVM();
            }
            else
            {
                User user = this._userRepository.GetOne(id.Value);

                item = new UsersEditVM
                {
                    Id = id.Value,
                    FirstName = user.Forename,
                    LastName = user.SurName,
                    Username = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                };
            }

            HotelReservationManagerDb context = new HotelReservationManagerDb();

            context.Dispose();

            return View(item);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Edit(UsersEditVM model)
        {
            User user = new User
            {
                Id = model.Id,
                Forename = model.FirstName,
                SurName = model.LastName,
                UserName = model.Username,
                Password = model.Password,
                Email = model.Email
            };

            if (user.Id > 0)
                this._userRepository.Update(user);
            else this._userRepository.Add(user);

            return RedirectToAction("AdminIndex");
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Delete(int id)
        {
            User user = this._userRepository.GetOne(id);
            this._userRepository.Remove(user);

            return RedirectToAction("AdminIndex");
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Add()
        {
            UsersEditVM item;
                item = new UsersEditVM();
            

            HotelReservationManagerDb context = new HotelReservationManagerDb();

            context.Dispose();

            return View(item);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Add(UsersEditVM model)
        {
            User user = new User
            {
                Id = model.Id,
                Forename = model.FirstName,
                MiddleName = model.SecondName,
                SurName = model.LastName,
                UserName = model.Username,
                Password = model.Password,
                Email = model.Email
            };

             this._userRepository.Add(user);

            return RedirectToAction("AdminIndex");
        }
    }
}