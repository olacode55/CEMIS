using CEMIS.Business.Model;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
   public  interface IRevenueExpenditure
    {
        List<RevenuExpenditureViewModel> GetRevenuecompensation();
        RevenueExpenditureItemViewModel GetRevenueCompensationItem(long Id);
        bool AddRevenueCompensationItem(RevenueExpenditureItemViewModel model, out string message);
        bool UpdateRevenueCompensationItem(RevenueExpenditureItemViewModel model, out string message);
    }
}
