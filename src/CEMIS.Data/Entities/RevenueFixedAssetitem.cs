using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RevenueFixedAssetitem : ClientBaseEntity
    {
        public long RevEpenditureId { get; set; }
        public string Code { get; set; }
        public string Accounttitle { get; set; }
        public decimal ApproveBudget { get; set; }
        public decimal AmountExpendedcurrentYear { get; set; }
        public decimal CumulativeAmt { get; set; }
        public decimal TotalAmtexpendedtilldate { get; set; }
        public decimal Balance { get; set; }
        public string Description { get; set; }
    }
}
