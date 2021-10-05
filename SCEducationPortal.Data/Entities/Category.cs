using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
    }
}
