using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data
{
   
        public class UserClaim : IdentityUserClaim<string> { }
        public class UserLogin : IdentityUserLogin<string> { }
        public class RoleClaim : IdentityRoleClaim<string> { }
        public class UserRole : IdentityUserRole<long>
        {
            public UserRole()
                : base()
            { }
            public long Id { get; set; }
            public DateTime LastModified { get; set; }
            public string ModifiedBy { get; set; }
       }
}
