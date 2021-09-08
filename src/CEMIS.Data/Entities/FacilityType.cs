using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class FacilityType : ClientBaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

    }
}
