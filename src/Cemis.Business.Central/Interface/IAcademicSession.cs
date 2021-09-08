using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Business.Central.Interface
{
    public interface IAcademicSession
    {
        List<KeyValuePairModel> GetSessionByCollegeId(long collegeId);
        List<KeyValuePairModel> GetStudentSession(string studentId);
    }
}
