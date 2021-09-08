using CEMIS.Data.Entities;
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data
{
    public class Course : ClientBaseEntity
    {
        [Required, MaxLength(10)]
        public string CourseCode { get; set; }

        [Required, MaxLength(100)]
        public string CourseTitle { get; set; }

        public byte Credit { get; set; }

        public CourseOption Option { get; set; }

        public Semester Semester { get; set; }

        public long ProgramId { get; set; }

        public long LevelId { get; set; }


    }
}
