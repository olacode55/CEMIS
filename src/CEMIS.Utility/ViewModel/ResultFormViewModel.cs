using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class ResultFormViewModel
    {
        public ResultFormViewModel()
        {
            this.Result = new List<ResultViewModel>();
        }

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

        public List<ResultViewModel> Result { get; set; }
    }
}
