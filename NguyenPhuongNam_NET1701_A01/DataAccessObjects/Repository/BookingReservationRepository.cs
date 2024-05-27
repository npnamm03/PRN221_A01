using BusinessObjects;
using DataAccessObjects.IRepository;

namespace DataAccessObjects.Repository
{
    public class BookingReservationRepository : IBookingReservationRepository
    {

        public IEnumerable<BookingReservation> GetAllBookingReservation()
        {
            return BookingReservationDAO.Instance.GetAllBookingReservation();
        }

        public IEnumerable<BookingReservation> GetAllBookingReservationByDate(DateTime startDate, DateTime endDate)
        {
            return BookingReservationDAO.Instance.GetAllBookingReservationByDate(startDate, endDate);
        }

        public List<BookingReservation>? GetBookingReservationByCustomerID(string id)
        {
            return BookingReservationDAO.Instance.GetBookingReservationByCustomerID(id);
        }

        public List<BookingReservation> SearchBookingReservation(string searchValue)
        {
            return BookingReservationDAO.Instance.SearchBookingReservation(searchValue);
        }
    }
}

