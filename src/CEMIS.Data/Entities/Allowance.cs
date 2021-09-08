using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Data.Entities
{
  public  class Allowance: ClientBaseEntity
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public bool IsBasicSalary { get; set; }
        public virtual ICollection<StaffAllowance> allowances { get; set; }
    }
}
