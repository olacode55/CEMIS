using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Business.Central.Interface
{
    public interface IResult
    {
        ResponseData<ResultViewModel> PushStudentResult(ResultViewModel result, long collegeId);
        List<StudentResultViewModel> GetStudentResult(string studentId, int SessionId, int level, int semester);
    }
}
