using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
   public class ForgetPasswordViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }
        public string returnUrl { get; set; }

    }
}
