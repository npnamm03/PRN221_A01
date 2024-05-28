using BusinessObjects;
using DataAccessObjects;
using DataAccessObjects.IRepository;

namespace DataAccess.Repository
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public List<BookingDetail>? GetBookDetailByBookingReservationID(string id)
        {
            return BookingDetailDAO.Instance.GetBookDetailByBookingReservationID(id);
        }

        public List<BookingDetail> SearchBookingDetail(string searchValue)
        {
            return BookingDetailDAO.Instance.SearchBookingDetail(searchValue);
        }
    }
}
