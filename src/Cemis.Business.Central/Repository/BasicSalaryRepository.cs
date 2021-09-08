
using Cemis.Data.Central.Entities;
using CEMIS.Business.Central.Interface;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CEMIS.Business.Central.Repository
{
  public class BasicSalaryRepository: IBasicSalary
    {
        private readonly IRepository<BasicSalary> _basicsalaryRepo;
        private readonly IAuthUser _authUser;
        private readonly IConfiguration _configration;

        public BasicSalaryRepository(IRepository<BasicSalary> basicsalaryRepo, IAuthUser authUser, IConfiguration configration)
        {
            _basicsalaryRepo = basicsalaryRepo;
            _authUser = authUser;
            _configration = configration;
        }

        public ResponseData<BasicSalaryViewModel> CreateBasicSalary(BasicSalaryViewModel basicSalary, long currentUser)
        {
            ResponseData<BasicSalaryViewModel> resp;

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
                if (basicSalary.step < 1)
                {
                    return new ResponseData<BasicSalaryViewModel>
                    {
                        Message = "Step cannot be lesser than one",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }

                if (basicSalary.gradeLevel < 1)
                {
                    return new ResponseData<BasicSalaryViewModel>
                    {
                        Message = "Grade level cannot be lesser than one",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
                var recordExist = _basicsalaryRepo.All().FirstOrDefault(x => x.GradeLevel == basicSalary.gradeLevel && x.Step == basicSalary.step);
                
                if(recordExist != null)
                {
                    return new ResponseData<BasicSalaryViewModel>
                    {
                        Message = $"Record with greade level {basicSalary.gradeLevel} and step {basicSalary.step} exist",
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
                        CreatedBy = currentUser,
                        DateCreated = DateTime.Now,
                    };
                                   _basicsalaryRepo.Create(basicsalary);

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

        public ResponseData<List<BasicSalaryViewModel>> GetAllBasicSalaryAPI()
        {
            try
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

                return new ResponseData<List<BasicSalaryViewModel>>
                {
                    Message = "Basic Salary gotten successfully",
                    RespCode = "00",
                    IsSuccessful = true,
                    Data = fecthdata,

                };

                
            }catch(Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<List<BasicSalaryViewModel>>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
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

        public ResponseData<BasicSalaryViewModel> UpdateBasicSalary(BasicSalaryViewModel basicSalary, long currentUser)
        {
            ResponseData<BasicSalaryViewModel> resp;
                try
                {
                    var basicsalary = _basicsalaryRepo.Find(basicSalary.Id);

                    basicsalary.GradeLevel = basicSalary.gradeLevel;
                    basicsalary.Step = basicSalary.step;
                    basicsalary.Amount = basicSalary.amount;
                    basicsalary.IsActive = true;
                    basicsalary.IsDeleted = false;
                    basicsalary.CreatedBy = currentUser;
                    basicsalary.UpdatedBy = long.Parse(_authUser.UserId);
                    basicsalary.DateUpdated = DateTime.Now;

                    _basicsalaryRepo.Update(basicsalary);



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

