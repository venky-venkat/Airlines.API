using Airlines.BL.BLInterfaces;
using Airlines.DL.Interfaces;
using Airlines.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airlines.BL.BusnessLogic
{
    public class FlightBusinessLogic : IFlightBL
    {
        private readonly IFlight _flightDL;
        public FlightBusinessLogic(IFlight flight)
        {
            _flightDL = flight;
        }

        public int Addflight(Flight flight)
        {
            return _flightDL.Addflight(flight);
        }

        public void Deleteflight(int id)
        {
            _flightDL.Deleteflight(id);
        }

        public List<Flight> GetFlightByFromandTo(string from, string to)
        {
            return _flightDL.GetFlightByFromandTo(from, to);
        }

        public Flight GetFlightByID(int ID)
        {
            return _flightDL.GetFlightByID(ID);
        }

        public List<Flight> GetFlights()
        {
            return _flightDL.GetFlights();
        }

        public int UpdateFlight(Flight flight)
        {
            return _flightDL.UpdateFlight(flight);
        }
    }
}
