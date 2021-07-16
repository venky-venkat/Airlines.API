
using System;
using System.Collections.Generic;
using System.Text;
using Airlines.BL.BLInterfaces;
using Airlines.DL.Interfaces;
using Airlines.DL.Models;

namespace Airlines.BL.BusnessLogic
{
    public class BookingBusinessLogic : IBookingBL
    {
        private readonly IBooking _bookingBL;
        public BookingBusinessLogic(IBooking booking)
        {
            _bookingBL = booking;
        }
        public int AddBooking(Booking booking)
        {
            return _bookingBL.AddBooking(booking);
        }

        public int CancelBookingByID(int id)
        {
            return _bookingBL.CancelBookingByID(id);
        }

        public int CancelBookingByPNR(string pnr)
        {
            return _bookingBL.CancelBookingByPNR(pnr);
        }

        public List<Booking> GetallBookings()
        {
            return _bookingBL.GetallBookings();
        }

        public Booking GetBookingByID(int Id)
        {
            return _bookingBL.GetBookingByID(Id);
        }

        public List<Booking> GetBookingsByUserID(int userID)
        {
            return _bookingBL.GetBookingsByUserID(userID);
        }

        public int UpdateBooking(Booking booking)
        {
            return _bookingBL.UpdateBooking(booking);
        }
    }
}
