using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T Add(T entity);

        void AddRange(IEnumerable<T> entity);

        T Get(int id);

        void Update(T entity);

        void DeleteBy(int id);

        void Delete(T entity);

        int SaveChanges();
    }
}
