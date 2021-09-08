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

namespace Cemis.Business.Central.Repository
{
   public class AllowanceRepository: IAllowance
    {
        private readonly IRepository<Allowance> _allowanceRepo;
        private readonly IAuthUser _authUser;
        private readonly IConfiguration _configration;
        public AllowanceRepository(IRepository<Allowance> allowanceRepo, IAuthUser authUser, IConfiguration configration)
        {

            _allowanceRepo = allowanceRepo;
            _authUser = authUser;
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
                            RespCode = "01",
                            IsSuccessful = false
                        };
                    }

                    var allowanceExist = _allowanceRepo.All().FirstOrDefault(x => x.Name == allowance.name);

                    if(allowanceExist != null)
                    {
                        return new ResponseData<AllowanceViewModel>
                        {
                            Message = $"Allowance with Name {allowance.name} already exist",
                            RespCode = "02",
                            IsSuccessful = false
                        };
                    }
                    var allowances = new Allowance
                    {
                        Name = allowance.name,
                        ParentId = allowance.ParentId,
                        IsDeleted = false,
                        IsActive = true,
                        CreatedBy = long.Parse(_authUser.UserId),
                        DateCreated = DateTime.Now,
                        UpdatedBy = null


                    };


                 

                    _allowanceRepo.Create(allowances);

                    transaction.Complete();

                    resp = new ResponseData<AllowanceViewModel>
                    {
                        Message = "Allowance created successfully",
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
            var item = _allowanceRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();

            fecthdata = ((from x in item
                          select new AllowanceViewModel
                          {
                              Id = x.Id,
                              name = x.Name,
                              


                          }).ToList());

            return fecthdata;
        }

        public ResponseData<List<AllowanceViewModel>> GetAllAllowanceAPI()
        {
            try
            {

                var fecthdata = new List<AllowanceViewModel>();
                var item = _allowanceRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();

                fecthdata = ((from x in item
                              select new AllowanceViewModel
                              {
                                  IsBasicSalry = x.IsBasicSalary,
                                  ParentId = x.ParentId,
                                  name = x.Name,
                                  Id = x.Id


                              }).ToList());

                return new ResponseData<List<AllowanceViewModel>>
                {
                    Message = "Basic Salary gotten successfully",
                    RespCode = "00",
                    IsSuccessful = true,
                    Data = fecthdata,

                };


            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<List<AllowanceViewModel>>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
        }

        public AllowanceViewModel GetAllowanceById(long Id)
        {
            var allowance = _allowanceRepo.Find(Id);
            if (allowance != null)
            {
                return new AllowanceViewModel
                {
                    name = allowance.Name,
                    ParentId = allowance.ParentId
                };
            }
            return null;
        }

        public List<Allowance> GetParentAllowance()
        {
            return _allowanceRepo.All().Where(x => x.ParentId == 0).ToList();
            
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
