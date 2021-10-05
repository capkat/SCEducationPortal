using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Data.Authentication
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreateDate { get; set; }
    }
}
