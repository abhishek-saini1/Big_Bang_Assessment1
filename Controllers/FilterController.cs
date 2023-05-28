using Hotel_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly HotelRoomDbContext _context;

        public FilterController(HotelRoomDbContext context)
        {
            _context = context;
        }

        [HttpGet("{location}/available-rooms")]
        public IActionResult GetAvailableRooms(string location)
        {
            try
            {
                var availableHotels = _context.Rooms
                    .Where(room => room.Hotel.HLocation == location && room.RoomAvailable)
                    .Select(room => room.Hotel)
                    .Distinct()
                    .ToList();

                return Ok(availableHotels);
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }
        }
    }
    
}
