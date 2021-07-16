using Airlines.DL.DBcontext;
using Airlines.DL.Interfaces;
using Airlines.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Airlines.DL.Repositories
{
    public class FlightRepository : IFlight
    {
        private readonly AirlinesDBContext _DB;
        public FlightRepository(AirlinesDBContext airlinesDBContext)
        {
            _DB = airlinesDBContext;
        }
        public int Addflight(Flight flight)
        {
            _DB.Flights.Add(flight);
            return _DB.SaveChanges();
        }

        public void Deleteflight(int id)
        {
            var result = GetFlightByID(id);
            if (result != null)
            {
                _DB.Flights.Remove(result);
            }
        }

        public List<Flight> GetFlightByFromandTo(string from, string to)
        {
            var result = _DB.Flights.Where(x=>x.From == from && x.To == to).ToList<Flight>();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public Flight GetFlightByID(int ID)
        {
            return _DB.Flights.FirstOrDefault(x => x.Id == ID);
        }

        public List<Flight> GetFlights()
        {
            var result = _DB.Flights.ToList<Flight>();
            return result;
        }

        public int UpdateFlight(Flight flight)
        {

            var res = GetFlightByID(flight.Id);
            if (res != null)
            {
                res.AirlineID = flight.AirlineID;
                res.Flightname = flight.Flightname;
                res.From = flight.From;
                res.Landing = flight.Landing;
                res.Meals = flight.Meals;
                res.Numberofbusinessseats = flight.Numberofbusinessseats;
                res.Numberofnonbusinessseats = flight.Numberofnonbusinessseats;
                res.Numberofrows = flight.Numberofrows;
                res.Scheduling = flight.Scheduling;
                res.Takeoff = flight.Takeoff;
                res.To = flight.To;
                res.Totalcost = flight.Totalcost;
                _DB.SaveChanges();
                return 1;
            }

            return 0;
        }
    }
}
