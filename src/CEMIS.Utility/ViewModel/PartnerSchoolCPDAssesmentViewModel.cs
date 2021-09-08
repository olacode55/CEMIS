using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class PartnerSchoolCPDAssesmentViewModel
    {
        public long Id { get; set; }
        public long PartnerSchoolId { get; set; }

        public string PartnerSchool { get; set; }

        public long AcademicYearId { get; set; }

        public string AcademicYear { get; set; }

        public CPDFORMTYPE FormType { get; set; }
        public Semester Semester { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required, StringLength(250)]
        public string FileName { get; set; }

        [Required, StringLength(250)]
        public string FilePath { get; set; }

        public IFormFile File { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public bool IsSynched { get; set; }

        public PartnerSchoolCPDAssesmentViewModel()
        {
            this.Date = DateTime.Now.Date;
        }
    }
}
