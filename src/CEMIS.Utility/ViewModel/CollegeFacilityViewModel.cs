using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class CollegeFacilityViewModel
    {

        public long Id { get; set; }


        public long CollegeId { get; set; }

        [Required]
        public string Name { get; set; }


        public string Description { get; set; }


        public long FacilityType { get; set; }

        public string FacilityTypeName { get; set; }

        public string FacilityTypeCentral { get; set; }

        [Required]
        public string YearOfConstruction { get; set; }

        [Required]
        public ClassRoomCondition PresentCondition { get; set; }

        [Required]
        public decimal LengthInMeters { get; set; }

        [Required]
        public decimal WidthInMeters { get; set; }

        [Required]
        public FloorMaterial FloorMaterial { get; set; }

        [Required]
        public RoofMaterial RoofMaterial { get; set; }

        [Required]
        public SeatAvailability Seatings { get; set; }

        [Required]
        public DisabilityAccessAvailability DisabilityAccess { get; set; }


        public bool IsSynched { get; set; }

        public bool IsActive { get; set; }

        public int Number { get; set; }
    }
}
