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
    public class BasicSalaryController : BaseController
    {
        private readonly IStaff _staffRepository;
        private readonly IMainAdminRole _mainAdminRole;
        private readonly IStaffGradeLevel _staffGradeLevel;
        private IHostingEnvironment _hostingEnvironment;
        private readonly IStaffCategory _staffCategory;
        private readonly IStaffRank _staffRank;
        private readonly IGradeLevel _gradeLevel;
        private readonly ICertificate _certificate;
        private readonly IStaffType _staffType;
        private readonly ISelectFactory _selectListFactory;
        private readonly IDepartment _department;
        private readonly IBasicSalary _basicSalary;

        public BasicSalaryController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, ISelectFactory selectListFactory, IDepartment department, IBasicSalary basicSalary, IStaffCategory staffCategory,  IGradeLevel gradeLevel, ICertificate certificate, IStaffRank staffRank, IStaffType staffType, IStaff staffRepository, IMainAdminRole mainAdminRole, IStaffGradeLevel staffGradeLevel, IHostingEnvironment hostingEnvironment) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _staffRepository = staffRepository;
            _mainAdminRole = mainAdminRole;
            _staffGradeLevel = staffGradeLevel;
            _hostingEnvironment = hostingEnvironment;
            _staffCategory = staffCategory;
            _staffRank = staffRank;
            _gradeLevel = gradeLevel;
            _certificate = certificate;
            _staffType = staffType;
            _selectListFactory = selectListFactory;
            _department = department;
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

        [HttpGet]
        public IActionResult FindStaffStep(int Level)
        {
            var rank = _gradeLevel.GetStep(Level);
               
            //category

            return new JsonResult(rank);
        }

        public IActionResult Edit(long Id)
        {
            //ViewBag.Session = _academicSession.GetAll();
            var basicSalary = _basicSalary.GetBasicSalaryById(Id);
           

            return PartialView("_Create", basicSalary);

        }
        public IActionResult Create()
        {
            var model = new BasicSalaryViewModel();
            ViewBag.GradeLevel = _gradeLevel.GetAllGradeLevel();
            return PartialView("_Create", model);
        }
        [HttpPost]
        public ActionResult Create(BasicSalaryViewModel model)
        {
            if (model.Id > 0)
            {
                _basicSalary.UpdateBasicSalary(model, true);
            }
            else
            {
                _basicSalary.CreateBasicSalary(model, true);
            }
          
            return RedirectToAction("Index");
        }
        public IActionResult Manage(long Id)
        {
            ViewBag.GradeLevel = _gradeLevel.GetAllGradeLevel();
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

        //public IActionResult Delete(long Id)
        //{
        //    _staffRepository.DeleteTeachingStaff(Id , true);
        //    return RedirectToAction("Index");
        //}
       
        }
    }
