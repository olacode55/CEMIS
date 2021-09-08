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

namespace CEMIS.Business
{
    public class CertificateRepository : ICertificate
    {
        private IRepository<Certificate> CertificateRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IConfiguration _configration;

        public CertificateRepository(IRepository<Certificate> staffRepo, IRepository<APIRequestLog> apiRequestRepo, IConfiguration configration)
        {
            CertificateRepo = staffRepo;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
        }
        public List<Certificate> GetAllCertificate()
        {
            return CertificateRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();
        }
        public ResponseData<Certificate> CreateCertificate(Certificate certificate, bool LogRequest)
        {
            ResponseData<Certificate> resp;
            using (var transaction = new TransactionScope())
            {
                try
                {
                    certificate.IsDeleted = false;
                    certificate.IsActive = true;
                    certificate.DateCreated = DateTime.Now;
                    if (LogRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(certificate);
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
                    CertificateRepo.Create(certificate);
                    transaction.Complete();
                    resp = new ResponseData<Certificate>
                    {
                        Message = "Staff created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };
                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<Certificate>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }



        public List<Certificate> GetCertificateById(long StaffId)
        {
            var cert = CertificateRepo.Filter(x=> x.StaffId == StaffId).ToList();
            return cert;
        }
        public ResponseData<Certificate> UpdateCertificate(Certificate certificate, bool LogRequest)
        {
            ResponseData<Certificate> resp;
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var cert = CertificateRepo.Find(certificate.Id);
                    cert.Url    = certificate.Url;
                    cert.StaffId = certificate.StaffId;
                    
                    CertificateRepo.Update(cert);
                    if (LogRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(certificate);
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
                    resp = new ResponseData<Certificate>
                    {
                        Message = "certificate created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };
                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<Certificate>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }

        public ResponseData<Certificate> DeleteCertificate(long Id)
        {
            ResponseData<Certificate> resp;
           
                try
                {
                    var cert = GetCertificateById(Id);
                    CertificateRepo.Delete(cert);
                    
                    }
                catch (Exception ex)
                {
                resp = new ResponseData<Certificate>
                   
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
