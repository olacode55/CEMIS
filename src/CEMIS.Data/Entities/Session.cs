using CEMIS.Utility;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CEMIS.Data.Entities
{
    public class Session : ClientBaseEntity
    {
        [Required]
        public string SessionName { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        public Postion  PositionName { get; set; }

        public string MembershipName { get; set; }

    }
}
