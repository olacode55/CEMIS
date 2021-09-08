using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class AnalyticsModel
    {
       public List<string> Name { get; set; }
       public List<string> Value { get; set; }
       public List<string> Color { get; set; }
    }

    public class AnalyticsPieChart
    {
        public string Label { get; set; }
        public int Data { get; set; }
        public string Color { get; set; }
    }
}
