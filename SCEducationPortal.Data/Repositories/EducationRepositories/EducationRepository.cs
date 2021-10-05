using Microsoft.EntityFrameworkCore;
using SCEducationPortal.Data.Context;
using SCEducationPortal.Data.Entities;
using SCEducationPortal.Data.Interfaces.EducationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCEducationPortal.Data.Repositories.EducationRepositories
{
    public class EducationRepository : RepositoryBase<Education>, IEducationRepository
    {
        private readonly EducationPortalDbContext _dbContext;
        private readonly DbSet<Education> _dbSet;

        public EducationRepository(EducationPortalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Education>();
        }

        public Education GetEducationDetail(int id)
        {
            var data = _dbSet.Where(c => c.Id == id).Include(x => x.EducationContents).ThenInclude(c=>c.EducationContentFiles).Include(c => c.User).FirstOrDefault();
            return data;
        }

        public IQueryable<Education> GetEducations()
        {
            return _dbSet.Include(x => x.User);
        }

        public IQueryable<Education> GetEducations(int userId)
        {
            return _dbSet.Where(c => c.UserId == userId);
        }

        public IQueryable<Education> GetEducations(int skip, int take)
        {
            return _dbSet.Where(c => c.IsActive == true).OrderByDescending(c=>c.CreateDate).Skip(skip).Take(take);
        }

        public IQueryable<Education> GetEducations(int skip, int take, int categoryId)
        {
            return _dbSet.Where(c => c.IsActive == true && c.CategoryId == categoryId).OrderByDescending(c => c.CreateDate).Skip(skip).Take(take);
        }

        public IQueryable<Education> GetEducations(List<int> ids)
        {
            return _dbSet.Where(c => ids.Contains(c.Id));
        }

    }
}
