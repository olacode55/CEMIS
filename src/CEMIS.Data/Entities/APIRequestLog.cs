using System;
using System.Collections.Generic;
using System.Text;
using CEMIS.Utility;

namespace CEMIS.Data.Entities
{
   public class APIRequestLog
    {
        public long Id { get; set; }
        public string Data { get; set; }
        public HTTPRequestType RequestType { get; set; }
        public string Url { get; set; }
        public bool Synched { get; set; }
    }
}
