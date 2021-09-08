using Cemis.Business.Central.Interface;
using Cemis.Data.Central.Entities;
using CEMIS.Business.Central.Interface;
using CEMIS.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cemis.Business.Central.Repository
{
    public class ActivityLogRepository : IActivityLog
    {
        private IRepository<ActivityLog> _activityLogRepo;
        public ActivityLogRepository(IRepository<ActivityLog> activityLogRepo)
        {
            _activityLogRepo = activityLogRepo;
        }
        public async Task CreateActivityLog(string descriptn, string moduleName, string moduleAction, Int64 userid, object record, string IPAddress)
        {

            try
            {
                ActivityLog alog = new ActivityLog
                {
                    Module = moduleName,
                    Action = moduleAction,
                    UserId = userid,
                    Description = descriptn,
                    Data = record != null ? JsonConvert.SerializeObject(record) : "N/A",
                    IPAddress = IPAddress,
                    DateCreated = DateTime.Now

                };
                await _activityLogRepo.CreateAsync(alog);
   
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }

        }

    }
}
