using CEMIS.Utility;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CEMIS.Data.Entities

  {
        public class CommitteMembers : ClientBaseEntity
        {
       
            public string SessionName { get; set; }
            public string CommitteMemberName { get; set; }
            public string CommitteName { get; set; }
            public Postion CommitteMemberPosition { get; set; }
            public long SessionId { get; set; }
            public long CommitteId { get; set; }
           public bool IsSynched { get; set; }
    }
    }


