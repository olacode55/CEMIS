using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
   public class CompensationReport
    {
        public int Id { get; set; }
        public int AllowanceId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CumulativeAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public DateTime DateCreated { get; set; }
        public bool  IsCommitted { get; set; }

    }
}
