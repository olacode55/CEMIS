using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CEMIS.Business
{
    public class FacilityRepository : IFacility
    {
        private IRepository<CollegeFacility> _facilityRepo;
        private readonly IRepository<FacilityType> _facilityTypeRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IRepository<TrackCollegeChanges> _trackCollegeChangesRepo;
        private IConfiguration _configration;

        public FacilityRepository(IRepository<CollegeFacility> facilityRepo, IRepository<FacilityType> facilityTypeRepo, IRepository<APIRequestLog> apiRequestRepo, IConfiguration configration
                                   ,IRepository<TrackCollegeChanges> trackCollegeChangesRepo)
        {
            _facilityRepo = facilityRepo;
            _facilityTypeRepo = facilityTypeRepo;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
            _trackCollegeChangesRepo = trackCollegeChangesRepo;
        }


        public List<CollegeFacilityViewModel> GetAllFacilities()
        {
            var facility = _facilityRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();
            var facilityType = _facilityTypeRepo.All().Where(x => x.IsActive == true && x.IsDeleted == false).ToList();

            var data = (from f in facility
                        join ft in facilityType on f.FacilityType equals ft.Id
                        select new CollegeFacilityViewModel()
                        {
                            Id = f.Id,
                            CollegeId = f.CollegeId,
                            Name = f.Name,
                            Description = f.Description,
                            FacilityType = f.FacilityType,
                            FacilityTypeName = ft.Name,
                            YearOfConstruction = f.YearOfConstruction,
                            PresentCondition = (ClassRoomCondition)f.PresentCondition,
                            LengthInMeters = f.LengthInMeters,
                            WidthInMeters = f.WidthInMeters,
                            FloorMaterial = (FloorMaterial)f.FloorMaterial,
                            RoofMaterial = (RoofMaterial)f.RoofMaterial,
                            Seatings = (SeatAvailability)f.Seatings,
                            DisabilityAccess = (DisabilityAccessAvailability)f.DisabilityAccess,
                            IsSynched = f.IsSynched,
                            IsActive = f.IsActive
                        }).ToList();

            return data;

            //return _facilityRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true)
            //    .Select(x => new CollegeFacilityViewModel()
            //    {
            //        Id = x.Id,
            //        CollegeId = x.CollegeId,
            //        Name = x.Name,
            //        Description = x.Description,
            //        FacilityType = x.FacilityType,
            //        YearOfConstruction = x.YearOfConstruction,
            //        PresentCondition = (ClassRoomCondition)x.PresentCondition,
            //        LengthInMeters = x.LengthInMeters,
            //        WidthInMeters = x.WidthInMeters,
            //        FloorMaterial = (FloorMaterial)x.FloorMaterial,
            //        RoofMaterial = (RoofMaterial)x.RoofMaterial,
            //        Seatings = (SeatAvailability)x.Seatings,
            //        DisabilityAccess = (DisabilityAccessAvailability)x.DisabilityAccess,
            //        IsSynched = x.IsSynched,
            //        IsActive = x.IsActive
            //    }).ToList();
        }


        public bool CreateFacility(CollegeFacilityViewModel model, out string message)
        {
            try
            {
                var collegeFacility = new CollegeFacility()
                {

                    CollegeId = 1,
                    Name = model.Name,
                    Description = model.Description,
                    FacilityType = model.FacilityType,
                    YearOfConstruction = model.YearOfConstruction,
                    PresentCondition = (int)model.PresentCondition,
                    LengthInMeters = model.LengthInMeters,
                    WidthInMeters = model.WidthInMeters,
                    FloorMaterial = (int)model.FloorMaterial,
                    RoofMaterial = (int)model.RoofMaterial,
                    Seatings = (int)model.Seatings,
                    DisabilityAccess = (int)model.DisabilityAccess,
                    IsSynched = model.IsSynched,
                    IsActive = true,
                    CreatedBy = 1,
                    DateCreated = DateTime.Now,
                    IsDeleted = false

                };

                var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.facility);
                module.HasChanged = true;

                using (var scope = new TransactionScope())
                {
                    _facilityRepo.Create(collegeFacility);
                    _trackCollegeChangesRepo.Update(module);
                    scope.Complete();
                }
                

            }
            catch (Exception ex)
            {
                message = ex.StackTrace;
                throw;
            }

            message = "Added Successfuly";
            return true;
        }

        public bool UpdateFacility(CollegeFacilityViewModel model, out string message)
        {
            try
            {
                var collegeFacility = _facilityRepo.Find(model.Id);


                //collegeFacility.CollegeId = model.CollegeId;
                collegeFacility.Name = model.Name;
                collegeFacility.Description = model.Description;
                collegeFacility.FacilityType = model.FacilityType;
                collegeFacility.YearOfConstruction = model.YearOfConstruction;
                collegeFacility.PresentCondition = (int)model.PresentCondition;
                collegeFacility.LengthInMeters = model.LengthInMeters;
                collegeFacility.WidthInMeters = model.WidthInMeters;
                collegeFacility.FloorMaterial = (int)model.FloorMaterial;
                collegeFacility.RoofMaterial = (int)model.RoofMaterial;
                collegeFacility.Seatings = (int)model.Seatings;
                collegeFacility.DisabilityAccess = (int)model.DisabilityAccess;
                collegeFacility.IsSynched = false;
                collegeFacility.UpdatedBy = 1;
                collegeFacility.DateUpdated = DateTime.Now;

                var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.facility);
                module.HasChanged = true;

                using (var scope = new TransactionScope())
                {
                    _facilityRepo.Update(collegeFacility);
                    _trackCollegeChangesRepo.Update(module);
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                message = ex.StackTrace;
                throw;
            }

            message = "Updated Successfuly";
            return true;

        }


        public CollegeFacilityViewModel GetFacilityById(long Id)
        {
            var facility = _facilityRepo.All()
                .Where(x => x.Id == Id).Select(x => new CollegeFacilityViewModel()
                {
                    Id = x.Id,
                    CollegeId = x.CollegeId,
                    Name = x.Name,
                    Description = x.Description,
                    FacilityType = x.FacilityType,
                    YearOfConstruction = x.YearOfConstruction,
                    PresentCondition = (ClassRoomCondition)x.PresentCondition,
                    LengthInMeters = x.LengthInMeters,
                    WidthInMeters = x.WidthInMeters,
                    FloorMaterial = (FloorMaterial)x.FloorMaterial,
                    RoofMaterial = (RoofMaterial)x.RoofMaterial,
                    Seatings = (SeatAvailability)x.Seatings,
                    DisabilityAccess = (DisabilityAccessAvailability)x.DisabilityAccess,
                    IsSynched = x.IsSynched,
                    IsActive = x.IsActive
                }).FirstOrDefault();

            return facility;
        }


        public bool DeleteFacility(long Id, out string message)
        {
            if (Id > 0)
            {
                try
                {
                    var facility = _facilityRepo.Find(Id);
                    facility.IsDeleted = true;
                    facility.IsActive = false;

                    var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.facility);
                    module.HasChanged = true;

                    using (var scope = new TransactionScope())
                    {
                        _facilityRepo.Update(facility);
                        _trackCollegeChangesRepo.Update(module);
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    message = ex.StackTrace;
                    throw;
                }

                message = "Deleted Successfully";
                return true;
            }
            else
            {
                message = "Oops Something went wrong";
                return true;
            }
        }


        public IEnumerable<SelectListItem> GetFacilityTypeList()
        {
            return _facilityTypeRepo.All()
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
        }


    }
}
