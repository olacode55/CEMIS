using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class GoodsAndServicesSettingSubItems
    {
            public long Id { get; set; }
            public long SettingId { get; set; }
            [ForeignKey("SettingId")]
            public GoodsAndServicesSettings Setting { get; set; }
            public string Description { get; set; }
            public decimal? TotalApproveBudget { get; set; }
            public decimal? TotalAmountExpendedcurrentYear { get; set; }
            public decimal? TotalCumulativeAmt { get; set; }
            public decimal? TotalAmtexpendedtilldate { get; set; }
            public bool HasSubCategory { get; set; }
    }
}
