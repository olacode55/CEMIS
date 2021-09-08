using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class PartnerSchoolViewModel
    {
        public long Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string HeadTeacher { get; set; }

        [Required]
        public string Address { get; set; }

        [Required, StringLength(20)]
        public string Phone { get; set; }

        public int NoOfMantees { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsSynched { get; set; }
    }
}
