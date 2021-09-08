using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business;
using CEMIS.Data;
using CEMIS.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CEMIS.Business.Model;
using Newtonsoft.Json;
using CEMIS.Web.Utilities;
using CEMIS.Business.Interface;


namespace CEMIS.Web.Controllers
{
    public class RevenueFixedAssetController : BaseController
    {
        private readonly ISession _sessionRepo;
        private readonly IRevenueFixedAsset _RevFixedRepo;
        private readonly IRepositoryUtility _Irepo;


        public RevenueFixedAssetController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, ISession SessionRepo, IRevenueFixedAsset RevFixedRepo, IRepositoryUtility Irepo, IMainAdminRole mainAdminRole) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _sessionRepo = SessionRepo;
            _RevFixedRepo = RevFixedRepo;
            _Irepo = Irepo;

        }
        public IActionResult Index()
        {
            try
            {


                return View("Index", new RevenueFixedAssetViewModel
                {
                    LstFixedmode = _RevFixedRepo.GetAllFixedAssetitems().Select(LstFixedAssetModelViewModel.EntityToModels).ToList()


                });


            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        public IActionResult AddRevenueFixedAsset()
        {
            try
            {
                return View("AddRevenueFixedAsset", new RevenueFixedAssetViewModel
                {
                    LstFixedmode = _RevFixedRepo.GetAllFixedAssetitemslog().Select(LstFixedAssetModelViewModel.EntityToModels1).ToList()
                });


            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult AddRevenueFixedAsset(RevenueFixedAssetViewModel model)
        {
            try
            {
                foreach (var items in model.LstFixedmode)
                {

                    RevenueFixedAssetHead mod = new RevenueFixedAssetHead();

                    RevenueFixedAssetitem _itm = new RevenueFixedAssetitem();
                    mod.CostCentre = model.CostCentre;
                    mod.MDA = model.MDA;
                    mod.ReportingPeriod = model.ReportingYear;
                    mod.ReportingPeriod = model.ReportingPeriod;
                    _RevFixedRepo.AddFixedAssetHead(mod);
                    long repoid = mod.Id;
                    _itm.Accounttitle = items.Accounttitle;
                    _itm.AmountExpendedcurrentYear = items.AmountExpendedcurrentYear;
                    _itm.Description = items.Description;
                    _itm.ApproveBudget = items.ApproveBudget;
                    _itm.Balance = items.Balance;
                    _itm.Code = items.Code;
                    _itm.CumulativeAmt = items.CumulativeAmt;
                    _itm.RevEpenditureId = repoid;
                    _itm.TotalAmtexpendedtilldate = items.TotalAmtexpendedtilldate;
                    _RevFixedRepo.AddFixedAssetitems(_itm);

                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Asset Added Sucessfully!", Title = "Create", Type = NotificationsType.success });
                    return View("Index", new RevenueFixedAssetViewModel
                    {
                        LstFixedmode = _RevFixedRepo.GetAllFixedAssetitems().Select(LstFixedAssetModelViewModel.EntityToModels).ToList()
                    });
                }

                return null;

            }
            catch (Exception)
            {

                throw;
            }

        }
        public IActionResult EditView(long id)
        {
            try
            {
                var getitemid = _RevFixedRepo.GetRevenuitembyId(id);
                //var getitemids = _RevFixedRepo.GetRevenueFixedAssetById(2);
                //RevenueFixedAssetViewModel mod = new RevenueFixedAssetViewModel
                //{
                //    MDA = getitemids.MDA
                //};
                RevenueFixedAssetViewModel model = new RevenueFixedAssetViewModel()
                {


                    LstFixedmode = _RevFixedRepo.GetAllFixedAssetitemslog().Select(LstFixedAssetModelViewModel.EntityToModels1).ToList()

                };

                foreach (var itm in model.LstFixedmode.Take(1))
                {
                    itm.Accounttitle = getitemid.Accounttitle;
                    itm.Code = getitemid.Code;
                    itm.Description = getitemid.Description;
                    itm.ApproveBudget = getitemid.ApproveBudget;
                    itm.TotalAmtexpendedtilldate = getitemid.TotalAmtexpendedtilldate;
                    itm.AmountExpendedcurrentYear = getitemid.AmountExpendedcurrentYear;
                    itm.CumulativeAmt = getitemid.CumulativeAmt;
                    itm.Balance = getitemid.Balance;
                };

                return View("EditView", model);


            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public IActionResult EditView(long id, RevenueFixedAssetViewModel model)
        {
            try
            {

                var getitemid = _RevFixedRepo.GetRevenuitembyId(id);

                foreach (var items in model.LstFixedmode)
                {
                    RevenueFixedAssetitem _itm = new RevenueFixedAssetitem();
                    _itm.Accounttitle = items.Accounttitle;
                    _itm.AmountExpendedcurrentYear = items.AmountExpendedcurrentYear;
                    _itm.ApproveBudget = items.ApproveBudget;
                    _itm.Balance = items.Balance;
                    _itm.Description = items.Description;
                    _itm.Code = items.Code;
                    _itm.CumulativeAmt = items.CumulativeAmt;
                    _itm.RevEpenditureId = items.RevEpenditureId;
                    _itm.TotalAmtexpendedtilldate = items.TotalAmtexpendedtilldate;
                    _RevFixedRepo.UpdateFixedItemHead(_itm, id);
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Asset updated Sucessfully!", Title = "Create", Type = NotificationsType.success });
                    return View("Index", new RevenueFixedAssetViewModel
                    {
                        LstFixedmode = _RevFixedRepo.GetAllFixedAssetitems().Select(LstFixedAssetModelViewModel.EntityToModels).ToList()
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

    }

}


