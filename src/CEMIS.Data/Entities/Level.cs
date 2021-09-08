using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class Level : ClientBaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
