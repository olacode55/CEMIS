using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CEMIS.Business.Repository
{
   public class AllowanceRepository: IAllowance
    {
        private readonly IRepository<Allowance> _allowanceRepo;
        private readonly IAuthUser _authUser;
        private readonly IRepository<APIRequestLog> _apiRequestRepo;
        private readonly IConfiguration _configration;
        public AllowanceRepository(IRepository<Allowance> allowanceRepo, IAuthUser authUser, IRepository<APIRequestLog> apiRequestRepo, IConfiguration configration)
        {

            _allowanceRepo = allowanceRepo;
            _authUser = authUser;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;

        }

        public ResponseData<AllowanceViewModel> CreateBasicAllowance(AllowanceViewModel allowance, bool logRequest)
        {
            ResponseData<AllowanceViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(allowance.name))
                    {
                        return new ResponseData<AllowanceViewModel>
                        {
                            Message = "Allowance cannot be empty",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }
                    var allowances = new Allowance
                    {
                        Name = allowance.name,
                      
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = long.Parse(_authUser.UserId),
                        DateCreated = DateTime.Now,
                        UpdatedBy = null


                    };


                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(allowance);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Allowance";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    _allowanceRepo.Create(allowances);

                    transaction.Complete();

                    resp = new ResponseData<AllowanceViewModel>
                    {
                        Message = "Basic Salary created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<AllowanceViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };


                }
            }
        }

        public bool DeleteAllowance(long Id, out string message)
        {
            throw new NotImplementedException();
        }

        public List<AllowanceViewModel> GetAllAllowance()
        {
            var fecthdata = new List<AllowanceViewModel>();
            var item = _allowanceRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true && m.ParentId > 0 && m.IsBasicSalary ==false).ToList();

            fecthdata = ((from x in item
                          select new AllowanceViewModel
                          {
                              Id = x.Id,
                              name = x.Name,
                              


                          }).ToList());

            return fecthdata;
        }

        public AllowanceViewModel GetAllowanceById(long Id)
        {
            var allowance = _allowanceRepo.Find(Id);
            if (allowance != null)
            {
                return new AllowanceViewModel
                {
                    name = allowance.Name,
                };
            }
            return null;
        }

        public Allowance GetAllowanceId(string name)
        {
            var fecthdata = _allowanceRepo.Filter(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).FirstOrDefault();
            return fecthdata;
        }

        public ResponseData<AllowanceViewModel> UpdateAllowance(AllowanceViewModel allowance, bool logRequest)
        {
            ResponseData<AllowanceViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(allowance);
                        string url = _configration.GetSection("BaseAPIURl").Value + "BasicSalary";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    var allowances = _allowanceRepo.Find(allowance.Id);

                    allowances.Name = allowance.name;  
                    allowances.IsActive = true;
                    allowances.IsDeleted = false;
                    allowances.CreatedBy = long.Parse(_authUser.UserId);
                    allowances.UpdatedBy = long.Parse(_authUser.UserId);
                    allowances.DateUpdated = DateTime.Now;

                    _allowanceRepo.Update(allowances);

                    transaction.Complete();



                    resp = new ResponseData<AllowanceViewModel>
                    {
                        Message = "Allowace Updated successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<AllowanceViewModel>
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
