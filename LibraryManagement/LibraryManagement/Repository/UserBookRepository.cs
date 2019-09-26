using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    public class UserBookRepository<T> : IRepository<T> where T : UserBook
    {
        private DemoContext _context;

        public UserBookRepository(DemoContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.UserBooks.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(T entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Remove(object id)
        {
            var u = _context.UserBooks.Find(id);
            _context.UserBooks.Remove(u);
            _context.SaveChanges();
        }

        public void Remove(T entityToDelete)
        {
            _context.UserBooks.Remove(entityToDelete);
            _context.SaveChanges();
        }
    }
}
