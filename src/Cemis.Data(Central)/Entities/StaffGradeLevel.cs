using CEMIS.Data.Central;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class StaffGradeLevel: BaseEntity
    {
        public long Name { get; set; }
        public string Code { get; set; }
    }
}
