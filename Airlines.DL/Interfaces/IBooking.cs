using Airlines.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Airlines.DL.Interfaces
{
    public interface IBooking
    {
        public List<Booking> GetallBookings();
        public Booking GetBookingByID(int Id);
        public List<Booking> GetBookingsByUserID(int userID);
        public int AddBooking(Booking booking);
        public int UpdateBooking(Booking booking);
        public int CancelBookingByID(int id);
        public int CancelBookingByPNR(string pnr);
    }
}
