using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEMIS.Business.Repository
{
    public class GoodsAndServicesRepository : IGoodsAndServices
    {
        private IRepository<RevenueGoodandServiceHead> _goodsAndServicesRepo;
        private IRepository<RevenueGoodsandServiceitem> _goodsAndServicesItemRepo;
        private IRepository<GoodsAndServicesSettings> _goodsAndServicesSettingRepo;
        private IRepository<GoodsAndServicesSettingSubItems> _goodsAndServicesSubSettingsRepo;
        private IConfiguration _configration;

        public GoodsAndServicesRepository(IRepository<RevenueGoodandServiceHead> goodsAndServicesRepo, IRepository<RevenueGoodsandServiceitem> goodsAndServicesItemRepo,
                                          IRepository<GoodsAndServicesSettings> goodsAndServicesSettingRepo, IRepository<GoodsAndServicesSettingSubItems> goodsAndServicesSubSettingsRepo, IConfiguration configration)
        {
            _goodsAndServicesRepo = goodsAndServicesRepo;
            _goodsAndServicesItemRepo = goodsAndServicesItemRepo;
            _goodsAndServicesSettingRepo = goodsAndServicesSettingRepo;
            _goodsAndServicesSubSettingsRepo = goodsAndServicesSubSettingsRepo;
            _configration = configration;
        }

        public List<RevenueGoodandServiceHead> GetGoodsAndServices()
        {
            var items = _goodsAndServicesRepo.All().Where(x => x.IsDeleted == false && x.IsActive == true).ToList();
            return items;
        }

        public List<GoodsAndServicesSettings> CreateGoodsAndServices()
        {
            var settings = _goodsAndServicesSettingRepo.All().Include(x=>x.Items).ToList();
            return settings;
        }

        public GoodsAndServicesHeaderViewModel GetGoodsAndServicesById(long Id)
        {
            var goodsAndServicesHeaderVM = new GoodsAndServicesHeaderViewModel();
            var goodsAndServicesDetail =_goodsAndServicesRepo.All().Include(x => x.RevenueGoodsandServiceitem).FirstOrDefault(x => x.Id == Id);
            var goodsAndServiceSettings = _goodsAndServicesSettingRepo.All().ToList();
            if (goodsAndServicesDetail != null)
            {
                goodsAndServicesHeaderVM.Id = goodsAndServicesDetail.Id;
                goodsAndServicesHeaderVM.MDA = goodsAndServicesDetail.MDA;
                goodsAndServicesHeaderVM.PeriodMonth = goodsAndServicesDetail.PeriodMonth;
                goodsAndServicesHeaderVM.PeriodYear = goodsAndServicesDetail.PeriodYear;
                goodsAndServicesHeaderVM.ReturnsOn = goodsAndServicesDetail.ReturnsOn;
                goodsAndServicesHeaderVM.FundType = goodsAndServicesDetail.FundType;
                goodsAndServicesHeaderVM.GoodsAndServicesItemsViewModel = goodsAndServicesDetail.RevenueGoodsandServiceitem.Select(x => new GoodsAndServicesItemsViewModel
                {
                    Id = x.Id,
                    Balance = x.Balance,
                    SettingsId = x.SettingsId,
                    Description = x.Description,
                    ApproveBudget = x.ApproveBudget,
                    CumulativeAmt = x.CumulativeAmt,
                    SubSettingsId = x.SubSettingsId,
                    AmountExpendedcurrentYear = x.AmountExpendedcurrentYear,
                    RevenueGoodandServiceHeadID = x.RevenueGoodandServiceHeadID,
                    TotalAmtexpendedtilldate = x.TotalAmtexpendedtilldate
                }).ToList();

                goodsAndServicesHeaderVM.GoodsAndServicesSettingsViewModel = goodsAndServiceSettings.Select(x => new GoodsAndServicesSettingsViewModel
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description,
                    AccountTitle = x.AccountTitle,
                    HasSubCategory = x.HasSubCategory
                }).ToList();

            }
            return goodsAndServicesHeaderVM;
        } 

        public GoodsAndServicesHeaderViewModel GetGoodAndServiceDetails(long Id)
        {
            var goodsAndServiceVM = new GoodsAndServicesHeaderViewModel();
        var goodsAndService = _goodsAndServicesRepo.All().FirstOrDefault(x => x.Id == Id);
            if (goodsAndService != null)
            {
                var goodItems = _goodsAndServicesItemRepo.All().Where(x => x.RevenueGoodandServiceHeadID == goodsAndService.Id).Select(x => new GoodsAndServicesHeaderViewModel
                {

                }).ToList();



    }
            return goodsAndServiceVM;


        }
public void AddGoodAndServices(GoodsAndServicesHeaderViewModel item)
{

}




    }
}
