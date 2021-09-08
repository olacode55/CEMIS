using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class GraduatingStudentFormViewModel
    {
        public long ProgramId { get; set; }

        public IEnumerable<GraduatingStudentViewModel> GradautionList { get; set; }

        public GraduatingStudentFormViewModel()
        {
            this.GradautionList = new List<GraduatingStudentViewModel>();
        }
    }
}
