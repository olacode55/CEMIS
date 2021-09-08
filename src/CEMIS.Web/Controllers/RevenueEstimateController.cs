using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CEMIS.Web.Controllers
{
    public class RevenueEstimateController : BaseController
    {
        private readonly IRevenueEstimate _revenueEstimateRepository;

        public RevenueEstimateController(IRevenueEstimate revenueEstimateRepository, UserManager<User> userManager, IConfiguration configuration, SignInManager<User> signInManager,
            RoleManager<Role> roleManager) : base(userManager, signInManager, roleManager, configuration)
        {
            _revenueEstimateRepository = revenueEstimateRepository;
        }
        public IActionResult Index()
        {
            var data = _revenueEstimateRepository.GetRevenuestimate();

            return View(data);
        }

        public IActionResult AddRevItem(long Id)
        {
            var data = _revenueEstimateRepository.GetRevenueEstimateItem(Id);
            return View(data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRevItem(RevenueEstimateItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool status;
                string message;
                if (model.Id < 1)
                {
                    status = _revenueEstimateRepository.AddRevenueEstimateItem(model, out message);
                }
                else
                {
                    status = _revenueEstimateRepository.UpdateRevenueEstimateItem(model, out message);
                }
                return RedirectToAction("Index", "RevenueEstimate");
            }
            else
            {
                return View(model);
            }



        }
    }
}