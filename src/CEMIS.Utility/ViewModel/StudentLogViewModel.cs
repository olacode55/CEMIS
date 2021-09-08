using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class StudentLogViewModel
    {
        public long Id { get; set; }
        public string AppRefNumber { get; set; }
        public string StudentId { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public long AcademicSessionId { get; set; }
        public long ProgramId { get; set; }
        public string Level { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
