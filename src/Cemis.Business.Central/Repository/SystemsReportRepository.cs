using Cemis.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility.CentralReportFilterVM;
using CEMIS.Utility.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace Cemis.Business.Central.Repository
{
    public class SystemsReportRepository : ISystemsReport
    {

        private appContextCentral _context;
        public SystemsReportRepository(appContextCentral context)
        {
            _context = context;
        }

        public List<ActivityLogViewModel> AuditReport(AuditReportFilterVM auditFilterVM)
        {
            auditFilterVM.module = auditFilterVM.module == null ? string.Empty : auditFilterVM.module;
            auditFilterVM.dateFrom = auditFilterVM.dateFrom == null ? string.Empty : Convert.ToDateTime(auditFilterVM.dateFrom, CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss.fff");
            auditFilterVM.dateTo = auditFilterVM.dateTo == null ? string.Empty : Convert.ToDateTime(auditFilterVM.dateTo, CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss.fff");

           
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                var details = new List<ActivityLogViewModel>();

                SqlCommand cmd = new SqlCommand("GetAuditReport", myCon);
                cmd.Parameters.AddWithValue("@Module", auditFilterVM.module);
                cmd.Parameters.AddWithValue("@UserId", auditFilterVM.userId);
                cmd.Parameters.AddWithValue("@DateFrom", auditFilterVM.dateFrom);
                cmd.Parameters.AddWithValue("@DateTo", auditFilterVM.dateTo);

                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    var obj = new ActivityLogViewModel();
                    obj.Id = (long)dr["Id"];
                    obj.Action = dr["Action"].ToString();
                    obj.UserName = dr["UserName"].ToString();
                    obj.Module = dr["Module"].ToString();
                    obj.IPAddress = dr["IPAddress"].ToString();
                    obj.Description = dr["Description"].ToString();

                    details.Add(obj);
                }

                myCon.Close();
                return details;
            }
        }
    }
}
