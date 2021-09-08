using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Data.Entities
{
  public  class Committee : ClientBaseEntity
    {
        public string Name { get; set; }
        public bool IsSynched { get; set; }
      
    }
}
