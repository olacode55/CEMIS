
using Cemis.Data.Central.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Business.Central.Repository
{
  public  interface IAllowance
    {
        ResponseData<AllowanceViewModel> CreateBasicAllowance(AllowanceViewModel allowance, bool logRequest);
        List<AllowanceViewModel> GetAllAllowance();
        List<Allowance> GetParentAllowance();
        ResponseData<List<AllowanceViewModel>> GetAllAllowanceAPI();
        Allowance GetAllowanceId(string name);
        AllowanceViewModel GetAllowanceById(long Id);
        ResponseData<AllowanceViewModel> UpdateAllowance(AllowanceViewModel allowance, bool logRequest);
        bool DeleteAllowance(long Id, out string message);
    }
}
