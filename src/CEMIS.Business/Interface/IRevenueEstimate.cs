using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
    public interface IRevenueEstimate
    {
        List<RevenuestimateViewModel> GetRevenuestimate();
        RevenueEstimateItemViewModel GetRevenueEstimateItem(long Id);

        bool AddRevenueEstimateItem(RevenueEstimateItemViewModel model, out string message);

        bool UpdateRevenueEstimateItem(RevenueEstimateItemViewModel model, out string message);
    }
}
