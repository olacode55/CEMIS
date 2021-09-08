using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RevenueFixedAssetHead : ClientBaseEntity
    {


        [Required]
        public string CostCentre { get; set; }
        [Required]

        public string MDA { get; set; }
        public string ReportingYear { get; set; }
        [Required]
        public string ReportingPeriod { get; set; }


    }
}
