using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Central
{
    public partial class TCoreUsersPasswordObject : BaseEntity
    {
        public long UserId { get; set; }
        public string PwdEncrypt { get; set; }
        public DateTime? PwdChangedDate { get; set; }
        public DateTime? PwdExpiryDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public int CumulativeLogins { get; set; }
        public int SuccessfulLogins { get; set; }
        public int InvalidLogins { get; set; }
        public bool? ForcePwdChange { get; set; }
        public bool? LockedOut { get; set; }
        public DateTime? LockoutDate { get; set; }
    }
}

  




    

