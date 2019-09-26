using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Remove(object id);

        void Remove(T entityToDelete);

        void Edit(T entityToUpdate);
    }
}
