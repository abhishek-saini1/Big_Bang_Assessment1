using Hotel_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Repository
{
    public interface IRepository
    {
       //for Hotel 
        public IEnumerable<Hotel> getelements();
         public void postelements(Hotel hotel);

        public void delete(int id);
        public void update(int id, Hotel hotel);



        //for Room
        public IEnumerable<Room> getelementfromroom();
        public void insert(Room room);
        public void deleteinroom(int id);
        public void updateinroom(int id, Room room);
    }
}
