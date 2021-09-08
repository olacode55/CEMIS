using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class StudentLog : ClientBaseEntity
    {
        //[Required, MaxLength(20)]
        public string AppRefNumber { get; set; }

        [Required, MaxLength(20)]
        public string StudentId { get; set; }

        [MaxLength(50)]
        public string Surename { get; set; }

        [MaxLength(100)]
        public string OtherNames { get; set; }

        public long AcademicSessionId { get; set; }

        public long ProgramId { get; set; }

        public long LevelId { get; set; }

        public bool IsSynched { get; set; }
    }
}
