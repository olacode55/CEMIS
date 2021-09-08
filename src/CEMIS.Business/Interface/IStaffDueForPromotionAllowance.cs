using CEMIS.Data.Entities;
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
   public  interface IStaffDueForPromotionAllowance
    {
        List<StaffDueForPromotionAllowance> GetAllStaffDueForPromotionAllowance();
        ResponseData<StaffDueForPromotionAllowance> DeleteStaffDueForPromotionAllowance(long Id);
        List<StaffDueForPromotionAllowance> GetStaffDueForPromotionAllowanceById(long StaffId);
    }
}
