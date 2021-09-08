using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Central
{
    public class CollegeClassRoomData
    {
        public long Id { get; set; }

        public int ClassRoomCount { get; set; }

        public int StaffRoomCount { get; set; }

        public int OfficeCount { get; set; }

        public int LibraryCount { get; set; }

        public int LaboratoryCount { get; set; }

        public int StoreRoomCount { get; set; }

        public int OthersCount { get; set; }

        public int IsClassHeldOutside { get; set; }
        public long CollegeId { get; set; }
        public long SourceId { get; set; }
        public DateTime? DateFetched { get; set; }

    }




}
