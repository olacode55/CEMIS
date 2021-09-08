using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
  public  class CollegeSummary
    {
        public int Teachingstaff { get; set; }
        public int College { get; set; }
        public int Leadership { get; set; }
        public int Facility { get; set; }
        public int Classroom { get; set; }

        public int StudentCount { get; set; }
        public int RegisteredStudentCount { get; set; }
        public int NoOfCoursesOffered { get; set; }
        public int NoOfProgramsOffered { get; set; }

        public DashBoardStatus TeachingstaffIncr { get; set; }
        public DashBoardStatus CollegeIncr { get; set; }
        public DashBoardStatus LeadershipIncr { get; set; }
        public DashBoardStatus FacilityIncr { get; set; }
        public DashBoardStatus ClassroomIncr { get; set; }
    }
}
