using Microsoft.EntityFrameworkCore;
using SCEducationPortal.Data.Context;
using SCEducationPortal.Data.Entities;
using SCEducationPortal.Data.Interfaces.EducationContentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCEducationPortal.Data.Repositories.EducationContentRepositories
{
    public class EducationContentRepository : RepositoryBase<EducationContent>, IEducationContentRepository
    {
        private readonly EducationPortalDbContext _dbContext;
        private readonly DbSet<EducationContent> _dbSet;

        public EducationContentRepository(EducationPortalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<EducationContent>();
        }

        public EducationContent GeteducationContent(int id)
        {
            return _dbSet.Include(c => c.EducationContentFiles).Where(c => c.IsActive == true && c.Id == id).FirstOrDefault();
        }
    }
}
