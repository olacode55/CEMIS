using CEMIS.Data.Central;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cemis.Data.Central.Entities
{
    public class Allowance :BaseEntity
    {

        //public long Id { get; set; }
        //public DateTime? DateFetched { get; set; }
        //public long CollegeID { get; set; }
        //public long StaffId { get; set; }
        //[ForeignKey("StaffId")]
        //public TeachingStaff teachingStaff { get; set; }
        //public decimal MarketPremium { get; set; }
        //public decimal Books { get; set; }
        //public decimal Research { get; set; }
        //public decimal Responsibility { get; set; }
        //public decimal CarMaintenance { get; set; }
        //public decimal MotorBikeMaintenance { get; set; }
        //public decimal BicycleMaintenance { get; set; }
        //public decimal DomesticServant { get; set; }
        //public decimal HouseholdSupplies { get; set; }
        //public decimal Entertainment { get; set; }
        //public decimal Others { get; set; }
        //public decimal BasicSalary { get; set; }
        //public decimal? BasicsalaryPromotion { get; set; }
        //public decimal? MarketPremiumPromotionAllowance { get; set; }
        //public decimal? BooksPromotionAllowance { get; set; }
        //public decimal? ResearchPromotionAllowance { get; set; }
        //public decimal? ResponsibilityPromotionAllowance { get; set; }
        //public decimal? CarMaintenancePromotionAllowance { get; set; }
        //public decimal? MotorBikeMaintenancePromotionAllowance { get; set; }
        //public decimal? BicycleMaintenancePromotionAllowance { get; set; }
        //public decimal? DomesticServantPromotionAllowance { get; set; }
        //public decimal? HouseholdSuppliesPromotionAllowance { get; set; }
        //public decimal? EntertainmentPromotionAllowance { get; set; }
        //public decimal? OthersPromotionAllowance { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
        public bool IsBasicSalary { get; set; }
    }
}
