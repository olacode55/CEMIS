using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class Certificate : ClientBaseEntity
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public Int64 StaffId { get; set; }
        //Navigation
        public virtual TeachingStaff Staff { get; set; }
    }
}
