using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Central
{
    public class ServiceOffered : BaseEntity
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


    }
}
