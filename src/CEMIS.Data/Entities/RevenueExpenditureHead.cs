using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
   public  class RevenueExpenditureHead:ClientBaseEntity
    {
        
        public string CostCentre { get; set; }
        public string FundType { get; set; }

        public string MDA { get; set; }
        public string ReturnOn { get; set; }
        [Required]
        public string ReportingPeriod { get; set; }
    }
}
