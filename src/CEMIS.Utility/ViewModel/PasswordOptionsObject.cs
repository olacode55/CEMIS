
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
     public class PasswordOptionsObject: BaseEntity
    {
        public int RequiredLength { get; set; }
        public int RequiredUniqueChars { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireDigit { get; set; }

    }
}

