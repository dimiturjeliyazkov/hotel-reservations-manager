using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using HotelReservationManager.Models.Clients;
using HotelReservationManager.Models.Filters;
using HotelReservationsManager;
using HotelReservationsManager.Entities;
using HotelReservationsManager.Models;
using HotelReservationsManager.Models.Clients;
using HotelReservationsManager.Repository;

namespace HotelReservationManager.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientRepository _clientRepository;

        public ClientsController()
        {
            this._clientRepository = new ClientRepository(new HotelReservationManagerDb());
        }

        public ActionResult ClientIndex(ClientsIndexVM model)
        {
           

            model.Pager = model.Pager ?? new PagerVM();
            model.Pager.Page = model.Pager.Page <= 0 ? 1 : model.Pager.Page;
            model.Pager.ItemsPerPage = model.Pager.ItemsPerPage <= 0 ? 10 : model.Pager.ItemsPerPage;

            model.Filter = model.Filter ?? new ClientsFilter();

            bool emptyUsername = string.IsNullOrWhiteSpace(model.Filter.Forename);
            bool emptyForeName = string.IsNullOrWhiteSpace(model.Filter.MiddleName);
            bool emptyLastName = string.IsNullOrWhiteSpace(model.Filter.SurName);
           

            IQueryable<Client> query = this._clientRepository.GetAll(u =>
                (emptyUsername || u.Forename.Contains(model.Filter.Forename)) &&
                (emptyForeName || u.Forename.Contains(model.Filter.MiddleName)) &&
                (emptyLastName || u.SurName.Contains(model.Filter.SurName)) &&
                (u.IsAdult== true));

            model.Pager.PagesCount = (int)Math.Ceiling(query.Count() / (double)model.Pager.ItemsPerPage);

            query = query.OrderBy(u => u.Id).Skip((model.Pager.Page - 1) * model.Pager.ItemsPerPage).Take(model.Pager.ItemsPerPage);

            model.Items = query.Select(u => new ClientsVM 
            {
                Id = u.Id,
                Forename = u.Forename,
                MiddleName = u.MiddleName,
                SurName = u.SurName,
                Email = u.Email,
                IsAdult = u.IsAdult
            }).ToList();

            return View(model);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int? id)
        {
            ClientsEditVM item;

            if (id == null)
            {
                item = new ClientsEditVM();
            }
            else
            {
                Client u = this._clientRepository.GetOne(id.Value);

                item = new ClientsEditVM
                {
                    Id = u.Id,
                    Forename = u.Forename,
                    MiddleName = u.MiddleName,
                    SurName = u.SurName,
                    Email = u.Email,
                    IsAdult = u.IsAdult
                };
            }

            HotelReservationManagerDb context = new HotelReservationManagerDb();

            context.Dispose();

            return View(item);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Edit(ClientsEditVM u)
        {
            Client Client = new Client
            {
                Id = u.Id,
                Forename = u.Forename,
                MiddleName = u.MiddleName,
                SurName = u.SurName,
                Email = u.Email,
                IsAdult = u.IsAdult
            };

            if (Client.Id > 0)
                this._clientRepository.Update(Client);
            else this._clientRepository.Add(Client);

            return RedirectToAction("ClientIndex");
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Delete(int id)
        {
            Client Client = this._clientRepository.GetOne(id);
            this._clientRepository.Remove(Client);

            return RedirectToAction("ClientIndex");
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Add()
        {
            ClientsEditVM item;
            item = new ClientsEditVM();


            HotelReservationManagerDb context = new HotelReservationManagerDb();

            context.Dispose();

            return View(item);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Add(ClientsEditVM u)
        {
            Client Client = new Client
            {
                Id = u.Id,
                Forename = u.Forename,
                MiddleName = u.MiddleName,
                SurName = u.SurName,
                Email = u.Email,
                IsAdult = u.IsAdult
            };

            this._clientRepository.Add(Client);

            return RedirectToAction("ClientIndex");
        }
    }
}