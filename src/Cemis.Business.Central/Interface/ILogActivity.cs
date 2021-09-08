using Cemis.Data.Central.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cemis.Business.Central.Interface
{
    public interface IActivityLog
    {
        Task CreateActivityLog(string descriptn, string moduleName, string moduleAction, Int64 userid, object record, string IPAddress);
    }
}
