using CEMIS.Data.Central;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Data.Central.Model
{
    public class CollegeVM
    {
        public College College { get; set; }
        public List<ServiceOffered> ServiceOffered { get; set; }

        public long CourseOfferedId { get; set; }

        public List<CourseOffered> CourseOffered { get; set; }

        public long CollegeFacilityId { get; set; }

        public List<CollegeFacility> CollegeFacility { get; set; }

        public long CollegeClassRoomDataId { get; set; }

        public CollegeClassRoomData CollegeClassRoomData { get; set; }

        public long CollegeClassRoomInfoId { get; set; }

        public List<CollegeClassRoomInfo> CollegeClassRoomInfo { get; set; }
    }
}
