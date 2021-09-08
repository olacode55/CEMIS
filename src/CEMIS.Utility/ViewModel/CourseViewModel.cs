using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class CourseViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Course Code is Required"), StringLength(10)]
        public string CourseCode { get; set; }

        [Required(ErrorMessage = "Course Code is Required"), StringLength(100)]
        public string CourseTitle { get; set; }

        public byte Credit { get; set; }

        public CourseOption Option { get; set; }

        [Required]
        public Semester Semester { get; set; }

        [Required]
        public long ProgramId { get; set; }

        [Required]
        public long LevelId { get; set; }

        public bool IsActive { get; set; }
    }
}
