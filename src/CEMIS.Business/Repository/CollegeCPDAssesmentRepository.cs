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
    public class CollegeCPDAssesmentRepository : ICollegeCPDAssesment
    {
        private IRepository<CollegeCPDAssesment> _collegeCPDRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IConfiguration _configration;
        private IAuthUser _authUser;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CollegeCPDAssesmentRepository(IRepository<CollegeCPDAssesment> collegeCPDRepo, IRepository<APIRequestLog> apiRequestRepo, IHostingEnvironment hostingEnvironment, IAuthUser authUser, IConfiguration configration)
        {
            _collegeCPDRepo = collegeCPDRepo;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
            _hostingEnvironment = hostingEnvironment;
            _authUser = authUser;
        }
        public List<CollegeCPDAssesment> GetAllCollegeCPDAssesment()
        {
            return _collegeCPDRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();
        }
        public ResponseData<CollegeCPDAssesmentViewModel> CreateCollegeCPDAssesment(CollegeCPDAssesmentViewModel collegeCPD, bool LogRequest)
        {
            ResponseData<CollegeCPDAssesmentViewModel> resp;
            using (var transaction = new TransactionScope())
            {
                try
                {

                    if (LogRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(collegeCPD);
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
                    CollegeCPDAssesment collegeCPDAssesment = new CollegeCPDAssesment()
                    {
                        CollegeID = collegeCPD.CollegeID,
                        SessionId = collegeCPD.SessionId,
                        Semester = collegeCPD.Semester,
                        FormType = collegeCPD.FormType,
                        Date = collegeCPD.Date.Date,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedBy = long.Parse(_authUser.UserId),
                        DateCreated = DateTime.Now,
                        DateUpdated = null,
                        UpdatedBy = null,


                    };
                    if (collegeCPD.File != null && collegeCPD.File.Length > 0)
                    {
                        var uploadDir = @"Upload/CollegeCPD";
                        var fileName = Path.GetFileNameWithoutExtension(collegeCPD.File.FileName);
                        var extension = Path.GetExtension(collegeCPD.File.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        collegeCPD.File.CopyToAsync(new FileStream(path, FileMode.Create));
                        collegeCPDAssesment.FileName = "/" + uploadDir + "/" + fileName;
                    }
                    _collegeCPDRepo.Create(collegeCPDAssesment);
                    transaction.Complete();
                    resp = new ResponseData<CollegeCPDAssesmentViewModel>
                    {
                        Message = "Staff created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };
                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<CollegeCPDAssesmentViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }



        public List<CollegeCPDAssesment> GetCollegeCPDAssesmentById(long CollegeId)
        {
            var collegeCPDs = _collegeCPDRepo.Filter(x => x.CollegeID == CollegeId).ToList();
            return collegeCPDs;
        }
        //public ResponseData<CollegeCPDAssesmenttViewModel> UpdateCollegeCPDAssesmentt(CollegeCPDAssesmenttViewModel staffCPD, bool LogRequest)
        //{
        //    ResponseData<CollegeCPDAssesmenttViewModel> resp;
        //    using (var transaction = new TransactionScope())
        //    {
        //        try
        //        {
        //            var staffCPDs = _staffCPDRepo.Find(staffCPD.Id);
        //            staffCPDs.StaffId = staffCPD.StaffId;
        //            staffCPDs.IsActive = true;
        //            staffCPDs.IsDeleted = false;
        //            staffCPDs.CreatedBy = long.Parse(_authUser.UserId);
        //            staffCPDs.DateCreated = DateTime.Now;
        //            staffCPDs. DateUpdated = DateTime.Now;
        //            staffCPDs.UpdatedBy = long.Parse(_authUser.UserId);
        //            if (staffCPD.File != null && staffCPD.File.Length > 0)
        //            {
        //                var uploadDir = @"Upload/StaffCPD";
        //                var fileName = Path.GetFileNameWithoutExtension(staffCPD.File.FileName);
        //                var extension = Path.GetExtension(staffCPD.File.FileName);
        //                var webRootPath = _hostingEnvironment.WebRootPath;
        //                fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
        //                var path = Path.Combine(webRootPath, uploadDir, fileName);
        //                staffCPD.File.CopyToAsync(new FileStream(path, FileMode.Create));
        //                staffCPDs.FileName = "/" + uploadDir + "/" + fileName;
        //            }
        //            _staffCPDRepo.Update(staffCPDs);
        //            if (LogRequest)
        //            {
        //                var data = Newtonsoft.Json.JsonConvert.SerializeObject(staffCPD);
        //                var apiRequestLog = new APIRequestLog
        //                {
        //                    Data = data,
        //                    RequestType = HTTPRequestType.Put,
        //                    Synched = false,
        //                    Url = _configration.GetSection("BaseAPIURl").Value + "/cert"
        //                };
        //                _apiRequestRepo.Create(apiRequestLog);
        //                transaction.Complete();
        //            }
        //            resp = new ResponseData<CollegeCPDAssesmenttViewModel>
        //            {
        //                Message = "certificate created successfully",
        //                RespCode = "00",
        //                IsSuccessful = true
        //            };
        //            return resp;
        //        }
        //        catch (Exception ex)
        //        {
        //            return new ResponseData<CollegeCPDAssesmenttViewModel>
        //            {
        //                Message = "Operation failed",
        //                RespCode = "04",
        //                IsSuccessful = false
        //            };
        //        }
        //    }
        //}

        public ResponseData<CollegeCPDAssesment> DeleteCollegeCPDAssesment(long Id)
        {
            ResponseData<CollegeCPDAssesment> resp;

            try
            {
                var collegeCPD = _collegeCPDRepo.Find(Id);
                collegeCPD.IsDeleted = true;
                collegeCPD.IsActive = false;
                _collegeCPDRepo.Update(collegeCPD);

            }
            catch (Exception ex)
            {
                resp = new ResponseData<CollegeCPDAssesment>

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
