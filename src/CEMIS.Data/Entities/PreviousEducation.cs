using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class PreviousEducation : BaseEntity
    {
        public string School { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string OfficeHeld { get; set; }
        public long StudentID { get; set; }
        public Student Student { get; set; }
    }
}
