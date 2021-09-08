using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CEMIS.Data.Entities
{
    public class AcademicSession : ClientBaseEntity
    {
        [Required, MaxLength(50)]
        public string AcademicPeriod { get; set; }

        public DateTime FirstSemesterStartDate { get; set; }

        public DateTime FirstSemesterEndDate { get; set; }

        public DateTime SecondSemesterStartDate { get; set; }

        public DateTime SecondSemesterEndDate { get; set; }
        public bool IsSynched { get; set; }

    }
}
