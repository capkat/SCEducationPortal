using SCEducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCEducationPortal.Data.Interfaces.CategoryInterfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        IQueryable<Category> GetCategories();
    }
}
