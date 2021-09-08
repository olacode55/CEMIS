using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class CollegeCPDAssesment : ClientBaseEntity
    {
        public string FileName { get; set; }
        public Int64 CollegeID { get; set; }
        public long SessionId { get; set; }
        public CPDFORMTYPE FormType { get; set; }
        public Semester Semester { get; set; }
        public DateTime Date { get; set; }

        //Navigation
        // public TeachingStaff Staff { get; set; }
    }
}
