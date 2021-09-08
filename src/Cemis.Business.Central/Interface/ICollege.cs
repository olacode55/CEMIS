using System.Collections.Generic;
using Cemis.Data.Central.Entities;
using Cemis.Data.Central.Model;
using CEMIS.Data.Central;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;

namespace CEMIS.Business.Central.Interface
{
    public interface ICollege
    {
        List<College> GetAllColleges();
        List<TeachingStaffAdminRole> GetAllAminRoles();
        College GetCollegeById(long Id);
        College GetCollegeByAPIKey(string APIKey);
        ResponseData<College> CreateCollege(College college);
        ResponseData<College> PushCollegeInformtion(CollegeDTO collegeVM, College college);
        ResponseData<AcademicSession> SessionInformtion(AcademicSessionViewModel sessionVM, College college);

    }
}
