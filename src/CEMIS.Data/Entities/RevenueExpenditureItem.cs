using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RevenueExpenditureItem:ClientBaseEntity
    {
        public long RevenueCompensationHeadId { get; set; }
        public long RevEpenditureId { get; set; }
        public string Code { get; set; }
        public decimal WageandSalary { get; set; }
        public decimal ApproveBudget { get; set; }
       public decimal AmountExpendedcurrentMonth { get; set; }
        public decimal CumulativeAmt { get; set; }
        public decimal TotalAmtexpendedtilldate { get; set; }
       public decimal  Balance { get; set; }

    }
}
