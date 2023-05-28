using Hotel_Management.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel_Management.Repository
{
    public class Repository : IRepository
    {
        private readonly HotelRoomDbContext _context;

        public Repository(HotelRoomDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Hotel> getelements()
        {
            return _context.Hotels.Include(a=>a.Rooms).ToList();
        }

        public void postelements(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if (hotel != null)
            {
                _context.Remove(hotel);
                _context.SaveChanges();
            }
            else
            {

                throw new NotImplementedException("not found");
            }
        }
        public void update(int id, Hotel hotel)
        {
            var e=_context.Hotels.Find(id);
            if (e != null)
            {
                e.HDescription = hotel.HDescription;
                e.HName = hotel.HName;
                e.HLocation = e.HLocation;
                e.HPrice = hotel.HPrice;
                e.HAmenities = hotel.HAmenities;

                _context.SaveChanges();
            }
            else
            {
                throw new NotImplementedException("not found");
            }
            
        }


       


        //for room
        public IEnumerable<Room> getelementfromroom()
        {
            return _context.Rooms.Include(a => a.Hotel).ToList();
        }

        public void insert(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void deleteinroom(int id)
        {
            var r = _context.Rooms.Find(id);
            if (r != null)
            {
                _context.Remove(r);
                _context.SaveChanges();
            }
            else
            {

                throw new NotImplementedException("not found");
            }
        }
        public void updateinroom(int id, Room room)
        {
            var e = _context.Rooms.Find(id);
            if (e != null)
            {
                e.RoomNumber=room.RoomNumber;
                e.RoomAvailable=room.RoomAvailable;
                e.RoomType=room.RoomType;
                

                _context.SaveChanges();
            }
            else
            {
                throw new NotImplementedException("not found");
            }

        }
    }
}
