using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
    public interface IStaffCPDAssesment
    {
        List<StaffCPDAssesment> GetAllStaffCPDAssesment();
        ResponseData<StaffCPDAssesmentViewModel> CreateStaffCPDAssesment(StaffCPDAssesmentViewModel staffCPD, bool LogRequest);
        List<StaffCPDAssesment> GetStaffCPDAssesmentById(long StaffId);
        ResponseData<StaffCPDAssesmentViewModel> UpdateStaffCPDAssesment(StaffCPDAssesmentViewModel staffCPD, bool LogRequest);
        ResponseData<StaffCPDAssesment> DeleteStaffCPDAssesment(long Id);
    }
}
