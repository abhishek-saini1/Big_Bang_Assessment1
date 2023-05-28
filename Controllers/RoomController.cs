using Hotel_Management.Models;
using Hotel_Management.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management.Controllers
{
   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRepository _irepository;
        public RoomController(IRepository irepository)
        {
            
            _irepository = irepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Room>> getT()
        {
            try
            {
                var g = _irepository.getelementfromroom();
                return Ok(g);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public void insert(Room room)
        {
            try
            {
                _irepository.insert(room);
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public ActionResult<IEnumerable<Room>> delete(int id)
        {

            _irepository.deleteinroom(id);
            return Ok();



        }
        [HttpPut]
        public ActionResult<IEnumerable<Hotel>> update(int id, Room room)
        {
            try
            {

                _irepository.updateinroom(id, room);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
