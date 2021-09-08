using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.CentralReportFilterVM
{
    public class CourseReportFilterVM
    {
        public string courseTitle { get; set; }
        public string courseCode { get; set; }
        public int Level { get; set; }
        public int collegeId { get; set; }
        public int programId { get; set; }
        public int status { get; set; }
        public int optionId { get; set; }
        public int semesterId { get; set; }
    }
}
