using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Central
{
    public class CourseOffered : BaseEntity
    {
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }

        public byte Credit { get; set; }

        public CourseOption Option { get; set; }

        public Semester Semester { get; set; }

        public long ProgramId { get; set; }

        public string Level { get; set; }

    }
}
