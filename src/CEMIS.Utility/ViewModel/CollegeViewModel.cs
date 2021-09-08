
using System;
using System.Collections.Generic;

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{

    public class CollegeViewModel
    {
        public long Id { get; set; }


        public Tab ActiveTab { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Address { get; set; }

        public string PrincipalName { get; set; }

        public string PrincipalEmail { get; set; }

        public string PrincipalPhone { get; set; }

        public string VicePrincipalName { get; set; }

        public string VicePrincipalEmail { get; set; }

        public string VicePrincipalPhone { get; set; }

        public string ICTSystemName { get; set; }

        public string ICTSystemEmail { get; set; }

        public string ICTSystemPhone { get; set; }

        public string AdminOfficerName { get; set; }

        public string AdminOfficerEmail { get; set; }

        public string AdminOfficerPhone { get; set; }

        public string GIS { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }


        public int SecretaryCount { get; set; }

        public int DriversCount { get; set; }

        public int HandymenCount { get; set; }

        public int SecurityGuardCount { get; set; }

        public int CleanerCount { get; set; }

        public long ServiceOfferedId { get; set; }

        public List<ServiceOfferedViewModel> ServiceOffered { get; set; }

        public long CourseOfferedId { get; set; }

        public List<CourseOfferedViewModel> CourseOfferedView { get; set; }

        public long CollegeFacilityId { get; set; }

        public List<CollegeFacilityViewModel> CollegeFacility { get; set; }

        public long CollegeClassRoomDataId { get; set; }

        public List<CollegeClassRoomDataViewModel> CollegeClassRoomData { get; set; }

        public long CollegeClassRoomInfoId { get; set; }

        public List<CollegeClassRoomInfoViewModel> CollegeClassRoomInfo { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsSynched { get; set; }

        [DataType(DataType.Date)]
        public DateTime FirstAccreditationDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CureentAccreditationDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime NextAccreditationDate { get; set; }

        public CollegeViewModel()
        {
            this.FirstAccreditationDate = DateTime.Now;
            this.CureentAccreditationDate = DateTime.Now;
            this.NextAccreditationDate = DateTime.Now;
        }

    }

    public class ServiceOfferedViewModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

    }

    public class CourseOfferedViewModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }

    //public class CollegeFacilityViewModel
    //{

    //    public long Id { get; set; }

    //    [Required]
    //    [StringLength(50)]
    //    public string Name { get; set; }
    //    public int Number { get; set; }
    //    public long CollegeId { get; set; }
    //    public List<CollegeFacilityList> CollegeFacility { get; set; }
    //    public bool IsDeleted { get; set; }
    //    public bool IsActive { get; set; }
    //    public long CreatedBy { get; set; }
    //    public long? UpdatedBy { get; set; }
    //    public DateTime DateCreated { get; set; }
    //    public DateTime? DateUpdated { get; set; }

    //    public CollegeFacilityViewModel()
    //    {
    //        this.CollegeFacility = new List<CollegeFacilityList>();
    //    }

    //}

    public class CollegeFacilityList
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }


    public class CollegeFacilityVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FacilityType { get; set; }
        public string YearOfConstruction { get; set; }
        public ClassRoomCondition PresentCondition { get; set; }
        public decimal LengthInMeters { get; set; }
        public decimal WidthInMeters { get; set; }
        public FloorMaterial FloorMaterial { get; set; }
        public RoofMaterial RoofMaterial { get; set; }
        public SeatAvailability Seatings { get; set; }
        public DisabilityAccessAvailability DisabilityAccess { get; set; }
        public string College { get; set; }
    }

    public class CollegeClassRoomDataViewModel
    {
        public long Id { get; set; }

        public int ClassRoomCount { get; set; }

        public int StaffRoomCount { get; set; }

        public int OfficeCount { get; set; }

        public int LibraryCount { get; set; }

        public int LaboratoryCount { get; set; }

        public int StoreRoomCount { get; set; }

        public int OthersCount { get; set; }

        public int IsClassHeldOutside { get; set; }

        public long CollegeId { get; set; }

    }

    public class CollegeClassRoomInfoViewModel
    {
        public long Id { get; set; }

        public string YearOfConstruction { get; set; }

        public ClassRoomCondition PresentCondition { get; set; }

        public decimal LengthInMeters { get; set; }

        public decimal WidthInMeters { get; set; }

        public FloorMaterial FloorMaterial { get; set; }

        public WallMaterial WallMaterial { get; set; }

        public RoofMaterial RoofMaterial { get; set; }

        public SeatAvailability Seatings { get; set; }

        public DisabilityAccessAvailability DisabilityAccess { get; set; }

        public long CollegeId { get; set; }
    }

    public enum Tab
    {
        College = 0,
        Facility,
        ClassRoomData,
        ClassRoomInfo
    }
}
