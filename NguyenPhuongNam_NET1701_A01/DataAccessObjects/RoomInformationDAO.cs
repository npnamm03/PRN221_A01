using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RoomInformationDAO : GenericDAO<RoomInformation>
    {
        public RoomInformationDAO(FuminiHotelManagementContext context) : base(context)
        {

        }
    }
}
