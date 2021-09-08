using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CEMIS.Web.CentralPortal
{
    public class DashBoardAnalyticsModel
    {
        public AnalyticsModel FacilityAnalytics { get; set; }
        public List<AnalyticsPieChart> TeachingStaffAnalytics { get; set; }
    }
}
