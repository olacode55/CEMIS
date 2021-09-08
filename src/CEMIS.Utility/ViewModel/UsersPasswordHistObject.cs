
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
 
        public class UsersPasswordHistObject : BaseEntity
        {
            public long UserId { get; set; }
            public int PwdCount { get; set; }
            public string PwdEncrypt { get; set; }

        }
    }

