using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BookingReservationDAO: GenericDAO<BookingReservation>
    {
        public BookingReservationDAO(FuminiHotelManagementContext context) : base(context)
        {

        }
    }
}
