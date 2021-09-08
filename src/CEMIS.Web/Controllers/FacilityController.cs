using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.Controllers
{
    //[Authorize]
    public class FacilityController : BaseController
    {
        private readonly IFacility _facilityRepository;
        private readonly ICollege _collegeRepository;
        public FacilityController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IFacility facilityRepository, ICollege collegeRepository, IMainAdminRole mainAdminRole) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _facilityRepository = facilityRepository;
            _collegeRepository = collegeRepository;


        }
        public IActionResult Index()
        {
            ViewBag.FacilityType = _facilityRepository.GetFacilityTypeList();
            var facilities = _facilityRepository.GetAllFacilities();
            return View(facilities);
        }


        public IActionResult Create()
        {
            ViewBag.FacilityType = _facilityRepository.GetFacilityTypeList();
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CollegeFacilityViewModel facility)
        {
            string message;

            var facilities = _facilityRepository.GetAllFacilities();
            var checkIfNameExist = facilities.Where(x => x.Name.ToUpper() == facility.Name.ToUpper()).ToList();

            if (facility.Id > 0)
            {
                checkIfNameExist = checkIfNameExist.Where(x => x.Id != facility.Id).ToList();
                if (checkIfNameExist.Count > 0)
                {
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"{facility.Name} already exist", Title = "Facilty", Type = NotificationsType.danger });
                    return RedirectToAction(nameof(Index));
                }

                _facilityRepository.UpdateFacility(facility, out message);

                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Updated Successfully", Title = "Facilty", Type = NotificationsType.success });
            }
            else
            {
                if (checkIfNameExist.Count > 0)
                {
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"{facility.Name} already exist", Title = "Facilty", Type = NotificationsType.danger });
                    return RedirectToAction(nameof(Index));
                }

                _facilityRepository.CreateFacility(facility, out message);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Created Successfully", Title = "Facilty", Type = NotificationsType.success });
            }

            //Set college IsSynced to false
            _collegeRepository.UpdateCollegeIsSynced(1);

            return RedirectToAction(nameof(Index));
        }


        public JsonResult Manage(long Id)
        {
            ViewBag.FacilityType = _facilityRepository.GetFacilityTypeList();
            var facility = _facilityRepository.GetFacilityById(Id);
            return Json(facility);
            //return PartialView("_Edit", facility);
        }

        public IActionResult Delete(long Id)
        {
            string message;
            _facilityRepository.DeleteFacility(Id, out message);
            _collegeRepository.UpdateCollegeIsSynced(1);

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"{message}", Title = "FacilityType", Type = NotificationsType.danger });
            return RedirectToAction("Index");
        }
    }
}