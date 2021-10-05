using SCEducationPortal.Business.Commons.Models.EducationContentFileModels;
using SCEducationPortal.Business.Commons.Models.EducationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Commons.Models.EducationContentModels
{
    public class EducationContentResponse
    {
        public int Id { get; set; }
        public int EducationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        //public virtual EducationResponse Educations { get; set; }
        public virtual List<EducationContentFileResponse> EducationContentFiles { get; set; }
    }
}
