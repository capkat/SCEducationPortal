using SCEducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCEducationPortal.Data.Interfaces.EducationContentInterfaces
{
    public interface IEducationContentRepository : IRepositoryBase<EducationContent>
    {
        EducationContent GeteducationContent(int id);
    }
}
