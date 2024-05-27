using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepository
{
    public interface IBookingReservationRepository
    {
        IEnumerable<BookingReservation> GetAllBookingReservation();
        IEnumerable<BookingReservation> GetAllBookingReservationByDate(DateTime startDate, DateTime endDate);
        List<BookingReservation>? GetBookingReservationByCustomerID(string id);
        List<BookingReservation> SearchBookingReservation(string searchValue);
    }
}
