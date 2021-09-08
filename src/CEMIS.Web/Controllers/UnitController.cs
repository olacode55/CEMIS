using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business;
using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;


namespace CEMIS.Web.Controllers
{
    public class UnitController : BaseController
    {
        private readonly IUnit _unitRepository;
        private readonly IDepartment _departmentRepository;
        

        public UnitController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IDepartment departmentRepository,IUnit unitRepository, IMainAdminRole mainAdminRole) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _departmentRepository = departmentRepository;
            _unitRepository = unitRepository;

        }
        public IActionResult Index()
        {
            var units = _unitRepository.GetAllUnit();
            return View(units);
        }

        public IActionResult Create()
        {
            // return View();
            var model = new UnitViewModel()
            {
                Departments = _departmentRepository.GetAllDepartment().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }).ToList(),
            };
            return PartialView("Create", model);

        }


        public IActionResult Edit(long id)
        {
            var unit = _unitRepository.GetUnitById(id);
            if(unit != null)
            {
                unit.Departments = _departmentRepository.GetAllDepartment().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }).ToList();
            }

            return PartialView("Create", unit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UnitViewModel unit)
        {
            if (unit.Id > 0)
            {
                _unitRepository.UpdateUnit(unit, true);
            }
            else
            {
                _unitRepository.CreateUnit(unit, true);
            }


            return RedirectToAction("index");
        }


        public JsonResult Manage(long Id)
        {

            var unit = _unitRepository.GetUnitById(Id);
            return Json(unit);

        }

        public IActionResult Delete(long Id)
        {
           //  _unitRepository.DeleteUnit(Id, true);
            string message;
            _unitRepository.DeleteUnit(Id, out message);

            return RedirectToAction("Index");
        }
      
    }
}