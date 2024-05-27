using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepository
{
    public interface IBookingDetailRepository
    {
        List<BookingDetail>? GetBookDetailByBookingReservationID(string id);
        List<BookingDetail> SearchBookingDetail(string searchValue);
    }
}
