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
using CEMIS.Business.Model;
using Newtonsoft.Json;
using CEMIS.Web.Utilities;
using Microsoft.EntityFrameworkCore;
using CEMIS.Business.Repository;
using CEMIS.Business.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using CEMIS.Web.Util;
namespace CEMIS.Web.Controllers
{
    public class ExecutiveMemberController : BaseController
    {
        private readonly ISession _sessionRepo;
        private readonly IRepositoryUtility _RepoUti;

        public ExecutiveMemberController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IRepositoryUtility RepoUti, ISession SessionRepo, IMainAdminRole mainAdminRole) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _sessionRepo = SessionRepo;
            _RepoUti = RepoUti;
        }
        public IActionResult Index()
        {
            try
            {
                if (TempData["MESSAGE"] != null)
                {
                    ViewBag.Msg = TempData["MESSAGE"] as String;
                }
                if (TempData["ERRORMESSAGE"] != null)
                {
                    ViewBag.ErrMsg = TempData["ERRORMESSAGE"] as String;
                }

                var model = _RepoUti.GetsessionMemberListing().ToList();

                return View(model);

            }
            catch (System.Exception ex)
            {

                throw (ex);
            }
        }

        [HttpGet]
        public IActionResult AddMemberSession()
        {
            try
            {
                SessionViewModel model = new SessionViewModel();

                var querylog = Getcontroller();
                ViewBag.drp = querylog.ToList();
                return PartialView("_PartialEditAdd");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpPost]
        public IActionResult AddMemberSession(SessionViewModel model)
        {
            try
            {


                CouncilMember modelcouncil = new CouncilMember
                {
                    SessionName = model.SessionName.ToString(),
                    CouncilMemberName = model.MembershipName,
                    CouncilMemberPosition = model.MembershipPosition,
                    IsActive = true
                };

                _sessionRepo.AddMemberInSession(model);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Member session Added!", Title = "Create", Type = NotificationsType.success });
                return Json(new { success = true });
            }

            catch (Exception)
            {

                throw;
            }
            return PartialView("_PartialEditAdd");
        }

        [HttpGet]
        public IActionResult UpdateMemberSession(long id)
        {
            try
            {
                // EditViewBagParams();
                var getId = _sessionRepo.GetCouncilMemberbyId(id);
                SessionViewModel model = new SessionViewModel
                {
                    SessionName = getId.SessionName,
                    MembershipName = getId.CouncilMemberName,
                    MembershipPosition = getId.CouncilMemberPosition
                };

                return PartialView("UpdateMemberSession", model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public IActionResult UpdateMemberSession(long id, SessionViewModel model)
        {
            try
            {
                EditViewBagParams();
                var getId = _sessionRepo.GetCouncilMemberbyId(id);
                getId.SessionName = model.SessionName.ToString();
                getId.CouncilMemberPosition = model.MembershipPosition;
                getId.CouncilMemberName = model.MembershipName;
                _sessionRepo.UpdateCoucilMember(model);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Member session Updated!", Title = "Update", Type = NotificationsType.success });

                return Json(new { success = true });
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public IActionResult Deactivate(long Id)
        {
            try
            {

                var getId = _sessionRepo.GetSessionById(Id);

                SessionViewModel mod = new SessionViewModel();
                mod.Id = getId.Id;
                return PartialView("Deactivate", mod);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Deactivate(long Id, SessionViewModel model)
        {
            try
            {

                var getId = _sessionRepo.GetSessionById(Id);

                _sessionRepo.UpdateentityId(Id);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Member session Deactivate!", Title = "Create", Type = NotificationsType.success });

                return Json(new { success = true });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SessionViewModel> Getcontroller()
        {
            var log = _sessionRepo.GetAllSession().Select(n => new SessionViewModel
            {
                Id = n.Id,
                SessionName = n.SessionName
            });
            return log.ToList();
        }

        public List<SessionViewModel> GetSession()
        {
            try
            {
                var query = _RepoUti.GetsessionbyMember();
                ViewBag.drp = query.ToList();
                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}








