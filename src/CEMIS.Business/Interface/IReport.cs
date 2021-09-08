
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static CEMIS.Utility.ViewModel.DashBoardViewModel;

namespace CEMIS.Business.Interface
{
    public interface IReport
    {
        CollegeSumaryReportDto FetchStaffDashBoardReport();
    }
}
