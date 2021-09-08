using CEMIS.Business.Interface;

using CEMIS.Data.Entities;
//using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Utility;
using Microsoft.Extensions.Configuration;
using CEMIS.Utility.ViewModel;
using Hangfire;
using System.IO;
using Microsoft.EntityFrameworkCore;
using CEMIS.Data;

namespace CEMIS.Web.Utilities
{
    public class HandFireJobHandler : IHandFireJobHandler
    {
        private readonly IConfiguration _configration;
        private readonly IRepository<APIRequestLog> _apiRequestRepo;
        private readonly IRepository<College> _collegeRepo;
        private readonly IRepository<TeachingStaff> _teachingRepo;
        private readonly IRepository<CollegeLeadership> _collegeLeadershipRepo;
        private readonly IRepository<TeachingStaffAdminRole> _staffAminRoleRepo;
        private readonly IStaffGradeLevel _staffGradeLevel;
        private readonly IRepository<CollegeFacility> _collegeFacilityRepo;
        private readonly IRepository<FacilityType> _facilityTypeRepo;
        private readonly IRepository<CollegeClassRoomData> _collegeClassRoomDataRepo;
        private readonly IRepository<CollegeClassRoomInfo> _collegeClassRoomInfoRepo;
        private readonly IRepository<Student> _studentRepo;
        private readonly IRepository<StaffCategory> _staffCategory;
        private readonly IRepository<StaffRank> _staffRank;
        private readonly IRepository<StaffType> _staffType;
        private readonly IRepository<AcademicSession> _academicSessionRepo;
        private readonly IRepository<CouncilMember> _councilMemberRepo;
        private readonly IRepository<Allowance> _allowanceRepo;
        private readonly IRepository<StaffAllowance> _staffAllowanceRepo;
        private readonly IRepository<StaffDueForPromotionAllowance> _staffDueForPromotionAllowanceRepo;
        private readonly IRepository<CEMIS.Data.Entities.Program> _serviceOfferedRepo;
        private readonly IRepository<Course> _courseOfferedRepo;
        private readonly IRepository<TrackCollegeChanges> _trackCollegeChangesRepo;
        private readonly IRepository<Result> _resultRepo;
        private readonly IRepository<Data.Entities.Level> _levelRepo;
        private readonly IRepository<Department> _departmentRepo;
        private readonly IRepository<CouncilSession> _councilSessionRepo;
        private readonly IRepository<CommitteMembers> _committeeMembersRepo;
        private readonly IRepository<Committee> _committeeRepo;
        private readonly IRepository<StudentLog> _studentLogRepo;
        public HandFireJobHandler(IRepository<APIRequestLog> apiRequestRepo, IRepository<College> collegeRepo, IRepository<TeachingStaff> teachingRepo,
            IRepository<CollegeFacility> collegeFacilityRepo, IRepository<CollegeClassRoomData> collegeClassRoomDataRepo, IRepository<CollegeClassRoomInfo> collegeClassRoomInfoRepo,
                                    IRepository<CEMIS.Data.Entities.Program> serviceOfferedRepo, IRepository<Course> courseOfferedRepo, IRepository<CollegeLeadership> collegeLeadershipRepo,
                                    IConfiguration configration, IStaffGradeLevel staffGradeLevel, IRepository<TeachingStaffAdminRole> staffAminRoleRepo, IRepository<Student> studentRepo,
                                    IRepository<StaffCategory> staffCategory, IRepository<StaffRank> staffRank, IRepository<StaffType> staffType,
                                    IRepository<FacilityType> facilityTypeRepo, IRepository<AcademicSession> academicSessionRepo, IRepository<CouncilMember> councilMemberRepo,
                                    IRepository<TrackCollegeChanges> trackCollegeChangesRepo , IRepository<Allowance> allowanceRepo , IRepository<StaffAllowance> staffAllowanceRepo
                                    ,IRepository<StaffDueForPromotionAllowance> staffDueForPromotionAllowanceRepo , IRepository<Result> resultRepo , IRepository<Data.Entities.Level> levelRepo,
                                    IRepository<Department> departmentRepo , IRepository<CouncilSession> councilSessionRepo , IRepository<CommitteMembers> committeeMembersRepo ,
                                    IRepository<Committee> committeeRepo , IRepository<StudentLog> studentLogRepo)
        {
            _levelRepo = levelRepo;
            _resultRepo = resultRepo;
            _collegeRepo = collegeRepo;
            _teachingRepo = teachingRepo;
            _collegeLeadershipRepo = collegeLeadershipRepo;
            _configration = configration;
            _staffAminRoleRepo = staffAminRoleRepo;
            _staffGradeLevel = staffGradeLevel;
            _collegeFacilityRepo = collegeFacilityRepo;
            _collegeClassRoomDataRepo = collegeClassRoomDataRepo;
            _collegeClassRoomInfoRepo = collegeClassRoomInfoRepo;
            _serviceOfferedRepo = serviceOfferedRepo;
            _courseOfferedRepo = courseOfferedRepo;
            _studentRepo = studentRepo;
            _staffCategory = staffCategory;
            _staffRank = staffRank;
            _staffType = staffType;
            _facilityTypeRepo = facilityTypeRepo;
            _academicSessionRepo = academicSessionRepo;
            _councilMemberRepo = councilMemberRepo;
            _trackCollegeChangesRepo = trackCollegeChangesRepo;
            _allowanceRepo = allowanceRepo;
            _staffAllowanceRepo = staffAllowanceRepo;
            _staffDueForPromotionAllowanceRepo = staffDueForPromotionAllowanceRepo;
            _departmentRepo = departmentRepo;
            _councilSessionRepo = councilSessionRepo;
            _committeeMembersRepo = committeeMembersRepo;
            _apiRequestRepo = apiRequestRepo;
            _committeeRepo = committeeRepo;
            _studentLogRepo = studentLogRepo;
        }
        public void ReccuringJob()
        {

            //RecurringJob.RemoveIfExists("GetBasicSalary");
            //RecurringJob.AddOrUpdate(() => new ManualJobHandler(_configration).GetBasicSalary(), "*/30 * * * *");

            //RecurringJob.RemoveIfExists(nameof(UploadStudentResult));
            //RecurringJob.AddOrUpdate(() => UploadStudentResult(), "*/3 * * * *");

            //RecurringJob.RemoveIfExists(nameof(HandleCollegeLeadershipRequest));
            //RecurringJob.AddOrUpdate(() => HandleCollegeLeadershipRequest(), "*/30 * * * *");

            //RecurringJob.RemoveIfExists(nameof(HandleCollegeTeachingStaffRequest));
            //RecurringJob.AddOrUpdate(() => HandleCollegeTeachingStaffRequest(), "*/2 * * * *");

            //RecurringJob.RemoveIfExists(nameof(PushCouncilSession));
            //RecurringJob.AddOrUpdate(() => PushCouncilSession(), "*/5 * * * *");

            //RecurringJob.RemoveIfExists(nameof(HandleCollegeInformationRequest));
            //RecurringJob.AddOrUpdate(() => HandleCollegeInformationRequest(), "*/20 * * * *");

            //RecurringJob.RemoveIfExists(nameof(PushCollegeSession));
            //RecurringJob.AddOrUpdate(() => PushCollegeSession(), "*/5 * * * *");

            //RecurringJob.RemoveIfExists(nameof(PushCollegeCouncilMembers));
            //RecurringJob.AddOrUpdate(() => PushCollegeCouncilMembers(), "*/10 * * * *");

            //RecurringJob.RemoveIfExists(nameof(HandleStudentDetailsRequest));
            //RecurringJob.AddOrUpdate(() => HandleStudentDetailsRequest(), "*/10 * * * *");

            //RecurringJob.RemoveIfExists(nameof(PushCommiteeMembers));
            //RecurringJob.AddOrUpdate(() => PushCommiteeMembers(), "*/2 * * * *");

            //RecurringJob.RemoveIfExists(nameof(PushCommitee));
            //RecurringJob.AddOrUpdate(() => PushCommitee(), "*/5 * * * *");

          //  RecurringJob.RemoveIfExists(nameof(Studentlog));
          //  RecurringJob.AddOrUpdate(() => Studentlog(), "*/5 * * * *");
            
        }


