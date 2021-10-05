using Microsoft.EntityFrameworkCore;
using SCEducationPortal.Data.Context;
using SCEducationPortal.Data.Entities;
using SCEducationPortal.Data.Interfaces.CategoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCEducationPortal.Data.Repositories.CategoryRepositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly EducationPortalDbContext _dbContext;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(EducationPortalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Category>();
        }

        public IQueryable<Category> GetCategories()
        {
            return _dbSet.Where(c => c.IsActive == true);
        }
    }
}
