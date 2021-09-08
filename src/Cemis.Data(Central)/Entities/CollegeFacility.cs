using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Data.Central
{
    public class CollegeFacility : BaseEntity
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        //public int Number { get; set; }
        public string Description { get; set; }

        [Required]
        public string FacilityType { get; set; }

        [Required]
        public string YearOfConstruction { get; set; }

        [Required]
        public int PresentCondition { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LengthInMeters { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal WidthInMeters { get; set; }

        [Required]
        public int FloorMaterial { get; set; }

        //[Required]
        //public int WallMaterial { get; set; }

        [Required]
        public int RoofMaterial { get; set; }

        [Required]
        public int Seatings { get; set; }

        [Required]
        public int DisabilityAccess { get; set; }


    }
}
