using CEMIS.Business.Central.Interface;
using CEMIS.Data;
using CEMIS.Data.Central;
using System;
using System.Collections.Generic;
using System.Text;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;

namespace CEMIS.Business.Central.Interface
{
    public interface IStaff
    {
        ResponseData<TeachingStaff> PushCollegeStaff(CollegeStaffViewModel teachingStaff, long collegeID);
    }
}
