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
    public class CommitteMemberController : BaseController
    {
        private readonly ICommitteMembers _committeMembers;
        private readonly ICommittee _committee;
        private readonly ICouncilSession _councilSession;
        private readonly IAuthUser _authUser;

        public CommitteMemberController(ICouncilSession councilSession, ICommittee committee, ICommitteMembers committeMembers, UserManager<User> userManager, IConfiguration configuration,
            SignInManager<User> signInManager, RoleManager<Role> roleManager, IAuthUser authUser)
            : base(userManager, signInManager, roleManager, configuration)
        {
            _committeMembers = committeMembers;
            _committee = committee;
            _councilSession = councilSession;
           _authUser = authUser;
        }
        public IActionResult Index()
        {
            var committeMember = _committeMembers.GetAllCommitteMember();
            return View(committeMember);
        }
        public JsonResult Manage(long Id)
        {

            var committeMember = _committeMembers.GetCommitteMemberById(Id);
            return Json(committeMember);

        }


        [HttpGet]
        public IActionResult Create()
        {
            // ViewBag.Session = _academicSession.GetAll();
            var model = new CommitteMemberViewModel()
            {
                sessionNames = _councilSession.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }).ToList(),
                CommitteNames = _committee.GetAllCommitte().Select(x=> new SelectListItem { Text = x.name, Value = x.Id.ToString() }).ToList(),
                
                

        };
            return PartialView("_Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CommitteMemberViewModel model)
        {
            if (model.Id > 0)
            {
                 _committeMembers.UpdateCommitteMember(model, true);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Committe Member Updated Successfully!", Title = "Committe Memeber", Type = NotificationsType.success });
            }
            else
            {
                _committeMembers.CreateCommitteMember(model, true);
            }
            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Committe Member Added Successfully!", Title = "Committe Memeber", Type = NotificationsType.success });
            return RedirectToAction(nameof(Index));
           
        }

        public IActionResult Edit(long Id)
        {
            //ViewBag.Session = _academicSession.GetAll();
             var committeMember  = _committeMembers.GetCommitteMemberById(Id);
            if (committeMember != null)
            {
                committeMember.sessionNames = _councilSession.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }).ToList();
                 committeMember.CommitteNames= _committee.GetAllCommitte().Select(x => new SelectListItem { Text = x.name, Value = x.Id.ToString() }).ToList();    

            }

            return PartialView("_Create", committeMember);

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