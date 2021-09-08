
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Central
{
   public class UsersPasswordHist : BaseEntity
    {
       
        public long CoreUserId { get; set; }
        public int PwdCount { get; set; }
        public string PwdEncrypt { get; set; }
    }
}
