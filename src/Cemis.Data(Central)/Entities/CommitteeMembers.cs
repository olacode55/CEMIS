using CEMIS.Data.Central;
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class CommitteeMembers : BaseEntity
    {
        public string SessionName { get; set; }
        public string CommitteMemberName { get; set; }
        public string CommitteName { get; set; }
        public Postion CommitteMemberPosition { get; set; }
        public long SessionSourceId { get; set; }
        public long CommitteSourceId { get; set; }
    }
}
