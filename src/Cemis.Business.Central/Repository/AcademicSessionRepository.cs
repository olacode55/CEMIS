using Cemis.Business.Central.Interface;
using Cemis.Data.Central.Entities;
using CEMIS.Business.Central.Interface;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cemis.Business.Central.Repository
{
    public class AcademicSessionRepository : IAcademicSession
    {
        private IRepository<AcademicSession> _academicSessionRepository;
        private IRepository<StudentLog> _studentLogRepository;
        public AcademicSessionRepository(IRepository<AcademicSession> academicSessionRepository , IRepository<StudentLog> studentLogRepository)
        {
            _studentLogRepository = studentLogRepository;
            _academicSessionRepository = academicSessionRepository;
        }
        List<KeyValuePairModel> IAcademicSession.GetSessionByCollegeId(long collegeId)
        {
            var session = _academicSessionRepository.All().Where(x => x.CollegeID == collegeId && x.IsDeleted == false).ToList();

            if (session != null && session.Count > 0)
            {
                return session.Select(x => new KeyValuePairModel
                {
                    key = int.Parse(x.SourceID.ToString()), //int.Parse(x.Id.ToString()),
                    Value = x.AcademicPeriod
                }).ToList();
            }
            else
            {
                return new List<KeyValuePairModel>();
            }
        }

        public List<KeyValuePairModel> GetStudentSession(string studentId)
        {
            var session = new List<AcademicSession>();
            var studentLogs = _studentLogRepository.All().Where(x => x.StudentId == studentId).Distinct().ToList();


            foreach (var studentLog in studentLogs)
            {
                var data = _academicSessionRepository.All().FirstOrDefault(x => x.CollegeID == studentLog.CollegeID && x.SourceID == studentLog.AcademicSessionSourceId);

                if(data != null)
                {
                    session.Add(data);
                }
            }

            if (session != null && session.Count > 0)
            {
                return session.Select(x => new KeyValuePairModel
                {
                    key = int.Parse(x.SourceID.ToString()), //int.Parse(x.Id.ToString()),
                    Value = x.AcademicPeriod
                }).ToList();
            }
            else
            {
                return new List<KeyValuePairModel>();
            }
        }
    }
}
