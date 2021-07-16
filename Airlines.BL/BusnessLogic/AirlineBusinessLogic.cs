using Airlines.BL.BLInterfaces;
using Airlines.BL.DTO;
using Airlines.DL.Interfaces;
using Airlines.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airlines.BL.BusnessLogic
{
    public class AirlineBusinessLogic : IAirlineBL
    {
        private readonly IAirlines _airlineDL;

        public AirlineBusinessLogic(IAirlines airlineDL)
        {
            _airlineDL = airlineDL; ;
        }

        public Airline AddAirline(AirlineDTO airline)
        {
            Airline al = new Airline()
            {
                AirlineName = airline.AirlineName,
                Contactaddress = airline.Contactaddress,
                Contactnumber = airline.Contactnumber,
                Logopath = airline.Logopath
            };
           return _airlineDL.AddAirline(al);
        }

        public void DeleteAirline(int id)
        {
            _airlineDL.DeleteAirline(id);
        }

        public AirlineDTO GetAirlinesbyID(int id)
        {
            var result = _airlineDL.GetAirlinesbyID(id);
            if (result != null)
            {
                AirlineDTO airlineDTO = new AirlineDTO()
            {
                AirlineName = result.AirlineName,
                Contactaddress = result.Contactaddress,
                Contactnumber = result.Contactnumber,
                Logopath = result.Logopath
            };
            return airlineDTO;
            }
            else
            {
                return null;
            }
            
        }

        public List<AirlineDTO> GetallAirlines()
        {
            var v = _airlineDL.GetallAirlines();
            var al = new List<AirlineDTO>();
            
            foreach (var vv in v)
            {
                var a = new AirlineDTO()
                {
                    AirlineName = vv.AirlineName,
                    Contactaddress = vv.Contactaddress,
                    Contactnumber = vv.Contactnumber,
                    Logopath = vv.Logopath
                };
                al.Add(a);
            }
            return al;
        }

        public Airline UpdateAirline(AirlineDTO airline)
        {
            Airline al = new Airline()
            {
                AirlineName = airline.AirlineName,
                Contactaddress = airline.Contactaddress,
                Contactnumber = airline.Contactnumber,
                Logopath = airline.Logopath
            };
            return _airlineDL.UpdateAirline(al);
        }
    }
}
