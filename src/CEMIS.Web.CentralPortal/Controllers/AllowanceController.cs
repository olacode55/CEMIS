using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemis.Business.Central.Interface;
using Cemis.Business.Central.Repository;
using CEMIS.Data.Central;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.CentralPortal.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.CentralPortal.Controllers
{
    public class AllowanceController : BaseController
    {
        private readonly IAllowance _allowance;

        public AllowanceController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IHttpContextAccessor accessor , IActivityLog logActivityRepo, 
                               IActionContextAccessor actionContextAccessor, IAllowance allowance ) : base(userManager, signInManager,
                               roleManager, configuration , accessor , actionContextAccessor , logActivityRepo)
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
            ParentAllowanceViewBag();
            var allowances = _allowance.GetAllowanceById(Id);
            return PartialView("_Create", allowances);

        }
        public IActionResult Create()
        {
            ParentAllowanceViewBag();
            var model = new AllowanceViewModel();
            return PartialView("_Create", model);
        }
        [HttpPost]
        public ActionResult Create(AllowanceViewModel model)
        {
            var resp = new ResponseData<AllowanceViewModel>();
            if (model.Id > 0)
            {
              resp = _allowance.UpdateAllowance(model, true);
            }
            else
            {
               resp =  _allowance.CreateBasicAllowance(model, true);
            }


            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = resp.Message, Title = "Allowance", Type = resp.IsSuccessful ? NotificationsType.Success : NotificationsType.Danger });
                LogActivity(resp.Message, model).ConfigureAwait(true);

            return RedirectToAction("Index");
        }


        public void ParentAllowanceViewBag()
        {
            var parentAllowance = _allowance.GetParentAllowance().Select(x => new ModelViewBagDTO()
            {
                Id = x.Id,
                Value = x.Name

            }).ToList();

            ViewBag.ParentAllowance = new SelectList(parentAllowance, "Id", "Value");
        }

    }
}