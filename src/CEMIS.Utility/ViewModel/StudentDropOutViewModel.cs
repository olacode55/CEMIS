using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class StudentDropOutViewModel
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string AppRefNumber { get; set; }
        public string RegistrationPin { get; set; }
        public Gender Gender { get; set; }

        [Required]
        public string DropOutComment { get; set; }
    }
}
