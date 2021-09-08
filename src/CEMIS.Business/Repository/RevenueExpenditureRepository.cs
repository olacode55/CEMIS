using CEMIS.Business.Interface;
using CEMIS.Business.Model;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CEMIS.Business.Repository
{
    public class RevenueExpenditureRepository : IRevenueExpenditure
    { 
        private readonly IRepository<RevenueExpenditureItem> _revenuexpenditureItem;
        private readonly IRepository<RevenueExpenditureHead> _revenueexpenditureHead;
        private readonly IRepository<RevenueExpenditureTypeCode> _revenueExpenditureTypeCode;

        public RevenueExpenditureRepository(IRepository<RevenueExpenditureItem> revenuexpenditureItem,
            IRepository<RevenueExpenditureHead> revenueexpenditureHead, IRepository<RevenueExpenditureTypeCode> revenueExpenditureTypeCode)
        {
            _revenuexpenditureItem = revenuexpenditureItem;
            _revenueexpenditureHead = revenueexpenditureHead;
            _revenueExpenditureTypeCode = revenueExpenditureTypeCode;
        }

        public bool AddRevenueCompensationItem(RevenueExpenditureItemViewModel model, out string message)
        {
           
                try
            { 
            var revenueCompensationHead = new RevenueExpenditureHead();

         //   var revenueCompensationItems = new RevenueExpenditureItem();

                revenueCompensationHead.CostCentre = model.CostCentre;
                revenueCompensationHead.MDA = model.MDA;
                revenueCompensationHead.ReportingPeriod = model.ReportingMonth;
                revenueCompensationHead.ReturnOn = model.ReturnOn;
                revenueCompensationHead.FundType = model.FundType;

                    revenueCompensationHead.IsActive = true;
                    revenueCompensationHead.IsDeleted = false;
                    revenueCompensationHead.CreatedBy = 1;
                    revenueCompensationHead.DateCreated = DateTime.Now;


            var rEHId = _revenueexpenditureHead.Create(revenueCompensationHead);



            foreach (var item in model.RevenueExpenditureItems)
            {
               var revenueCompensationItems = new RevenueExpenditureItem();

                    revenueCompensationItems.WageandSalary = item.WageandSalary;
                    revenueCompensationItems.ApproveBudget = item.Approvebudget;
                    revenueCompensationItems.AmountExpendedcurrentMonth = item.Amountexpendedcurrentmonth;
                    revenueCompensationItems.CumulativeAmt = item.Cumulativeamt;
                    revenueCompensationItems.TotalAmtexpendedtilldate = item.Totalexpendituretodate;
                    revenueCompensationItems.Balance = item.Balance;
                    revenueCompensationItems.RevEpenditureId = item.Id;
                    revenueCompensationItems.RevenueCompensationHeadId = rEHId.Id;
                    revenueCompensationItems.IsActive = true;
                    revenueCompensationItems.IsDeleted = false;
                    revenueCompensationItems.CreatedBy = 1;
                    revenueCompensationItems.DateCreated = DateTime.Now;

                _revenuexpenditureItem.Create(revenueCompensationItems);
            }
                  


                }
            catch (Exception ex)
            {

                throw;
            }
            

            message = "";
            return true;
        }

        public List<RevenuExpenditureViewModel> GetRevenuecompensation()
        {
            return _revenueexpenditureHead.All()
               .Where(x => x.IsActive == true && x.IsDeleted == false)
               .Select(x => new RevenuExpenditureViewModel
               {
                   Id = x.Id,
                   MDA = x.MDA,
                   CostCentre = x.CostCentre,
                   ReturnOn = x.ReturnOn,
                   Month =  x.ReportingPeriod,
                   FundType = x.FundType

               }).ToList();
        }

        public  RevenueExpenditureItemViewModel GetRevenueCompensationItem(long Id)
        {
            var data = new RevenueExpenditureItemViewModel();
            try
            {

                var RevHead = _revenueexpenditureHead.All()
                    .Where(x => x.Id == Id).FirstOrDefault();
                if (RevHead == null)
                {
                    RevHead = new RevenueExpenditureHead();
                }
                var revItem = _revenuexpenditureItem.All().Where(x => x.IsActive == true && x.IsDeleted == false && x.RevenueCompensationHeadId == Id).ToList();
                var revTypeCode = _revenueExpenditureTypeCode.All().Where(x => x.IsActive == true && x.IsDeleted == false).ToList();

                var query = (from rtc in revTypeCode
                             join ri in revItem on rtc.Id equals ri.RevEpenditureId into rei
                             from RevEstItm in rei.DefaultIfEmpty()
                             select new RevenueExpenditureTypeViewModel
                             {
                                 Id = rtc.Id,
                                 RevenueExpenditureType = rtc.Code + " - " + rtc.Name,//rtc.Code + "-" + rtc.Name,
                                 WageandSalary = RevEstItm?.WageandSalary ?? 0,
                                 Approvebudget = RevEstItm?.ApproveBudget ?? 0,
                                 Amountexpendedcurrentmonth = RevEstItm?.AmountExpendedcurrentMonth ?? 0,
                                 Cumulativeamt = RevEstItm?.CumulativeAmt ?? 0,
                                 Totalexpendituretodate = RevEstItm?.TotalAmtexpendedtilldate ?? 0,
                                 Balance = RevEstItm?.Balance ?? 0,
                                 

                             }).ToList();

                data.Id = RevHead.Id;
                data.MDA = RevHead.MDA;
                data.CostCentre = RevHead.CostCentre;
                data.ReportingMonth = RevHead.ReportingPeriod;
                data.ReturnOn = RevHead.ReturnOn;
                data.FundType = RevHead.FundType;
                //data.ReportingYear = RevHead.ReportingYear;
                data.RevenueExpenditureItems = query;

            }
            catch (Exception ex)
            {

                throw;
            }

            return data;

        }

        public bool UpdateRevenueCompensationItem(RevenueExpenditureItemViewModel model, out string message)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }

            message = "";
            return true;
        }
    }

}