using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Entities
{
    public class EducationContentFile
    {
        public int Id { get; set; }
        public int EducationContentId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual EducationContent EducationContents { get; set; }
    }
}
