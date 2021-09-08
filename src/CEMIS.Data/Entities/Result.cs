using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class Result : ClientBaseEntity
    {
        [Required, MaxLength(20)]
        public string StudentId { get; set; }

        [Required, MaxLength(10)]
        public string Score { get; set; }

        [Required, MaxLength(10)]
        public string Grade { get; set; }

        [Required]
        public long CourseId { get; set; }

        [Required]
        public long AcademicSessionId { get; set; }


        [Required]
        public long ProgramId { get; set; }


        [Required]
        public long LevelId { get; set; }

        public bool IsSynched { get; set; }
    }
}
