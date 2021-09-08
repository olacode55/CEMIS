using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
  public  class StaffGradeStep:ClientBaseEntity
    {
        public int GradeID { get; set; }
        public int StepID { get; set; }
        public decimal BasicSalary { get; set; }
    }
}
