using BusinessObjects;
using DataAccessObjects.Admin;
using DataAccessObjects.Enum;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CustomerDAO: GenericDAO<Customer>
    {
        public CustomerDAO(FuminiHotelManagementContext context) : base(context)
        {

        }
    }
}
