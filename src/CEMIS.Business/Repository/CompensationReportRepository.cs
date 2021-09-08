using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CEMIS.Business.Repository
{
   public  class CompensationReportRepository: ICompensationReport
    {
        private IRepository<CompensationReport> _compensationRepo;
        private IConfiguration _configration;
        private readonly string _connStr;

        public CompensationReportRepository(IRepository<CompensationReport> compensationRepo, IConfiguration configration)
        {
            _compensationRepo = compensationRepo;
            _configration = configration;
            _connStr = configration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<CompensationReportViewModel> GetCompensation(string month, string year)
        {

            try
            {
                IEnumerable<CompensationReportViewModel> report = null;
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@month", month);
                queryParameters.Add("@year", year);
             

                using (IDbConnection conn = new SqlConnection(_connStr))
                {
                    report = conn.Query<CompensationReportViewModel>("getCompensation", queryParameters, commandType: CommandType.StoredProcedure).AsList();

                };

                return report;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }

        }

        public CompensationReport CheckCompensation(string month, string year)
        {
            var fetchdata = _compensationRepo.Filter(x => x.Month == month && x.Year == year && x.IsCommitted==true ).FirstOrDefault();
            return fetchdata;
        }

        public void CommitCompensationReport(string month, string year)
        {

            try
            {
              
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@month", month);
                queryParameters.Add("@year", year);


                using (IDbConnection conn = new SqlConnection(_connStr))
                {
                 conn.Execute("CommitCompensationReport", queryParameters, commandType: CommandType.StoredProcedure);

                };

                return ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
