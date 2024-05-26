using BusinessObjects;
using DataAccessObjects.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepository
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        ICollection<Customer> GetCustomerByCondition(Expression<Func<Customer, bool>> condition);
        Role? CheckLogin(string email, string password);
        bool AddCustomer(Customer member);
        bool UpdateCustomer(Customer member);
        bool DeleteCustomer(int id);
    }
}
