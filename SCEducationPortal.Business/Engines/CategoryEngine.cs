using SCEducationPortal.Business.Commons.Models.CategoryModels;
using SCEducationPortal.Business.IEngines;
using SCEducationPortal.Business.Mapping;
using SCEducationPortal.Data.Interfaces.CategoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Engines
{
    public class CategoryEngine : AutoMapperService, ICategoryEngine
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryEngine(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<CategoryListResponse> GetCategories()
        {
            var list = _categoryRepository.GetCategories();
            return Mapper.Map<List<CategoryListResponse>>(list);
        }
    }
}
