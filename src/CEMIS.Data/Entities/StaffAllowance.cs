using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
   public class StaffAllowance:ClientBaseEntity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsBasicSalary { get; set; }
        public Int64 AllowanceId { get; set; }
        public Int64 StaffId { get; set; }
        //Navigation
        public virtual TeachingStaff Staff { get; set; }
        public virtual Allowance Allowance { get; set; }
        //public bool IsSynched { get; set; }


    }
}
