using HotelReservationsManager.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelReservationsManager.Repository
{
    public class RoomRepository
    {
        private readonly HotelReservationsManagerDb _dbContext;



        public RoomRepository(HotelReservationsManagerDb dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<Room> GetAll()
        {
            return this._dbContext.Rooms.AsQueryable();
        }

        public IQueryable<Room> GetAll(Expression<Func<Room, bool>> predicate)
        {
            return this._dbContext.Rooms.Where(predicate).AsQueryable();
        }

        public Room GetOne(int id)
        {
            return this._dbContext.Rooms.Find(id);
        }

        public Room GetOne(Expression<Func<Room, bool>> predicate)
        {
            return this._dbContext.Rooms.FirstOrDefault(predicate);
        }

        public void Add(Room entity)
        {
            this._dbContext.Rooms.Add(entity);
            this._dbContext.SaveChanges();
        }

        public void Update(Room entity)
        {
            this._dbContext.Entry(entity).State = EntityState.Modified;
            this._dbContext.SaveChanges();
        }

        public void Remove(Room entity)
        {
            this._dbContext.Rooms.Remove(entity);
            this._dbContext.SaveChanges();
        }

        public int Count()
        {
            return this._dbContext.Rooms.Count();
        }

        public int Count(Expression<Func<Room, bool>> predicate)
        {
            return this._dbContext.Rooms.Count(predicate);
        }
    }
}
