using BusinessObjects;
using DataAccessObjects.Admin;
using DataAccessObjects.Enum;
using DataAccessObjects.IRepository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        private AdminAccount _admin;

        public CustomerRepository(AdminAccount admin)
        {
            _admin = admin;
        }

        public Role? CheckLogin(string email, string password)
        {
            if (email.Equals(_admin.AdminEmail?.ToString()) && password.Equals(_admin.AdminPassword?.ToString()))
            {
                return Role.Admin;
            }

            var allCus = CustomerDAO.Instance.GetAll();
            if (!allCus.Where(u => u.EmailAddress.Equals(email) && u.Password.Equals(password)).ToList().IsNullOrEmpty())
            {
                return Role.Customer;
            }

            return Role.None;
        }

        public ICollection<Customer> GetAllCustomers()
        {
            var allCus = CustomerDAO.Instance.GetAll();
            return allCus;
        }

        public ICollection<Customer> GetCustomerByCondition(Expression<Func<Customer, bool>> condition)
        {
            return CustomerDAO.Instance.GetByCondition(condition);
        }

        public bool AddCustomer(Customer customer)
        {
            var checkExist = GetCustomerByCondition(u => u.CustomerId.Equals(customer.CustomerId));
            if (checkExist != null) return false;

            var result = CustomerDAO.Instance.Add(customer);
            return result;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var checkExist = GetCustomerByCondition(u => u.CustomerId.Equals(customer.CustomerId)).FirstOrDefault();
            if (checkExist == null) return false;

            checkExist.CustomerFullName = customer.CustomerFullName;
            checkExist.Telephone = customer.Telephone;
            checkExist.CustomerBirthday = customer.CustomerBirthday;
            var result =  CustomerDAO.Instance.Update(checkExist);

            return result;
        }

        public bool DeleteCustomer(int id)
        {
            var checkExist = GetCustomerByCondition(u => u.CustomerId.Equals(id)).FirstOrDefault();
            if (checkExist == null) return false;

            var result = CustomerDAO.Instance.Delete(checkExist);

            return result;
        }

        public ICollection<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
