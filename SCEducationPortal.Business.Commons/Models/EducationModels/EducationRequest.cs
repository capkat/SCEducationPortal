using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Commons.Models.EducationModels
{
    public class EducationRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreateDate { get; set; }

        public string Description { get; set; }
        public int Quota { get; set; }
    }
}
