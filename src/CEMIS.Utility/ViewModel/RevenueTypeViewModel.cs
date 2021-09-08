using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class RevenueTypeViewModel
    {
        public long Id { get; set; }

        public string RevenueType { get; set; }

        public decimal MonthlyTarget { get; set; }
        public decimal MonthlyAmtCollected { get; set; }
        public decimal AmmountCollectedToDate { get; set; }
        public decimal MonthlyAmtPaidIntoConsol { get; set; }
        public decimal PaidIntoConsol { get; set; }
        public decimal MonthlyAmountRetained { get; set; }
        public decimal CumAmountRetained { get; set; }
        public decimal Variance { get; set; }
    }
}
