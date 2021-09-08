using System;
using System.Collections.Generic;
using System.Text;
using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using System.Linq;
using Microsoft.Extensions.Configuration;
using CEMIS.Data;
using System.Transactions;
using CEMIS.Utility;


namespace CEMIS.Business
{
    public class MainAdminRoleRepository : IMainAdminRole
    {

        private IRepository<TeachingStaffAdminRole> _staffAdminRoleRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IConfiguration _configration;

        public MainAdminRoleRepository(IRepository<TeachingStaffAdminRole> staffAdminRoleRepo , IRepository<APIRequestLog> apiRequestRepo , IConfiguration configration)
        {
            _staffAdminRoleRepo = staffAdminRoleRepo;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
        }
        public ResponseData<TeachingStaffAdminRole> CreateAdminRole(TeachingStaffAdminRole teachingStaffAdminRole , bool LogRequest)
        {
            ResponseData<TeachingStaffAdminRole> resp;
            using (var transaction = new TransactionScope())
            {
                try{ 
                teachingStaffAdminRole.IsDeleted = false;
                teachingStaffAdminRole.IsActive = true;
                teachingStaffAdminRole.DateCreated = DateTime.Now;
                if (LogRequest)
                {
                    var data = Newtonsoft.Json.JsonConvert.SerializeObject(teachingStaffAdminRole);
                    string url = _configration.GetSection("BaseAPIURl").Value + "MainAdminRole";
                    var apiRequestLog = new APIRequestLog
                    {
                        Data = data,
                        RequestType = HTTPRequestType.Post,
                        Synched = false,
                        Url = url
                    };
                    _apiRequestRepo.Create(apiRequestLog);
                }

                _staffAdminRoleRepo.Create(teachingStaffAdminRole);
                transaction.Complete();
                resp = new ResponseData<TeachingStaffAdminRole>
                {
                    Message = "Admin Role created successfully",
                    RespCode = "00",
                    IsSuccessful = true
                };

                return resp;
            }
                catch (Exception ex)
            {
                return new ResponseData<TeachingStaffAdminRole>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };


            }
        }
        }

        public ResponseData<TeachingStaffAdminRole> DeleteAdminRole(long Id, bool LogRequest)
        {

            ResponseData<TeachingStaffAdminRole> resp;
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var role = GetAdminRoleById(Id);
                    role.IsDeleted = true;
                    role.IsActive = false;

                    _staffAdminRoleRepo.Update(role);//;.Update(staff);

                    if (LogRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(role);
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = _configration.GetSection("BaseAPIURl").Value + "MainAdminRole"
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    transaction.Complete();

                    resp = new ResponseData<TeachingStaffAdminRole>
                    {
                        Message = "Admin role deleted successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<TeachingStaffAdminRole>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }

        public List<TeachingStaffAdminRole> GetAllAdminRole()
        {
            return _staffAdminRoleRepo.All().Where(m => m.IsActive == true && m.IsDeleted == false).ToList();
        }

        public TeachingStaffAdminRole GetAdminRoleById(long Id)
        {
            return _staffAdminRoleRepo.Find(Id);
     
        }

        public ResponseData<TeachingStaffAdminRole> UpdateAdminRole(TeachingStaffAdminRole teachingStaffadminRole , bool LogRequest)
        {
            ResponseData<TeachingStaffAdminRole> resp;
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var staffAdminRole = _staffAdminRoleRepo.Find(teachingStaffadminRole.Id);

                    teachingStaffadminRole.DateUpdated = DateTime.Now;
                    teachingStaffadminRole.IsActive = staffAdminRole.IsActive;
                    teachingStaffadminRole.IsDeleted = staffAdminRole.IsDeleted;
                    teachingStaffadminRole.CreatedBy = staffAdminRole.CreatedBy;
                    teachingStaffadminRole.DateCreated = staffAdminRole.DateCreated;
                    teachingStaffadminRole.CollegeID = staffAdminRole.CollegeID;

                    _staffAdminRoleRepo.Update(teachingStaffadminRole);

                    if (LogRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(teachingStaffadminRole);

                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = _configration.GetSection("BaseAPIURl").Value + "MainAdminRole"
                        };
                        _apiRequestRepo.Create(apiRequestLog);

                        transaction.Complete();


                    }

                    resp = new ResponseData<TeachingStaffAdminRole>
                    {
                        Message = "Admin Role updated successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<TeachingStaffAdminRole>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }
    }
 }
