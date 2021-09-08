using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Data.Entities
{
   public class Unit : ClientBaseEntity
    {
      
        [Required(ErrorMessage = "Name is required")]
        [StringLength(200)]
        public string Name { get; set; }
        public long DepartmentId { get; set; }
        
    }
}
