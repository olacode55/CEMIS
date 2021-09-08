using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
  public  class BasicSalaryViewModel
    {
        public long Id { get; set; }
        public int gradeLevel { get; set; }
        public int step { get; set; }
        public decimal amount { get; set; }
    }
}
