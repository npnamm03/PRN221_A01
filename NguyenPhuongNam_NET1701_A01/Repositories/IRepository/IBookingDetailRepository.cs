using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IBookingDetailRepository
    {
        Task<IEnumerable<BookingReservation>> GetAll();
        Task<bool> Create(BookingReservation bookingReservation);
        Task<bool> Update(BookingReservation bookingReservation);
        Task<bool> Delete(BookingReservation bookingReservation);
        Task<IEnumerable<BookingReservation>> SearchAny(string searchText);
        IQueryable<BookingReservation> GetByCondition(Expression<Func<BookingReservation, bool>> condition);
    }
}
