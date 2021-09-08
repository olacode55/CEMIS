using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Data.ViewModel;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace CEMIS.Business
{
    public class CollegeRepository : ICollege
    {
        private IRepository<College> _collegeRepo;
        private IRepository<CollegeFacility> _collegeFacilityRepo;
        private IRepository<CollegeClassRoomData> _collegeClassRoomDataRepo;
        private IRepository<CollegeClassRoomInfo> _collegeClassRoomInfoRepo;
        private readonly IRepository<FacilityType> _facilityTypeRepo;
        private readonly IRepository<TrackCollegeChanges> _trackCollegeChangesRepo;
        private readonly IRepository<Program> _programRepo;
        private readonly IRepository<TeachingStaff> _staffRepo;
        private IConfiguration _configration;

        public CollegeRepository(IRepository<College> collegeRepo, IRepository<CollegeFacility> collegeFacilityRepo, IRepository<CollegeClassRoomData> collegeClassRoomDataRepo,
             IRepository<CollegeClassRoomInfo> collegeClassRoomInfoRepo, IRepository<FacilityType> facilityTypeRepo, IRepository<TrackCollegeChanges> trackCollegeChangesRepo,
             IRepository<Program> programRepo, IRepository<TeachingStaff> staffRepo, IConfiguration configration)
        {
            _collegeRepo = collegeRepo;
            _configration = configration;
            _collegeFacilityRepo = collegeFacilityRepo;
            _collegeClassRoomDataRepo = collegeClassRoomDataRepo;
            _collegeClassRoomInfoRepo = collegeClassRoomInfoRepo;
            _facilityTypeRepo = facilityTypeRepo;
            _trackCollegeChangesRepo = trackCollegeChangesRepo;
            _programRepo = programRepo;
            _staffRepo = staffRepo;
        }

        public List<College> GetAllColleges()
        {
            return _collegeRepo.All().Where(x => x.IsDeleted == false && x.IsActive == true).ToList();
        }



        public CollegeViewModel GetCollegeById(long Id)
        {
            if (Id > 0)
            {
                return _collegeRepo.All().Where(x => x.Id == Id).Select(x => new CollegeViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    AdminOfficerEmail = x.AdminOfficerEmail,
                    AdminOfficerName = x.AdminOfficerName,
                    AdminOfficerPhone = x.AdminOfficerPhone,
                    CleanerCount = x.CleanerCount,
                    DriversCount = x.DriversCount,
                    FirstAccreditationDate = x.FirstAccreditationDate,
                    CureentAccreditationDate = x.CureentAccreditationDate,
                    NextAccreditationDate = x.NextAccreditationDate,
                    Email = x.Email,
                    CreatedBy = x.CreatedBy,
                    UpdatedBy = x.UpdatedBy,
                    DateCreated = x.DateCreated,
                    DateUpdated = x.DateUpdated,
                    GIS = x.GIS,
                    HandymenCount = x.HandymenCount,
                    ICTSystemEmail = x.ICTSystemEmail,
                    ICTSystemName = x.ICTSystemName,
                    ICTSystemPhone = x.ICTSystemPhone,
                    Name = x.Name,
                    IsActive = x.IsActive,
                    IsDeleted = x.IsDeleted,
                    Phone = x.Phone,
                    PrincipalEmail = x.PrincipalEmail,
                    PrincipalName = x.PrincipalName,
                    PrincipalPhone = x.PrincipalPhone,
                    VicePrincipalEmail = x.VicePrincipalEmail,
                    VicePrincipalName = x.VicePrincipalName,
                    VicePrincipalPhone = x.VicePrincipalPhone,
                    SecretaryCount = x.SecretaryCount,
                    SecurityGuardCount = x.SecurityGuardCount,
                    IsSynched = x.IsSynched


                }).FirstOrDefault();
            }
            else
            {
                var data = new CollegeViewModel();
                return data;
            }




        }

        public CollegeClassRoomDataViewModel GetClassRoomDataById(long Id)
        {
            CollegeClassRoomDataViewModel data = new CollegeClassRoomDataViewModel();

            var collegeClassRoomInfo = _collegeClassRoomInfoRepo.All()
                    .Where(x => x.CollegeId == Id)
                    .Select(x => x.CollegeId).Count();


            data.ClassRoomCount = collegeClassRoomInfo;

            var collegeData = _collegeClassRoomDataRepo.All().Where(x => x.CollegeId == Id).FirstOrDefault();
            if (collegeData != null)
            {
                data.Id = collegeData.Id;
                data.CollegeId = collegeData.CollegeId;
                data.IsClassHeldOutside = collegeData.IsClassHeldOutside;
                data.LaboratoryCount = collegeData.LaboratoryCount;
                data.LibraryCount = collegeData.LibraryCount;
                data.OfficeCount = collegeData.OfficeCount;
                data.OthersCount = collegeData.OthersCount;
                data.StaffRoomCount = collegeData.StaffRoomCount;
                data.StoreRoomCount = collegeData.StoreRoomCount;

                return data;

            }




            return data;
        }

        public CollegeClassRoomInfoViewModel GetClassRoomInfoById(long Id)
        {
            return _collegeClassRoomInfoRepo.All().Where(x => x.Id == Id).Select(x => new CollegeClassRoomInfoViewModel
            {
                Id = x.Id,
                CollegeId = x.CollegeId,
                DisabilityAccess = (DisabilityAccessAvailability)x.DisabilityAccess,
                FloorMaterial = (FloorMaterial)x.FloorMaterial,
                LengthInMeters = x.LengthInMeters,
                PresentCondition = (ClassRoomCondition)x.PresentCondition,
                RoofMaterial = (RoofMaterial)x.RoofMaterial,
                Seatings = (SeatAvailability)x.Seatings,
                WallMaterial = (WallMaterial)x.WallMaterial,
                WidthInMeters = x.WidthInMeters,
                YearOfConstruction = x.YearOfConstruction


            }).FirstOrDefault();
        }

        public List<CollegeClassRoomInfoViewModel> GetClassRoomInfoListById(long Id)
        {
            return _collegeClassRoomInfoRepo.All().Where(x => x.CollegeId == Id).Select(x => new CollegeClassRoomInfoViewModel
            {
                Id = x.Id,
                CollegeId = x.CollegeId,
                DisabilityAccess = (DisabilityAccessAvailability)x.DisabilityAccess,
                FloorMaterial = (FloorMaterial)x.FloorMaterial,
                LengthInMeters = x.LengthInMeters,
                PresentCondition = (ClassRoomCondition)x.PresentCondition,
                RoofMaterial = (RoofMaterial)x.RoofMaterial,
                Seatings = (SeatAvailability)x.Seatings,
                WallMaterial = (WallMaterial)x.WallMaterial,
                WidthInMeters = x.WidthInMeters,
                YearOfConstruction = x.YearOfConstruction


            }).ToList();
        }
        public List<CollegeViewModel> GetCollegeListById(long Id)
        {
            return _collegeRepo.All().Where(x => x.Id == Id).Select(x => new CollegeViewModel
            {
                Id = x.Id,
                Address = x.Address,
                AdminOfficerEmail = x.AdminOfficerEmail,
                AdminOfficerName = x.AdminOfficerName,
                AdminOfficerPhone = x.AdminOfficerPhone,
                FirstAccreditationDate = x.FirstAccreditationDate.Date,
                CureentAccreditationDate = x.CureentAccreditationDate.Date,
                NextAccreditationDate = x.CureentAccreditationDate.Date,
                CleanerCount = x.CleanerCount,
                DriversCount = x.DriversCount,
                Email = x.Email,
                CreatedBy = x.CreatedBy,
                UpdatedBy = x.UpdatedBy,
                DateCreated = x.DateCreated,
                DateUpdated = x.DateUpdated,
                GIS = x.GIS,
                HandymenCount = x.HandymenCount,
                ICTSystemEmail = x.ICTSystemEmail,
                ICTSystemName = x.ICTSystemName,
                ICTSystemPhone = x.ICTSystemPhone,
                Name = x.Name,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                Phone = x.Phone,
                PrincipalEmail = x.PrincipalEmail,
                PrincipalName = x.PrincipalName,
                PrincipalPhone = x.PrincipalPhone,
                VicePrincipalEmail = x.VicePrincipalEmail,
                VicePrincipalName = x.VicePrincipalName,
                VicePrincipalPhone = x.VicePrincipalPhone,
                SecretaryCount = x.SecretaryCount,
                SecurityGuardCount = x.SecurityGuardCount,
                IsSynched = x.IsSynched


            }).ToList();



        }


        public bool CreateCollege(CollegeViewModel model, out string message)
        {
            try
            {
                var collegeData = new College
                {
                    Address = model.Address,
                    AdminOfficerEmail = model.AdminOfficerEmail,
                    AdminOfficerName = model.AdminOfficerName,
                    AdminOfficerPhone = model.AdminOfficerPhone,
                    CleanerCount = model.CleanerCount,
                    DriversCount = model.DriversCount,
                    Email = model.Email,
                    CreatedBy = 1,
                    DateCreated = DateTime.Now,
                    GIS = model.GIS,
                    HandymenCount = model.HandymenCount,
                    ICTSystemEmail = model.ICTSystemEmail,
                    ICTSystemName = model.ICTSystemName,
                    ICTSystemPhone = model.ICTSystemPhone,
                    Name = model.Name,
                    IsActive = true,
                    IsDeleted = false,
                    Phone = model.Phone,
                    PrincipalEmail = model.PrincipalEmail,
                    PrincipalName = model.PrincipalName,
                    PrincipalPhone = model.PrincipalPhone,
                    VicePrincipalEmail = model.VicePrincipalEmail,
                    VicePrincipalName = model.VicePrincipalName,
                    VicePrincipalPhone = model.VicePrincipalPhone,
                    SecretaryCount = model.SecretaryCount,
                    SecurityGuardCount = model.SecurityGuardCount,
                    FirstAccreditationDate = model.FirstAccreditationDate,
                    CureentAccreditationDate = model.CureentAccreditationDate,
                    NextAccreditationDate = model.NextAccreditationDate

                };

                _collegeRepo.Create(collegeData);


            }
            catch (System.Exception ex)
            {
                message = ex.StackTrace;
                throw;
            }



            message = "Added Successfuly";
            return true;
        }

        public bool UpdateCollege(CollegeViewModel model, out string message)
        {
            try
            {
                var collegeData = _collegeRepo.Find(model.Id);


                collegeData.Address = model.Address;
                collegeData.AdminOfficerEmail = model.AdminOfficerEmail;
                collegeData.AdminOfficerName = model.AdminOfficerName;
                collegeData.AdminOfficerPhone = model.AdminOfficerPhone;
                collegeData.CleanerCount = model.CleanerCount;
                collegeData.DriversCount = model.DriversCount;
                collegeData.Email = model.Email;
                collegeData.UpdatedBy = 1;
                collegeData.DateUpdated = DateTime.Now;
                collegeData.GIS = model.GIS;
                collegeData.HandymenCount = model.HandymenCount;
                collegeData.ICTSystemEmail = model.ICTSystemEmail;
                collegeData.ICTSystemName = model.ICTSystemName;
                collegeData.ICTSystemPhone = model.ICTSystemPhone;
                collegeData.Name = model.Name;
                collegeData.IsDeleted = false;
                collegeData.Phone = model.Phone;
                collegeData.PrincipalEmail = model.PrincipalEmail;
                collegeData.PrincipalName = model.PrincipalName;
                collegeData.PrincipalPhone = model.PrincipalPhone;
                collegeData.VicePrincipalEmail = model.VicePrincipalEmail;
                collegeData.VicePrincipalName = model.VicePrincipalName;
                collegeData.VicePrincipalPhone = model.VicePrincipalPhone;
                collegeData.SecretaryCount = model.SecretaryCount;
                collegeData.SecurityGuardCount = model.SecurityGuardCount;
                collegeData.IsSynched = model.IsSynched;
                collegeData.IsSynched = false;
                collegeData.FirstAccreditationDate = model.FirstAccreditationDate;
                collegeData.CureentAccreditationDate = model.CureentAccreditationDate;
                collegeData.NextAccreditationDate = model.NextAccreditationDate;

                var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.CollegeDetails);
                module.HasChanged = true;

                using (var scope = new TransactionScope())
                {
                    _collegeRepo.Update(collegeData);
                    _trackCollegeChangesRepo.Update(module);
                    scope.Complete();
                }




            }
            catch (System.Exception ex)
            {
                message = ex.StackTrace;
                throw;
            }



            message = "Updated Successfuly";
            return true;
        }

        public bool CreateCollegeClassRoomData(CollegeClassRoomDataViewModel model, out string message)
        {
            try
            {
                var collegeClassRoomInfo = _collegeClassRoomInfoRepo.All()
                  .Where(x => x.CollegeId == model.CollegeId)
                  .Select(x => x.CollegeId).Count();

                var collegeClassRoomData = new CollegeClassRoomData
                {
                    ClassRoomCount = collegeClassRoomInfo,
                    IsClassHeldOutside = model.IsClassHeldOutside,
                    LaboratoryCount = model.LaboratoryCount,
                    LibraryCount = model.LibraryCount,
                    OfficeCount = model.OfficeCount,
                    StaffRoomCount = model.StaffRoomCount,
                    StoreRoomCount = model.StoreRoomCount,
                    OthersCount = model.OthersCount,
                    CollegeId = model.CollegeId,

                };

                var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.ClassRoomData);
                module.HasChanged = true;


                using (var scope = new TransactionScope())
                {
                    _collegeClassRoomDataRepo.Create(collegeClassRoomData);
                    _trackCollegeChangesRepo.Update(module);
                    scope.Complete();
                }


            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                throw;
            }

            message = "Added Successfuly";
            return true;
        }

        public bool UpdateCollegeClassRoomData(CollegeClassRoomDataViewModel model, out string message)
        {
            try
            {
                var collegeClassRoomData = _collegeClassRoomDataRepo.Find(model.Id);

                if (collegeClassRoomData != null)
                {
                    var collegeClassRoomInfo = _collegeClassRoomInfoRepo.All()
                   .Where(x => x.CollegeId == model.CollegeId).ToList();
                    //.Select(x => x.CollegeId).Count();

                    var collegeCount = collegeClassRoomInfo != null ? collegeClassRoomInfo.Count : 0;
                    collegeClassRoomData.ClassRoomCount = collegeCount;
                    collegeClassRoomData.IsClassHeldOutside = model.IsClassHeldOutside;
                    collegeClassRoomData.LaboratoryCount = model.LaboratoryCount;
                    collegeClassRoomData.LibraryCount = model.LibraryCount;
                    collegeClassRoomData.OfficeCount = model.OfficeCount;
                    collegeClassRoomData.StaffRoomCount = model.StaffRoomCount;
                    collegeClassRoomData.StoreRoomCount = model.StoreRoomCount;
                    collegeClassRoomData.OthersCount = model.OthersCount;


                    var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.ClassRoomData);
                    module.HasChanged = true;


                    using (var scope = new TransactionScope())
                    {
                        _collegeClassRoomDataRepo.Update(collegeClassRoomData);
                        _trackCollegeChangesRepo.Update(module);
                        scope.Complete();
                    }


                }

            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                throw;
            }

            message = "Added Successfuly";
            return true;
        }

        public bool CreateCollegeClassRoomInfo(CollegeClassRoomInfoViewModel model, out string message)
        {
            try
            {
                var collegeClassRoomInfoData = new CollegeClassRoomInfo
                {
                    DisabilityAccess = (int)model.DisabilityAccess,
                    FloorMaterial = (int)model.FloorMaterial,
                    LengthInMeters = model.LengthInMeters,
                    PresentCondition = (int)model.PresentCondition,
                    RoofMaterial = (int)model.RoofMaterial,
                    Seatings = (int)model.Seatings,
                    WallMaterial = (int)model.WallMaterial,
                    WidthInMeters = model.WidthInMeters,
                    YearOfConstruction = model.YearOfConstruction,

                    CollegeId = model.CollegeId,



                };

                var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.ClassRoomInfo);
                module.HasChanged = true;

                using (var scope = new TransactionScope())
                {
                    _collegeClassRoomInfoRepo.Create(collegeClassRoomInfoData);
                    _trackCollegeChangesRepo.Update(module);
                    scope.Complete();
                }
            }
            catch (Exception)
            {

                throw;
            }

            message = "Added Successfuly";
            return true;
        }

        public bool UpdateCollegeClassRoomInfo(CollegeClassRoomInfoViewModel model, out string message)
        {
            try
            {

                var collegeClassRoomInfoData = _collegeClassRoomInfoRepo.Find(model.Id);

                collegeClassRoomInfoData.DisabilityAccess = Convert.ToInt32(model.DisabilityAccess);
                collegeClassRoomInfoData.FloorMaterial = (int)model.FloorMaterial;
                collegeClassRoomInfoData.LengthInMeters = model.LengthInMeters;
                collegeClassRoomInfoData.PresentCondition = (int)model.PresentCondition;
                collegeClassRoomInfoData.RoofMaterial = (int)model.RoofMaterial;
                collegeClassRoomInfoData.Seatings = (int)model.Seatings;
                collegeClassRoomInfoData.WallMaterial = (int)model.WallMaterial;
                collegeClassRoomInfoData.WidthInMeters = model.WidthInMeters;
                collegeClassRoomInfoData.YearOfConstruction = model.YearOfConstruction;

                var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.ClassRoomInfo);
                module.HasChanged = true;

                using (var scope = new TransactionScope())
                {
                    _collegeClassRoomInfoRepo.Update(collegeClassRoomInfoData);
                    _trackCollegeChangesRepo.Update(module);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                throw;
            }

            message = "Added Successfuly";
            return true;
        }

        public CollegeFormDataViewModel GetCollegeSummary()
        {


            var collegeSummary = _collegeRepo.All().Where(x => x.Id == 1).FirstOrDefault();

            var formData = new CollegeFormDataViewModel();

            if (collegeSummary != null)
            {

                formData.Id = collegeSummary.Id;
                formData.Name = collegeSummary.Name;
                formData.Address = collegeSummary.Address;
                formData.Email = collegeSummary.Email;
                formData.Phone = collegeSummary.Phone;
                formData.GIS = collegeSummary.GIS;
                formData.FirstAccreditationDate = collegeSummary.FirstAccreditationDate;
                formData.CureentAccreditationDate = collegeSummary.CureentAccreditationDate;
                formData.NextAccreditationDate = collegeSummary.NextAccreditationDate;
                formData.ServiceOfferedId = collegeSummary.ServiceOfferedId;
                formData.SecretaryCount = collegeSummary.SecretaryCount;
                formData.DriversCount = collegeSummary.DriversCount;
                formData.HandymenCount = collegeSummary.HandymenCount;
                formData.CleanerCount = collegeSummary.CleanerCount;
                formData.SecurityGuardCount = collegeSummary.SecurityGuardCount;

                //var staffRecords = _staffRepo.All().Where(x => x.IsActive == true && x.IsRetired == false && x.IsDeleted == false);

                //var PrinsipalDetails = staffRecords.Where()


                formData.PrincipalName = collegeSummary.PrincipalName;
                formData.PrincipalEmail = collegeSummary.PrincipalEmail;
                formData.PrincipalPhone = collegeSummary.PrincipalPhone;
                formData.VicePrincipalName = collegeSummary.VicePrincipalName;
                formData.VicePrincipalEmail = collegeSummary.VicePrincipalEmail;
                formData.VicePrincipalPhone = collegeSummary.VicePrincipalPhone;
                formData.ICTSystemName = collegeSummary.ICTSystemName;
                formData.ICTSystemEmail = collegeSummary.ICTSystemEmail;
                formData.ICTSystemPhone = collegeSummary.ICTSystemPhone;
                formData.AdminOfficerName = collegeSummary.AdminOfficerName;
                formData.AdminOfficerEmail = collegeSummary.AdminOfficerEmail;
                formData.AdminOfficerPhone = collegeSummary.AdminOfficerPhone;

                var collegeFacility = _collegeFacilityRepo.All().Where(x => x.IsActive == true && x.IsDeleted == false).ToList();
                var facilityType = _facilityTypeRepo.All().Where(x => x.IsActive == true && x.IsDeleted == false).ToList();

                var data = (from cf in collegeFacility
                            join ft in facilityType on cf.FacilityType equals ft.Id
                            select new
                            {
                                cf.FacilityType,
                                ft.Name
                            }).ToList();

                formData.CollegeFacility = data
                    .GroupBy(x => x.FacilityType)
                    .Select(x => new CollegeFacilityViewModel
                    {
                        FacilityType = x.Key,
                        FacilityTypeName = x.First().Name,
                        Number = x.Count(),

                    }).ToList();

                var program = _programRepo.All().Where(x => x.IsActive == true && x.IsDeleted == false).ToList();
                var servicesOffered = program.Select(x => new ProgramViewModel()
                {
                    Name = x.Name
                }).ToList();

                formData.ServicesOffered = servicesOffered;



                var collegeClassRoomInfo = _collegeClassRoomInfoRepo.All()
                     .Where(x => x.CollegeId == collegeSummary.Id)
                        .Select(x => new CollegeClassRoomInfoViewModel
                        {
                            YearOfConstruction = x.YearOfConstruction,
                            PresentCondition = (ClassRoomCondition)x.PresentCondition,
                            LengthInMeters = x.LengthInMeters,
                            WidthInMeters = x.WidthInMeters,
                            FloorMaterial = (FloorMaterial)x.FloorMaterial,
                            WallMaterial = (WallMaterial)x.WallMaterial,
                            RoofMaterial = (RoofMaterial)x.RoofMaterial,
                            Seatings = (SeatAvailability)x.Seatings,
                            DisabilityAccess = (DisabilityAccessAvailability)x.DisabilityAccess

                        }).ToList();



                var classRoomData = _collegeClassRoomDataRepo.All().Where(x => x.CollegeId == collegeSummary.Id).FirstOrDefault();

                formData.ClassRoomCount = collegeClassRoomInfo != null ? collegeClassRoomInfo.Count() : 0; //classRoomData.ClassRoomCount;
                formData.OfficeCount = classRoomData != null ? classRoomData.OfficeCount : 0;
                formData.LibraryCount = classRoomData != null ? classRoomData.LibraryCount : 0;
                formData.LaboratoryCount = classRoomData != null ? classRoomData.LaboratoryCount : 0;
                formData.StoreRoomCount = classRoomData != null ? classRoomData.StoreRoomCount : 0;
                formData.StaffRoomCount = classRoomData != null ? classRoomData.StaffRoomCount : 0;
                formData.OthersCount = classRoomData != null ? classRoomData.OthersCount : 0;
                formData.IsClassHeldOutside = classRoomData != null ? classRoomData.IsClassHeldOutside : 0;

                formData.CollegeClassRoomInfo = collegeClassRoomInfo;



                return formData;
            }

            else
            {
                return formData;
            }


        }

        public bool DeleteClassRoomInfo(long Id, out string message, out long CollegeId)
        {
            try
            {
                var classRoomInfo = _collegeClassRoomInfoRepo.Find(Id);

                ;

                CollegeId = classRoomInfo.CollegeId;


                var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.ClassRoomInfo);
                module.HasChanged = true;

                using (var scope = new TransactionScope())
                {
                    _collegeClassRoomInfoRepo.Delete(classRoomInfo);
                    _trackCollegeChangesRepo.Update(module);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                throw;
            }


            message = "Deleted Successfuly";
            return true;


        }

        public bool UpdateCollegeIsSynced(long CollegeId)
        {
            try
            {
                //var collegeData = _collegeRepo.Find(CollegeId);//college should contain only one record on cemis portal
                var collegeData = _collegeRepo.All().FirstOrDefault(x => x.IsActive == true && x.IsDeleted == false);
                if (collegeData != null)
                {
                    collegeData.IsSynched = false;

                    _collegeRepo.Update(collegeData);

                    return true;
                }



                return false;
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                throw;
            }
        }

    }
}
