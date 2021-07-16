using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airlines.BL.BLInterfaces;
using Airlines.DL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airlines.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        // GET: api/<BookingController>
        private readonly IBookingBL _bookingBL;
        public BookingController(IBookingBL bookingBL)
        {
            _bookingBL = bookingBL;
        }
        [HttpGet]
        public List<Booking> Get()
        {
            return _bookingBL.GetallBookings();
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result =   _bookingBL.GetBookingByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Invalid booking id");
        }

        [HttpGet("GetbyuserID/{userid}")]
        [ActionName("History")]
        public IActionResult GetbyuserID(int userid)
        {
            var result = _bookingBL.GetBookingsByUserID(userid);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No Booking Found");
        }

        // POST api/<BookingController>
        [HttpPost]
        public IActionResult Post([FromBody] Booking booking)
        {
            var result = _bookingBL.AddBooking(booking);
            if (result > 0)
            {
                return Created(HttpContext.Request.Scheme + ":/" + HttpContext.Request.Host + "/" + HttpContext.Request.Path + "/"
                    + booking.Id , booking);
            }
            return BadRequest();
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Booking booking)
        {
            var result = _bookingBL.UpdateBooking(booking);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookingBL.CancelBookingByID(id);
            return Ok();
        }

        [HttpDelete("{Pnr}")]
        public IActionResult Delete(string Pnr)
        {
            _bookingBL.CancelBookingByPNR(Pnr);
            return Ok();
        }
    }
}