        public void PushCollegeSession()
        {
            var sessionList = _academicSessionRepo.All().Where(x => x.IsSynched == false).ToList();
            try
            {

                foreach (var session in sessionList)
                {
                    var sessionVM = new AcademicSessionViewModel
                    {
                        Id = session.Id,
                        AcademicPeriod = session.AcademicPeriod,
                        FirstSemesterEndDate = session.FirstSemesterEndDate,
                        FirstSemesterStartDate = session.FirstSemesterStartDate,
                        SecondSemesterEndDate = session.SecondSemesterEndDate,
                        SecondSemesterStartDate = session.SecondSemesterStartDate,
                        IsActiveSync = session.IsActive,//created IsActiveSync because IsActive is a type of string in the viewmodel
                        CreatedBy = session.CreatedBy,
                        IsDeleted = session.IsDeleted,
                        DateCreated = session.DateCreated,
                        DateUpdated = session.DateUpdated,
                        UpdatedBy = session.UpdatedBy

                    };
                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(sessionVM);
                    var apiKey = _configration.GetSection("APIKey").Value;
                    string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("AcademicSessionAPIURL").Value.Replace("{API-Key}", apiKey);
                    var postResponse = HTTPClientWrapper<object>.PostRequest(url, sessionVM).Result;
                    if (postResponse.IsSuccessful)
                    {
                        session.IsSynched = true;

                        _academicSessionRepo.Update(session);

                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = true,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }

        }




        public void PushCouncilSession()
        {
            var sessionList = _councilSessionRepo.All().Where(x => x.IsSynched == false).ToList();
            try
            {

                foreach (var session in sessionList)
                {
                    var sessionVM = new CouncilSessionViewModel
                    {
                        Id = session.Id,
                        endDate = session.EndDate,
                        startDate  = session.StartDate,
                        name = session.Name,
                        IsActiveSyn = session.IsActive,//created IsActiveSync because IsActive is a type of string in the viewmodel
                        CreatedBy = session.CreatedBy,
                        IsDeleted = session.IsDeleted,
                        DateCreated = session.DateCreated,
                        DateUpdated = session.DateUpdated,
                        UpdatedBy = session.UpdatedBy

                    };
                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(sessionVM);
                    var apiKey = _configration.GetSection("APIKey").Value;
                    string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("CouncilSessionAPIURL").Value.Replace("{API-Key}", apiKey);
                    var payLoad = new ResponseData<CouncilSessionViewModel>
                    {
                        Data = sessionVM
                    };

                    var postResponse = HTTPClientWrapper<ResponseData<CouncilSessionViewModel>>.PostRequest(url, payLoad).Result;

                    //var postResponse = HTTPClientWrapper<object>.PostRequest(url, sessionVM).Result;
                    if (postResponse.IsSuccessful)
                    {
                        session.IsSynched = true;

                        _councilSessionRepo.Update(session);

                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = true,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }

        }


        public void PushCollegeCouncilMembers()
        {
            var councilMemeberList = _councilMemberRepo.All().Where(x => x.IsSynched == false).ToList();
            try
            {

                foreach (var member in councilMemeberList)
                {
                    var memeberVM = new CouncilMemberViewModel
                    {
                        Id = member.Id,
                        councilMemberName = member.CouncilMemberName,
                        councilMemberPosition = member.CouncilMemberPosition,
                        sessionId = member.SessionId,
                        sessionName = member.SessionName,
                        IsActive = member.IsActive,
                        CreatedBy = member.CreatedBy,
                        IsDeleted = member.IsDeleted,
                        DateCreated = member.DateCreated,
                        DateUpdated = member.DateUpdated,
                        UpdatedBy = member.UpdatedBy,
                        
                    };
                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(memeberVM);
                    var apiKey = _configration.GetSection("APIKey").Value;
                    string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("CouncilMemberAPIURL").Value.Replace("{API-Key}", apiKey);
                    var postResponse = HTTPClientWrapper<object>.PostRequest(url, memeberVM).Result;
                    if (postResponse.IsSuccessful)
                    {
                        member.IsSynched = true;

                        _councilMemberRepo.Update(member);

                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = true,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }

        }


        public void PushCommitee()
        {
            var commiteeList = _committeeRepo.All().Where(x => x.IsSynched == false).ToList();

            try
            {
                foreach (var committee in commiteeList)
                {
                    var commiteeVM = new CommitteViewModel
                    {
                        Id = committee.Id,
                        name = committee.Name,
                        IsActive = committee.IsActive,
                        CreatedBy = committee.CreatedBy,
                        IsDeleted = committee.IsDeleted,
                        DateCreated = committee.DateCreated,
                        DateUpdated = committee.DateUpdated,
                        UpdatedBy = committee.UpdatedBy,
                    };
                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(commiteeVM);
                    var apiKey = _configration.GetSection("APIKey").Value;
                    string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("CommiteeAPIURL").Value.Replace("{API-Key}", apiKey);
                    var postResponse = HTTPClientWrapper<object>.PostRequest(url, commiteeVM).Result;
                    if (postResponse.IsSuccessful)
                    {
                        committee.IsSynched = true;

                        _committeeRepo.Update(committee);

                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = true,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }

        }


        public void PushCommiteeMembers()
        {
            var commiteeMemeberList = _committeeMembersRepo.All().Where(x => x.IsSynched == false).ToList();
            try
            {
                foreach (var member in commiteeMemeberList)
                {
                    var memeberVM = new CommitteMemberViewModel
                    {
                        Id = member.Id,
                        committeMemberName = member.CommitteMemberName,
                        committeMemberPosition = member.CommitteMemberPosition,
                        committeName = member.CommitteName,
                        committeId = member.CommitteId,
                        sessionId = member.SessionId,
                        sessionName = member.SessionName,
                        IsActive = member.IsActive,
                        CreatedBy = member.CreatedBy,
                        IsDeleted = member.IsDeleted,
                        DateCreated = member.DateCreated,
                        DateUpdated = member.DateUpdated,
                        UpdatedBy = member.UpdatedBy,
                    };
                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(memeberVM);
                    var apiKey = _configration.GetSection("APIKey").Value;
                    string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("CommiteeMembersAPIURL").Value.Replace("{API-Key}", apiKey);
                    var postResponse = HTTPClientWrapper<object>.PostRequest(url, memeberVM).Result;
                    if (postResponse.IsSuccessful)
                    {
                        member.IsSynched = true;

                        _committeeMembersRepo.Update(member);

                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = true,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }
        }

        public void HandleCollegeLeadershipRequest()
        {
            var pendingPayLoads = _collegeLeadershipRepo.All().Where(x => x.IsSynched == false).ToList();
            try
            {

                foreach (var payLoad in pendingPayLoads)
                {
                    //var role = _staffAminRoleRepo.All().FirstOrDefault(x => x.Id == (long)payLoad.Role);

                    //var roleCode = role == null ? string.Empty : role.Code;
                    var collegeLeadershipVM = new CollegeLeadershipViewModel
                    {
                        Id = payLoad.Id,
                        CouncilMember = payLoad.CouncilMember,
                        CouncilMemberEmail = payLoad.CouncilMemberEmail,
                        CouncilMemberPhone1 = payLoad.CouncilMemberPhone1,
                        CouncilMemberPhone2 = payLoad.CouncilMemberPhone2,
                        CouncilMemberPostalAddress = payLoad.CouncilMemberPostalAddress,
                        CouncilMemberSponsor = payLoad.CouncilMemberSponsor,
                        CreatedBy = payLoad.CreatedBy,
                        DateCreated = payLoad.DateCreated,
                        DateAppointed = payLoad.DateAppointed,
                        DateLeft = payLoad.DateLeft,
                        DateOfBirth = payLoad.DateOfBirth,
                        DateUpdated = payLoad.DateUpdated,
                        UpdatedBy = payLoad.UpdatedBy,
                        Gender = payLoad.Gender,
                        Name = payLoad.Name,
                        Role = payLoad.Role,
                        IsActive = payLoad.IsActive,
                        IsDeleted = payLoad.IsDeleted,
                        SessionId = payLoad.Session,
                        SessionName = payLoad.SessionName
                    };

                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(collegeLeadershipVM);
                    var apiKey = _configration.GetSection("APIKey").Value;
                    string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("CollegeLeadershipAPIURL").Value.Replace("{API-Key}", apiKey);
                    var postResponse = HTTPClientWrapper<object>.PostRequest(url, collegeLeadershipVM).Result;
                    if (postResponse.IsSuccessful)
                    {
                        payLoad.IsSynched = true;

                        _collegeLeadershipRepo.Update(payLoad);

                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = true,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }
        }



        public void HandleCollegeInformationRequest()
        {
            var collegeFacilityDTO = new List<CollegeFacilityDTO>();
            var claassRoomInfoDTO = new List<CollegeClassRoomInfoDTO>();
            var serviceOfferedDTO = new List<ServiceOfferedDTO>();
            var courseOfferedDTO = new List<CourseOfferedDTO>();
            var classRoomDataDTO = new CollegeClassRoomDataDTO();
            var collegeDetailsDTO = new CollegeDetailsDTO();
            try
            {
                var collegeDetails = _collegeRepo.All().FirstOrDefault(x => x.IsSynched == false);

                var changesList = _trackCollegeChangesRepo.All().ToList();
                var changesToFacility = changesList.FirstOrDefault(x => x.ModuleID == (int)CollegeModule.facility).HasChanged;
                var changesToClassRoomData = changesList.FirstOrDefault(x => x.ModuleID == (int)CollegeModule.ClassRoomData).HasChanged;
                var changesToClassRoomInfo = changesList.FirstOrDefault(x => x.ModuleID == (int)CollegeModule.ClassRoomInfo).HasChanged;
                var changesToServices = changesList.FirstOrDefault(x => x.ModuleID == (int)CollegeModule.Programs).HasChanged;
                var changesToCourses = changesList.FirstOrDefault(x => x.ModuleID == (int)CollegeModule.Courses).HasChanged;
                var changesToCollegeDetails = changesList.FirstOrDefault(x => x.ModuleID == (int)CollegeModule.CollegeDetails).HasChanged;

                var levelList = _levelRepo.All().ToList();

                if (collegeDetails != null)
                {
                    if (changesToFacility)
                    {
                        var collegeFacility = _collegeFacilityRepo.All().ToList();
                        
                        if (collegeFacility != null)
                        {
                            collegeFacilityDTO = collegeFacility.Select(x => new CollegeFacilityDTO
                            {
                                CreatedBy = x.CreatedBy,
                                DateCreated = x.DateCreated,
                                DateUpdated = x.DateUpdated,
                                Id = x.Id,
                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                Name = x.Name,
                                Description = x.Description,
                                DisabilityAccess = x.DisabilityAccess,
                                FloorMaterial = x.FloorMaterial,
                                LengthInMeters = x.LengthInMeters,
                                PresentCondition = x.PresentCondition,
                                RoofMaterial = x.RoofMaterial,
                                Seatings = x.Seatings,
                                WidthInMeters = x.WidthInMeters,
                                YearOfConstruction = x.YearOfConstruction,
                                FacilityType = _facilityTypeRepo.All().FirstOrDefault(m => m.Id == x.FacilityType).Name,
                                //Number = x.Number,
                                UpdatedBy = x.UpdatedBy
                            }).ToList();
                        }
                    }


                    if (changesToClassRoomData)
                    {
                        var classRoomData = _collegeClassRoomDataRepo.All().SingleOrDefault();

                        if (classRoomData != null)
                        {
                            classRoomDataDTO = new CollegeClassRoomDataDTO
                            {
                                Id = classRoomData.Id,
                                ClassRoomCount = classRoomData.ClassRoomCount,
                                IsClassHeldOutside = classRoomData.IsClassHeldOutside,
                                LaboratoryCount = classRoomData.LaboratoryCount,
                                LibraryCount = classRoomData.LibraryCount,
                                OfficeCount = classRoomData.OfficeCount,
                                OthersCount = classRoomData.OthersCount,
                                StaffRoomCount = classRoomData.StaffRoomCount,
                                StoreRoomCount = classRoomData.StoreRoomCount

                            };
                        }
                        else
                        {
                            classRoomDataDTO = new CollegeClassRoomDataDTO();
                        }
                    }

                    if (changesToClassRoomInfo)
                    {

                        var classRoomInfo = _collegeClassRoomInfoRepo.All().ToList();
                        if (classRoomInfo != null)
                        {
                            claassRoomInfoDTO = classRoomInfo.Select(x => new CollegeClassRoomInfoDTO
                            {
                                Id = x.Id,
                                DisabilityAccess = x.DisabilityAccess,
                                FloorMaterial = x.FloorMaterial,
                                LengthInMeters = x.LengthInMeters,
                                PresentCondition = x.PresentCondition,
                                RoofMaterial = x.RoofMaterial,
                                Seatings = x.Seatings,
                                WallMaterial = x.WallMaterial,
                                WidthInMeters = x.WidthInMeters,
                                YearOfConstruction = x.YearOfConstruction
                            }).ToList();
                        }

                    }

                    if (changesToServices)
                    {
                        var serviceOffered = _serviceOfferedRepo.All().ToList();
                        if (serviceOffered != null)
                        {
                            serviceOfferedDTO = serviceOffered.Select(x => new ServiceOfferedDTO
                            {
                                Id = x.Id,
                                Name = x.Name,
                                CreatedBy = x.CreatedBy,
                                DateCreated = x.DateCreated,
                               DateUpdated = x.DateUpdated,
                               IsActive = x.IsActive,
                               IsDeleted = x.IsDeleted,
                               UpdatedBy = x.UpdatedBy
                            }).ToList();
                        }
                    }

                    if (changesToCourses)
                    {
                        var courseOffered = _courseOfferedRepo.All().ToList();

                        if (courseOffered != null)
                        {
                            courseOfferedDTO = courseOffered.Select(x => new CourseOfferedDTO
                            {
                                Id = x.Id,
                                CourseCode = x.CourseCode,
                                CourseTitle = x.CourseTitle,
                                Credit = x.Credit,
                                Level = levelList.FirstOrDefault(m => m.Id == x.LevelId).Name,
                                Option = x.Option,
                                ProgramId = x.ProgramId,
                                Semester = x.Semester,
                                CreatedBy = x.CreatedBy,
                                DateCreated = x.DateCreated,
                                DateUpdated = x.DateUpdated,
                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                UpdatedBy = x.UpdatedBy
                            }).ToList();
                        }
                    }

                    if(changesToCollegeDetails) {
                        collegeDetailsDTO = new CollegeDetailsDTO
                        {
                            Id = collegeDetails.Id,
                            Address = collegeDetails.Address,
                            AdminOfficerEmail = collegeDetails.AdminOfficerEmail,
                            AdminOfficerName = collegeDetails.AdminOfficerName,
                            AdminOfficerPhone = collegeDetails.AdminOfficerPhone,
                            CleanerCount = collegeDetails.CleanerCount,
                            CreatedBy = collegeDetails.CreatedBy,
                            DateCreated = collegeDetails.DateCreated,
                            DateUpdated = collegeDetails.DateUpdated,
                            DriversCount = collegeDetails.DriversCount,
                            UpdatedBy = collegeDetails.UpdatedBy,
                            Email = collegeDetails.Email,
                            GIS = collegeDetails.GIS,
                            HandymenCount = collegeDetails.HandymenCount,
                            ICTSystemEmail = collegeDetails.ICTSystemEmail,
                            ICTSystemName = collegeDetails.ICTSystemName,
                            ICTSystemPhone = collegeDetails.ICTSystemPhone,
                            IsActive = collegeDetails.IsActive,
                            IsDeleted = collegeDetails.IsDeleted,
                            Name = collegeDetails.Name,
                            Phone = collegeDetails.Phone,
                            PrincipalEmail = collegeDetails.PrincipalEmail,
                            PrincipalName = collegeDetails.PrincipalName,
                            PrincipalPhone = collegeDetails.PrincipalPhone,
                            SecretaryCount = collegeDetails.SecretaryCount,
                            SecurityGuardCount = collegeDetails.SecurityGuardCount,
                            VicePrincipalEmail = collegeDetails.VicePrincipalEmail,
                            VicePrincipalName = collegeDetails.VicePrincipalName,
                            VicePrincipalPhone = collegeDetails.VicePrincipalPhone,
                        };

                    }

                    var collegeInformation = new CollegeDTO
                    {
                        ChangesOnClassRoomData = changesToClassRoomData,
                        ChangesOnClassRoomInfo = changesToClassRoomInfo,
                        ChangesOnCollegeDetails = changesToCollegeDetails,
                        ChangesOnCourse = changesToCourses,
                        ChangesOnFacicility = changesToFacility,
                        ChangesOnServices = changesToServices,
                        CollegeDetailsDTO = collegeDetailsDTO,
                        CollegeClassRoomDataDTO = classRoomDataDTO,
                        CollegeClassRoomInfoDTO = claassRoomInfoDTO,
                        CollegeFacilityDTO = collegeFacilityDTO,
                        ServiceOfferedDTO = serviceOfferedDTO,
                        CourseOfferedDTO = courseOfferedDTO
                    };
                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(collegeInformation);
                    var apiKey = _configration.GetSection("APIKey").Value;
                    string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("CollegeInformationAPIURL").Value.Replace("{API-Key}", apiKey);
                    var postResponse = HTTPClientWrapper<object>.PostRequest(url, collegeInformation).Result;
                    if (postResponse.IsSuccessful)
                    {
                        collegeDetails.IsSynched = true;
                        _collegeRepo.Update(collegeDetails);
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = true,
                            Url = url
                        };

                        var changedList = changesList.Where(x => x.HasChanged == true).ToList();

                        foreach(var item in changedList) {
                            item.HasChanged = false;
                        }

                        _trackCollegeChangesRepo.Update(changedList);
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    else
                    {
                    }

                }

            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }
        }
        public void HandleCollegeTeachingStaffRequest()
        {
            var teachingStaffs = _teachingRepo.All().Include(x => x.Certificates).Include(x => x.allowances)
                                                   .Include(x => x.StaffDueForPromotions)
                                                   .Where(x => x.IsSynched == false).ToList();
            var allowances = _allowanceRepo.All().ToList();
            var allowanceVM = new List<AllowanceVM>();
            var allowancePromotionVM = new List<AllowancePromotionVM>();
            try
            {
                foreach (var teachingStaff in teachingStaffs)
                {
                    var main = _staffAminRoleRepo.All().FirstOrDefault(x => x.Id == (long)teachingStaff.MainAdminRole);
                    var lecturegrade = _staffGradeLevel.GetAllStaffGradeLevel().FirstOrDefault(x => x.Id == (long)teachingStaff.LecturerGrade);
                    var grade = _staffAminRoleRepo.All().FirstOrDefault(x => x.Id == (long)teachingStaff.GradeLevel);
                    var category = _staffCategory.All().FirstOrDefault(x => x.Id == teachingStaff.Staffcategory);
                    var rank = _staffRank.All().FirstOrDefault(x => x.Id == teachingStaff.Staffrank);
                    var type = _staffType.All().FirstOrDefault(x => x.Id == teachingStaff.Stafftype);
                    var department = _departmentRepo.All().FirstOrDefault(x => x.Id == teachingStaff.Departments);

                    var mainCode = main == null ? string.Empty : main.Code;
                    var gradelevelCode = grade == null ? string.Empty : grade.Code;
                    var lecturegradeCode = lecturegrade == null ? string.Empty : lecturegrade.Code;
                    var StaffCategory = category == null ? string.Empty : category.Name;
                    var staffRank = rank == null ? string.Empty : rank.Name;
                    var staffType = type == null ? string.Empty : type.Name;
                    var departmentName = department == null ? string.Empty : department.Name;

                    if (teachingStaff.allowances != null)
                    {
                    allowanceVM = teachingStaff.allowances.Select(x => new AllowanceVM
                        {
                            Id = x.Id,
                            Amount = x.Amount,
                            Name = x.Allowance.Name,
                            CreatedBy = x.CreatedBy,
                            DateCreated = x.DateCreated,
                            DateUpdated = x.DateUpdated,
                            IsActive = x.IsActive,
                            IsDeleted = x.IsDeleted,
                            UpdatedBy = x.UpdatedBy
                        }).ToList();
                    }

                    if (teachingStaff.DueForPromotion && teachingStaff.StaffDueForPromotions != null)
                    {
                        allowancePromotionVM = teachingStaff.StaffDueForPromotions.Select(x => new AllowancePromotionVM
                        {
                            Id = x.Id,
                            Amount = x.Amount,
                            Name = x.Allowance.Name,
                            CreatedBy = x.CreatedBy,
                            DateCreated = x.DateCreated,
                            DateUpdated = x.DateUpdated,
                            IsActive = x.IsActive,
                            IsDeleted = x.IsDeleted,
                            UpdatedBy = x.UpdatedBy
                        }).ToList();
                    }

                    //get allowances
                    
                    var certificateList = new List<CertificateVM>();
                    if (teachingStaff.Certificates != null && teachingStaff.Certificates.Count > 0)
                    {


                        foreach (var certificate in teachingStaff.Certificates)
                        {
                            string folderName = "Upload";
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName + "\\" + certificate.Url);
                            string imageString = ImageConverter(path);

                            if (!string.IsNullOrEmpty(imageString))
                            {
                                var certificateVM = new CertificateVM();
                                certificateVM.Id = certificate.Id;
                                certificateVM.Name = certificate.Name;
                                certificateVM.Image = imageString;
                                certificateVM.NameAndExtention = certificate.Url;


                                certificateList.Add(certificateVM);
                            }

                        }
                    }
                    var collegestaffVM = new CollegeStaffViewModel
                    {
                        Id = teachingStaff.Id,
                        FirstName = teachingStaff.FirstName,
                        LastName = teachingStaff.LastName,
                        Gender = teachingStaff.Gender,
                        GradeLevelCode = gradelevelCode,
                        DateOfFirstAppointment = teachingStaff.DateOfFirstAppointment,
                        DateOfCurrentAppointment = teachingStaff.DateOfCurrentAppointment,
                        AcademicQualification = teachingStaff.AcademicQualification,
                        AcademicQualificationCertNo = teachingStaff.AcademicQualificationCertNo,
                        TeachingQualification = teachingStaff.TeachingQualification,
                        TeachingQualificationCertNo = teachingStaff.TeachingQualificationCertNo,
                        StaffFileNo = teachingStaff.StaffFileNo,
                        SourceOfSalary = teachingStaff.SourceOfSalary,
                        DateOfBirth = teachingStaff.DateOfBirth,
                        YearOfFirstAppointment = teachingStaff.YearOfFirstAppointment,
                        YearOfPresentAppointment = teachingStaff.YearOfPresentAppointment,
                        YearOfPostingToCollege = teachingStaff.YearOfPostingToCollege,
                        SubjectOfQualification = teachingStaff.SubjectOfQualification,
                        AreaOfSpecialization = teachingStaff.AreaOfSpecialization,
                        MainSubjectTaught = teachingStaff.MainSubjectTaught,
                        InServiceTraining = teachingStaff.InServiceTraining,
                        DateCreated = teachingStaff.DateCreated,
                        DateUpdated = teachingStaff.DateUpdated,
                        MainAdminRoleCode = mainCode,
                        LecturerGradeCode = lecturegradeCode,
                        IsActive = teachingStaff.IsActive,
                        IsDeleted = teachingStaff.IsDeleted,

                        DueForPromotion = teachingStaff.DueForPromotion,
                        RetiredDate = teachingStaff.RetiredDate,
                        StaffCategory = StaffCategory,
                        StaffRank = staffRank,
                        StaffType = staffType,
                        Step = teachingStaff.Step.ToString(),
                        CreatedBy = teachingStaff.CreatedBy,
                        TeachingType = teachingStaff.TeachingType,
                        Allowances = allowanceVM,
                        AllowancePromotionVM = allowancePromotionVM,
                        Certificates = certificateList,
                        GradeLevelPromotion = teachingStaff.GradeLevelPromotion,
                        StepPromotion = teachingStaff.StepPromotion,
                        BasicSalary = teachingStaff.Basicsalary,
                        BasicSalaryPromotion = teachingStaff.BasicsalaryPromotion,
                        StaffCategoryCode = teachingStaff.StaffCategoryCode,
                        IsRetired = teachingStaff.IsRetired,
                        Department = departmentName,
                        

                    };
                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(collegestaffVM);
                    var apiKey = _configration.GetSection("APIKey").Value;
                    string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("TeachingStaffAPIURL").Value.Replace("{API-Key}", apiKey);
                    var postResponse = HTTPClientWrapper<object>.PostRequest(url, collegestaffVM).Result;
                    if (postResponse.IsSuccessful)
                    {
                        teachingStaff.IsSynched = true;

                        _teachingRepo.Update(teachingStaff);

                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = true,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }
        }

        public void HandleStudentDetailsRequest()
        {
            var pendingPayLoads = _studentRepo.All().Where(x => x.IsSynched == false).ToList();

            try
            {
                foreach (var payLoad in pendingPayLoads)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _configration.GetSection("StudentPassportUploadPath").Value + "\\" + payLoad.Passport);
                    //var memory = new MemoryStream();
                    //using (var stream = new FileStream(path, FileMode.Open))
                    //{
                    //    stream.CopyToAsync(memory);
                    //}
                    // memory.Position = 0;



                    //var passport = File.Create(path);

                    var previousEducation = new List<PreviousEducationViewModel>();
                    if (payLoad.previousEducations != null && payLoad.previousEducations.Count > 0)
                    {
                        previousEducation = payLoad.previousEducations.Select(x => new PreviousEducationViewModel
                        {
                            Id = x.Id,
                            CreatedBy = x.CreatedBy,
                            DateUpdated = x.DateUpdated,
                            DateCreated = x.DateCreated,
                            IsActive = x.IsActive,
                            IsDeleted = x.IsDeleted,
                            UpdatedBy = x.UpdatedBy,
                            FromDate = x.FromDate,
                            OfficeHeld = x.OfficeHeld,
                            School = x.School,
                            ToDate = x.ToDate
                        }).ToList();
                    }
                    var StudentVM = new StudentViewModel
                    {
                        Id = payLoad.Id,
                        CreatedBy = payLoad.CreatedBy,
                        DateCreated = payLoad.DateCreated,
                        DateUpdated = payLoad.DateUpdated,
                        IsActive = payLoad.IsActive,
                        IsDeleted = payLoad.IsDeleted,
                        UpdatedBy = payLoad.UpdatedBy,
                        AppRefNumber = payLoad.AppRefNumber,
                        ContactAddress = payLoad.ContactAddress,
                        Disability = payLoad.Disability,
                        District = payLoad.District,
                        DOB = payLoad.DOB,
                        FirstChoiceCollege = payLoad.FirstChoiceCollege,
                        FirstChoiceProgram = payLoad.FirstChoiceProgram,
                        Gender = payLoad.Gender,
                        HomeTown = payLoad.HomeTown,
                        LanguagesSpoken = payLoad.LanguagesSpoken,
                        MaritalStatus = payLoad.MaritalStatus,
                        OtherNames = payLoad.OtherNames,
                        ParentParticulars = payLoad.ParentParticulars,
                        POB = payLoad.POB,
                        Region = payLoad.Region,
                        Religion = payLoad.Religion,
                        Result = payLoad.Result,
                        SecondChoiceCollege = payLoad.SecondChoiceCollege,
                        SecondChoiceProgram = payLoad.SecondChoiceProgram,
                        TelephoneNumber = payLoad.TelephoneNumber,
                        Surname = payLoad.Surname,
                        ThirdChoiceCollege = payLoad.ThirdChoiceCollege,
                        ThreeChoiceProgram = payLoad.ThreeChoiceProgram,
                        previousEducations = previousEducation,
                        Passport = payLoad.Passport,
                        StudentId = payLoad.StudentId,
                        RegistrationPin = payLoad.RegistrationPin,
                        DropOutComment = payLoad.DropOutComment,
                        ProgramId = payLoad.ProgramId
                        
                    };

                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(StudentVM);
                    //StudentVM.PassportStream = passport;
                    var apiKey = _configration.GetSection("APIKey").Value;
                    string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("StudentDetailsAPIURL").Value.Replace("{API-Key}", apiKey);
                    // var postResponse = HTTPClientWrapper<object>.PostRequest(url, StudentVM).Result;
                    using (var stream = new FileStream(path, FileMode.Open))
                    {

                        var postResponse = HTTPClientWrapper<object>.PostStudentRequest(url, StudentVM, stream, StudentVM.Passport).Result;

                        if (postResponse.IsSuccessful)
                        {
                            payLoad.IsSynched = true;

                            _studentRepo.Update(payLoad);

                            var apiRequestLog = new APIRequestLog
                            {
                                Data = data,
                                RequestType = HTTPRequestType.Post,
                                Synched = true,
                                Url = url
                            };
                            _apiRequestRepo.Create(apiRequestLog);
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }
        }



        public void UploadStudentResult()
        {
            var studentResults = _resultRepo.All().Where(x => x.IsSynched == false).ToList();
            var levelList = _levelRepo.All().ToList();

            try
            {
                foreach (var result in studentResults)
                {

                    var resultVM = new ResultViewModel
                    {
                        Id = result.Id,
                        AcademicSessionId = result.AcademicSessionId,
                        StudentId = result.StudentId,
                        CourseId = result.CourseId,
                        Grade = result.Grade,
                        ProgramId = result.ProgramId,
                        Score = result.Score,
                        Level = levelList.FirstOrDefault(x => x.Id == result.LevelId).Name,
                        CreatedBy = result.CreatedBy,
                        DateCreated = result.DateCreated,
                        DateUpdated = result.DateUpdated,
                        UpdateBy = result.UpdatedBy,
                        IsActive = result.IsActive,
                        IsDeleted = result.IsDeleted,
                    };
                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(resultVM);
                    var apiKey = _configration.GetSection("APIKey").Value;
                    string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("ResultUploadAPIURL").Value.Replace("{API-Key}", apiKey);

                    var payLoad = new ResponseData<ResultViewModel>
                    {
                        Data = resultVM
                    };

                        var postResponse = HTTPClientWrapper<ResponseData<ResultViewModel>>.PostRequest(url, payLoad).Result;

                        if (postResponse.IsSuccessful)
                        {
                            result.IsSynched = true;

                            _resultRepo.Update(result);

                            var apiRequestLog = new APIRequestLog
                            {
                                Data = data,
                                RequestType = HTTPRequestType.Post,
                                Synched = true,
                                Url = url
                            };
                            _apiRequestRepo.Create(apiRequestLog);
                        }
                        else
                        {

                        }
                    }
                
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }
        }



        public void Studentlog()
        {
            var studentLogs = _studentLogRepo.All().Where(x => x.IsSynched == false).ToList();
            var levelList = _levelRepo.All().ToList();

            try
            {
                foreach (var studentLog in studentLogs)
                {
                    var studentlogVM = new StudentLogViewModel
                    {
                        Id = studentLog.Id,
                        AcademicSessionId = studentLog.AcademicSessionId,
                        StudentId = studentLog.StudentId,
                        AppRefNumber = studentLog.AppRefNumber,
                        ProgramId = studentLog.ProgramId,
                        OtherNames = studentLog.OtherNames,
                        Surname = studentLog.Surename,
                        Level = levelList.FirstOrDefault(x => x.Id == studentLog.LevelId).Name,
                        CreatedBy = studentLog.CreatedBy,
                        DateCreated = studentLog.DateCreated,
                        DateUpdated = studentLog.DateUpdated,
                        UpdatedBy = studentLog.UpdatedBy,
                        IsActive = studentLog.IsActive,
                        IsDeleted = studentLog.IsDeleted,
                    };
                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(studentlogVM);
                    var apiKey = _configration.GetSection("APIKey").Value;
                    string url = _configration.GetSection("BaseAPIURl").Value + _configration.GetSection("StudentLogAPIURL").Value.Replace("{API-Key}", apiKey);

                    var payLoad = new ResponseData<StudentLogViewModel>
                    {
                        Data = studentlogVM
                    };

                    var postResponse = HTTPClientWrapper<ResponseData<StudentLogViewModel>>.PostRequest(url, payLoad).Result;

                    if (postResponse.IsSuccessful)
                    {
                        studentLog.IsSynched = true;

                        _studentLogRepo.Update(studentLog);

                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = true,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                }

            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }
        }




        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private string ImageConverter(string path)
        {
            using (var image = new FileStream(path, FileMode.Open, FileAccess.Read))
            {

                byte[] bytes = System.IO.File.ReadAllBytes(path);
                image.Read(bytes, 0, System.Convert.ToInt32(image.Length));

                image.Close();

                string base64String = Convert.ToBase64String(bytes);
                return base64String;

            }
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }


}
