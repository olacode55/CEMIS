using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIS.Utility.ViewModel
{
    public class LoginDTO
    {
        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}
