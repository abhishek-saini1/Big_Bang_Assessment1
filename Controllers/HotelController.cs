using Hotel_Management.Models;
using Hotel_Management.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;

namespace Hotel_Management.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IRepository _irepository;
        public HotelController(IRepository repository)
        {
            
            _irepository = repository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> gett()
        {

            try
            {
                var g = _irepository.getelements();
                return Ok(g);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

           
        }

        [HttpPost]
        public void post(Hotel hotel)
        {
            try
            {
                _irepository.postelements(hotel);
            }
            catch (Exception ex)
            {
                 BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public ActionResult<IEnumerable<Hotel>> delete(int id)
        {

                _irepository.delete(id);
            return Ok();
            
          
            
        }
        [HttpPut]
        public ActionResult<IEnumerable<Hotel>> update(int id, Hotel hotel)
        {
            _irepository.update(id, hotel);
            return Ok();
        }
    }
}
