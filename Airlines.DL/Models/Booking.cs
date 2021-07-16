using System;
using System.Collections.Generic;
using System.Text;

namespace Airlines.DL.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string FlightID { get; set; }
        public string PassengerName { get; set; }
        public string EmailId {get;set;}
        public string Phone { get; set; }
        public int UserID { get; set; }
        public string PNR { get; set; }
        public Boolean IsPromocodeApplied { get; set; }
        public Boolean IsCancel { get; set; }

    }
}
