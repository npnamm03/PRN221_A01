using BusinessObjects;
using DataAccessObjects.Enum;
using DataAccessObjects.IRepository;
using System.Linq.Expressions;

namespace DataAccessObjects.Repository
{
    public class CustomerRepository: ICustomerRepository
    {

        public CustomerRepository()
        {
        }

        public Role CheckLogin(string email, string password)
        {
            var result = CustomerDAO.Instance.CheckLogin(email, password);
            return result;
        }

        public IEnumerable<Customer> GetAll()
        {
            var allCus = CustomerDAO.Instance.GetAll();
            return allCus;
        }

        public List<Customer> GetCustomerByCondition(Expression<Func<Customer, bool>> condition)
        {
            return CustomerDAO.Instance.GetCustomerByCondition(condition);
        }

        public bool AddCustomer(Customer customer)
        {

            var result = CustomerDAO.Instance.CreateCustomer(customer);
            return result;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var checkExist = GetCustomerByCondition(u => u.CustomerId.Equals(customer.CustomerId)).FirstOrDefault();
            if (checkExist == null) return false;

            checkExist.CustomerFullName = customer.CustomerFullName;
            checkExist.Telephone = customer.Telephone;
            checkExist.CustomerBirthday = customer.CustomerBirthday;
            var result =  CustomerDAO.Instance.UpdateCustomer(checkExist);

            return result;
        }

        public bool DeleteCustomer(int id)
        {
            var checkExist = GetCustomerByCondition(u => u.CustomerId.Equals(id)).FirstOrDefault();
            if (checkExist == null) return false;

            var result = CustomerDAO.Instance.DeleteCustomer(id);

            return result;
        }

        public bool CheckExist(string telephone, string email)
        {
            return CustomerDAO.Instance.CheckExist(telephone, email);
        }
    }
}
