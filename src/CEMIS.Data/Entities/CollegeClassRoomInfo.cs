using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class CollegeClassRoomInfo
    {
        public long Id { get; set; }

        public string YearOfConstruction { get; set; }

        public int PresentCondition { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LengthInMeters { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal WidthInMeters { get; set; }

        public int FloorMaterial { get; set; }

        public int WallMaterial { get; set; }

        public int RoofMaterial { get; set; }

        public int Seatings { get; set; }

        public int DisabilityAccess { get; set; }
        public long CollegeId { get; set; }

        public bool IsSynched { get; set; }

    }
}
