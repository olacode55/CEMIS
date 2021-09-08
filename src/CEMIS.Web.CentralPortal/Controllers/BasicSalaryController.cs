using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemis.Business.Central.Interface;
using Cemis.Data.Central.Entities;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.CentralPortal.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.CentralPortal.Controllers
{
   
    public class BasicSalaryController : BaseController
    {
        private readonly IBasicSalary _basicSalary;
        public BasicSalaryController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IHttpContextAccessor accessor, IActivityLog logActivityRepo, 
                               IActionContextAccessor actionContextAccessor, IBasicSalary basicSalary) : base(userManager, signInManager,
                               roleManager, configuration, accessor, actionContextAccessor, logActivityRepo)
        {
           
            //_gradeLevel = gradeLevel;
            _basicSalary = basicSalary;

        }
        public IActionResult Index()
        {
            
            var basicSalaries = _basicSalary.GetAllBasicSalary();
            return View(basicSalaries);
        }

        [HttpGet]
        public IActionResult GetBasicSalary(int gradelevel, int step)
        {
            var basicSalary = _basicSalary.GetBasicSalarysById(gradelevel, step).Amount;
            //category

            return new JsonResult(basicSalary);
        }

        //[HttpGet]
        //public IActionResult FindStaffStep(int Level)
        //{
        //    //var rank = _gradeLevel.GetStep(Level);

        //    //category

        //   // return new JsonResult(rank);
        //}

        public IActionResult Edit(long Id)
        {
            //ViewBag.Session = _academicSession.GetAll();
            var basicSalary = _basicSalary.GetBasicSalaryById(Id);


            return PartialView("_Create", basicSalary);

        }
        public IActionResult Create()
        {
            var model = new BasicSalaryViewModel();
           // ViewBag.GradeLevel = _gradeLevel.GetAllGradeLevel();

            return PartialView("_Create", model);
        }
        [HttpPost]
        public ActionResult Create(BasicSalaryViewModel model)
        {
            var resp = new ResponseData<BasicSalaryViewModel>();
            if (model.Id > 0)
            {
               resp = _basicSalary.UpdateBasicSalary(model, CurrentUser);
            }
            else
            {
                resp =_basicSalary.CreateBasicSalary(model, CurrentUser);
            }

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = resp.Message, Title = "Basic Salary", Type = resp.IsSuccessful ? NotificationsType.Success :  NotificationsType.Danger });
                LogActivity(resp.Message, model).ConfigureAwait(true);

            return RedirectToAction("Index");
        }
        public IActionResult Manage(long Id)
        {

            //ViewBag.GradeLevel = _gradeLevel.GetAllGradeLevel();
            var basic = _basicSalary.GetBasicSalaryById(Id);
            BasicSalaryViewModel basicSalary = new BasicSalaryViewModel
            {
                Id = basic.Id,
                gradeLevel = basic.gradeLevel,
                step = basic.step,
                amount = basic.amount,

            };

            return View("Create", basicSalary);
        }



    }
}
