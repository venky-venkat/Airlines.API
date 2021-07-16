using Airlines.DL.DBcontext;
using Airlines.DL.Interfaces;
using Airlines.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Airlines.DL.Repositories
{
    public class AirlineRepository : IAirlines
    {
        public readonly AirlinesDBContext _DB;

        public AirlineRepository(AirlinesDBContext airlines)
        {
            _DB = airlines;
        }

        public Airline AddAirline(Airline airline)
        {
            _DB.Airlines.Add(airline);
            _DB.SaveChanges();
            return airline;
        }

        public void DeleteAirline(int id)
        {
            var result = _DB.Airlines.SingleOrDefault(b => b.Id ==id);
            _DB.Airlines.Remove(result);
        }

        public Airline GetAirlinesbyID(int id)
        {
            return _DB.Airlines.FirstOrDefault(x => x.Id == id);
        }

        public List<Airline> GetallAirlines()
        {
            return _DB.Airlines.ToList();
        }

        public Airline UpdateAirline(Airline airline)
        {
            var result = _DB.Airlines.SingleOrDefault(b => b.Id == airline.Id);
            if (result != null)
            {
                result.AirlineName = airline.AirlineName;
                result.Contactaddress = airline.Contactaddress;
                result.Contactnumber = airline.Contactnumber;
                _DB.SaveChanges();
                return airline;
            }
            return null;
        }
    }
}
