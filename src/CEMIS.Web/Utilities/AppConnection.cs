using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CEMIS.Data.Utilities
{
    //public class AppConnection
    //{

    //    static IConfiguration _config;
    //    static appContext _context;

    //    public AppConnection(IConfiguration config,appContext context)
    //    {
    //        _config = config;
    //        _context = context;

    //    }
    //    public static string GetAppConnection()
    //    {

    //       var conString = _context.Database.GetDbConnection().ConnectionString;
    //        return conString;
    //    }
    //}


    public class AppConnection : IAppConnection
    {

        IConfiguration _config;
        appContext _context;

        public AppConnection(IConfiguration config, appContext context)
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
