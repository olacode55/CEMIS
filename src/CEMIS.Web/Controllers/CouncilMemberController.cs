using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.Controllers
{
    public class CouncilMemberController : BaseController
    {
        private readonly ICouncilMembers _councilMembers;
        private readonly ICouncilSession _councilSession;
        private readonly IAuthUser _authUser;

        public CouncilMemberController(ICouncilMembers councilMembers, ICouncilSession councilSession, UserManager<User> userManager, IConfiguration configuration,
            SignInManager<User> signInManager, RoleManager<Role> roleManager, IAuthUser authUser)
            : base(userManager, signInManager, roleManager, configuration)
        {
            _councilMembers = councilMembers;
            _councilSession = councilSession;
           _authUser = authUser;
        }
        public IActionResult Index()
        {
            var membercouncil = _councilMembers.GetAllMember();
            return View(membercouncil);
        }
        public JsonResult Manage(long Id)
        {

            var councilMember = _councilMembers.GetMemberById(Id);
            return Json(councilMember);

        }


        [HttpGet]
        public IActionResult Create()
        {
           // ViewBag.Session = _academicSession.GetAll();
            var model = new CouncilMemberViewModel()
            {
                sessionNames = _councilSession.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }).ToList()

        };
            return PartialView("_Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CouncilMemberViewModel model)
        {
            if (model.Id > 0)
            {
                 _councilMembers.UpdateMember(model, true);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Council Member Updated Successfully!", Title = "Council Memeber", Type = NotificationsType.success });
            }
            else
            {
                _councilMembers.CreateMember(model, true);
            }
            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Council Member Added Successfully!", Title = "Council Memeber", Type = NotificationsType.success });
            return RedirectToAction(nameof(Index));
           
        }

        public IActionResult Edit(long Id)
        {
            //ViewBag.Session = _academicSession.GetAll();
             var councilMember  = _councilMembers.GetMemberById(Id);
            if (councilMember != null)
            {
                councilMember.sessionNames = _councilSession.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }).ToList();
            }

            return PartialView("_Create", councilMember);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(CouncilMemberViewModel model)
        //{

        //    var user = long.Parse(_authUser.UserId);
        //    if (ModelState.IsValid)
        //    {
        //        var councilMember = _councilMembers.GetById(model.Id);
        //        if (councilMember == null)
        //        {
        //            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Council Member Does not  exist on the system!", Title = "Council Memeber", Type = NotificationsType.info });
        //            RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            councilMember.CouncilMemberName = model.councilMemberName;
        //            councilMember.CouncilMemberPosition = model.councilMemberPosition;
        //            councilMember.SessionName = model.sessionName;
        //            councilMember.SessionId = model.sessionId;
        //            councilMember.IsActive =  true;
        //            councilMember.UpdatedBy = user;
        //            councilMember.DateUpdated = DateTime.Now;


        //            _councilMembers.Update(councilMember);
        //            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Council Member Updated Successfully!", Title = "Council Memeber", Type = NotificationsType.success });

        //            return RedirectToAction(nameof(Index));
        //        }
        //    }

        //    return View(model);
        //}
    }
}