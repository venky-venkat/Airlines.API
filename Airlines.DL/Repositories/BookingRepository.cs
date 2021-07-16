using Airlines.DL.DBcontext;
using Airlines.DL.Interfaces;
using Airlines.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Airlines.DL.Repositories
{
    public class BookingRepository : IBooking
    {

        private readonly AirlinesDBContext _DB;
        public BookingRepository(AirlinesDBContext airlinesDBContext)
        {
            _DB = airlinesDBContext;
        }
        public int AddBooking(Booking booking)
        {
            _DB.Bookings.Add(booking);
            return _DB.SaveChanges();
        }

        public int CancelBookingByID(int id)
        {
            var result = _DB.Bookings.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.IsCancel = true;
                return _DB.SaveChanges();
            }
            return 0;
        }

        public int CancelBookingByPNR(string pnr)
        {
            var result = _DB.Bookings.FirstOrDefault(x => x.PNR == pnr);
            if (result != null)
            {
                result.IsCancel = true;
                return _DB.SaveChanges();
            }
            return 0;
        }

        public List<Booking> GetallBookings()
        {
            return _DB.Bookings.Where(x => x.IsCancel == false).ToList<Booking>();
        }

        public Booking GetBookingByID(int Id)
        {
            var result = _DB.Bookings.FirstOrDefault(x => x.Id == Id );
            return result;
        }

        public List<Booking> GetBookingsByUserID(int userID)
        {
            return _DB.Bookings.Where(x => x.IsCancel == false && x.UserID == userID).ToList<Booking>();
        }

        public int UpdateBooking(Booking booking)
        {
            var result = GetBookingByID(booking.Id);
            if (result != null)
            {
                result.PassengerName = booking.PassengerName;
                result.Phone = booking.Phone;
                result.EmailId = booking.EmailId;
                return _DB.SaveChanges();
            }
            return 0;
        }
    }
}
