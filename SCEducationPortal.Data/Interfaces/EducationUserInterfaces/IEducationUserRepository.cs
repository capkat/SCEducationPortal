using SCEducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCEducationPortal.Data.Interfaces.EducationUserInterfaces
{
    public interface IEducationUserRepository : IRepositoryBase<EducationUser>
    {
        EducationUser GetEducationUser(int userId, int educationId);
        IQueryable<EducationUser> TrainingsIAttended(int userId, int skip, int take);
    }
}
