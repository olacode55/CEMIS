using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEMIS.Business.Repository
{
    public class StaffGradeLevelRepository : IStaffGradeLevel
    {
        private readonly IRepository<StaffGradeLevel> _staffGradelevelRepo;
        private readonly IRepository<APIRequestLog> _apiRequestRepo;
        private readonly IConfiguration _configration;

        public StaffGradeLevelRepository(IRepository<StaffGradeLevel> staffGradelevelRepo, IRepository<APIRequestLog> apiRequestRepo, IConfiguration configration)
        {
            _staffGradelevelRepo = staffGradelevelRepo;
            _apiRequestRepo = apiRequestRepo;
            _configration = configration;
            
        }
        public List<StaffGradeLevel> GetAllStaffGradeLevel()
        {
              return _staffGradelevelRepo.All().Where(m => m.IsActive == true && m.IsDeleted == false).ToList();
            
        }
    }
}
