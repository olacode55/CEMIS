using CEMIS.Business.Interface;
using CEMIS.Business.Repository;
using CEMIS.Data;
using CEMIS.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace CEMIS.Business
{
    public class StaffCPDAssesmentRepository : IStaffCPDAssesment
    {
        private IRepository<StaffCPDAssesment> _staffCPDRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IConfiguration _configration;
        private IAuthUser _authUser;
        private readonly IHostingEnvironment _hostingEnvironment;

        public StaffCPDAssesmentRepository(IRepository<StaffCPDAssesment> staffCPDRepo, IRepository<APIRequestLog> apiRequestRepo, IHostingEnvironment hostingEnvironment, IAuthUser authUser, IConfiguration configration)
        {
            _staffCPDRepo = staffCPDRepo;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
            _hostingEnvironment = hostingEnvironment;
            _authUser = authUser;
        }
        public List<StaffCPDAssesment> GetAllStaffCPDAssesment()
        {
            return _staffCPDRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();
        }
        public ResponseData<StaffCPDAssesmentViewModel> CreateStaffCPDAssesment(StaffCPDAssesmentViewModel staffCPD, bool LogRequest)
        {
            ResponseData<StaffCPDAssesmentViewModel> resp;
            using (var transaction = new TransactionScope())
            {
                try
                {

                    if (LogRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(staffCPD);
                        string url = _configration.GetSection("BaseAPIURl").Value + "cert";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    StaffCPDAssesment staffCPDAssesment = new StaffCPDAssesment()
                    {
                        StaffId = staffCPD.StaffId,
                        Semester = staffCPD.Semester,
                        SessionId = staffCPD.SessionId,
                        FormType = staffCPD.FormType,
                        Date = staffCPD.Date.Date,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedBy = long.Parse(_authUser.UserId),
                        DateCreated = DateTime.Now,
                        DateUpdated = null,
                        UpdatedBy = null,


                    };
                    if (staffCPD.File != null && staffCPD.File.Length > 0)
                    {
                        var uploadDir = @"Upload/StaffCPD";
                        var fileName = Path.GetFileNameWithoutExtension(staffCPD.File.FileName);
                        var extension = Path.GetExtension(staffCPD.File.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        staffCPD.File.CopyToAsync(new FileStream(path, FileMode.Create));
                        staffCPDAssesment.FileName = "/" + uploadDir + "/" + fileName;
                    }
                    _staffCPDRepo.Create(staffCPDAssesment);
                    transaction.Complete();
                    resp = new ResponseData<StaffCPDAssesmentViewModel>
                    {
                        Message = "Staff created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };
                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<StaffCPDAssesmentViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }



        public List<StaffCPDAssesment> GetStaffCPDAssesmentById(long StaffId)
        {
            var staffCPDs = _staffCPDRepo.Filter(x => x.StaffId == StaffId).ToList();
            return staffCPDs;
        }
        public ResponseData<StaffCPDAssesmentViewModel> UpdateStaffCPDAssesment(StaffCPDAssesmentViewModel staffCPD, bool LogRequest)
        {
            ResponseData<StaffCPDAssesmentViewModel> resp;
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var staffCPDs = _staffCPDRepo.Find(staffCPD.Id);
                    staffCPDs.StaffId = staffCPD.StaffId;
                    staffCPD.Semester = staffCPD.Semester;
                    staffCPD.SessionId = staffCPD.SessionId;
                    staffCPD.FormType = staffCPD.FormType;
                    staffCPD.Date = staffCPD.Date.Date;
                    staffCPDs.IsActive = true;
                    staffCPDs.IsDeleted = false;
                    staffCPDs.CreatedBy = long.Parse(_authUser.UserId);
                    staffCPDs.DateCreated = DateTime.Now;
                    staffCPDs.DateUpdated = DateTime.Now;
                    staffCPDs.UpdatedBy = long.Parse(_authUser.UserId);
                    if (staffCPD.File != null && staffCPD.File.Length > 0)
                    {
                        var uploadDir = @"Upload/StaffCPD";
                        var fileName = Path.GetFileNameWithoutExtension(staffCPD.File.FileName);
                        var extension = Path.GetExtension(staffCPD.File.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        staffCPD.File.CopyToAsync(new FileStream(path, FileMode.Create));
                        staffCPDs.FileName = "/" + uploadDir + "/" + fileName;
                    }
                    _staffCPDRepo.Update(staffCPDs);
                    if (LogRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(staffCPD);
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = _configration.GetSection("BaseAPIURl").Value + "/cert"
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                        transaction.Complete();
                    }
                    resp = new ResponseData<StaffCPDAssesmentViewModel>
                    {
                        Message = "certificate created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };
                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<StaffCPDAssesmentViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }

        public ResponseData<StaffCPDAssesment> DeleteStaffCPDAssesment(long Id)
        {
            ResponseData<StaffCPDAssesment> resp;

            try
            {
                var staffCPD = _staffCPDRepo.Find(Id);
                staffCPD.IsDeleted = true;
                staffCPD.IsActive = false;
                _staffCPDRepo.Update(staffCPD);

            }
            catch (Exception ex)
            {
                resp = new ResponseData<StaffCPDAssesment>

                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
            return null;
        }



    }
}
