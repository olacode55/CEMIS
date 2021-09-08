using Cemis.Business.Central.Interface;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cemis.Business.Central.Repository
{
    public class CourseRepository : ICourse
    {
        private IRepository<CourseOffered> _courseOfferedRepo;

        public CourseRepository(IRepository<CourseOffered> courseOfferedRepo)
        {
            _courseOfferedRepo = courseOfferedRepo;
        }

        public List<KeyValuePairModel> GetCoursesByProgramId(long programId , long collegeId)
        {
            var programs = _courseOfferedRepo.All().Where(x => x.CollegeID == collegeId  && x.ProgramId == programId && x.IsDeleted == false).ToList();

            if (programs != null && programs.Count > 0)
            {
                return programs.Select(x => new KeyValuePairModel
                {
                    key = int.Parse(x.SourceID.ToString()),
                    Value = x.CourseCode
                }).ToList();
            }
            else
            {
                return new List<KeyValuePairModel>();
            }
        }
    }
}
