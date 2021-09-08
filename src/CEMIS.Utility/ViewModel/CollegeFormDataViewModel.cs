
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class CollegeFormDataViewModel
    {
        public long Id { get; set; }

        public Tab ActiveTab { get; set; }

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

        public int SecretaryCount { get; set; }

        public int DriversCount { get; set; }

        public int HandymenCount { get; set; }

        public int SecurityGuardCount { get; set; }

        public int CleanerCount { get; set; }

        public string FacilityName { get; set; }
        public int FacilityNo { get; set; }

        public int ClassRoomCount { get; set; }

        public int StaffRoomCount { get; set; }

        public int OfficeCount { get; set; }

        public int LibraryCount { get; set; }

        public int LaboratoryCount { get; set; }

        public int StoreRoomCount { get; set; }

        public int OthersCount { get; set; }

        public int IsClassHeldOutside { get; set; }

        public string YearOfConstruction { get; set; }

        public int PresentCondition { get; set; }

        public decimal LengthInMeters { get; set; }

        public decimal WidthInMeters { get; set; }

        public int FloorMaterial { get; set; }

        public int WallMaterial { get; set; }

        public int RoofMaterial { get; set; }

        public int Seatings { get; set; }

        public int DisabilityAccess { get; set; }

        public long ServiceOfferedId { get; set; }

        public long CourseOfferedId { get; set; }

        public bool IsSynched { get; set; }

        public List<ProgramViewModel> ServicesOffered { get; set; }
        public List<CourseOfferedViewModel> CourseOfferedView { get; set; }

        public List<CollegeFacilityViewModel> CollegeFacility { get; set; }

        public List<CollegeClassRoomInfoViewModel> CollegeClassRoomInfo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FirstAccreditationDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CureentAccreditationDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime NextAccreditationDate { get; set; }

        public CollegeFormDataViewModel()
        {
            this.CollegeFacility = new List<CollegeFacilityViewModel>();
            this.CollegeClassRoomInfo = new List<CollegeClassRoomInfoViewModel>();
            this.CourseOfferedView = new List<CourseOfferedViewModel>();
            this.ServicesOffered = new List<ProgramViewModel>();
        }


    }
}
