using Microsoft.AspNetCore.Identity;
using SCEducationPortal.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCEducationPortal.Data.Authentication
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        
        public virtual ICollection<Education> Educations { get; set; }
    }
}
