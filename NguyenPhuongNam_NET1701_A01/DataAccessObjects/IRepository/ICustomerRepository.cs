using BusinessObjects;
using DataAccessObjects.Enum;
using System.Linq.Expressions;

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
