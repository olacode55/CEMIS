using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEMIS.Business.Repository
{
    public class RevenueEstimateRepository : IRevenueEstimate
    {
        private readonly IRepository<RevenueestimateItem> _revenuestimateItem;
        private readonly IRepository<RevenueEstimateHead> _revenueEstimateHead;
        private readonly IRepository<RevenueEstimateTypeCode> _revenueEstimateTypeCode;

        public RevenueEstimateRepository(IRepository<RevenueestimateItem> revenuestimateItem,
            IRepository<RevenueEstimateHead> revenueEstimateHead, IRepository<RevenueEstimateTypeCode> revenueEstimateTypeCode)
        {
            _revenuestimateItem = revenuestimateItem;
            _revenueEstimateHead = revenueEstimateHead;
            _revenueEstimateTypeCode = revenueEstimateTypeCode;
        }


        public List<RevenuestimateViewModel> GetRevenuestimate()
        {
            return _revenueEstimateHead.All()
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .Select(x => new RevenuestimateViewModel
                {
                    Id = x.Id,
                    MDA = x.MDA,
                    LodgementAccNo = x.LodgementAccNo,
                    RetentionAccNo = x.RetentionAccNo,
                    Month = x.ReportingMonth,
                    Year = x.ReportingYear

                }).ToList();
        }

        public RevenueEstimateItemViewModel GetRevenueEstimateItem(long Id)
        {
            var data = new RevenueEstimateItemViewModel();
            try
            {

                var RevHead = _revenueEstimateHead.All()
                    .Where(x => x.Id == Id).FirstOrDefault();
                if (RevHead == null)
                {
                    RevHead = new RevenueEstimateHead();
                }
                var revItem = _revenuestimateItem.All().Where(x => x.IsActive == true && x.IsDeleted == false && x.RevenueHeadId == Id).ToList();
                var revTypeCode = _revenueEstimateTypeCode.All().Where(x => x.IsActive == true && x.IsDeleted == false).ToList();

                var query = (from rtc in revTypeCode
                             join ri in revItem on rtc.Id equals ri.RevenueTypeId into rei
                             from RevEstItm in rei.DefaultIfEmpty()
                             select new RevenueTypeViewModel
                             {
                                 Id = rtc.Id,
                                 RevenueType = rtc.Code + " - " + rtc.Name,
                                 MonthlyTarget = RevEstItm?.MonthlyTargetAmt ?? 0M,
                                 MonthlyAmtCollected = RevEstItm?.MonthlyAmtCollected ?? 0M,
                                 AmmountCollectedToDate = RevEstItm?.MonthlyAmountCollectedToDate ?? 0M,
                                 MonthlyAmtPaidIntoConsol = RevEstItm?.MonthlyAmtPayIntoConsol ?? 0M,
                                 PaidIntoConsol = RevEstItm?.PaidIntoConsol ?? 0M,
                                 MonthlyAmountRetained = RevEstItm?.MonthlyAmtRetained ?? 0M,
                                 CumAmountRetained = RevEstItm?.CumulativeAmtRetained ?? 0M,
                                 Variance = RevEstItm?.Variance ?? 0M

                             }).ToList();

                data.Id = RevHead.Id;
                data.MDA = RevHead.MDA;
                data.CostCentre = RevHead.CostCentre;
                data.LodgementAccNo = RevHead.LodgementAccNo;
                data.RetentionAccNo = RevHead.RetentionAccNo;
                data.ReportingMonth = RevHead.ReportingMonth;
                data.ReportingYear = RevHead.ReportingYear;
                data.RevenueItems = query;

            }
            catch (Exception ex)
            {

                throw;
            }

            return data;

        }

        public bool AddRevenueEstimateItem(RevenueEstimateItemViewModel model, out string message)
        {
            try
            {
                var revenueEstimateHead = new RevenueEstimateHead();



                revenueEstimateHead.CostCentre = model.CostCentre;
                revenueEstimateHead.LodgementAccNo = model.LodgementAccNo;
                revenueEstimateHead.MDA = model.MDA;
                revenueEstimateHead.ReportingYear = model.ReportingYear;
                revenueEstimateHead.ReportingMonth = model.ReportingMonth;
                revenueEstimateHead.RetentionAccNo = model.RetentionAccNo;
                revenueEstimateHead.IsActive = true;
                revenueEstimateHead.IsDeleted = false;
                revenueEstimateHead.CreatedBy = 1;
                revenueEstimateHead.DateCreated = DateTime.Now;


                var rEHId = _revenueEstimateHead.Create(revenueEstimateHead);



                foreach (var item in model.RevenueItems)
                {
                    var revenueEstimateItems = new RevenueestimateItem();

                    revenueEstimateItems.MonthlyTargetAmt = item.MonthlyTarget;
                    revenueEstimateItems.MonthlyAmtCollected = item.MonthlyAmtCollected;
                    revenueEstimateItems.MonthlyAmountCollectedToDate = item.AmmountCollectedToDate;
                    revenueEstimateItems.MonthlyAmtPayIntoConsol = item.MonthlyAmtPaidIntoConsol;
                    revenueEstimateItems.PaidIntoConsol = item.PaidIntoConsol;
                    revenueEstimateItems.MonthlyAmtRetained = item.MonthlyAmountRetained;
                    revenueEstimateItems.CumulativeAmtRetained = item.CumAmountRetained;
                    revenueEstimateItems.Variance = item.Variance;
                    revenueEstimateItems.RevenueTypeId = item.Id;
                    revenueEstimateItems.RevenueHeadId = rEHId.Id;
                    revenueEstimateItems.IsActive = true;
                    revenueEstimateItems.IsDeleted = false;
                    revenueEstimateItems.CreatedBy = 1;
                    revenueEstimateItems.DateCreated = DateTime.Now;

                    _revenuestimateItem.Create(revenueEstimateItems);
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            message = "Saved Successfully";
            return true;
        }

        public bool UpdateRevenueEstimateItem(RevenueEstimateItemViewModel model, out string message)
        {

            try
            {
                var revenueEstimateHead = _revenueEstimateHead.All().Where(x => x.Id == model.Id).FirstOrDefault();

                var revenueEstimateItems = _revenuestimateItem.All().Where(x => x.RevenueHeadId == model.Id).ToList();

                revenueEstimateHead.CostCentre = model.CostCentre;
                revenueEstimateHead.LodgementAccNo = model.LodgementAccNo;
                revenueEstimateHead.MDA = model.MDA;
                revenueEstimateHead.ReportingYear = model.ReportingYear;
                revenueEstimateHead.ReportingMonth = model.ReportingMonth;
                revenueEstimateHead.RetentionAccNo = model.RetentionAccNo;
                revenueEstimateHead.UpdatedBy = 1;
                revenueEstimateHead.DateUpdated = DateTime.Now;


                var rEHId = _revenueEstimateHead.Update(revenueEstimateHead);

                if (revenueEstimateItems != null)
                {
                    //delete existing items

                    foreach (var deleteItem in revenueEstimateItems)
                    {

                        _revenuestimateItem.Delete(deleteItem);

                    }

                    //Create New items

                    foreach (var item in model.RevenueItems)
                    {
                        var revenueEstimateItem = new RevenueestimateItem();

                        revenueEstimateItem.MonthlyTargetAmt = item.MonthlyTarget;
                        revenueEstimateItem.MonthlyAmtCollected = item.MonthlyAmtCollected;
                        revenueEstimateItem.MonthlyAmountCollectedToDate = item.AmmountCollectedToDate;
                        revenueEstimateItem.MonthlyAmtPayIntoConsol = item.MonthlyAmtPaidIntoConsol;
                        revenueEstimateItem.PaidIntoConsol = item.PaidIntoConsol;
                        revenueEstimateItem.MonthlyAmtRetained = item.MonthlyAmountRetained;
                        revenueEstimateItem.CumulativeAmtRetained = item.CumAmountRetained;
                        revenueEstimateItem.Variance = item.Variance;
                        revenueEstimateItem.RevenueTypeId = item.Id;
                        revenueEstimateItem.RevenueHeadId = model.Id;
                        revenueEstimateItem.IsActive = true;
                        revenueEstimateItem.IsDeleted = false;
                        revenueEstimateItem.CreatedBy = 1;
                        revenueEstimateItem.DateCreated = DateTime.Now;


                        _revenuestimateItem.Create(revenueEstimateItem);
                    }

                }
                else
                {
                    foreach (var item in model.RevenueItems)
                    {
                        var revenueEstimateItem = new RevenueestimateItem();

                        revenueEstimateItem.MonthlyTargetAmt = item.MonthlyTarget;
                        revenueEstimateItem.MonthlyAmtCollected = item.MonthlyAmtCollected;
                        revenueEstimateItem.MonthlyAmountCollectedToDate = item.AmmountCollectedToDate;
                        revenueEstimateItem.MonthlyAmtPayIntoConsol = item.MonthlyAmtPaidIntoConsol;
                        revenueEstimateItem.PaidIntoConsol = item.PaidIntoConsol;
                        revenueEstimateItem.MonthlyAmtRetained = item.MonthlyAmountRetained;
                        revenueEstimateItem.CumulativeAmtRetained = item.CumAmountRetained;
                        revenueEstimateItem.Variance = item.Variance;
                        revenueEstimateItem.RevenueTypeId = item.Id;
                        revenueEstimateItem.RevenueHeadId = model.Id;
                        revenueEstimateItem.IsActive = true;
                        revenueEstimateItem.IsDeleted = false;
                        revenueEstimateItem.CreatedBy = 1;
                        revenueEstimateItem.DateCreated = DateTime.Now;


                        _revenuestimateItem.Create(revenueEstimateItem);
                    }
                }



            }
            catch (Exception ex)
            {

                throw;
            }

            message = "Updated Successfully";
            return true;
        }
    }

}
