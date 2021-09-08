
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CEMIS.Utility;

namespace CEMIS.Data.Central
{
    public class CollegeLeadership : BaseEntity
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public string CouncilMember { get; set; }

        public string CouncilMemberPhone1 { get; set; }

        public string CouncilMemberPhone2 { get; set; }

        public string CouncilMemberEmail { get; set; }

        public string CouncilMemberPostalAddress { get; set; }

        public Sponspor CouncilMemberSponsor { get; set; }

        public DateTime DateAppointed { get; set; }

        public DateTime? DateLeft { get; set; }

        public Postion Role { get; set; }

        [ForeignKey("CollegeID")]
        public College College { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long SessionSourceID { get; set; }
        public string SessionName { get; set; }
    }
}
