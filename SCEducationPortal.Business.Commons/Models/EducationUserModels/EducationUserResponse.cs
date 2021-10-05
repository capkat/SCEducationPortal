using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Commons.Models.EducationUserModels
{
    public class EducationUserResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EducationId { get; set; }
        public DateTime Createdate { get; set; }
    }
}
