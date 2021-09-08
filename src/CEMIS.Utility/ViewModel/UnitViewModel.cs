using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIS.Utility.ViewModel
{
    public class UnitViewModel
    {

        public UnitViewModel()
        {
            Departments = new List<SelectListItem>();
        }
        public long Id { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "* Name is required")]
        public string Name { get; set; }
      
        [Required(ErrorMessage = "Department is required")]
        public long DepartmentId { get; set; }

        public string Department { get; set; }

        public List<SelectListItem> Departments { get; set; }
        public Boolean IsDeleted { get; set; }     
        public DateTime DateCreated { get; set; }
        public long CreatedBy { get; set; }
    }
}
