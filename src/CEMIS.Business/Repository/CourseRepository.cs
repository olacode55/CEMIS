using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly IRepository<Course> _courserepository;
        private readonly IAuthUser _authUser;

        public CourseRepository(IRepository<Course> courserepository, IAuthUser authUser)
        {
            _courserepository = courserepository;
            _authUser = authUser;
        }
        public async Task CreatAsync(Course model)
        {
            await _courserepository.CreateAsync(model);
        }

        public void Delete(long Id)
        {
            var course = _courserepository.Find(Id);
            if (course != null)
            {
                _courserepository.Delete(course);
            }

        }

        public List<Course> GetAll()
        {
            return _courserepository.All()
                .Where(x => x.IsDeleted == false)
                .ToList();
        }

        public List<Course> GetCourseByFilter(long ProgramId, long LevelId, Semester Semester)
        {
            return _courserepository.All()
                .Where(x => x.IsDeleted == false
                && x.ProgramId == ProgramId && x.LevelId == LevelId
                && x.Semester == Semester
                )
                .ToList();
        }

        public Course GetByCourseCode(string CourseCode)
        {
            return _courserepository.All()
                .Where(x => x.CourseCode.ToUpper() == CourseCode.ToUpper())
                .FirstOrDefault();
        }

        public Course GetById(long Id)
        {
            return _courserepository.Find(Id);
        }



        public IEnumerable<SelectListItem> GetCourseList()
        {
            return _courserepository.All().Where(x => x.IsDeleted == false && x.IsActive == true).Select(x => new SelectListItem()
            {
                Text = x.CourseCode + "-" + x.CourseTitle,
                Value = x.Id.ToString()
            }).ToList();
        }

        public void Update(Course model)
        {
            _courserepository.Update(model);
        }

        public void Toggle(long Id)
        {
            var course = _courserepository.Find(Id);

            if (course.IsActive == true)
            {
                course.IsActive = false;
                course.UpdatedBy = long.Parse(_authUser.UserId);
                course.DateUpdated = DateTime.Now;
            }
            else
            {
                course.IsActive = true;
                course.UpdatedBy = long.Parse(_authUser.UserId);
                course.DateUpdated = DateTime.Now;
            }

            _courserepository.Update(course);

        }
    }
}
