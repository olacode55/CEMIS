using CEMIS.Utility.CentralReportFilterVM;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Business.Central.Interface
{
    public interface ISystemsReport
    {
        List<ActivityLogViewModel> AuditReport(AuditReportFilterVM auditFilterVM);
    }
}
