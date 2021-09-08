using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
   public class BasicSalary:ClientBaseEntity
    {
        public int GradeLevel { get; set; }
        public int Step { get; set; }
        public decimal Amount { get; set; }
    }
}
