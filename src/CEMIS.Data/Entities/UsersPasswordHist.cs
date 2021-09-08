using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data
{
   public class UsersPasswordHist : BaseEntity
    {
       
        public long CoreUserId { get; set; }
        public int PwdCount { get; set; }
        public string PwdEncrypt { get; set; }
    }
}
