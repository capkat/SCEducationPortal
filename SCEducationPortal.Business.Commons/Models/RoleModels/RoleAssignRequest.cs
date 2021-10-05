using System;
using System.Collections.Generic;
using System.Text;

namespace SCEducationPortal.Business.Commons.Models.RoleModels
{
    public class RoleAssignRequest
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool HasAssign { get; set; }
    }
}
