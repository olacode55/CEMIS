using System;
using System.Collections.Generic;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class CollegeDTO
    {
        public bool ChangesOnFacicility { get; set; }
        public bool ChangesOnClassRoomInfo { get; set; }
        public bool ChangesOnClassRoomData{ get; set; }
        public bool ChangesOnCollegeDetails { get; set; }
        public bool ChangesOnServices { get; set; }
        public bool ChangesOnCourse { get; set; }
        public CollegeDetailsDTO CollegeDetailsDTO { get; set; }
        public List<CollegeFacilityDTO> CollegeFacilityDTO { get; set; }
        public CollegeClassRoomDataDTO CollegeClassRoomDataDTO { get; set; }
        public List<CollegeClassRoomInfoDTO> CollegeClassRoomInfoDTO { get; set; }
        public List<CourseOfferedDTO> CourseOfferedDTO { get; set; }
        public List<ServiceOfferedDTO> ServiceOfferedDTO { get; set; }

    }

    public class CollegeDetailsDTO
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Name { get; set; }

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

        public string Phone { get; set; }
        public string Email { get; set; }

        public long ServiceOfferedId { get; set; }

        public int SecretaryCount { get; set; }

        public int DriversCount { get; set; }

        public int HandymenCount { get; set; }

        public int SecurityGuardCount { get; set; }

        public int CleanerCount { get; set; }
    }

    public class CollegeFacilityDTO
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FacilityType { get; set; }
        public string YearOfConstruction { get; set; }
        public int PresentCondition { get; set; }
        public decimal LengthInMeters { get; set; }
        public decimal WidthInMeters { get; set; }
        public int FloorMaterial { get; set; }
        public int RoofMaterial { get; set; }
        public int Seatings { get; set; }
        public int DisabilityAccess { get; set; }
        //public int Number { get; set; }
    }

    public class CollegeClassRoomDataDTO
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

    }

    public class CollegeClassRoomInfoDTO
    {
        public long Id { get; set; }
        public string YearOfConstruction { get; set; }
        public int PresentCondition { get; set; }
        public decimal LengthInMeters { get; set; }
        public decimal WidthInMeters { get; set; }
        public int FloorMaterial { get; set; }
        public int WallMaterial { get; set; }
        public int RoofMaterial { get; set; }
        public int Seatings { get; set; }
        public int DisabilityAccess { get; set; }

    }


    public class CourseOfferedDTO
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }

        public byte Credit { get; set; }

        public CourseOption Option { get; set; }

        public Semester Semester { get; set; }

        public long ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string CollegeName { get; set; }

        public string Level { get; set; }

    }

    public class ServiceOfferedDTO
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Name { get; set; }

    }


}
