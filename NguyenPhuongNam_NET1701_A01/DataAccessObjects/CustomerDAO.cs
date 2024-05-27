using BusinessObjects;
using DataAccessObjects.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace DataAccessObjects
{
    public class CustomerDAO
    {
        private static CustomerDAO? instance;
        private static readonly object instanceLook = new object();
        public CustomerDAO() { }
        public static CustomerDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                }
                return instance;
            }
        }
        public Role CheckLogin(string email, string password)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Path.Combine(
                Directory
                .GetParent(Directory
                .GetParent(Directory
                .GetParent(Directory
                .GetParent(Directory
                .GetCurrentDirectory()).FullName).FullName).FullName).FullName, "DataAccessObjects"))
                .AddJsonFile("appsettings.json", true, true).Build();
            var user = configuration.GetSection("AdminAccount:Email").Value;
            var pass = configuration.GetSection("AdminAccount:Password").Value;
            using var db = new FuminiHotelManagementContext();
            if (email.Equals(user) && password.Equals(pass))
            {
                return Role.Admin;
            }
            else
            {
                Customer? result = db.Customers.FirstOrDefault(m => m.EmailAddress.Equals(email) && m.Password.Equals(password));
                return result != null ? Role.Customer : Role.None;
            }
        }
        public IEnumerable<Customer> GetAll()
        {
            var listCustomer = new List<Customer>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                listCustomer = db.Customers.Include(a => a.BookingReservations).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCustomer;
        }
        public List<Customer> GetCustomerByCondition(Expression<Func<Customer, bool>> condition)
        {
            using var db = new FuminiHotelManagementContext();
            var customer = db.Customers.Include(a => a.BookingReservations).Where(condition).ToList();
            return customer;
        }

        public bool UpdateCustomer(Customer customerUpdate)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.Customers.Update(customerUpdate);
                var result = db.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CreateCustomer(Customer customerCreate)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                db.Customers.Add(customerCreate);
                var result = db.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Customer> SearchCustomer(string searchValue)
        {
            var listCustomer = new List<Customer>();
            try
            {
                using var db = new FuminiHotelManagementContext();
                listCustomer = db.Customers.Include(a => a.BookingReservations).Where(a => a.CustomerFullName.Contains(searchValue) ||
                a.EmailAddress.Contains(searchValue)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCustomer;
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                using var db = new FuminiHotelManagementContext();
                var customer = db.Customers.FirstOrDefault(a => a.CustomerId == id);
                db.Customers.Remove(customer);
                var result = db.SaveChanges();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CheckExist(string telephone, string email)
        {
            using var db = new FuminiHotelManagementContext();
            var customer = db.Customers.FirstOrDefault(u => u.Telephone.Equals(telephone) || u.EmailAddress.Equals(email));
            if(customer != null) return false;
            return true;
        }
    }
}
