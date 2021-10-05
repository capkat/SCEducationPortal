using SCEducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCEducationPortal.Data.Interfaces.EducationInterfaces
{
    public interface IEducationRepository : IRepositoryBase<Education>
    {
        Education GetEducationDetail(int id);
        IQueryable<Education> GetEducations();
        IQueryable<Education> GetEducations(int userId);
        IQueryable<Education> GetEducations(int skip, int take);
        IQueryable<Education> GetEducations(int skip, int take, int categoryId);
        IQueryable<Education> GetEducations(List<int> ids);


    }
}
