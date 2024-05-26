using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RoomTypeDAO : GenericDAO<RoomType>
    {
        public RoomTypeDAO(FuminiHotelManagementContext context) : base(context)
        {

        }
    }
}
