using SCEducationPortal.Business.Commons.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.IEngines
{
    public interface ICategoryEngine
    {
        List<CategoryListResponse> GetCategories();
    }
}
