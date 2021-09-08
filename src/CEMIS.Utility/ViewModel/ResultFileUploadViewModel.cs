using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class ResultFileUploadViewModel
    {
        [Required]
        public long AcademicSessionId { get; set; }

        [Required]
        public Semester Semester { get; set; }

        [Required]
        public long ProgramId { get; set; }

        [Required]
        public long LevelId { get; set; }

        [Required]
        public long CourseId { get; set; }


        public IFormFile StudentResultFile { get; set; }
    }
}
