using Microsoft.EntityFrameworkCore;
using SCEducationPortal.Data.Context;
using SCEducationPortal.Data.Entities;
using SCEducationPortal.Data.Interfaces.EducationContentFileInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Repositories.EducationContentFileRepositories
{
    public class EducationContentFileRepository : RepositoryBase<EducationContentFile>, IEducationContentFileRepository
    {
        private readonly EducationPortalDbContext _dbContext;
        private readonly DbSet<EducationContentFile> _dbSet;

        public EducationContentFileRepository(EducationPortalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<EducationContentFile>();
        }
    }
}
