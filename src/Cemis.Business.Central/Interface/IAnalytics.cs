using System.Collections.Generic;
using CEMIS.Utility.ViewModel;

namespace Cemis.Business.Central.Interface
{
    public interface IAnalytics
    {
        AnalyticsModel CollegeAnalyticsByFacilityNumber();
        List<AnalyticsPieChart> CollegeAnalyticsByStaffNumber();
    }
}