using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
   public class StaffType: ClientBaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
