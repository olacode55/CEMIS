using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class GoodsAndServicesHeaderViewModel
    {
        public long Id { get; set; }
        public string MDA { get; set; }
        public int PeriodYear { get; set; }
        public Month PeriodMonth { get; set; }
        public string ReturnsOn { get; set; }
        public string FundType { get; set; }
        public List<GoodsAndServicesItemsViewModel> GoodsAndServicesItemsViewModel { get; set; }
        public List<GoodsAndServicesSettingsViewModel> GoodsAndServicesSettingsViewModel { get; set; }
    }

    public class GoodsAndServicesItemsViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal ApproveBudget { get; set; }
        public decimal AmountExpendedcurrentYear { get; set; }
        public decimal CumulativeAmt { get; set; }
        public decimal TotalAmtexpendedtilldate { get; set; }
        public decimal Balance { get; set; }
        public long SettingsId { get; set; }
        public long SubSettingsId { get; set; }
        public long RevenueGoodandServiceHeadID { get; set; }

    }
}
