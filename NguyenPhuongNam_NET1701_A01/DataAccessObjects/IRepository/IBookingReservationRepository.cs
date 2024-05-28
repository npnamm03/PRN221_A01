using BusinessObjects;

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
