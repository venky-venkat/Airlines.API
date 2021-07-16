using Airlines.BL.DTO;
using Airlines.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airlines.BL.BLInterfaces
{
   public interface IAirlineBL
    {
        public List<AirlineDTO> GetallAirlines();
        public AirlineDTO GetAirlinesbyID(int id);
        public Airline AddAirline(AirlineDTO airline);
        public Airline UpdateAirline(AirlineDTO airline);
        public void DeleteAirline(int id);
    }
}
