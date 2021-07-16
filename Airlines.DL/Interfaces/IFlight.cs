using System;
using System.Collections.Generic;
using System.Text;
using Airlines.DL.Models;
namespace Airlines.DL.Interfaces
{
    public interface IFlight
    {
        public List<Flight> GetFlights();
        public Flight GetFlightByID(int ID);
        public List<Flight> GetFlightByFromandTo(string from, string to);
        public int Addflight(Flight flight);
        public int UpdateFlight(Flight flight);
        public void Deleteflight(int id);

    }
}
