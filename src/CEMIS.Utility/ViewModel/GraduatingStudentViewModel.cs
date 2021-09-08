using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class GraduatingStudentViewModel
    {
        public long Id { get; set; }
        public string AppRefNo { get; set; }
        public string StudentId { get; set; }
        public string Surname { get; set; }
        public string OtherName { get; set; }
        public string Program { get; set; }
        public string SessionAdmited { get; set; }
        public bool IsGraduated { get; set; }


    }
}
