using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RevenueItemSummary : ClientBaseEntity
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal Amount { get; set; }
    }
}
