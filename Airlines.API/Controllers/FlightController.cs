using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airlines.BL.BLInterfaces;
using Microsoft.AspNetCore.Mvc;
using Airlines.DL.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airlines.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightBL _flightBL;
        public FlightController(IFlightBL flightBL)
        {
            _flightBL = flightBL;
        }
        // GET: api/<FlightController>
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return _flightBL.GetFlights();
        }

        // GET api/<FlightController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _flightBL.GetFlightByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Invalid ID");
            }
        }

        // POST api/<FlightController>
        [HttpPost]
        public IActionResult Post([FromBody] Flight flight)
        {
            var result = _flightBL.Addflight(flight);
            if (result > 0)
            {
                return Created(HttpContext.Request.Scheme + ":/" + HttpContext.Request.Host + "/" + 
                    HttpContext.Request.Path + "/" + flight.Id,result);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<FlightController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Flight flight)
        {
            var result = _flightBL.UpdateFlight(flight);
            if (result > 0)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<FlightController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _flightBL.Deleteflight(id);
            return NoContent();
        }
    }
}
