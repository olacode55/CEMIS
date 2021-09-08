using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class DashboardHistory
    {
        public long ID { get; set; }
        public long UserID { get; set; }
        public long CollegeCount { get; set; }
        public long TeachingStaffCOunt { get; set; }
        public long CollegeLeadershipCount { get; set; }
        public long FacilityCount { get; set; }
        public long ClassRoomCount { get; set; }

    }
}
