using Hotel_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountController : ControllerBase
    {
        private readonly HotelRoomDbContext dbContext;

        public CountController(HotelRoomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("count")]
        public ActionResult<int> GetAvailableRoomsCount(int Id)
        {

            try
            {
                Hotel w = dbContext.Hotels.FirstOrDefault(h => h.HId == Id);

                if (w== null)
                {
                    return NotFound();
                }

                int countofemptyrooms = dbContext.Rooms.Count(r => r.HotelId == Id && r.RoomAvailable == true);

                return Ok(countofemptyrooms);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
