using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business;
using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CEMIS.Web.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly IDepartment _departmentRepository;

        public DepartmentController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IDepartment departmentRepository, IMainAdminRole mainAdminRole) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _departmentRepository = departmentRepository;

        }
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAllDepartment();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (department.Id > 0)
            {
                _departmentRepository.UpdateDepartment(department, true);
            }
            else
            {
                _departmentRepository.CreateDepartment(department, true);
            }


            return RedirectToAction("index");
        }


        public JsonResult Manage(long Id)
        {

            var department = _departmentRepository.GetDepartmentById(Id);
            return Json(department);

        }

        public IActionResult Delete(long Id)
        {
            // _facilityTypeRepository.DeleteFacilityType(Id, true);
            string message;
            _departmentRepository.DeleteDepartment(Id, out message);

            return RedirectToAction("Index");
        }
    }
}