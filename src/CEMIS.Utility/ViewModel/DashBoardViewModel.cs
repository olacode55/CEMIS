using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
   public class DashBoardViewModel
    {
        public class CollegeSummaryDto
        {
            public string Period { get; set; }
            public int Count { get; set; }

        }
        public class CollegeSumaryReportDto
        {
            public int? StaffNoSynched { get; set; }
            public int? staffNumberPending { get; set; }
            public int? CollegeNoSynched { get; set; }
            public int? CollegeNumberPending { get; set; }
            public int? LeadershipNoSynched { get; set; }
            public int? LeaderShipNumberPending { get; set; }

        }
        public class DashBoard
        {
            public CollegeSumaryReportDto CollegeSumaryReportDtos { get; set; }
            public List<CollegeSummaryDto> periodSummaryDtos { get; set; }
            public CollegeSumaryReportDto CollegeSumaryReport { get; set; }

        }

    }
}
