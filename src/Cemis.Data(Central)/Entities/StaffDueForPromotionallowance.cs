using CEMIS.Data.Central;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class StaffDueForPromotionallowance : BaseEntity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        //public long AllowanceId { get; set; }
        public long StaffId { get; set; }
        public long SourceStaffId { get; set; }
    }
}
