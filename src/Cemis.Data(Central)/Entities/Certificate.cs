using CEMIS.Data.Central;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class Certificate 
    {
        public long Id { get; set; }
        public long CollegeID { get; set; }
        public DateTime? DateFetched { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public long StaffId { get; set; }
        [ForeignKey("StaffId")]
        public virtual TeachingStaff Staff { get; set; }
    }
}
