using Microsoft.EntityFrameworkCore;
using SCEducationPortal.Data.Context;
using SCEducationPortal.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        private readonly EducationPortalDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        private bool _disposed;

        public RepositoryBase(EducationPortalDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public void AddRange(IEnumerable<T> entity)
        {
            _dbSet.AddRange(entity);
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteBy(int id)
        {
            var entity = Get(id);
            Delete(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }
    }
}
