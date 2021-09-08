using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class RevenueExpenditureTypeViewModel
    {
        public long Id { get; set; }

        public string  RevenueExpenditureType { get; set; }
        public decimal WageandSalary { get; set; }
        public decimal Approvebudget { get; set; }
        public decimal Amountexpendedcurrentmonth { get; set; }
        public decimal Cumulativeamt { get; set; }
        public decimal Totalexpendituretodate
        {
            get; set;
        }
        public decimal Balance { get; set; }

    }
}
