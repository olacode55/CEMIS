using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class StudentFormViewModel
    {
        public StudentFormViewModel()
        {
            this.AcademicSession = new AcademicSessionViewModel();
            this.Program = new ProgramViewModel();
            this.ProgramId = 0;
            this.AcademicSessionId = 0;
            this.Students = new List<StudentViewModel>();
        }

        [Required]
        public long AcademicSessionId { get; set; }

        public AcademicSessionViewModel AcademicSession { get; set; }

        [Required]
        public long ProgramId { get; set; }

        public ProgramViewModel Program { get; set; }

        public List<StudentViewModel> Students { get; set; }
    }
}
