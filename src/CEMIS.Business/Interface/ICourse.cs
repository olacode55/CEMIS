using CEMIS.Data;
using CEMIS.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Interface
{
    public interface ICourse
    {

        List<Course> GetAll();

        List<Course> GetCourseByFilter(long ProgramId, long LevelId, Semester Semester);

        Course GetById(long Id);


        Course GetByCourseCode(string CourseCode);

        Task CreatAsync(Course model);

        void Update(Course model);

        void Delete(long Id);

        IEnumerable<SelectListItem> GetCourseList();

        void Toggle(long Id);

    }
}
