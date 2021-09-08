using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Business.Model
{
    public class RevenueExpenditureViewModel
    {
        public long Id { get; set; }
        public long revepenitureid { get; set; }
        public string Code { get; set; }
        public string Fundtype { get; set; }
        public decimal WageandSalary { get; set; }
        public decimal Approvebudget { get; set; }
        public decimal Amountexpendedcurrentmonth { get; set; }
        public decimal Cumulativeamt { get; set; }
        public decimal Totalexpendituretodate { get; set; }
        public decimal Balance { get; set; }
        //    public string mda { get; set; }
        //    public  string costcenter { get; set; }
        //    public string reportingYear { get; set; }
        //    [Required]
        //    public string reportingPeriod { get; set; }
        //    public RevenueExpenditureModel ModelExpenditure { get; set; }
        //    public List<LstRevenueExpenditureModelViewModel> LstExpendituremode { get; set; }


        //    public static RevenueExpenditureViewModel EntityToModels(RevenueExpenditureItem dbmodel)

        //    {
        //        return dbmodel == null
        //            ? null
        //            : new RevenueExpenditureViewModel
        //            {
        //                id = dbmodel.Id,

        //                code = dbmodel.Code,
        //                balance = dbmodel.Balance,
        //                wageandsalary = dbmodel.WageandSalary,
        //                amountexpendedcurrentmonth = dbmodel.AmountExpendedcurrentMonth,
        //                approvebudget = dbmodel.ApproveBudget,
        //                cumulativeamt = dbmodel.CumulativeAmt,
        //               //fundtype = dbmodel.fu
        //                totalexpendituretodate = dbmodel.TotalAmtexpendedtilldate



        //            };
        //    }

        //    public class RevenueExpenditureModel
        //    {
        //        public long id { get; set; }
        //        public long revepenitureid { get; set; }
        //        public string code { get; set; }
        //        public decimal wageandsalary { get; set; }
        //        public decimal approvebudget { get; set; }
        //        public decimal amountexpendedcurrentmonth { get; set; }
        //        public decimal cumulativeamt { get; set; }
        //        public decimal totalexpendituretodate { get; set; }
        //        public decimal balance { get; set; }
        //        public string mda { get; set; }
        //        public string reportingYear { get; set; }
        //        [Required]
        //        public string reportingPeriod { get; set; }
        //    }



        //    public class LstRevenueExpenditureModelViewModel
        //    {
        //        public long id { get; set; }
        //        public long revepenitureid { get; set; }
        //        public string code { get; set; }
        //        public decimal wageandsalary { get; set; }
        //        public decimal approvebudget { get; set; }
        //        public decimal amountexpendedcurrentmonth { get; set; }
        //        public decimal cumulativeamt { get; set; }
        //        public decimal totalexpendituretodate { get; set; }
        //        public decimal balance { get; set; }
        //        public string mda { get; set; }
        //        public string reportingYear { get; set; }
        //        [Required]
        //        public string reportingPeriod { get; set; }
        //        public static LstRevenueExpenditureModelViewModel EntityToModels(RevenueExpenditureItem dbmodel)
        //        {
        //            return dbmodel == null
        //                ? null
        //                : new LstRevenueExpenditureModelViewModel
        //                {
        //                    id = dbmodel.Id,
        //                    balance = dbmodel.Balance,
        //                    code = dbmodel.Code,

        //                    amountexpendedcurrentmonth = dbmodel.AmountExpendedcurrentMonth,
        //                    approvebudget = dbmodel.ApproveBudget,
        //                    cumulativeamt = dbmodel.CumulativeAmt,
        //                    totalexpendituretodate = dbmodel.TotalAmtexpendedtilldate



        //                };
        //        }



        //        public static LstRevenueExpenditureModelViewModel EntityToModels1(RevenueExpenditureItem dbmodel)
        //        {
        //            return dbmodel == null
        //                ? null
        //                : new LstRevenueExpenditureModelViewModel
        //                {
        //                    id = dbmodel.Id,
        //                    // Accounttitle = "",
        //                    code = "",
        //                    balance = 0.00M,
        //                    amountexpendedcurrentmonth = 0.00M,
        //                    approvebudget = 0.00M,
        //                    cumulativeamt = 0.00M,
        //                    totalexpendituretodate = 0.00M



        //                };
        //        }
        //    }
        //}
    }
}
     