using Microsoft.EntityFrameworkCore;
using SCEducationPortal.Data.Context;
using SCEducationPortal.Data.Entities;
using SCEducationPortal.Data.Interfaces.EducationUserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCEducationPortal.Data.Repositories.EducationUserRepositories
{
    public class EducationUserRepository : RepositoryBase<EducationUser>, IEducationUserRepository
    {
        private readonly EducationPortalDbContext _dbContext;
        private readonly DbSet<EducationUser> _dbSet;

        public EducationUserRepository(EducationPortalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<EducationUser>();
        }

        public EducationUser GetEducationUser(int userId, int educationId)
        {
            return _dbSet.Where(c => c.UserId == userId && c.EducationId == educationId).FirstOrDefault();
        }

        public IQueryable<EducationUser> TrainingsIAttended(int userId, int skip, int take)
        {
            return _dbSet.Where(c => c.UserId == userId).OrderByDescending(c => c.Createdate);
        }
    }
}
