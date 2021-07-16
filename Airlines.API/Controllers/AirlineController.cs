using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airlines.BL.BLInterfaces;
using Airlines.BL.DTO;
using Airlines.DL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airlines.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineBL _airlineBL;
        public AirlineController(IAirlineBL airlineBL)
        {
            _airlineBL = airlineBL;
        }
        // GET: api/<AirlineController>
        [HttpGet]
        public IEnumerable<AirlineDTO> Get()
        {
            return _airlineBL.GetallAirlines();
        }

        // GET api/<AirlineController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           var result =  _airlineBL.GetAirlinesbyID(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("No result found");
            }
        }

        // POST api/<AirlineController>
        [HttpPost]
        public Airline Post([FromBody] AirlineDTO airlineDTO)
        {
            return _airlineBL.AddAirline(airlineDTO);
        }

        // PUT api/<AirlineController>/5
        [HttpPut]
        public Airline Put([FromBody] AirlineDTO airlineDTO)
        {
            return _airlineBL.UpdateAirline(airlineDTO);
        }

        // DELETE api/<AirlineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _airlineBL.DeleteAirline(id);
        }
    }
}
