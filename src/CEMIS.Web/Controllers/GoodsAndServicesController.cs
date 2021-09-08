using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CEMIS.Web.Controllers
{
    public class GoodsAndServicesController : BaseController
    {
        
        private readonly IGoodsAndServices _goodsAndServicesRepository;
        private IRepository<GoodsAndServicesSettings> _goodsAndServicesSettingRepo;
        private IRepository<RevenueGoodandServiceHead> _goodsAndServicesHeadRepo;
        private IRepository<RevenueGoodsandServiceitem> _goodsAndServicesItemRepo;

        public GoodsAndServicesController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IGoodsAndServices goodsAndServicesRepository, IRepository<GoodsAndServicesSettings> goodsAndServicesSettingRepo,
                                          IRepository<RevenueGoodandServiceHead> goodsAndServicesHeadRepo, IRepository<RevenueGoodsandServiceitem> goodsAndServicesItemRepo) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _goodsAndServicesRepository = goodsAndServicesRepository;
            _goodsAndServicesSettingRepo = goodsAndServicesSettingRepo;
            _goodsAndServicesHeadRepo = goodsAndServicesHeadRepo;
            _goodsAndServicesItemRepo = goodsAndServicesItemRepo;
        }
        public IActionResult Index()
        {
           var goodsAndServices = _goodsAndServicesRepository.GetGoodsAndServices();


            return View(goodsAndServices);
        }

        public IActionResult Create()
        {
            var create = _goodsAndServicesRepository.CreateGoodsAndServices();
            return View(create);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection formCollection)
        {
            var subCatCount =  Convert.ToInt32(formCollection["subCatCount"]);
            using (var transaction = new TransactionScope())
            {
                var revenueGoodsAndServices = new RevenueGoodandServiceHead
                {
                    PeriodMonth = (Month)Convert.ToInt32(formCollection["periodMonth"]),
                    DateCreated = DateTime.Now,
                    CreatedBy = 0,
                    MDA = formCollection["MDA"],
                    PeriodYear = Convert.ToInt32(formCollection["periodYear"]),
                    FundType = formCollection["FundType"],
                    IsActive = true,
                    IsDeleted = false,
                    ReturnsOn = formCollection["ReturnOn"]
                };

                _goodsAndServicesHeadRepo.Create(revenueGoodsAndServices);

                var revenueGoodsandServiceitemList = new List<RevenueGoodsandServiceitem>();


                for (int i = 0; i < subCatCount; i++)
                {
                    var settingID = Convert.ToInt32(formCollection["ItemID" + i.ToString()]);
                    var setting = _goodsAndServicesSettingRepo.All().Include(x => x.Items).FirstOrDefault(x => x.Id == settingID);

                    if (setting.Items != null)
                    {
                        foreach (var item in setting.Items)
                        {
                            var revenueGoodsandServiceitem = new RevenueGoodsandServiceitem();
                            revenueGoodsandServiceitem.RevenueGoodandServiceHeadID = revenueGoodsAndServices.Id;
                            revenueGoodsandServiceitem.SettingsId = settingID;
                            revenueGoodsandServiceitem.SubSettingsId = item.Id;
                            revenueGoodsandServiceitem.ApproveBudget = formCollection[ApplicationConstant.approvedBuget + item.Id.ToString()] == "" ? 0 : Convert.ToDecimal(formCollection[ApplicationConstant.approvedBuget + item.Id.ToString()]);
                            revenueGoodsandServiceitem.AmountExpendedcurrentYear = formCollection[ApplicationConstant.amountExpended + item.Id.ToString()] == "" ? 0 : Convert.ToDecimal(formCollection[ApplicationConstant.amountExpended + item.Id.ToString()]);
                            revenueGoodsandServiceitem.CumulativeAmt = formCollection[ApplicationConstant.cummulativeAmt + item.Id.ToString()] == "" ? 0 : Convert.ToDecimal(formCollection[ApplicationConstant.cummulativeAmt + item.Id.ToString()]);
                            revenueGoodsandServiceitem.TotalAmtexpendedtilldate = revenueGoodsandServiceitem.AmountExpendedcurrentYear + revenueGoodsandServiceitem.CumulativeAmt; //Convert.ToDecimal(formCollection[ApplicationConstant.totalAmt + item.Id.ToString()]);
                            revenueGoodsandServiceitem.Balance = revenueGoodsandServiceitem.ApproveBudget - revenueGoodsandServiceitem.TotalAmtexpendedtilldate;//Convert.ToDecimal(formCollection[ApplicationConstant.balance + item.Id.ToString()]);
                            //revenueGoodsandServiceitem.ApproveBudget = Convert.ToDecimal(formCollection[ApplicationConstant.approvedBuget + item.Id.ToString()]);
                            revenueGoodsandServiceitem.IsActive = true;
                            revenueGoodsandServiceitem.IsDeleted = false;
                            revenueGoodsandServiceitem.DateCreated = DateTime.Now;
                            revenueGoodsandServiceitem.CreatedBy = 0;
                            revenueGoodsandServiceitem.Description = item.Description;

                            //revenueGoodsandServiceitemList.Add(revenueGoodsandServiceitem);
                            _goodsAndServicesItemRepo.Create(revenueGoodsandServiceitem);
                        }

                        //_goodsAndServicesItemRepo.Create(revenueGoodsandServiceitemList);
                    }


                }
                transaction.Complete();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(long Id)
        {
            var goodsAndServices = _goodsAndServicesRepository.GetGoodsAndServicesById(Id);
            return View(goodsAndServices);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IFormCollection formCollection)
        {
            var subCatCount = Convert.ToInt32(formCollection["subCatCount"]); 
            var headerID = Convert.ToInt64(formCollection["GoodsAndServicesHeaderID"]);

            var goodsAndServicesHeader = _goodsAndServicesHeadRepo.All().FirstOrDefault(x => x.Id == headerID);
            using (var transaction = new TransactionScope())
            {
                if (goodsAndServicesHeader != null) {
                    goodsAndServicesHeader.PeriodMonth = (Month)Convert.ToInt32(formCollection["periodMonth"]);
                    goodsAndServicesHeader.MDA = formCollection["MDA"];
                    goodsAndServicesHeader.PeriodYear = Convert.ToInt32(formCollection["periodYear"]);
                    goodsAndServicesHeader.FundType = formCollection["FundType"];
                    goodsAndServicesHeader.ReturnsOn = formCollection["ReturnOn"];

                    _goodsAndServicesHeadRepo.Update(goodsAndServicesHeader);
                }


                // _goodsAndServicesItemRepo.Create(revenueGoodsandServiceitem);

                var revenueGoodsandServiceitemList = new List<RevenueGoodsandServiceitem>();
                for (int i = 0; i < subCatCount; i++)
                {
                    var settingID = Convert.ToInt32(formCollection["ItemID" + i.ToString()]);
                    var setting = _goodsAndServicesItemRepo.All().Where(x => x.RevenueGoodandServiceHeadID == headerID).ToList();
                    var existingGoodsAndServItems = _goodsAndServicesItemRepo.All().Where(x => x.SettingsId == settingID).ToList();
                    if (setting != null)
                    {
                        foreach (var item in setting)
                        {
                            var revenueGoodsandServiceitem = new RevenueGoodsandServiceitem();
                            revenueGoodsandServiceitem.RevenueGoodandServiceHeadID = goodsAndServicesHeader.Id;
                            revenueGoodsandServiceitem.SettingsId = settingID;
                            revenueGoodsandServiceitem.SubSettingsId = item.SubSettingsId;
                            revenueGoodsandServiceitem.ApproveBudget = formCollection[ApplicationConstant.approvedBuget + item.Id.ToString()] == "" ? 0 : Convert.ToDecimal(formCollection[ApplicationConstant.approvedBuget + item.Id.ToString()]);
                            revenueGoodsandServiceitem.AmountExpendedcurrentYear = formCollection[ApplicationConstant.amountExpended + item.Id.ToString()] == "" ? 0 : Convert.ToDecimal(formCollection[ApplicationConstant.amountExpended + item.Id.ToString()]);
                            revenueGoodsandServiceitem.CumulativeAmt = formCollection[ApplicationConstant.cummulativeAmt + item.Id.ToString()] == "" ? 0 : Convert.ToDecimal(formCollection[ApplicationConstant.cummulativeAmt + item.Id.ToString()]);
                            revenueGoodsandServiceitem.TotalAmtexpendedtilldate = revenueGoodsandServiceitem.AmountExpendedcurrentYear + revenueGoodsandServiceitem.CumulativeAmt; //Convert.ToDecimal(formCollection[ApplicationConstant.totalAmt + item.Id.ToString()]);
                            revenueGoodsandServiceitem.Balance = revenueGoodsandServiceitem.ApproveBudget - revenueGoodsandServiceitem.TotalAmtexpendedtilldate;//Convert.ToDecimal(formCollection[ApplicationConstant.balance + item.Id.ToString()]);

                            //revenueGoodsandServiceitem.ApproveBudget = Convert.ToDecimal(formCollection[ApplicationConstant.approvedBuget + item.Id.ToString()]);
                            //revenueGoodsandServiceitem.AmountExpendedcurrentYear = Convert.ToDecimal(formCollection[ApplicationConstant.amountExpended + item.Id.ToString()]);
                            //revenueGoodsandServiceitem.CumulativeAmt = Convert.ToDecimal(formCollection[ApplicationConstant.cummulativeAmt + item.Id.ToString()]);
                            //revenueGoodsandServiceitem.TotalAmtexpendedtilldate = Convert.ToDecimal(formCollection[ApplicationConstant.totalAmt + item.Id.ToString()]);
                            //revenueGoodsandServiceitem.Balance = Convert.ToDecimal(formCollection[ApplicationConstant.balance + item.Id.ToString()]);                            revenueGoodsandServiceitem.IsActive = true;
                            revenueGoodsandServiceitem.IsDeleted = false;
                            revenueGoodsandServiceitem.DateCreated = DateTime.Now;
                            revenueGoodsandServiceitem.CreatedBy = 0;
                            revenueGoodsandServiceitem.Description = item.Description;

                            revenueGoodsandServiceitemList.Add(revenueGoodsandServiceitem);
                            //_goodsAndServicesItemRepo.Create(revenueGoodsandServiceitem);
                        }
                        _goodsAndServicesItemRepo.Delete(existingGoodsAndServItems);
                        _goodsAndServicesItemRepo.Create(revenueGoodsandServiceitemList);
                    }


                }
                transaction.Complete();
            }
            return RedirectToAction("index");
        }
        }
}