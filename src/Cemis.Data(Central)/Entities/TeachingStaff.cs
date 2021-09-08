using CEMIS.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Data.Central
{
    public class TeachingStaff : BaseEntity
    {
        public string Name { get; set; }
        public Utility.Gender Gender { get; set; }
        public long LecturerGrade { get; set; }
        public long MainAdminRole { get; set; }
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
        public long GradeLevel { get; set; }
        public string SubjectOfQualification { get; set; }
        public string AreaOfSpecialization { get; set; }
        public string MainSubjectTaught { get; set; }
        public TeachingType TeachingType { get; set; }
        public string InServiceTraining { get; set; }
        public DateTime RetiredDate { get; set; }
        public string StaffType { get; set; }
        public string StaffCategory { get; set; }
        public string StaffRank { get; set; }
        //public decimal BasicSalary { get; set; }
        public string Step { get; set; }
        public bool DueForPromotion { get; set; }
        //public decimal? BasicsalaryPromotion { get; set; }
        public int? GradeLevelPromotion { get; set; }
        public int? StepPromotion { get; set; }
        public int BasicSalary { get; set; }
        public int? BasicSalaryPromotion { get; set; }
        public string StaffCategoryCode { get; set; }
        public bool IsRetired { get; set; }
        public string Department { get; set; }
    }
}
