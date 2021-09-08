using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class DropoutStudentViewModel
    {
        public long Id { get; set; }

        public string StudentId { get; set; }

        public string Surname { get; set; }

        public string OtherName { get; set; }

        public string SessionAdmited { get; set; }

        public string ReasonForDropout { get; set; }

        public string Program { get; set; }
    }
}
