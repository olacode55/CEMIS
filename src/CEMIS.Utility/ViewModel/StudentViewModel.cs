using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace CEMIS.Utility.ViewModel
{
    public class StudentViewModel
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string AppRefNumber { get; set; }
        public string RegistrationPin { get; set; }
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
        public IFormFile File { get; set; }
        public string College { get; set; }
        public string StudentId { get; set; }

        public long ProgramId { get; set; }
        public string DropOutComment { get; set; }
        //public FileStream PassportStream { get; set; }
        public List<PreviousEducationViewModel> previousEducations { get; set; }
    }


    public class PreviousEducationViewModel
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string School { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string OfficeHeld { get; set; }
    }

    public class StudentFileUpload
    {
        public long AcademicSessionId { get; set; }

        public AcademicSessionViewModel AcademicSessions { get; set; }
        public long ProgramId { get; set; }

        public ProgramViewModel Programs { get; set; }
        public IFormFile StudentRecords { get; set; }

        public IFormFile StudentPhotos { get; set; }
    }
}

