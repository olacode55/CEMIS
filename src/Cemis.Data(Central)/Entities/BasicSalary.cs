using CEMIS.Data.Central;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class BasicSalary : BaseEntity
    {
        public int GradeLevel { get; set; }
        public int Step { get; set; }
        public decimal Amount { get; set; }
    }
}
