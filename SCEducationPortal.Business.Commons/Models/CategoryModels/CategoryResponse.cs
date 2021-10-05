using SCEducationPortal.Business.Commons.Models.EducationModels;
using SCEducationPortal.Business.Commons.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Commons.Models.CategoryModels
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }

        public List<EducationResponse> Educations { get; set; }
    }
}
