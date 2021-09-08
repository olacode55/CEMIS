using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Entities
{
  public  class GradeLevel: ClientBaseEntity
    {
        public string Name { get; set; }
        public int LowerBoundStep { get; set; }
        public int UpperBoundStep { get; set; }
    }
}

