using CEMIS.Business;
using CEMIS.Business.Interface;
using CEMIS.Business.Model;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CEMIS.Business.Model.RevenueExpenditureViewModel;

namespace CEMIS.Web.Controllers
{
    public class RevenueExpenditureController : BaseController
    {

        private readonly IRevenueExpenditure _revenueExpenditure;


        public RevenueExpenditureController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IRevenueExpenditure revenueExpenditure) : base(userManager, signInManager,
                               roleManager, configuration)
        {

            _revenueExpenditure = revenueExpenditure;


        }

        public IActionResult Index()
        {
            try
            {
                var data = _revenueExpenditure.GetRevenuecompensation();
                return View(data);

            }
            catch (Exception)
            {

                throw;
            }

        }
        
        public IActionResult AddRevenueExpenditure(long Id )
        {
            try
            {
                var data = _revenueExpenditure.GetRevenueCompensationItem(Id);
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

       


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRevenueExpenditure(RevenueExpenditureItemViewModel model)
        {
            bool status;
            string message;
            if (model.Id < 1)
            {
                status = _revenueExpenditure.AddRevenueCompensationItem(model, out message);
            }
            else
            {
                status = _revenueExpenditure.UpdateRevenueCompensationItem(model, out message);
            }

            return RedirectToAction("Index", "RevenueExpenditure");
     
        }
    }
}