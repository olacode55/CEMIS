
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class CollegeLeadership : ClientBaseEntity
    {
        public string Name { get; set; }

        public Utility.Gender Gender { get; set; }

        public string CouncilMember { get; set; }
        [MaxLength(20)]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^([0-9]{9,14})$", ErrorMessage = "Invalid Phone Number.")]
        public string CouncilMemberPhone1 { get; set; }
        [MaxLength(20)]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Mobile Number")]
        [RegularExpression(@"^([0-9]{9,14})$", ErrorMessage = "Invalid Mobile Number.")]
        public string CouncilMemberPhone2 { get; set; }
        [MaxLength(50)]
        [EmailAddress]
        public string CouncilMemberEmail { get; set; }
     
        public string CouncilMemberPostalAddress { get; set; }

        public Sponspor CouncilMemberSponsor { get; set; }

        public DateTime DateAppointed { get; set; }

        public DateTime? DateLeft { get; set; }

        public int Session { get; set; }
        public string SessionName { get; set; }
        public Postion Role { get; set; }
        [Display(Name = "DateOfBirth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public bool IsSynched { get; set; }

    }
}

