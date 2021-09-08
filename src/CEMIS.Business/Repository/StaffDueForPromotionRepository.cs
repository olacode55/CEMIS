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
   public class StaffDueForPromotionRepository: IStaffDueForPromotionAllowance
    {
        private IRepository<StaffDueForPromotionAllowance> _staffDueForPromotionAllowanceRepo;
        private readonly IAuthUser _authUser;
        private readonly IRepository<APIRequestLog> _apiRequestRepo;
        private readonly IConfiguration _configration;

        public StaffDueForPromotionRepository(IRepository<StaffDueForPromotionAllowance> staffDueForPromotionAllowanceRepo, IAuthUser authUser, IRepository<APIRequestLog> apiRequestRepo, IConfiguration configration)
        {
            _staffDueForPromotionAllowanceRepo = staffDueForPromotionAllowanceRepo;
            _authUser = authUser;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
        }

        public List<StaffDueForPromotionAllowance> GetAllStaffDueForPromotionAllowance()
        {
            return _staffDueForPromotionAllowanceRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true).ToList();
        }

        public ResponseData<StaffDueForPromotionAllowance> DeleteStaffDueForPromotionAllowance(long Id)
        {
            ResponseData<StaffDueForPromotionAllowance> resp;

            try
            {
                var allowance = GetStaffDueForPromotionAllowanceById(Id);
                _staffDueForPromotionAllowanceRepo.Delete(allowance);

            }
            catch (Exception ex)
            {
                resp = new ResponseData<StaffDueForPromotionAllowance>

                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
            return null;
        }

        public List<StaffDueForPromotionAllowance> GetStaffDueForPromotionAllowanceById(long StaffId)
        {
            var allowance = _staffDueForPromotionAllowanceRepo.Filter(x => x.StaffId == StaffId).ToList();
            return allowance;
        }
    }
}
