using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class GoodsAndServicesSettings
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string AccountTitle { get; set; }
        public string Description { get; set; }
        public decimal? TotalApproveBudget { get; set; }
        public decimal? TotalAmountExpendedcurrentYear { get; set; }
        public decimal? TotalCumulativeAmt { get; set; }
        public decimal? TotalAmtexpendedtilldate { get; set; }
        public bool HasSubCategory { get; set; }

        public List<GoodsAndServicesSettingSubItems> Items { get; set; }
    }
}
