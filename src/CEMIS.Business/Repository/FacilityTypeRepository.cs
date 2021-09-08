using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CEMIS.Business.Repository
{
   public class FacilityTypeRepository: IFacilityType
    {
        private IRepository<FacilityType> _facilityTypeRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IConfiguration _configration;

        public FacilityTypeRepository(IRepository<FacilityType> facilityTypeRepo, IRepository<APIRequestLog> apiRequestRepo, IConfiguration configration)
        {
            _facilityTypeRepo = facilityTypeRepo;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
        }

        public ResponseData<FacilityType> CreateFacilityType(FacilityType facility, bool logRequest)
        {
            ResponseData<FacilityType> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(facility.Name))
                    {
                        return new ResponseData<FacilityType>
                        {
                            Message = "Facility Name cannot be empty",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }

                    if (checkNameexist(facility.Name))
                    {
                        return new ResponseData<FacilityType>
                        {
                            Message = "Facility Type already exist",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }
                    facility.IsDeleted = false;
                    facility.IsActive = true;
                    facility.DateCreated = DateTime.Now;
                    facility.Name = facility.Name;

                    //if (logRequest)
                    //{
                    //    var data = Newtonsoft.Json.JsonConvert.SerializeObject(facility);
                    //    string url = _configration.GetSection("BaseAPIURl").Value + "FacilityType";
                    //    var apiRequestLog = new APIRequestLog
                    //    {
                    //        Data = data,
                    //        RequestType = HTTPRequestType.Post,
                    //        Synched = false,
                    //        Url = url
                    //    };
                    //    _apiRequestRepo.Create(apiRequestLog);
                    //}

                    _facilityTypeRepo.Create(facility);

                    transaction.Complete();

                    resp = new ResponseData<FacilityType>
                    {
                        Message = "Facility Type created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<FacilityType>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };


                }
            }
        }

        public List<FacilityType> GetAllFacilityType()
        {
            return _facilityTypeRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();
        }
        public FacilityType GetFacilityTypeById(long Id)
        {
            var facility = _facilityTypeRepo.Find(Id);
            return facility;
        }

        public bool checkNameexist(string name)
        {
            
                return _facilityTypeRepo.All().Any(slt => slt.Name.Trim().ToLower() == name.Trim().ToLower() && slt.IsActive == true);
            
        }

        public ResponseData<FacilityType> UpdateFacilityType(FacilityType facility, bool logRequest)
        {
            ResponseData<FacilityType> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (checkUpdateNameexist(facility))
                    {
                        return new ResponseData<FacilityType>
                        {
                            Message = "facility type already exist",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }
                   
                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(facility);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Facility";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    var getFacility = _facilityTypeRepo.Find(facility.Id);
                    getFacility.Name = facility.Name;
                    getFacility.IsActive = true;
                    getFacility.IsDeleted = false;
                    getFacility.CreatedBy = facility.CreatedBy;
                    //getFacility.DateCreated = DateTime.Now;
                    getFacility.DateUpdated = DateTime.Now;

                    _facilityTypeRepo.Update(getFacility);

                    transaction.Complete();

                  

                    resp = new ResponseData<FacilityType>
                    {
                        Message = "Facility Type Updateds successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<FacilityType>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }

        public bool checkUpdateNameexist(FacilityType facilityType)
     
        {
         
                return _facilityTypeRepo.All().Any(slt => slt.Name.Trim().ToLower() == facilityType.Name.Trim().ToLower() && slt.Id != facilityType.Id && slt.IsActive == true);
            
        }

        public bool DeleteFacilityType(long Id, out string message)
        {
            if (Id > 0)
            {
                try
                {
                    var facilityType = _facilityTypeRepo.Find(Id);
                    facilityType.IsDeleted = true;
                    facilityType.IsActive = false;

                    _facilityTypeRepo.Update(facilityType);

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
    }
}
