using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
   public class TeachingStaffViewModel
    {

       
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string MiddleName { get; set; }
        public Gender gender { get; set; }
        public string LecturerGrade { get; set; }
        public string staffCategoryCode { get; set; }
        public string MainAdminRole { get; set; }
        public DateTime retiredDate { get; set; }
        public DateTime DateOfFirstAppointment { get; set; }
        public DateTime DateOfCurrentAppointment { get; set; }
        public string AcademicQualification { get; set; }
        public string AcademicQualificationCertNo { get; set; }
        public string TeachingQualification { get; set; }
        public string TeachingQualificationCertNo { get; set; }
        public string awardingInstitutionforHighestTeachingQualification { get; set; }
        public string awardingInstitutionforHighestQualification { get; set; }
        public int department { get; set; }
        public string StaffFileNo { get; set; }
        public SourceOfIncome SourceOfSalary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string YearOfFirstAppointment { get; set; }
        public string YearOfPresentAppointment { get; set; }
        public string YearOfPostingToCollege { get; set; }
        public string GradeLevel { get; set; }
        public string SubjectOfQualification { get; set; }
        public string AreaOfSpecialization { get; set; }
        public string MainSubjectTaught { get; set; }
        public TeachingType TeachingType { get; set; }
        public string InServiceTraining { get; set; }
        public long CollegeID { get; set; }
        public string College { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsSynched { get; set; }

        public int staffType { get; set; }
        public string staffCategory { get; set; }
        public string staffRank { get; set; }
        public int basicSalary { get; set; }

        public string step { get; set; }
        public bool DueForPromotion { get; set; }

        public decimal marketPremium { get; set; }
        public decimal books { get; set; }
        public decimal research { get; set; }
        public decimal responsibility { get; set; }
        public decimal carMaintenance { get; set; }
        public decimal motorBikeMaintenance { get; set; }
        public decimal bicycleMaintenance { get; set; }
        public decimal domesticServant { get; set; }
        public decimal householdSupplies { get; set; }
        public decimal entertainment { get; set; }

        public decimal others { get; set; }

        public int basicsalaryPromotion { get; set; }
        public int gradeLevelPromotion { get; set; }
        public string stepPromotion { get; set; }
        public decimal marketPremiumPromotionAllowance { get; set; }
        public decimal booksPromotionAllowance { get; set; }
        public decimal researchPromotionAllowance { get; set; }
        public decimal responsibilityPromotionAllowance { get; set; }
        public decimal carMaintenancePromotionAllowance { get; set; }
        public decimal motorBikeMaintenancePromotionAllowance { get; set; }
        public decimal bicycleMaintenancePromotionAllowance { get; set; }
        public decimal domesticServantPromotionAllowance { get; set; }
        public decimal householdSuppliesPromotionAllowance { get; set; }
        public decimal entertainmentPromotionAllowance { get; set; }
        public decimal othersPromotionAllowance { get; set; }
        public List<CertificatesViewModel> Certificates { get; set; }
        public List<StaffAllowanceViewModel> StaffAllowances { get; set; }
        public List<StaffDueForPromotionViewModel> staffDueForPromotions { get; set; }



        public TeachingStaffViewModel()
        {
            
            this.Certificates = new List<CertificatesViewModel>();
            this.StaffAllowances = new List<StaffAllowanceViewModel>();
            this.staffDueForPromotions = new List<StaffDueForPromotionViewModel>();
        }
    }


    

    public class StaffGradeLevelViewModel
    {
        public long Name { get; set; }
        public string Code { get; set; }
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public long CollegeID { get; set; }
        public long SourceID { get; set; }
        public DateTime DateFetched { get; set; }
    }   


}

