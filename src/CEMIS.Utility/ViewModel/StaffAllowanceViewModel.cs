using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
  public  class StaffAllowanceViewModel
    {

        public long Id { get; set; }
        public long AllowanceId { get; set; }
        public string name { get; set; }
        public decimal amount { get; set; }
    }
}
