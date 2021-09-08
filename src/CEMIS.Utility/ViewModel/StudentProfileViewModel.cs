using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class StudentProfileViewModel
    {
        public long Id { get; set; }
        public string CollegeName { get; set; }
        public string Surname { get; set;}
        public string OtherName { get; set;}
        public string ApplicationRef { get; set;}
        public string StudentId { get; set;}
        public string Program { get; set;}
        public string Level { get; set;}
        public string Session { get; set;}
        public Gender Gender { get; set;}
        public string MaritalStatus { get; set;}
        public DateTime DOB { get; set;}
        public string POB { get; set; }
        public string HomeTown { get; set;}
        public string District { get; set;}
        public string Region { get; set;}
        public string Religion { get; set;}
        public string LanguagesSpoken { get; set;}
        public string ContactAddress { get; set;}
        public string TelephoneNumber { get; set;}
        public string Passport { get; set;}
    }
}
