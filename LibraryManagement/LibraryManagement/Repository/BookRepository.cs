using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    public class BookRepository<T> : IRepository<T> where T : Book
    {
        private DemoContext _context;

        public BookRepository(DemoContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public void Edit(T entityToUpdate)
        {
            throw new NotImplementedException();
        }

        public void Remove(object id)
        {
            var u = _context.Books.Find(id);
            _context.Books.Remove(u);
            _context.SaveChanges();
        }

        public void Remove(T entityToDelete)
        {
            _context.Books.Remove(entityToDelete);
            _context.SaveChanges();
        }
    }
}
