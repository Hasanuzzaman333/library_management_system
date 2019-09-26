using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    public class UserRepository<T> : IRepository<T> where T : User
    {
        private DemoContext _context;
        
        public UserRepository(DemoContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(T entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Remove(object id)
        {
            var u = _context.Users.Find(id);
            _context.Users.Remove(u);
            _context.SaveChanges();
        }

        public void Remove(T entityToDelete)
        {
            _context.Users.Remove(entityToDelete);
            _context.SaveChanges();
        }
    }
}
