﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Models.Authentication
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreateDate { get; set; }
    }
}
