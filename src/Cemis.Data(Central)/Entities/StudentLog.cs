using CEMIS.Data.Central;
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class StudentLog : BaseEntity
    {
        //[Required, MaxLength(20)]
        public string AppRefNumber { get; set; }

        [Required, MaxLength(20)]
        public string StudentId { get; set; }

        [MaxLength(50)]
        public string Surename { get; set; }

        [MaxLength(100)]
        public string OtherNames { get; set; }

        public long AcademicSessionSourceId { get; set; }

        public long ProgramSourceId { get; set; }

        public string Level { get; set; }

    }
}
