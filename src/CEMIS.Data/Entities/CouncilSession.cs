using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
  public  class CouncilSession: ClientBaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsSynched { get; set; }
    }
}
