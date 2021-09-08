using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class RevenueExpenditureItemViewModel
    {
        public long Id { get; set; }

        public string CostCentre { get; set; }


        public string MDA { get; set; }


        //public string ReportingYear { get; set; }

        public string ReportingMonth { get; set; }

        public string ReturnOn { get; set; }


        public string FundType { get; set; }

        public List<RevenueExpenditureTypeViewModel> RevenueExpenditureItems { get; set; }

        public RevenueExpenditureItemViewModel()
        {
            this.RevenueExpenditureItems = new List<RevenueExpenditureTypeViewModel>();
        }
    }
}
