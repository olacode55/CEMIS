using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
  public  interface IStaffGradeLevel
    {
        List<StaffGradeLevel> GetAllStaffGradeLevel();
    }
}
