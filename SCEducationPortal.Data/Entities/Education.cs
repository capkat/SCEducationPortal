using SCEducationPortal.Data.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Entities
{
    public class Education
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public int Quota { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<EducationContent> EducationContents { get; set; }
        public virtual Category Category { get; set; }
    }
}
