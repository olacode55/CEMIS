using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEMIS.Business.Repository
{
    public class StaffAllowanceRepository : IStaffAllowance
    {
        private IRepository<StaffAllowance> _staffAllowanceRepo;
        private readonly IAuthUser _authUser;
        private readonly IRepository<APIRequestLog> _apiRequestRepo;
        private readonly IConfiguration _configration;

        public StaffAllowanceRepository(IRepository<StaffAllowance> staffAllowanceRepo, IAuthUser authUser, IRepository<APIRequestLog> apiRequestRepo, IConfiguration configration)
        {
            _staffAllowanceRepo = staffAllowanceRepo;
            _authUser = authUser;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
        }

        public List<StaffAllowance> GetAllStaffAllowance()
        {
            return _staffAllowanceRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();

        }

        public ResponseData<StaffAllowance> DeleteStaffAllowance(long Id)
        {
            ResponseData<StaffAllowance> resp;

            try
            {
                var allowance = GetStaffAllowanceById(Id);
                _staffAllowanceRepo.Delete(allowance);

            }
            catch (Exception ex)
            {
                resp = new ResponseData<StaffAllowance>

                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
            return null;
        }

        public List<StaffAllowance> GetStaffAllowanceById(long StaffId)
        {
            var allowance = _staffAllowanceRepo.Filter(x => x.StaffId == StaffId).ToList();
            return allowance;
        }
    }
}  


