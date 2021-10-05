using SCEducationPortal.Data.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Entities
{
    public class EducationUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EducationId { get; set; }
        public DateTime Createdate { get; set; }
    }
}
