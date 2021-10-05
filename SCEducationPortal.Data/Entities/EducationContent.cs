using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Entities
{
    public class EducationContent
    {
        public int Id { get; set; }
        public int EducationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Education Educations { get; set; }
        public virtual ICollection<EducationContentFile> EducationContentFiles { get; set; }
    }
}
