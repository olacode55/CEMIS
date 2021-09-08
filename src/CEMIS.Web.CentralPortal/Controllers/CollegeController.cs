using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemis.Business.Central.Interface;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility;
using CEMIS.Web.CentralPortal.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.CentralPortal.Controllers
{
   [Authorize]
    public class CollegeController : BaseController
    {

        private readonly ICollege _collegeRepository;
        public CollegeController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IHttpContextAccessor accessor, IActivityLog logActivityRepo,
                               IActionContextAccessor actionContextAccessor, ICollege collegeRepository) : base(userManager, signInManager,
                               roleManager, configuration, accessor, actionContextAccessor, logActivityRepo)
        {
            _collegeRepository = collegeRepository;
        }
        
        public IActionResult Index()
        {
            var colleges = _collegeRepository.GetAllColleges();
            return View(colleges);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(College college)
        {
            var resp = new ResponseData<College>();
            college.APIKey = Guid.NewGuid().ToString();
            college.CreatedBy = CurrentUser;
            if (college.Id > 0)
            {
                
            }
            else
            {
               resp = _collegeRepository.CreateCollege(college);
            }


            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = resp.Message, Title = "College Setup", Type = resp.IsSuccessful ? NotificationsType.Success : NotificationsType.Danger });
            LogActivity(resp.Message, college).ConfigureAwait(true);

            return RedirectToAction("index");
        }


        public JsonResult Manage(long Id)
        {

           // var facility = _facilityRepository.GetFacilityById(Id);
            return Json("");
            //return PartialView("_Edit", facility);
        }

        public IActionResult Delete(long Id)
        {
          //  _facilityRepository.DeleteFacility(Id, true);
            return RedirectToAction("Index");
        }
     
    }
}