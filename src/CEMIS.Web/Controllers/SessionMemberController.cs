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

namespace CEMIS.Web.Controllers
{
    public class SessionMemberController : BaseController
    {
        private readonly ISession _sessionRepo;

        public SessionMemberController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, ISession SessionRepo, IMainAdminRole mainAdminRole) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _sessionRepo = SessionRepo;

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

                //var model = _sessionRepo.GetAllSession().Select(SessionViewModel.EntityToModels).ToList();

                var model = _sessionRepo.GetAllSession().Select(x => new SessionViewModel()
                {
                    Id = x.Id,
                    SessionName = x.SessionName,
                    IsActive = x.IsActive,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    MembershipName = x.MembershipName,
                    MembershipPosition = x.PositionName

                }).ToList();
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
                CreateViewBagParams();
                return PartialView("_PartialEditAdd");

            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public IActionResult AddMemberSession(SessionViewModel model)
        {
            try
            {

                Session modelSession = new Session();
                modelSession.SessionName = model.SessionName.ToString();
                modelSession.StartDate = model.StartDate.ToString();
                modelSession.EndDate = model.EndDate;
                modelSession.IsActive = true;
                modelSession.PositionName = model.MembershipPosition;
                modelSession.MembershipName = model.MembershipName;
                _sessionRepo.AddSession(model);
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
        public IActionResult UpdaSession(long id)
        {
            try
            {
                // EditViewBagParams();
                var getId = _sessionRepo.GetSessionById(id);
                SessionViewModel model = new SessionViewModel();

                model.SessionName = getId.SessionName;
                model.StartDate = getId.StartDate;
                model.EndDate = getId.EndDate;
                model.MembershipName = getId.MembershipName;
                model.MembershipPosition = getId.PositionName;
                return PartialView("UpdaSession", model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public IActionResult UpdaSession(long id, SessionViewModel model)
        {
            try
            {
                EditViewBagParams();
                var getId = _sessionRepo.GetSessionById(id);
                getId.SessionName = model.SessionName.ToString();
                getId.StartDate = model.StartDate;
                getId.EndDate = model.EndDate;
                getId.MembershipName = model.MembershipName;
                getId.PositionName = model.MembershipPosition;
                _sessionRepo.UpdateSession(model);
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
    }

}






