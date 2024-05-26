using BusinessObjects;
using DataAccessObjects.Admin;
using DataAccessObjects.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class GenericDAO<T> where T : class
    {
        private readonly FuminiHotelManagementContext _context;
        private static GenericDAO<T>? instance = null;
        private static object lockObject = new object();

        private GenericDAO()
        {
        }

        public GenericDAO(FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public static GenericDAO<T> Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new GenericDAO<T>();
                    }
                    return instance;
                }
            }
        }

        public ICollection<T> GetAll()
        {
            var allCus = _context.Set<T>().ToList();
            return allCus;
        }

        public ICollection<T> GetByCondition(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition).ToList();
        }

        public bool Add(T entity)
        {
            _context.Set<T>().Add(entity);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool Update(T entity)
        {
            _context.Set<T>().Update(entity);

            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            var result = _context.SaveChanges();

            return result > 0;
        }
    }
}
