using CEMIS.Data.Entities;
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
   public  interface  IStaffAllowance
    {
        List<StaffAllowance> GetAllStaffAllowance();
        ResponseData<StaffAllowance> DeleteStaffAllowance(long Id);
        List<StaffAllowance> GetStaffAllowanceById(long StaffId);
    }
}
