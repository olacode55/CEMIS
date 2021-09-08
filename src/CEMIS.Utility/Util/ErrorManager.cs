using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;

namespace CEMIS.Utility
{
    public partial class ManagerLog
    {
        public int ID { get; set; }
        public string ErrorDetails { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class ErrorLogManager
    {
        public static void Error(Exception ex, string connectionString)
        {
            ManagerLog log = new ManagerLog
            {
                DateCreated = DateTime.Now,
                Message = ex.Message,
                ErrorDetails = ex.InnerException == null ? ("<strong>Error Message:</strong><br/>" + ex.Message + "<br/><strong>StackTrace:</strong><br/>" + ex.StackTrace)
                : "<strong>Error Message:</strong><br/>" + ex.Message + "<br/><strong>StackTrace:</strong><br/>" + ex.StackTrace +
                "<br/><br/><strong>Inner Exception Message:</strong><br/>" + ex.InnerException.Message + "<br/><strong>Inner Exception StackTrace:</strong><br/>" + ex.InnerException.StackTrace
            };

            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SPErrorLog", myCon);
                cmd.Parameters.AddWithValue("@DateCreated", log.DateCreated);
                cmd.Parameters.AddWithValue("@MethodContoller", log.Message);
                cmd.Parameters.AddWithValue("@ErrorDetails", log.ErrorDetails);
                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                cmd.ExecuteReader();

            }
        }


        public static void Error(string error, SqlConnection connection, DbContext context)
        {
            ManagerLog log = new ManagerLog
            {
                DateCreated = DateTime.Now,
                Message = error,
                ErrorDetails = string.Empty
            };


            //SqlConnection connection = null;
            DataSet dset = new DataSet();
            SqlParameter[] parameters = {
                                       new SqlParameter("@DateCreated",log.DateCreated),
                                       new SqlParameter("@MethodContoller",log.Message),
                                       new SqlParameter("@ErrorDetails",log.ErrorDetails)
                                      };
            try
            {
                //connection = GetAppConnection();

                connection.Open();

                //dset = SqlHelper.ExecuteDataset(connection, "SPErrorLog", parameters);
            }
            catch (Exception)
            {
            }
            finally { connection.Close(); }
        }

        public static void Error(Exception exception)
        {
            string errorMessage = "Date/Time: " + DateTime.Now + Environment.NewLine +
                     "Error message: " + exception.Message + Environment.NewLine +
                     "Inner exception: " + exception.InnerException + Environment.NewLine +
                     "Stack trace: " + exception.StackTrace + Environment.NewLine;

            //string path = HttpContext.Current.Server.MapPath("~/ErrorLog.txt");
            string path = Path.Combine("ErrorLog.txt");
            if (!File.Exists(path))
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (var tw = new StreamWriter(fs))
                    {
                        tw.WriteLine(errorMessage);
                        tw.Close();
                    }
                }
            }
            else if (File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))       
                {
                    tw.WriteLine(errorMessage);
                    tw.Close();
                }
                   
            }
        }

        public static void LogString(string errorMessage)
        {
            // errorMessage = DateTime.Now + ": " + errorMessage + Environment.NewLine;
            //string path = HttpContent.Current.Server.MapPath("~/ErrorLog.txt");
            string path = Path.Combine("~/ErrorLog.txt");
            if (!File.Exists(path))
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (var tw = new StreamWriter(fs))
                    {
                        tw.WriteLine(errorMessage);
                        tw.Close();
                    }
                }
            }
            else if (File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(errorMessage);
                    tw.Close();
                }
            }
        }

    }
}
