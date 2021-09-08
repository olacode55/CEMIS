using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class ClassRoomFacility : BaseEntity
    {
        public string YearOfConstruction {get;set;}
        public int PresentCondition { get; set; } 
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public int FloorMaterial { get; set; }
        public int WallMaterial { get; set; }
        public int RoofMaterial { get; set; }
        public int Seating { get; set; }
        public int DisabledAccess { get; set; }
 
    }
}
