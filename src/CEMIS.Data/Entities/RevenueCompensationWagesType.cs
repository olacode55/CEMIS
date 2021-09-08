using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class RevenueCompensationWagesType:ClientBaseEntity
    {
        public long WagesId { get; set; }

        public string WagesName { get; set; }
    }

}
