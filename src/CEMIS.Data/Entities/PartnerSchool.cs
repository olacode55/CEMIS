using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class PartnerSchool : ClientBaseEntity
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string HeadTeacher { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, StringLength(20)]
        public string Phone { get; set; }

        public int NoOfMantees { get; set; }

        public bool IsSynched { get; set; }
    }
}
