using CEMIS.Utility;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CEMIS.Data.Entities

  {
        public class CouncilMember : ClientBaseEntity
        {
       
            public string SessionName { get; set; }
         
            public string CouncilMemberName { get; set; }
    
            public Postion CouncilMemberPosition { get; set; }
            public long SessionId { get; set; }
            public bool IsSynched { get; set; }
    }
    }


