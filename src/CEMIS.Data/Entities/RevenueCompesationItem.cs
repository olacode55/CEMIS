using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
   public class RevenueCompesationItem:ClientBaseEntity
    {
        public long RevcompesationId { get; set; }
        public long WagesId { get; set; }
        public string Code { get; set; }
        public string WagesandSalary { get; set; }
        public decimal ApproveBudget { get; set; }
        public decimal AmtExpended { get; set; }
        public decimal CumAmt { get; set; }
        public decimal TotaExpendinture { get; set; }
        public decimal Balance { get; set; }
    }
}
