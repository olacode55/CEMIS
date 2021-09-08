using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class CollegeStaffViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public long CollegeID { get; set; }
        public string LecturerGrade { get; set; }
        public string LecturerGradeCode { get; set; }
        public string MainAdminRoleCode { get; set; }
        public DateTime DateOfFirstAppointment { get; set; }
        public DateTime DateOfCurrentAppointment { get; set; }
        public string AcademicQualification { get; set; }
        public string AcademicQualificationCertNo { get; set; }
        public string TeachingQualification { get; set; }
        public string TeachingQualificationCertNo { get; set; }
        public string StaffFileNo { get; set; }
        public SourceOfIncome SourceOfSalary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string YearOfFirstAppointment { get; set; }
        public string YearOfPresentAppointment { get; set; }
        public string YearOfPostingToCollege { get; set; }
        public string GradeLevel { get; set; }
        public string GradeLevelCode { get; set; }
        public string SubjectOfQualification { get; set; }
        public string AreaOfSpecialization { get; set; }
        public string MainSubjectTaught { get; set; }
        public TeachingType TeachingType { get; set; }
        public string InServiceTraining { get; set; }

        public DateTime RetiredDate { get; set; }
        public string StaffType { get; set; }
        public string StaffCategory { get; set; }
        public string StaffRank { get; set; }
  

        public string Step { get; set; }
        public bool DueForPromotion { get; set; }

        public int? GradeLevelPromotion { get; set; }
        public int? StepPromotion { get; set; }
        public int BasicSalary { get; set; }
        public int? BasicSalaryPromotion { get; set; }
        public List<AllowanceVM> Allowances { get; set; }
        public List<AllowancePromotionVM> AllowancePromotionVM { get; set; }
        public List<CertificateVM> Certificates { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string StaffCategoryCode { get; set; }
        public bool IsRetired { get; set; }
        public string Department { get; set; }


    }


    public class AllowanceVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }

    public class AllowancePromotionVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }

    public class CertificateVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image {get;set;}
        public string NameAndExtention { get; set; }

    }
}
