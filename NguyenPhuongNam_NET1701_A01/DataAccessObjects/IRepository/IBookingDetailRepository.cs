using BusinessObjects;

namespace DataAccessObjects.IRepository
{
    public interface IBookingDetailRepository
    {
        List<BookingDetail>? GetBookDetailByBookingReservationID(string id);
        List<BookingDetail> SearchBookingDetail(string searchValue);
    }
}
