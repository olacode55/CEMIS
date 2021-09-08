using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Business.Interface
{
    public interface ICollegeCPDAssesment
    {
        List<CollegeCPDAssesment> GetAllCollegeCPDAssesment();
        ResponseData<CollegeCPDAssesmentViewModel> CreateCollegeCPDAssesment(CollegeCPDAssesmentViewModel collegeCPD, bool LogRequest);
        List<CollegeCPDAssesment> GetCollegeCPDAssesmentById(long CollegeId);
       // ResponseData<CollegeCPDAssesmentViewModel> UpdateCollegeCPDAssesment(CollegeCPDAssesmentViewModel collegeCPD, bool LogRequest);
        ResponseData<CollegeCPDAssesment> DeleteCollegeCPDAssesment(long Id);
    }
}
