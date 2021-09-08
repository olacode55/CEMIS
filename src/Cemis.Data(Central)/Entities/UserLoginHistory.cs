using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Central
{
    public class UserLoginHistory
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string IpAddress { get; set; }
        public DateTime SessionDate { get; set; }
        public string Operation { get; set; }
        public string Browser { get; set; }
        public long CreatedBy { get; set; }
    }
}
