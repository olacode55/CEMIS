using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using CEMIS.Data.Entities;

namespace CEMIS.Business.Model
{
    public class RevenueFixedAssetViewModel
    {
        public long Id { get; set; }
        public long RevEpenditureId { get; set; }
        public string Code { get; set; }
        public string Accounttitle { get; set; }
        public decimal ApproveBudget { get; set; }
        public decimal AmountExpendedcurrentYear { get; set; }
        public decimal CumulativeAmt { get; set; }
        public decimal TotalAmtexpendedtilldate { get; set; }

        public decimal Balance { get; set; }
        [Required]
        public string CostCentre { get; set; }
        [Required]

        public string MDA { get; set; }
        public string ReportingYear { get; set; }
        [Required]
        public string ReportingPeriod { get; set; }
        public FixedAssetModel Modelfixed { get; set; }
        public List<FixedAssetModel> Ficed { get; set; }
        public List<LstFixedAssetModelViewModel> LstFixedmode { get; set; }
        public static RevenueFixedAssetViewModel EntityToModels(RevenueFixedAssetitem dbmodel)
        {
            return dbmodel == null
                ? null
                : new RevenueFixedAssetViewModel
                {
                    Id = dbmodel.Id,
                    Accounttitle = dbmodel.Accounttitle,
                    Code = dbmodel.Code,
                    Balance = dbmodel.Balance,
                    AmountExpendedcurrentYear = dbmodel.AmountExpendedcurrentYear,

                };
        }
    }

    public class FixedAssetModel
    {
        public long Id { get; set; }
        public long RevEpenditureId { get; set; }
        public string Code { get; set; }
        public string Accounttitle { get; set; }
        public decimal ApproveBudget { get; set; }
        public decimal AmountExpendedcurrentYear { get; set; }
        public decimal CumulativeAmt { get; set; }
        public decimal TotalAmtexpendedtilldate { get; set; }

        public decimal Balance { get; set; }
        [Required]
        public string CostCentre { get; set; }
        [Required]

        public string MDA { get; set; }
        public string ReportingYear { get; set; }
        [Required]
        public string ReportingPeriod { get; set; }
        public static FixedAssetModel EntityToModels3(RevenueFixedAssetHead dbmodel)
        {
            return dbmodel == null
                ? null
                : new FixedAssetModel
                {
                    Id = dbmodel.Id,
                    MDA = dbmodel.MDA,
                    ReportingYear = dbmodel.ReportingYear,
                    ReportingPeriod = dbmodel.ReportingPeriod,
                    CostCentre = dbmodel.CostCentre,

                };
        }
    }

    public class LstFixedAssetModelViewModel
    {
        public long Id { get; set; }
        public long RevEpenditureId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Accounttitle { get; set; }
        public decimal ApproveBudget { get; set; }
        public decimal AmountExpendedcurrentYear { get; set; }
        public decimal CumulativeAmt { get; set; }
        public decimal TotalAmtexpendedtilldate { get; set; }

        public decimal Balance { get; set; }
        [Required]
        public string CostCentre { get; set; }
        [Required]

        public string MDA { get; set; }
        public string ReportingYear { get; set; }
        [Required]
        public string ReportingPeriod { get; set; }
        public static LstFixedAssetModelViewModel EntityToModels(RevenueFixedAssetitem dbmodel)
        {
            return dbmodel == null
                ? null
                : new LstFixedAssetModelViewModel
                {
                    Id = dbmodel.Id,
                    Accounttitle = dbmodel.Accounttitle,
                    Code = dbmodel.Code,
                    Description = dbmodel.Description,
                    Balance = dbmodel.Balance,
                    AmountExpendedcurrentYear = dbmodel.AmountExpendedcurrentYear,
                    ApproveBudget = dbmodel.ApproveBudget,
                    CumulativeAmt = dbmodel.CumulativeAmt,
                    TotalAmtexpendedtilldate = dbmodel.TotalAmtexpendedtilldate

                };


        }

        public static LstFixedAssetModelViewModel EntityToModels1(Revenueitemlog dbmodel)
        {
            return dbmodel == null
                ? null
                : new LstFixedAssetModelViewModel
                {
                    Id = dbmodel.Id,
                    Accounttitle = "",
                    Code = "",
                    Description = "",
                    Balance = 0M,
                    AmountExpendedcurrentYear = 0M,
                    ApproveBudget = 0M,
                    CumulativeAmt = 0M,
                    TotalAmtexpendedtilldate = 0M

                };
        }
    }
}
