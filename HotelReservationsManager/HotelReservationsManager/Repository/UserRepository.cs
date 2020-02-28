using HotelReservationsManager.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelReservationsManager.Repository
{
    public class UserRepository
    {
        private readonly HotelReservationManagerDb _dbContext;

        public UserRepository(HotelReservationManagerDb dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<User> GetAll()
        {
            return this._dbContext.Users.AsQueryable();
        }

        public IQueryable<User> GetAll(Expression<Func<User, bool>> predicate)
        {
            return this._dbContext.Users.Where(predicate).AsQueryable();
        }

        public User GetOne(int id)
        {
            return this._dbContext.Users.Find(id);
        }

        public User GetOne(Expression<Func<User, bool>> predicate)
        {
            return this._dbContext.Users.FirstOrDefault(predicate);
        }

        public void Add(User entity)
        {
            this._dbContext.Users.Add(entity);
            this._dbContext.SaveChanges();
        }

        public void Update(User entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
            this._dbContext.SaveChanges();
        }

        public void Remove(User entity)
        {
            this._dbContext.Users.Remove(entity);
            this._dbContext.SaveChanges();
        }

        public int Count()
        {
            return this._dbContext.Users.Count();
        }

        public int Count(Expression<Func<User, bool>> predicate)
        {
            return this._dbContext.Users.Count(predicate);
        }
    }
}
