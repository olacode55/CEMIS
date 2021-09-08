using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class ExistingStudentFormViewModel
    {
        public ExistingStudentFormViewModel()
        {
            this.Students = new List<ExistingSudentViewModel>();
        }


        [Required]
        public long AcademicSessionId { get; set; }

        public AcademicSessionViewModel AcademicSession { get; set; }

        [Required]
        public long ProgramId { get; set; }

        public ProgramViewModel Program { get; set; }

        [Required]
        public long LevelId { get; set; }

        public LevelViewModel Level { get; set; }

        public List<ExistingSudentViewModel> Students { get; set; }
    }
}
