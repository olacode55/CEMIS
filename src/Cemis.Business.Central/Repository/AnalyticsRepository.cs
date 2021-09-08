using Cemis.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Cemis.Business.Central.Repository
{
    public class AnalyticsRepository : IAnalytics
    {
        private appContextCentral _context;
        public AnalyticsRepository(appContextCentral context)
        {
            _context = context;
        }
        public List<AnalyticsPieChart> CollegeAnalyticsByStaffNumber()
        {

            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                var details = new List<AnalyticsPieChart>();

                SqlCommand cmd = new SqlCommand("Analytics_Top10CollegesByStaffNo", myCon);
                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new AnalyticsPieChart
                    {
                         Color = dr["Color"].ToString(),
                        Label = dr["Name"].ToString(),
                        Data = Convert.ToInt32(dr["Value"]),
                    };
                    details.Add(obj);

                }
                myCon.Close();
               
                return details;
            
              
            }
        }



        public AnalyticsModel CollegeAnalyticsByFacilityNumber()
        {

            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {

                DataTable dt = new DataTable();
                //List<AnalyticsModel> details = new List<AnalyticsModel>();
                var color = new List<string>();
                var name = new List<string>();
                var value = new List<string>();
                SqlCommand cmd = new SqlCommand("Analytics_Top10CollegesByFacility", myCon);
                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    //AnalyticsModel obj = new AnalyticsModel
                    //{
                    //    Color = dr["Color"].ToString(),
                    //    Name = dr["Name"].ToString(),
                    //    Value = dr["Value"].ToString(),
                    //};
                    //details.Add(obj);
                    color.Add(dr["Color"].ToString());
                    name.Add(dr["Name"].ToString());
                    value.Add(dr["Value"].ToString());
                }
                myCon.Close();
                AnalyticsModel obj = new AnalyticsModel
                {
                    Color = color,
                    Name = name,
                    Value = value
                };
                return obj;
            }
        }



    }
}
