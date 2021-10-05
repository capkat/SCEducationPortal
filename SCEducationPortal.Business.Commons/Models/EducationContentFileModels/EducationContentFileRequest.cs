using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Commons.Models.EducationContentFileModels
{
    public class EducationContentFileRequest
    {
        public int EducationContentId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
