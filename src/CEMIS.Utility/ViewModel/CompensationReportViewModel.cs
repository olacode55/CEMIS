using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
  public  class CompensationReportViewModel
    {
        public int CompensationReport { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CumulativeAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public string  Name { get; set; }
        public int? ParentId { get; set; }
        public int AllowanceId { get; set; }
    }
}
