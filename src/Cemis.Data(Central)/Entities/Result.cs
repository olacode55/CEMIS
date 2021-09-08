using CEMIS.Data.Central;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class Result : BaseEntity
    {
        [Required, MaxLength(20)]
        public string StudentId { get; set; }

        [Required, MaxLength(10)]
        public string Score { get; set; }

        [Required, MaxLength(10)]
        public string Grade { get; set; }

        [Required]
        public long CourseSourceId { get; set; }

        [Required]
        public long AcademicSessionSourceId { get; set; }


        [Required]
        public long ProgramSourceId { get; set; }


        [Required]
        public string Level { get; set; }

    }
}
