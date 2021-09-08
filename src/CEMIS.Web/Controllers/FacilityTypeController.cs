using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business;
using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Web.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.Controllers
{
    public class FacilityTypeController : BaseController
    {
        private readonly IFacilityType _facilityTypeRepository;

        public FacilityTypeController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IFacilityType facilityTypeRepository, IMainAdminRole mainAdminRole) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _facilityTypeRepository = facilityTypeRepository;

        }
        public IActionResult Index()
        {
            var facilityTypes = _facilityTypeRepository.GetAllFacilityType();
            return View(facilityTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FacilityType facilityType)
        {
            var facilties = _facilityTypeRepository.GetAllFacilityType();

            var checkIfNameExit = facilties.Where(x => x.Name.ToUpper() == facilityType.Name.ToUpper()).ToList();


            if (facilityType.Id > 0)
            {
                checkIfNameExit = checkIfNameExit.Where(x => x.Id != facilityType.Id).ToList();
                if (checkIfNameExit.Count() > 0)
                {
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"{facilityType.Name.ToUpper()} already exist", Title = "FacilityType", Type = NotificationsType.danger });
                    return RedirectToAction("index");
                }

                _facilityTypeRepository.UpdateFacilityType(facilityType, true);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Updated Successfully", Title = "FacilityType", Type = NotificationsType.success });
            }
            else
            {
                if (checkIfNameExit.Count() > 0)
                {
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"{facilityType.Name.ToUpper()} already exist", Title = "FacilityType", Type = NotificationsType.danger });
                    return RedirectToAction("index");
                }

                _facilityTypeRepository.CreateFacilityType(facilityType, true);

                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Created Successfully", Title = "FacilityType", Type = NotificationsType.success });
            }


            return RedirectToAction("index");
        }


        public JsonResult Manage(long Id)
        {

            var facilityType = _facilityTypeRepository.GetFacilityTypeById(Id);
            return Json(facilityType);

        }

        public IActionResult Delete(long Id)
        {
            // _facilityTypeRepository.DeleteFacilityType(Id, true);
            string message;
            _facilityTypeRepository.DeleteFacilityType(Id, out message);

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"{message}", Title = "FacilityType", Type = NotificationsType.danger });

            return RedirectToAction("Index");
        }
    }
}