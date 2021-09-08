using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Data.ViewModel;
using CEMIS.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using CEMIS.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Headers;
using CEMIS.Utility.Util;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CEMIS.Web.Controllers
{

    [Authorize]
    public class AllowanceController : BaseController
    {
       
        private readonly IAllowance _allowance;

        public AllowanceController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration,  IAllowance allowance) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _allowance = allowance;
        }
        public IActionResult Index()
        {
            var allowances = _allowance.GetAllAllowance();
            return View(allowances);
        }
        public IActionResult Edit(long Id)
        {
            var allowances = _allowance.GetAllowanceById(Id);
            return PartialView("_Create", allowances);

        }
        public IActionResult Create()
        {
            var model = new AllowanceViewModel();
            return PartialView("_Create", model);
        }
        [HttpPost]
        public ActionResult Create(AllowanceViewModel model)
        {
           
            if (model.Id > 0)
            {
                _allowance.UpdateAllowance(model, true);
            }
            else
            {
                _allowance.CreateBasicAllowance(model, true);
            }
          
            return RedirectToAction("Index");
        }
     

        //public IActionResult Delete(long Id)
        //{
        //    _staffRepository.DeleteTeachingStaff(Id , true);
        //    return RedirectToAction("Index");
        //}
       
        }
    }
