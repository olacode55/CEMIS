using CEMIS.Data.Central;
using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class Student : BaseEntity
    {
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string ApplicationRef{ get; set; }
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
        public string StudentId { get; set; }
        public string DropOutComment { get; set; }
        public long ProgramSourceId { get; set; }
        public string RegistrationPin { get; set; }
        public string EmailAddress { get; set; }
        public bool IsRegistered { get; set; }
        public List<PreviousEducation> previousEducations { get; set; }
    }
}

