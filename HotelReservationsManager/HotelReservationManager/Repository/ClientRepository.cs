using HotelReservationsManager.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelReservationsManager.Repository
{
    public class ClientRepository
    {
        private readonly HotelReservationsManagerDb _dbContext;

        public ClientRepository(HotelReservationsManagerDb dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<Client> GetAll()
        {
            return this._dbContext.Clients.AsQueryable();
        }

        public IQueryable<Client> GetAll(Expression<Func<Client, bool>> predicate)
        {
            return this._dbContext.Clients.Where(predicate).AsQueryable();
        }

        public Client GetOne(int id)
        {
            return this._dbContext.Clients.Find(id);
        }

        public Client GetOne(Expression<Func<Client, bool>> predicate)
        {
            return this._dbContext.Clients.FirstOrDefault(predicate);
        }

        public void Add(Client entity)
        {
            this._dbContext.Clients.Add(entity);
            this._dbContext.SaveChanges();
        }

        public void Update(Client entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
            this._dbContext.SaveChanges();
        }

        public void Remove(Client entity)
        {
            this._dbContext.Clients.Remove(entity);
            this._dbContext.SaveChanges();
        }

        public int Count()
        {
            return this._dbContext.Clients.Count();
        }

        public int Count(Expression<Func<Client, bool>> predicate)
        {
            return this._dbContext.Clients.Count(predicate);
        }
    }
}