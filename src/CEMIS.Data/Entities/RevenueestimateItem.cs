using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RevenueestimateItem : ClientBaseEntity
    {
        public long RevenueHeadId { get; set; }
        public long RevenueTypeId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyTargetAmt { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyAmtCollected { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyAmountCollectedToDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyAmtPayIntoConsol { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PaidIntoConsol { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MonthlyAmtRetained { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CumulativeAmtRetained { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Variance { get; set; }
    }
}
