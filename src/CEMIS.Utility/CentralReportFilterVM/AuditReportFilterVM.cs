using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.CentralReportFilterVM
{
    public class AuditReportFilterVM
    {
        public string module { get; set; }
        public long userId { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
    }
}
