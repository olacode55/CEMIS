using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class RevenueEstimateItemViewModel
    {
        public long Id { get; set; }

        [Required]
        public string CostCentre { get; set; }

        [Required]
        public string MDA { get; set; }

        [Required]
        public string ReportingYear { get; set; }

        [Required]
        public Month ReportingMonth { get; set; }

        [Required]
        public string LodgementAccNo { get; set; }

        [Required]
        public string RetentionAccNo { get; set; }

        [Required]
        public List<RevenueTypeViewModel> RevenueItems { get; set; }

        public RevenueEstimateItemViewModel()
        {
            this.RevenueItems = new List<RevenueTypeViewModel>();
        }
    }
}
