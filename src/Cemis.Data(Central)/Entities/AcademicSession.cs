using CEMIS.Data.Central;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class AcademicSession : BaseEntity
    {
        public string AcademicPeriod { get; set; }

        public DateTime FirstSemesterStartDate { get; set; }

        public DateTime FirstSemesterEndDate { get; set; }

        public DateTime SecondSemesterStartDate { get; set; }

        public DateTime SecondSemesterEndDate { get; set; }
    }
}
