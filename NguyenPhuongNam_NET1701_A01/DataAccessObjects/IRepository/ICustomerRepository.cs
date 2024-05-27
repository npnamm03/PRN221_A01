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
        IEnumerable<Customer> GetAll();
        Role CheckLogin(string email, string password);
        bool UpdateCustomer(Customer customerUpdate);
        bool AddCustomer(Customer customerCreate);
        bool DeleteCustomer(int id);
        List<Customer> GetCustomerByCondition(Expression<Func<Customer, bool>> condition);
        bool CheckExist(string telephone, string email);
    }
}
