using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RevenueExpenditureTypeCode : ClientBaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
