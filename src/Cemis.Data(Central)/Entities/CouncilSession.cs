using CEMIS.Data.Central;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class CouncilSession : BaseEntity
    {
        public string Name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
