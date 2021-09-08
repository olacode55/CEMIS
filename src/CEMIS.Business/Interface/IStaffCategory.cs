using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
   public interface IStaffCategory
    {
       List <StaffCategory> GetStaffCategoryById(long stafftypeid);
        List<StaffCategory> GetStaffCategoryId(long Id);
        StaffCategory GetStaffCategory(long Id);
    }
}
