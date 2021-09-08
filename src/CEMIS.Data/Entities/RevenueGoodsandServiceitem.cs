using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RevenueGoodsandServiceitem : ClientBaseEntity
    {
        public string Description { get; set; }
        public decimal ApproveBudget { get; set; }
        public decimal AmountExpendedcurrentYear { get; set; }
        public decimal CumulativeAmt { get; set; }
        public decimal TotalAmtexpendedtilldate { get; set; }
        public decimal Balance { get; set; }
        public long SettingsId { get; set; }
        public long SubSettingsId { get; set; }
        public long RevenueGoodandServiceHeadID { get; set; }
        [ForeignKey("RevenueGoodandServiceHeadID")]
        public RevenueGoodandServiceHead RevenueGoodandServiceHead { get; set; }

    }
}
