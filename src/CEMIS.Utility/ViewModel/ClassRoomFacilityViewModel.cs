using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class ClassRoomFacilityViewModel
    {
        public string YearOfConstruction { get; set; }
        public string PresentCondition { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string FloorMaterial { get; set; }
        public string WallMaterial { get; set; }
        public string RoofMaterial { get; set; }
        public string Seating { get; set; }
        public string DisabledAccess { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
