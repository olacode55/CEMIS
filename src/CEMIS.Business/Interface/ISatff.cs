using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;

namespace CEMIS.Business
{
    public interface IStaff
    {
        List<TeachingStaff> GetAllTeachingStaff();
        bool CreateTeachingStaff(TeachingStaffViewModel teachingStaff , bool LogRequest);
        TeachingStaff GetTeachingStaffById(long Id);
        void RetireStaff(long Id);
        TeachingStaff GetTeachingStaffById(string staffno);


        bool UpdateTeachingStaff(TeachingStaffViewModel model, bool LogRequest);
        //ResponseData<TeachingStaffViewModel> DeleteTeachingStaff(long Id , bool LogRequest);
    }
}
