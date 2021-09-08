using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class RevenuestimateViewModel
    {
        public long Id { get; set; }
        public string Year { get; set; }

        public Month Month { get; set; }

        public string MDA { get; set; }

        public string LodgementAccNo { get; set; }
        public string RetentionAccNo { get; set; }
    }
}
