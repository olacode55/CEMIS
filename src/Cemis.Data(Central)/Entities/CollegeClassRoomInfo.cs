using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Central
{
    public class CollegeClassRoomInfo 
    {
        public long Id { get; set; }

        public string YearOfConstruction { get; set; }

        public int PresentCondition { get; set; }

        public decimal LengthInMeters { get; set; }

        public decimal WidthInMeters { get; set; }

        public int FloorMaterial { get; set; }

        public int WallMaterial { get; set; }

        public int RoofMaterial { get; set; }

        public int Seatings { get; set; }

        public int DisabilityAccess { get; set; }
        public long CollegeId { get; set; }
        public long SourceId { get; set; }
        public DateTime? DateFetched { get; set; }
    }
}
