using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Linq;

namespace CEMIS.Business.Repository
{
   public class DepartmentRepository : IDepartment
    {
        private IRepository<Department> _departmentRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IConfiguration _configration;

        public DepartmentRepository(IRepository<Department> departmentRepo, IRepository<APIRequestLog> apiRequestRepo, IConfiguration configration)
        {
            _departmentRepo = departmentRepo;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
        }

        public ResponseData<Department> CreateDepartment(Department department, bool logRequest)
        {
            ResponseData<Department> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (string.IsNullOrEmpty(department.Name))
                    {
                        return new ResponseData<Department>
                        {
                            Message = "Name cannot be empty",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }

                    if (checkNameexist(department.Name))
                    {
                        return new ResponseData<Department>
                        {
                            Message = "Department Name already exist",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }
                    department.IsDeleted = false;
                    department.IsActive = true;
                    department.DateCreated = DateTime.Now;
                    department.Name = department.Name;

                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(department);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Department";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    _departmentRepo.Create(department);

                    transaction.Complete();

                    resp = new ResponseData<Department>
                    {
                        Message = "Department created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<Department>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };


                }
            }
        }

        public List<Department> GetAllDepartment()
        {
            return _departmentRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();
        }
        public Department GetDepartmentById(long Id)
        {
            var department = _departmentRepo.Find(Id);
            return department;
        }

        public bool checkNameexist(string name)
        {
           return _departmentRepo.All().Any(slt => slt.Name.Trim().ToLower() == name.Trim().ToLower() && slt.IsActive == true);
            
        }

        public ResponseData<Department> UpdateDepartment(Department department, bool logRequest)
        {
            ResponseData<Department> resp;

            using (var transaction = new TransactionScope())
            {
                try
                {
                    if (checkUpdateNameexist(department))
                    {
                        return new ResponseData<Department>
                        {
                            Message = "Department already exist",
                            RespCode = "04",
                            IsSuccessful = false
                        };
                    }

                    if (logRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(department);
                        string url = _configration.GetSection("BaseAPIURl").Value + "Department";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }

                    var getdepartment = _departmentRepo.Find(department.Id);
                    getdepartment.Name = department.Name;
                    getdepartment.IsActive = true;
                    getdepartment.IsDeleted = false;
                    getdepartment.CreatedBy = department.CreatedBy;
                    //getFacility.DateCreated = DateTime.Now;
                    getdepartment.DateUpdated = DateTime.Now;

                    _departmentRepo.Update(getdepartment);

                    transaction.Complete();



                    resp = new ResponseData<Department>
                    {
                        Message = "Department Updated successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                catch (Exception ex)
                {
                    return new ResponseData<Department>
                    {
                        Message = "Operation failed",
                        RespCode = "04",
                        IsSuccessful = false
                    };
                }
            }
        }

        public bool checkUpdateNameexist(Department department)

        {
          return _departmentRepo.All().Any(slt => slt.Name.Trim().ToLower() == department.Name.Trim().ToLower() && slt.Id != department.Id && slt.IsActive == true);
            
        }

        public bool DeleteDepartment(long Id, out string message)
        {
            if (Id > 0)
            {
                try
                {
                    var department = _departmentRepo.Find(Id);
                    department.IsDeleted = true;
                    department.IsActive = false;

                    _departmentRepo.Update(department);

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
