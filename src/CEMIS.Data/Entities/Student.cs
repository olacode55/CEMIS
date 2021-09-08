using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class Student : BaseEntity
    {
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string AppRefNumber { get; set; }

        [MaxLength(50)]
        public string RegistrationPin { get; set; }

        [MaxLength(20)]
        public string StudentId { get; set; }
        public Gender Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime DOB { get; set; }
        public string POB { get; set; }
        public string HomeTown { get; set; }
        public string District { get; set; }
        public string Region { get; set; }
        public string Religion { get; set; }
        public string LanguagesSpoken { get; set; }
        public string ContactAddress { get; set; }
        public string Disability { get; set; }
        public string FirstChoiceProgram { get; set; }
        public string SecondChoiceProgram { get; set; }
        public string ThreeChoiceProgram { get; set; }
        public string FirstChoiceCollege { get; set; }
        public string SecondChoiceCollege { get; set; }
        public string ThirdChoiceCollege { get; set; }
        public string ParentParticulars { get; set; }
        public string Result { get; set; }
        public string TelephoneNumber { get; set; }
        public string Passport { get; set; }
        public bool IsSynched { get; set; }
        public bool IsGraduated { get; set; }
        public int Level { get; set; }
        public long ProgramId { get; set; }
        public long AcademicSessionId { get; set; }
        public List<PreviousEducation> previousEducations { get; set; }
        public string DropOutComment { get; set; }
    }
}
