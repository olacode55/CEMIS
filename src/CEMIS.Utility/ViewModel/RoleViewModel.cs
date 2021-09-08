using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
   public class RoleViewModel
    {
        public long roleid { get; set; }
        [Required]
        public string rolename { get; set; }
        public string roledesc { get; set; }
        public bool issuperuser { get; set; }
        public int numberofusers { get; set; }
        public string conconrrency { get; set; }
    }
}
