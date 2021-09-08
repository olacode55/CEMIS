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
  public class BasicSalaryRepository: IBasicSalary
    {
        private readonly IRepository<BasicSalary> _basicsalaryRepo;
        private readonly IAuthUser _authUser;
        private readonly IRepository<APIRequestLog> _apiRequestRepo;
        private readonly IConfiguration _configration;

        public BasicSalaryRepository(IRepository<BasicSalary> basicsalaryRepo, IAuthUser authUser, IRepository<APIRequestLog> apiRequestRepo,  IConfiguration configration)
        {
            _basicsalaryRepo = basicsalaryRepo;
            _authUser = authUser;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
        }

        public ResponseData<BasicSalaryViewModel> CreateBasicSalary(BasicSalaryViewModel basicSalary, bool logRequest)
        {
            ResponseData<BasicSalaryViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (basicSalary.amount < 1)
                    {
                        return new ResponseData<BasicSalaryViewModel>
                        {
                            Message = "Salary cannot be empty",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }
                    var basicsalary = new BasicSalary
                    {
                        GradeLevel = basicSalary.gradeLevel,
                        Step = basicSalary.step,
                        Amount = basicSalary.amount,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = long.Parse(_authUser.UserId),
                        DateCreated = DateTime.Now,
                        UpdatedBy = null


                    };


                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(basicSalary);
                        string url = _configration.GetSection("BaseAPIURl").Value + "BasicSalary";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    _basicsalaryRepo.Create(basicsalary);

                    transaction.Complete();

                    resp = new ResponseData<BasicSalaryViewModel>
                    {
                        Message = "Basic Salary created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<BasicSalaryViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };


                }
            }

        }

        public bool DeleteBasicSalary(long Id, out string message)
        {
            throw new NotImplementedException();
        }

        public List<BasicSalaryViewModel> GetAllBasicSalary()
        {
            var fecthdata = new List<BasicSalaryViewModel>();
            var item = _basicsalaryRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();

            fecthdata = ((from x in item
                          select new BasicSalaryViewModel
                          {
                              Id = x.Id,
                              gradeLevel = x.GradeLevel,
                              step = x.Step,
                              amount = x.Amount,
                         

                          }).ToList());

            return fecthdata;
        }

        public BasicSalaryViewModel GetBasicSalaryById(long Id)
        {
            var basicSalary = _basicsalaryRepo.Find(Id);
            if (basicSalary != null)
            {
                return new BasicSalaryViewModel
                {
                    gradeLevel = basicSalary.GradeLevel,
                    step = basicSalary.Step,
                    amount = basicSalary.Amount,
                   
                };
            }
            return null;
        }

        public BasicSalary GetBasicSalarysById(int Gradelevel, int Step)
        {
            var Fecthdata = _basicsalaryRepo.Filter(x => x.GradeLevel == Gradelevel && x.Step == Step).FirstOrDefault();
            return Fecthdata;
        }

        public ResponseData<BasicSalaryViewModel> UpdateBasicSalary(BasicSalaryViewModel basicSalary, bool logRequest)
        {
            ResponseData<BasicSalaryViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                   

                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(basicSalary);
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

                    var basicsalary = _basicsalaryRepo.Find(basicSalary.Id);

                    basicsalary.GradeLevel = basicSalary.gradeLevel;
                    basicsalary.Step = basicSalary.step;
                    basicsalary.Amount = basicSalary.amount;
                    basicsalary.IsActive = true;
                    basicsalary.IsDeleted = false;
                    basicsalary.CreatedBy = long.Parse(_authUser.UserId);
                    basicsalary.UpdatedBy = long.Parse(_authUser.UserId);
                    basicsalary.DateUpdated = DateTime.Now;

                    _basicsalaryRepo.Update(basicsalary);

                    transaction.Complete();



                    resp = new ResponseData<BasicSalaryViewModel>
                    {
                        Message = "Basic Salary Updated successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<BasicSalaryViewModel>
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

