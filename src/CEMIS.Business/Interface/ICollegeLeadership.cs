using System.Collections.Generic;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;

namespace CEMIS.Business
{
    public interface ICollegeLeadership
    {
        ResponseData<CollegeLeadershipViewModel> CreateCollegeLeadership(CollegeLeadershipViewModel collegeLeadership, bool logRequest);
        ResponseData<CollegeLeadershipViewModel> DeleteCollegeLeadership(long Id, bool LogRequest);
        List<CollegeLeadershipViewModel> GetAllcollegeLeadership();
        CollegeLeadership GetCollegeLeadershipById(long Id);
        ResponseData<CollegeLeadershipViewModel> UpdateCollegeLeadership(CollegeLeadershipViewModel collegeLeadership, bool logRequest);
    }
}