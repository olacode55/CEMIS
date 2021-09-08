using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEMIS.Business.Repository
{
    public class ResultRepository : IResult
    {
        private readonly IRepository<Result> _resultRepository;

        public ResultRepository(IRepository<Result> resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public void Create(Result model)
        {
            _resultRepository.Create(model);
        }

        public List<Result> GetAll()
        {
            return _resultRepository.All()
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .ToList();
        }

        public Result GetResultByFilterAppRefNo(long AcademicSessionId, long ProgramId, long LevelId, long CourseId, string StudentId)
        {
            return _resultRepository.All()
             .Where(x => x.IsActive == true && x.IsDeleted == false
             && x.AcademicSessionId == AcademicSessionId && x.ProgramId == ProgramId
             && x.LevelId == LevelId && x.CourseId == x.CourseId && x.StudentId == StudentId)
             .FirstOrDefault();
        }

        public List<Result> GetResultByFilterByCourse(long AcademicSessionId, long ProgramId, long LevelId, long CourseId)
        {
            return _resultRepository.All()
              .Where(x => x.IsActive == true && x.IsDeleted == false
              && x.AcademicSessionId == AcademicSessionId && x.ProgramId == ProgramId
              && x.LevelId == LevelId && x.CourseId == x.CourseId)
              .ToList();
        }

        public void Update(Result model)
        {
            _resultRepository.Update(model);
        }
    }
}
