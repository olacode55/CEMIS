using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Data.Entities
{
    public class TeachingStaff : ClientBaseEntity
    {
        public TeachingStaff()
        {
            Certificates = new List<Certificate>();
            allowances = new List<StaffAllowance>();
            StaffDueForPromotions = new List<StaffDueForPromotionAllowance>();
        }
        public string FirstName { get; set; }
        public string  MiddleName { get; set; }
        public string LastName { get; set; }
        public Utility.Gender Gender { get; set; }
        public int LecturerGrade { get; set; }
        public int MainAdminRole { get; set; }
        public DateTime DateOfFirstAppointment { get; set; }
        public DateTime DateOfCurrentAppointment { get; set; }
        public string AcademicQualification { get; set; }
        public string AcademicQualificationCertNo { get; set; }
        public string TeachingQualification { get; set; }
        public string AwardingInstitutionforHighestTeachingQualification { get; set; }
        public string AwardingInstitutionforHighestQualification { get; set; }
        public int Departments  { get; set; }
        public string TeachingQualificationCertNo { get; set; }
        public string StaffFileNo { get; set; }
        public SourceOfIncome SourceOfSalary { get; set; }
        [Display(Name = "DateOfBirth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public string YearOfFirstAppointment { get; set; }
        public string YearOfPresentAppointment { get; set; }
        public string YearOfPostingToCollege { get; set; }
        public int GradeLevel { get; set; }
        public string SubjectOfQualification { get; set; }
        public string AreaOfSpecialization { get; set; }
        public string MainSubjectTaught { get; set; }
        [StringLength(200)]
        public string StaffCategoryCode { get; set; }
        public bool IsRetired { get; set; }
        public TeachingType TeachingType { get; set; }
        public DateTime RetiredDate { get; set; }
        public int Stafftype { get; set; }
        public int Staffcategory { get; set; }
        public int Staffrank { get; set; }
        public int Basicsalary { get; set; }
        public int Step { get; set; }
        public bool DueForPromotion { get; set; }
        public string InServiceTraining { get; set; }
        public bool IsSynched { get; set; }
        public string  OfficerStatus { get; set; }
        public int BasicsalaryPromotion { get; set; }
        public int GradeLevelPromotion { get; set; }
        public int StepPromotion { get; set; }
        
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<StaffAllowance> allowances { get; set; }
        public virtual ICollection<StaffDueForPromotionAllowance> StaffDueForPromotions { get; set; }
    }
}
