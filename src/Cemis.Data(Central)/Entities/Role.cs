using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Central
{
    public class Role : IdentityRole<long>
    {

        public string PermissionsInRole { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public long ModifiedBy { get; set; }
        public bool IsSuperUser { get; set; }
        public string RoleDesc { get; set; }
        //public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
