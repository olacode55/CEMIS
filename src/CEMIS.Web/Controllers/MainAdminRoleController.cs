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

namespace CEMIS.Web.Controllers
{
    [Authorize]
    public class MainAdminRoleController : BaseController
    {
        private readonly IMainAdminRole _mainAdminRoleRepository;
        public MainAdminRoleController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IFacility facilityRepository, IMainAdminRole mainAdminRoleRepository) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _mainAdminRoleRepository = mainAdminRoleRepository;


        }
        public IActionResult Index()
        {
            var adminRoles = _mainAdminRoleRepository.GetAllAdminRole();
            return View(adminRoles);
        }


        public IActionResult _Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeachingStaffAdminRole teachingStaffAdminRole)
        {
            if (teachingStaffAdminRole.Id > 0)
            {
                _mainAdminRoleRepository.UpdateAdminRole(teachingStaffAdminRole, true);
            }
            else
            {
                _mainAdminRoleRepository.CreateAdminRole(teachingStaffAdminRole, true);
            }

            return RedirectToAction("index");
        }


        public JsonResult Manage(long Id)
        {

            var facility = _mainAdminRoleRepository.GetAdminRoleById(Id);
            return Json(facility);
            //return PartialView("_Edit", facility);
        }

        public IActionResult Delete(long Id)
        {
            _mainAdminRoleRepository.DeleteAdminRole(Id, true);
            return RedirectToAction("Index");
        }
    }
}