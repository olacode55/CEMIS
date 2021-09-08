using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class PartnerSchoolCPDAssesment : ClientBaseEntity
    {
        public long PartnerSchoolId { get; set; }
        public long AcademicYearId { get; set; }

        public CPDFORMTYPE FormType { get; set; }
        public Semester Semester { get; set; }

        public DateTime Date { get; set; }

        [Required, StringLength(250)]
        public string FileName { get; set; }

        [Required, StringLength(250)]
        public string FilePath { get; set; }

        public bool IsSynched { get; set; }
    }
}
