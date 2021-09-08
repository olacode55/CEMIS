using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class ResultViewModel
    {
        public long Id { get; set; }
        [Required]
        public string StudentId { get; set; }
        public string StudentName { get; set; }

        public string Course { get; set; }
        public string Program { get; set; }
        public string Session { get; set; }
        public string Level { get; set; }
        [Required]
        public string Score { get; set; }
        [Required]
        public string Grade { get; set; }
        public string College { get; set; }
        [Required]
        public long CourseId { get; set; }

        [Required]
        public long AcademicSessionId { get; set; }
        [Required]
        public long ProgramId { get; set; }
        [Required]
        public long LevelId { get; set; }

        public DateTime DateCreated { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public long? UpdateBy { get; set; }

        public bool IsSynched { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
