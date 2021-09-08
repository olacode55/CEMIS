using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class CollegeLeadershipViewModel
    {
        public long Id { get; set; }
        public long CollegeID { get; set; }
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

        public string Session { get; set; }
        public long SessionId { get; set; }
        public string SessionName { get; set; }
        public string RoleCode { get; set; }
        public Postion Role { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string College { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
