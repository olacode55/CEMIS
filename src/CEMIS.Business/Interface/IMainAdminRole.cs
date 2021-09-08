using CEMIS.Data;
using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CEMIS.Utility;
namespace CEMIS.Business
{
    public interface IMainAdminRole
    {
        List<TeachingStaffAdminRole> GetAllAdminRole();
        ResponseData<TeachingStaffAdminRole> CreateAdminRole(TeachingStaffAdminRole teachingStaffAdminRole , bool LogRequest);
        TeachingStaffAdminRole GetAdminRoleById(long Id);
        ResponseData<TeachingStaffAdminRole> UpdateAdminRole(TeachingStaffAdminRole teachingStaffadminRole , bool LogRequest);
        ResponseData<TeachingStaffAdminRole> DeleteAdminRole(long Id , bool LogRequest);
    }
}
