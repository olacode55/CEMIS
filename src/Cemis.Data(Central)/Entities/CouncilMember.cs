using CEMIS.Data.Central;
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class CouncilMember : BaseEntity
    {

        public string SessionName { get; set; }

        public string CouncilMemberName { get; set; }

        public Postion CouncilMemberPosition { get; set; }
        public long SessionSourceId { get; set; }
    }
}
