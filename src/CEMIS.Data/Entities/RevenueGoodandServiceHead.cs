using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RevenueGoodandServiceHead : ClientBaseEntity
    {
        public string MDA { get; set; }
        public int PeriodYear { get; set; }
        public Month PeriodMonth { get; set; }
        public string ReturnsOn { get; set; }
        public string FundType { get; set; }
        public bool IsSynced { get; set; }
        public List<RevenueGoodsandServiceitem> RevenueGoodsandServiceitem { get; set; }
        //public string CostCentre { get; set; }

        //public string MDA { get; set; }
        //public string ReportingYear { get; set; }
        //[Required]
        //public string ReportingPeriod { get; set; }
    }
}
