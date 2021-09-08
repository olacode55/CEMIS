
using Cemis.Data.Central.Entities;
using Cemis.Data.Central.Model;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;


namespace CEMIS.Business.Central.Repository
{
    public class CollegeRepository : ICollege
    {
        private IRepository<College> _collegeRepo;
        private IRepository<CollegeFacility> _collegeFacilityRepo;
        private IRepository<CollegeClassRoomInfo> _collegeClassRoomInfoRepo;
        private IRepository<CollegeClassRoomData> _collegeClassRoomDataRepo;
        private IRepository<CourseOffered> _coursesofferedRepo;
        private IRepository<ServiceOffered> _serviceOfferedRepo;
        private IRepository<TeachingStaffAdminRole> _teachingstaffRoleRepo;
        private IRepository<AcademicSession> _academicSessionRepo;

        private IConfiguration _configration;

        public CollegeRepository(IRepository<College> collegeRepo, IConfiguration configration, IRepository<CollegeFacility> collegeFacilityRepo,
                                 IRepository<CollegeClassRoomInfo> collegeClassRoomInfoRepo , IRepository<CollegeClassRoomData> collegeClassRoomDataRepo,
                                 IRepository<CourseOffered> coursesofferedRepo , IRepository<ServiceOffered> serviceOfferedRepo , 
                                 IRepository<TeachingStaffAdminRole> teachingstaffRoleRepo , IRepository<AcademicSession> academicSessionRepo)
        {
            _collegeRepo = collegeRepo;
            _collegeFacilityRepo = collegeFacilityRepo;
            _collegeClassRoomInfoRepo = collegeClassRoomInfoRepo;
            _collegeClassRoomDataRepo = collegeClassRoomDataRepo;
            _serviceOfferedRepo = serviceOfferedRepo;
            _coursesofferedRepo = coursesofferedRepo;
            _configration = configration;
            _teachingstaffRoleRepo = teachingstaffRoleRepo;
            _academicSessionRepo = academicSessionRepo;
        }

        public List<College> GetAllColleges()
        {
            return _collegeRepo.All().Where(x => x.IsDeleted == false && x.IsActive == true).ToList();
        }
        public List<TeachingStaffAdminRole> GetAllAminRoles()
        {
            return _teachingstaffRoleRepo.All().Where(x => x.IsDeleted == false && x.IsActive == true).ToList();
        }

        public College GetCollegeByAPIKey(string APIKey)
        {
            return _collegeRepo.All().FirstOrDefault(x => x.APIKey == APIKey);
        }

        public College GetCollegeById(long Id)
        {
            return _collegeRepo.Find(Id);
        }

        public ResponseData<College> CreateCollege(College college)
        {
            ResponseData<CollegeLeadership> resp;
            college.IsActive = true;
            college.IsDeleted = false;

           var collegeExist =  _collegeRepo.All().FirstOrDefault(x => x.Name == college.Name);
            if(collegeExist != null)
            {
                return new ResponseData<College>
                {
                    IsSuccessful = false,
                    Message = "College already exist",
                    RespCode = "01"
                };
            }
   
            _collegeRepo.Create(college);

            return new ResponseData<College>
            {
                Data = college,
                IsSuccessful = true,
                Message = "College created successfully",
                RespCode = "00"
            };
        }

