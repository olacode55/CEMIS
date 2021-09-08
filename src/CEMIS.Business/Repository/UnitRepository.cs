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

    public class UnitRepository : IUnit
    {
        private IRepository<Unit> _unitRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IRepository<Department> _departmentRepo;
        private IConfiguration _configration;

        public UnitRepository(IRepository<Unit> unitRepo, IRepository<APIRequestLog> apiRequestRepo, IRepository<Department> departmentRepo, IConfiguration configration)
        {
            _unitRepo = unitRepo;
            _apiRequestRepo = apiRequestRepo;
            _departmentRepo = departmentRepo;
            _configration = configration;
        }

        public ResponseData<UnitViewModel> CreateUnit(UnitViewModel unit, bool logRequest)
        {
            ResponseData<UnitViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(unit.Name))
                    {
                        return new ResponseData<UnitViewModel>
                        {
                            Message = "Unit cannot be empty",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }

                    if (checkNameexist(unit.Name))
                    {
                        return new ResponseData<UnitViewModel>
                        {
                            Message = "Unit already exist",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }
                    var unitvalue = new Unit
                    {
                        IsDeleted = false,
                        IsActive = true,
                        DepartmentId = unit.DepartmentId,
                        DateCreated = DateTime.Now,
                        Name = unit.Name,

                    };


                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(unit);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Unit";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    _unitRepo.Create(unitvalue);

                    transaction.Complete();

                    resp = new ResponseData<UnitViewModel>
                    {
                        Message = "Unit created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<UnitViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };


                }
            }
        }

        public List<UnitViewModel> GetAllUnit()
        {
            var container = new List<UnitViewModel>();
          var  item = _unitRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();

            container = ((from x in item
                          select new UnitViewModel
                          {
                              Id = x.Id,
                              Name = x.Name,
                              Department = _departmentRepo.Find(x.DepartmentId).Name,
                              DepartmentId = x.DepartmentId,
                              DateCreated = x.DateCreated,
                              IsActive = x.IsActive,
                              IsDeleted = x.IsDeleted
                          }).ToList());

            return container;
        }

        public UnitViewModel GetUnitById(long Id)
        {
            var unit = _unitRepo.Find(Id);
            if(unit != null)
            {
                return new UnitViewModel
                {
                    DepartmentId = unit.DepartmentId,
                    Name = unit.Name,
                    Id = unit.Id
                };
            }
            return null;
        }

        public bool checkNameexist(string name)
        {
            return _unitRepo.All().Any(slt => slt.Name.Trim().ToLower() == name.Trim().ToLower() && slt.IsActive == true);

        }

        public ResponseData<UnitViewModel> UpdateUnit(UnitViewModel unit, bool logRequest)
        {
            ResponseData<UnitViewModel> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (checkUpdateNameexist(unit))
                    {
                        return new ResponseData<UnitViewModel>
                        {
                            Message = "Unit already exist",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }

                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(unit);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Unit";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    var getunit = _unitRepo.Find(unit.Id);
                   
                    getunit.Name = unit.Name;
                    getunit.IsActive = true;
                    getunit.IsDeleted = false;
                    getunit.CreatedBy = unit.CreatedBy;
                    getunit.DepartmentId = unit.DepartmentId;

                    //getFacility.DateCreated = DateTime.Now;
                    getunit.DateUpdated = DateTime.Now;

                    _unitRepo.Update(getunit);

                    transaction.Complete();



                    resp = new ResponseData<UnitViewModel>
                    {
                        Message = "Unit Updated successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<UnitViewModel>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }

        public bool checkUpdateNameexist(UnitViewModel unit)

        {
            return _unitRepo.All().Any(slt => slt.Name.Trim().ToLower() == unit.Name.Trim().ToLower() && slt.Id != unit.Id && slt.IsActive == true);

        }

        public bool DeleteUnit(long Id, out string message)
        {
            if (Id > 0)
            {
                try
                {
                    var unit = _unitRepo.Find(Id);
                    unit.IsDeleted = true;
                    unit.IsActive = false;

                    _unitRepo.Update(unit);

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
