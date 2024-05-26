using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BookingDetailDAO: GenericDAO<BookingDetail>
    {
        public BookingDetailDAO(FuminiHotelManagementContext context) : base(context)
        {

        }
    }
}
