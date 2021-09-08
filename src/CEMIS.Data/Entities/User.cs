using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace CEMIS.Data.Entities
{
    public class User :  IdentityUser<long> 
    {
        //public string Name { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string  StaffID { get; set; }
        public long CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModeified { get; set; }
        public long? ModifiedBy { get; set; }
        public Boolean Isdeleted { get; set; }
        public bool ForcePwdChange { get; set; }
        public bool IsFirstLogin { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? PwdChangedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime PwdExpiryDate { get; set; }
    }
}
