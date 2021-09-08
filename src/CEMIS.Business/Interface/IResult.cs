using System;
using System.Collections.Generic;
using System.Text;
using CEMIS.Data.Entities;
using CEMIS.Utility;

namespace CEMIS.Business.Interface
{
    public interface IResult
    {
        List<Result> GetAll();

        List<Result> GetResultByFilterByCourse(long AcademicSessionId, long ProgramId, long LevelId, long CourseId);
        Result GetResultByFilterAppRefNo(long AcademicSessionId, long ProgramId, long LevelId, long CourseId, string StudentId);

        void Create(Result model);
        void Update(Result model);
    }
}
