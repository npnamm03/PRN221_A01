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
    public class CustomerDAO
    {
        private readonly FuminiHotelManagementContext _context;
        private AdminAccount _admin;
        private static CustomerDAO? instance = null;
        private static object lockObject = new object();

        private CustomerDAO()
        {
        }

        public CustomerDAO(AdminAccount admin, FuminiHotelManagementContext context)
        {
            _admin = admin;
            _context = context;
        }
        public static CustomerDAO Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }

        public Role? CheckLogin(string email, string password)
        {
            if (email.Equals(_admin.AdminEmail?.ToString()) && password.Equals(_admin.AdminPassword?.ToString()))
            {
                return Role.Admin;
            }

            if (!_context.Customers.Where(u => u.EmailAddress.Equals(email) && u.Password.Equals(password)).IsNullOrEmpty())
            {
                return Role.Customer;
            }

            return Role.None;
        }

        public List<Customer> GetAll()
        {
            var allCus = _context.Customers.ToList();
            return allCus;
        }

        public List<Customer> GetCustomerByCondition(Expression<Func<Customer, bool>> condition)
        {
            return _context.Customers.Where(condition).ToList();
        }

        public bool AddCustomer(Customer customer)
        {
            var checkExist = GetCustomerByCondition(u => u.CustomerId.Equals(customer.CustomerId));
            if (checkExist != null) return false;

            _context.Customers.Add(customer);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool UpdateCustomer(Customer customer)
        {
            var checkExist = GetCustomerByCondition(u => u.CustomerId.Equals(customer.CustomerId)).FirstOrDefault();
            if (checkExist == null) return false;

            checkExist.CustomerFullName = customer.CustomerFullName;
            checkExist.Telephone = customer.Telephone;
            checkExist.CustomerBirthday = customer.CustomerBirthday;
            _context.Customers.Update(checkExist);

            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool DeleteCustomer(int id)
        {
            var checkExist = GetCustomerByCondition(u => u.CustomerId.Equals(id)).FirstOrDefault();
            if (checkExist == null) return false;

            _context.Customers.Remove(checkExist);
            var result = _context.SaveChanges();

            return result > 0;
        }
    }
}
