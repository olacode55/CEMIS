using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class ActivityLogViewModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Module { get; set; }
        public string Action { get; set; }
        public string IPAddress { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
