using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class StaffRank : ClientBaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public long StaffCategoryId { get; set; }
        public bool IsPrincipal { get; set; }

    }
}
