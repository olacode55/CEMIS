using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CEMIS.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using CEMIS.Utility;
using CEMIS.Web.Utilities;
using Newtonsoft.Json;

namespace CEMIS.Web.Controllers
{
    [Authorize]

    public class CollegeController : BaseController

    {

        private readonly ICollege _collegeRepository;



        public CollegeController(UserManager<User> userManager, IConfiguration configuration, ICollege collegeRepository, SignInManager<User> signInManager,
            RoleManager<Role> roleManager) : base(userManager, signInManager, roleManager, configuration)
        {
            _collegeRepository = collegeRepository;
        }


        public IActionResult Index()
        {
            var collegeFormData = _collegeRepository.GetCollegeSummary();
            return View(collegeFormData);

        }



        [HttpGet]
        public IActionResult CollegeSetup(long Id)
        {
            var model = new CollegeViewModel();

            if (Id > 0)
            {

                model = _collegeRepository.GetCollegeById(Id);
            }




            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CollegeSetup(CollegeViewModel model)
        {
            string message;
            bool status;

            if (!ModelState.IsValid)
            {



            }
            else
            {


                if (model.Id > 0)
                {
                    status = _collegeRepository.UpdateCollege(model, out message);
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "College Info Updated Successfully", Title = "College Setup", Type = NotificationsType.success });
                }
                else
                {
                    status = _collegeRepository.CreateCollege(model, out message);
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "College Info Created Successfully", Title = "College Setup", Type = NotificationsType.success });

                }
            }



            return RedirectToAction("Index", "College");

        }



        [HttpGet]
        public IActionResult ClassRoomData(long Id)
        {

            var model = _collegeRepository.GetClassRoomDataById(Id);



            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClassRoomData(CollegeClassRoomDataViewModel model)
        {
            string message;
            bool status;

            try
            {
                if (model.Id > 0)
                {
                    status = _collegeRepository.UpdateCollegeClassRoomData(model, out message);
                }
                else
                {
                    status = _collegeRepository.CreateCollegeClassRoomData(model, out message);
                }

                _collegeRepository.UpdateCollegeIsSynced(model.CollegeId);


            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
            }

            return RedirectToAction("Index", "College");
        }


        [HttpGet]
        public IActionResult ClassRoomInfo(long CollegeId)
        {
            var model = _collegeRepository.GetClassRoomInfoListById(CollegeId);   //_collegeRepository.GetClassRoomInfoById(Id);



            return View(model);
        }

        [HttpGet]
        public JsonResult editClassRoomInfo(long Id)
        {

            var classroomInfo = _collegeRepository.GetClassRoomInfoById(Id);
            return Json(classroomInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClassRoomInfo(CollegeClassRoomInfoViewModel model)
        {
            string message;
            bool status;

            if (!ModelState.IsValid)
            {



            }
            else
            {
                if (model.Id > 0)
                {
                    status = _collegeRepository.UpdateCollegeClassRoomInfo(model, out message);
                }
                else
                {
                    status = _collegeRepository.CreateCollegeClassRoomInfo(model, out message);
                }

                _collegeRepository.UpdateCollegeIsSynced(model.CollegeId);
            }



            return RedirectToAction("Index", "College");
        }

        public IActionResult DeleteClassRoomInfo(long Id)
        {

            long collegeId;
            string message;
            //if (Id > 0)
            //{
            var status = _collegeRepository.DeleteClassRoomInfo(Id, out message, out collegeId);

            _collegeRepository.UpdateCollegeIsSynced(collegeId);

            return RedirectToAction("ClassRoomInfo", new { CollegeId = collegeId });
            //}



        }

    }




}
