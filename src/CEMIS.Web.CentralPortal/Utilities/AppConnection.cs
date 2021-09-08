using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CEMIS.Data.Central
{
    public class AppConnection : IAppConnection
    {

         IConfiguration _config;
         appContextCentral _context;

        public AppConnection(IConfiguration config, appContextCentral context)
        {
            _config = config;
            _context = context;
        }
        public string GetAppConnection()
        {
            var conString = _context.Database.GetDbConnection().ConnectionString;
            return conString;
        }
    }
}
