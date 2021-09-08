using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class ProgramViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Program Name is required"), MaxLength(50)]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string College { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
