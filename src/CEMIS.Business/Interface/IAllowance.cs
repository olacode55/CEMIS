using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
  public  interface IAllowance
    {
        ResponseData<AllowanceViewModel> CreateBasicAllowance(AllowanceViewModel allowance, bool logRequest);
        List<AllowanceViewModel> GetAllAllowance();
        Allowance GetAllowanceId(string name);
        AllowanceViewModel GetAllowanceById(long Id);
        ResponseData<AllowanceViewModel> UpdateAllowance(AllowanceViewModel allowance, bool logRequest);
        bool DeleteAllowance(long Id, out string message);
    }
}
