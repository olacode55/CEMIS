using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class CourseFormViewModel
    {
        public CourseFormViewModel()
        {
            this.Courses = new List<CourseViewModel>();
        }
        [Required]
        public long ProgramId { get; set; }

        public ProgramViewModel Program { get; set; }

        [Required]
        public long LevelId { get; set; }

        public LevelViewModel Level { get; set; }

        [Required]
        public Semester Semester { get; set; }

        public List<CourseViewModel> Courses { get; set; }
    }
}
