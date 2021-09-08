using CEMIS.Business.Interface;
using CEMIS.Business.Model;
using CEMIS.Data;
//using CEMIS.Data.Central;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CEMIS.Data.Entities;
using CEMIS.Utility;

namespace CEMIS.Business.Repository
{
    public class RepositoryUtility : IRepositoryUtility
    {
        private readonly appContext _context;
        public RepositoryUtility(appContext context)
        {
            _context = context;
        }

        public List<RevenueFixedAssetitem> GetAssetRevenuebyId(long Id)
        {
            throw new NotImplementedException();
        }

        //  List<RevenueFixedAssetViewModel> GetRevenueFixedAssetItem();
        public List<RevenueFixedAssetViewModel> GetRevenueFixedAsset()
        {
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection Con = new SqlConnection(connectionString))
            {

                DataTable dt = new DataTable();
                List<RevenueFixedAssetViewModel> info = new List<RevenueFixedAssetViewModel>();

                SqlCommand cmd = new SqlCommand("getRevenueFixedAsset", Con)
                {

                    CommandType = CommandType.StoredProcedure
                };
                Con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    RevenueFixedAssetViewModel model = new RevenueFixedAssetViewModel
                    {
                        Id = (long)dr["Id"],
                        MDA = dr["MDA"].ToString(),
                        CostCentre = dr["CostCentre"].ToString(),
                        ReportingPeriod = dr["ReportingPeriod"].ToString(),

                    };

                }

                Con.Close();
                return info;
            }
        }
        
       public List<RevenueFixedAssetitem> GetRevenueFixedAssetItem()
        {
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection Con = new SqlConnection(connectionString))
            {

                DataTable dt = new DataTable();
                List<RevenueFixedAssetitem> info = new List<RevenueFixedAssetitem>();

                SqlCommand cmd = new SqlCommand("getRevenueFixedAssetItem", Con)
                {

                    CommandType = CommandType.StoredProcedure
                };
                Con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    RevenueFixedAssetViewModel model = new RevenueFixedAssetViewModel
                    {
                        Id = (long)dr["Id"],
                        Accounttitle = dr["Accounttitle"].ToString(),
                        AmountExpendedcurrentYear=Convert.ToDecimal(dr["AmountExpendedcurrentYear"]),
                        ApproveBudget= Convert.ToDecimal(dr["ApproveBudget"]),
                        Balance = Convert.ToDecimal(dr["Balance"]),
                        CumulativeAmt = Convert.ToDecimal(dr["CumulativeAmt"]),
                        TotalAmtexpendedtilldate = Convert.ToDecimal(dr["TotalAmtexpendedtilldate"]),
                        Code= dr["Code"].ToString(),
                       
                    };

                }

                Con.Close();
                return info;
            }
        }
        public List<SessionViewModel> GetsessionbyMember()
        {
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection Con = new SqlConnection(connectionString))
            {

                DataTable dt = new DataTable();
                List<SessionViewModel> info = new List<SessionViewModel>();

                SqlCommand cmd = new SqlCommand("GetMemberSession", Con)
                {
                    //cmd.Parameters.AddWithValue("@km", kl);
                    //cmd.Parameters.AddWithValue("@kl", ki);
                    CommandType = CommandType.StoredProcedure
                };
                Con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    SessionViewModel model = new SessionViewModel
                    {
                        Id = (long)dr["Id"],
                        SessionName = dr["SessionName"].ToString(),

                    };
                    info.Add(model);
                }

                Con.Close();
                return info;
            }
        }
        
        public List<SessionViewModel> GetsessionMemberListing()
        {
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection Con = new SqlConnection(connectionString))
            {

                DataTable dt = new DataTable();
                List<SessionViewModel> info = new List<SessionViewModel>();

                SqlCommand cmd = new SqlCommand("GetMemberListenReport", Con)
                {
                    //cmd.Parameters.AddWithValue("@km", kl);
                    //cmd.Parameters.AddWithValue("@kl", ki);
                    CommandType = CommandType.StoredProcedure
                };
                Con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    SessionViewModel model = new SessionViewModel
                    {
                        Id = (long)dr["Id"],
                        MembershipName = dr["MembershipName"].ToString(),
                        MembershipPosition = (Postion) dr["MembershipPosition"],
                        SessionName = dr["SessionName"].ToString(),
                        StartDate = dr["StartDate"].ToString(),
                        EndDate = dr["EndDate"].ToString()
                    };
                    info.Add(model);
                }

                Con.Close();
                return info;
            }
        }

        List<RevenueFixedAssetitem> IRepositoryUtility.GetRevenueFixedAssetItem()
        {
            throw new NotImplementedException();
        }
    }
}