        public ResponseData<College> PushCollegeInformtion(CollegeDTO collegeVM , College college)
        {
            ResponseData<College> resp;
            var facilityList = collegeVM.CollegeFacilityDTO;
            var classRoomInfoList = collegeVM.CollegeClassRoomInfoDTO;
            var classRoomData = collegeVM.CollegeClassRoomDataDTO;
            var coursesOfferedList = collegeVM.CourseOfferedDTO;
            var serviceOfferedList = collegeVM.ServiceOfferedDTO;
            using (var transaction = new TransactionScope())
            {
                try
                {
                   var CollegeById = college.Id;
                    if (collegeVM.ChangesOnCollegeDetails)
                    {
                        college.SourceID = collegeVM.CollegeDetailsDTO.Id;
                        college.Address = collegeVM.CollegeDetailsDTO.Address;
                        college.AdminOfficerEmail = collegeVM.CollegeDetailsDTO.AdminOfficerEmail;
                        college.AdminOfficerName = collegeVM.CollegeDetailsDTO.AdminOfficerName;
                        college.AdminOfficerPhone = collegeVM.CollegeDetailsDTO.AdminOfficerPhone;
                        college.CleanerCount = collegeVM.CollegeDetailsDTO.CleanerCount;
                        college.CreatedBy = collegeVM.CollegeDetailsDTO.CreatedBy;
                        college.DateCreated = collegeVM.CollegeDetailsDTO.DateCreated;
                        college.DateUpdated = collegeVM.CollegeDetailsDTO.DateUpdated;
                        college.DriversCount = collegeVM.CollegeDetailsDTO.DriversCount;
                        college.Email = collegeVM.CollegeDetailsDTO.Email;
                        college.GIS = collegeVM.CollegeDetailsDTO.GIS;
                        college.HandymenCount = collegeVM.CollegeDetailsDTO.HandymenCount;
                        college.ICTSystemEmail = collegeVM.CollegeDetailsDTO.ICTSystemEmail;
                        college.ICTSystemName = collegeVM.CollegeDetailsDTO.ICTSystemName;
                        college.ICTSystemPhone = collegeVM.CollegeDetailsDTO.ICTSystemPhone;
                        college.IsActive = collegeVM.CollegeDetailsDTO.IsActive;
                        college.IsDeleted = collegeVM.CollegeDetailsDTO.IsDeleted;
                        college.Name = collegeVM.CollegeDetailsDTO.Name;
                        college.Phone = collegeVM.CollegeDetailsDTO.Phone;
                        college.PrincipalEmail = collegeVM.CollegeDetailsDTO.PrincipalEmail;
                        college.PrincipalName = collegeVM.CollegeDetailsDTO.PrincipalName;
                        college.PrincipalPhone = collegeVM.CollegeDetailsDTO.PrincipalPhone;
                        college.SecretaryCount = collegeVM.CollegeDetailsDTO.SecretaryCount;
                        college.SecurityGuardCount = collegeVM.CollegeDetailsDTO.SecurityGuardCount;
                        college.UpdatedBy = collegeVM.CollegeDetailsDTO.UpdatedBy;
                        college.VicePrincipalEmail = collegeVM.CollegeDetailsDTO.VicePrincipalEmail;
                        college.VicePrincipalName = collegeVM.CollegeDetailsDTO.VicePrincipalName;
                        college.VicePrincipalPhone = collegeVM.CollegeDetailsDTO.VicePrincipalPhone;
                        college.DateFetched = DateTime.Now;


                        _collegeRepo.Update(college);

                    }

                    if (collegeVM.ChangesOnFacicility)
                    {
                        var facilityExist = _collegeFacilityRepo.All().Where(x => x.CollegeID == college.Id).ToList();

                        if (facilityExist.Count > 0)
                        {
                            _collegeFacilityRepo.Delete(facilityExist);
                        }
                        var facilityListModel = new List<CollegeFacility>();
                        foreach (var facility in facilityList)
                        {
                            var facilityModel = new CollegeFacility
                            {
                                CollegeID = college.Id,
                                SourceID = facility.Id,
                                CreatedBy = facility.CreatedBy,
                                DateCreated = facility.DateCreated,
                                DateUpdated = facility.DateUpdated,
                                IsActive = facility.IsActive,
                                IsDeleted = facility.IsDeleted,
                                Name = facility.Name,
                                Description = facility.Description,
                                DisabilityAccess = facility.DisabilityAccess,
                                FacilityType = facility.FacilityType,
                                FloorMaterial = facility.FloorMaterial,
                                LengthInMeters = facility.LengthInMeters,
                                PresentCondition = facility.PresentCondition,
                                RoofMaterial = facility.RoofMaterial,
                                Seatings = facility.Seatings,
                                WidthInMeters = facility.WidthInMeters,
                                YearOfConstruction = facility.YearOfConstruction,
                                UpdatedBy = facility.UpdatedBy,
                                DateFetched = DateTime.Now
                            };
                            facilityListModel.Add(facilityModel);


                        }
                        _collegeFacilityRepo.Create(facilityListModel);
                    }

                    if (collegeVM.ChangesOnClassRoomData)
                    {
                        var classRoomDataExist = _collegeClassRoomDataRepo.All().FirstOrDefault(x => x.CollegeId == college.Id && x.SourceId == classRoomData.Id);

                        var ClassRoomData = new CollegeClassRoomData
                        {
                            ClassRoomCount = classRoomData.ClassRoomCount,
                            IsClassHeldOutside = classRoomData.IsClassHeldOutside,
                            LaboratoryCount = classRoomData.LaboratoryCount,
                            LibraryCount = classRoomData.LibraryCount,
                            OfficeCount = classRoomData.OfficeCount,
                            OthersCount = classRoomData.OthersCount,
                            StaffRoomCount = classRoomData.StaffRoomCount,
                            StoreRoomCount = classRoomData.StoreRoomCount,
                            SourceId = classRoomData.Id,
                            CollegeId = college.Id,
                            DateFetched = DateTime.Now
                        };

                        if (classRoomDataExist == null)
                        {
                            classRoomData.Id = 0;

                            _collegeClassRoomDataRepo.Create(ClassRoomData);
                        }
                        else
                        {
                            classRoomDataExist.ClassRoomCount = classRoomData.ClassRoomCount;
                            classRoomDataExist.IsClassHeldOutside = classRoomData.IsClassHeldOutside;
                            classRoomDataExist.LaboratoryCount = classRoomData.LaboratoryCount;
                            classRoomDataExist.LibraryCount = classRoomData.LibraryCount;
                            classRoomDataExist.OfficeCount = classRoomData.OfficeCount;
                            classRoomDataExist.OthersCount = classRoomData.OthersCount;
                            classRoomDataExist.StaffRoomCount = classRoomData.StaffRoomCount;
                            classRoomDataExist.StoreRoomCount = classRoomData.StoreRoomCount;

                            _collegeClassRoomDataRepo.Update(classRoomDataExist);

                        }
                    }

                    if (collegeVM.ChangesOnClassRoomInfo)
                    {
                        var classRoomInfoExist = _collegeClassRoomInfoRepo.All().Where(x => x.CollegeId == college.Id).ToList();
                        if (classRoomInfoExist.Count > 0)
                        {
                            _collegeClassRoomInfoRepo.Delete(classRoomInfoExist);
                        }
                        var collegeClassRoomInfoList = new List<CollegeClassRoomInfo>();
                        foreach (var classRoom in classRoomInfoList)
                        {
                            var collegeClassRoomInfo = new CollegeClassRoomInfo
                            {
                                CollegeId = college.Id,
                                SourceId = classRoom.Id,
                                DateFetched = DateTime.Now,
                                DisabilityAccess = classRoom.DisabilityAccess,
                                FloorMaterial = classRoom.FloorMaterial,
                                LengthInMeters = classRoom.LengthInMeters,
                                PresentCondition = classRoom.PresentCondition,
                                RoofMaterial = classRoom.RoofMaterial,
                                Seatings = classRoom.Seatings,
                                WallMaterial = classRoom.WallMaterial,
                                WidthInMeters = classRoom.WidthInMeters,
                                YearOfConstruction = classRoom.YearOfConstruction
                            };

                            collegeClassRoomInfoList.Add(collegeClassRoomInfo);


                        }
                        _collegeClassRoomInfoRepo.Create(collegeClassRoomInfoList);
                    }


                    if (collegeVM.ChangesOnServices)
                    {
                        var existingServicesOffered = _serviceOfferedRepo.All().Where(x => x.CollegeID == college.Id).ToList();
                        if (existingServicesOffered.Count > 0)
                        {
                            _serviceOfferedRepo.Delete(existingServicesOffered);
                        }

                        var servicesOfferedList = new List<ServiceOffered>();
                        foreach (var service in serviceOfferedList)
                        {
                            var serviceOffered = new ServiceOffered
                            {
                                CollegeID = college.Id,
                                SourceID = service.Id,
                                CreatedBy = service.CreatedBy,
                                DateCreated = service.DateCreated,
                                DateUpdated = service.DateUpdated,
                                IsActive = service.IsActive,
                                IsDeleted = service.IsDeleted,
                                UpdatedBy = service.UpdatedBy,
                                DateFetched = DateTime.Now,
                                Name = service.Name
                            };
                            servicesOfferedList.Add(serviceOffered);
                        }
                        _serviceOfferedRepo.Create(servicesOfferedList);


                    }

                    if (collegeVM.ChangesOnCourse)
                    {
                        var existingCoursesOffered = _coursesofferedRepo.All().Where(x => x.CollegeID == college.Id).ToList();
                        if (existingCoursesOffered.Count > 0)
                        {
                            _coursesofferedRepo.Delete(existingCoursesOffered);
                        }

                        var courseOfferedList = new List<CourseOffered>();
                        foreach (var course in coursesOfferedList)
                        {
                            var courseOffered = new CourseOffered
                            {
                                CollegeID = college.Id,
                                SourceID = course.Id,
                                DateFetched = DateTime.Now,
                                CourseCode = course.CourseCode,
                                CourseTitle = course.CourseTitle,
                                Credit = course.Credit,
                                Level = course.Level,
                                Option = course.Option,
                                ProgramId = course.ProgramId,
                                Semester = course.Semester,
                                CreatedBy = course.CreatedBy,
                                DateCreated = course.DateCreated,
                                DateUpdated = course.DateUpdated,
                                IsActive = course.IsActive,
                                IsDeleted = course.IsDeleted,
                                UpdatedBy = course.UpdatedBy
                            };
                            courseOfferedList.Add(courseOffered);
                        }
                        _coursesofferedRepo.Create(courseOfferedList);

                    }
                  

                    transaction.Complete();

                    resp = new ResponseData<College>
                    {
                        Message = "College Information created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;

                }
                catch (Exception ex)
                {
                    ErrorLogManager.Error(ex);
                    return new ResponseData<College>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }

        public ResponseData<AcademicSession> SessionInformtion(AcademicSessionViewModel sessionVM, College college)
        {
            ResponseData<AcademicSession> resp;
            try
            {

                var sessionExist = _academicSessionRepo.All().FirstOrDefault(x => x.SourceID == sessionVM.Id && x.CollegeID == college.Id);
                if(sessionExist == null) {
                    var academicSession = new AcademicSession
                    {
                        AcademicPeriod = sessionVM.AcademicPeriod,
                        CollegeID = college.Id,
                        CreatedBy = sessionVM.CreatedBy,
                        DateCreated = sessionVM.DateCreated,
                        DateFetched = DateTime.Now,
                        DateUpdated = sessionVM.DateUpdated,
                        FirstSemesterEndDate = sessionVM.FirstSemesterEndDate,
                        FirstSemesterStartDate = sessionVM.FirstSemesterStartDate,
                        SecondSemesterEndDate = sessionVM.SecondSemesterEndDate,
                        SecondSemesterStartDate = sessionVM.SecondSemesterStartDate,
                        SourceID = sessionVM.Id,
                        IsActive = sessionVM.IsActiveSync,
                        IsDeleted = sessionVM.IsDeleted,
                        UpdatedBy = sessionVM.UpdatedBy,

                    };

                    _academicSessionRepo.Create(academicSession);

                    resp = new ResponseData<AcademicSession>
                    {
                        Message = "Session created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }



                sessionExist.AcademicPeriod = sessionVM.AcademicPeriod;
                sessionExist.CollegeID = college.Id;
                sessionExist.DateUpdated = sessionVM.DateUpdated;
                sessionExist.FirstSemesterEndDate = sessionVM.FirstSemesterEndDate;
                sessionExist.FirstSemesterStartDate = sessionVM.FirstSemesterStartDate;
                sessionExist.SecondSemesterEndDate = sessionVM.SecondSemesterEndDate;
                sessionExist.SecondSemesterStartDate = sessionVM.SecondSemesterStartDate;
                sessionExist.IsActive = sessionVM.IsActiveSync;
                sessionExist.IsDeleted = sessionVM.IsDeleted;
                sessionExist.UpdatedBy = sessionVM.UpdatedBy;

                _academicSessionRepo.Update(sessionExist);

                resp = new ResponseData<AcademicSession>
                {
                    Message = "Session updated successfully",
                    RespCode = "00",
                    IsSuccessful = true
                };

                return resp;

            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<AcademicSession>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
        }
    }
}
