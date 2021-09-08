using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class ActivityLog
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Description { get; set; }
        public string Module { get; set; }
        public string Action { get; set; }
        public string Data { get; set; }
        public string IPAddress { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
