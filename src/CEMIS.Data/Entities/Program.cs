using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class Program : ClientBaseEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
