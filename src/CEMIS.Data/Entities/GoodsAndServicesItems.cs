using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class GoodsAndServicesItems : BaseEntity
    {
        public string Code { get; set; }
        public string AccountTitle { get; set; }
        public string Description { get; set; }
        public double APPROVEBUDGET { get; set; }
        public double AmtExpendedInCurMonth { get; set; }
        public double CumAmountExpended { get; set; }
        public double TotalAmountExpended { get; set; }
        public double Balance { get; set; }
        public bool IsSubCategory { get; set; }
        public long GoodsAndServicesID { get; set; }
        [ForeignKey("GoodsAndServicesID")]
        public GoodsAndServices GoodsAndServices { get; set; }


    }
}
