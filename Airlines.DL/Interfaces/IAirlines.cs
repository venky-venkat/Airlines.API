using System;
using System.Collections.Generic;
using System.Text;
using Airlines.DL.Models;
namespace Airlines.DL.Interfaces
{
    public interface IAirlines
    {
        public List<Airline> GetallAirlines();
        public Airline GetAirlinesbyID(int id);
        public Airline AddAirline(Airline airline);
        public Airline UpdateAirline(Airline airline);
        public void DeleteAirline(int id);
    }
}
