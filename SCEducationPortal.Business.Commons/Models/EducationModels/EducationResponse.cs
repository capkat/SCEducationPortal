using System;
using System.Collections.Generic;
using System.Text;
using SCEducationPortal.Business.Commons.Models.CategoryModels;
using SCEducationPortal.Business.Commons.Models.EducationContentModels;
using SCEducationPortal.Business.Commons.Models.UserModels;

namespace SCEducationPortal.Business.Commons.Models.EducationModels
{
    public class EducationResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        public string Description { get; set; }
        public int Quota { get; set; }

        public UserResponse User { get; set; }
        public  List<EducationContentResponse> EducationContents { get; set; }
        public CategoryResponse Category { get; set; }
    }
}
