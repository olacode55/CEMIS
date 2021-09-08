using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RevenueEstimateHead : ClientBaseEntity
    {


        [Required]
        public string CostCentre { get; set; }

        [Required]
        public string MDA { get; set; }

        [Required]
        public string ReportingYear { get; set; }
        [Required]
        public Month ReportingMonth { get; set; }


        public string LodgementAccNo { get; set; }


        public string RetentionAccNo { get; set; }


    }
}
