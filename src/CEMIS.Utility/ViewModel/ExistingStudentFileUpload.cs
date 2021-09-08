using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class ExistingStudentFileUpload
    {
        [Required]
        public long AcademicSessionId { get; set; }
        public AcademicSessionViewModel AcademicSessions { get; set; }

        [Required]
        public long ProgramId { get; set; }
        public ProgramViewModel Programs { get; set; }

        [Required]
        public long LevelId { get; set; }
        public LevelViewModel Levels { get; set; }


        public IFormFile StudentRecords { get; set; }
    }
}
