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
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.Controllers
{
    public class CouncilSessionController : BaseController
    {
        private readonly ICouncilSession _councilSession;
        private readonly IAuthUser _authUser;

        public CouncilSessionController(ICouncilSession councilSession, IAuthUser authUser, UserManager<User> userManager, IConfiguration configuration,
            SignInManager<User> signInManager, RoleManager<Role> roleManager)
            : base(userManager, signInManager, roleManager, configuration)
        {
            _councilSession = councilSession;
            _authUser = authUser;
        }
        public IActionResult Index()
        {
            var councilSession = _councilSession.GetAll()
                .Select(x => new CouncilSessionViewModel()
                {
                    Id = x.Id,
                    name = x.Name,
                    startDate = x.StartDate,
                    endDate = x.EndDate,
                    IsActive = x.IsActive == false ? "0" : "1"
                }).OrderByDescending(x => x.name).ToList();

            return View(councilSession);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new CouncilSessionViewModel();
             model.startDate = DateTime.Today;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CouncilSessionViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            var councilSessions = _councilSession.GetAll();
            var checkIfExist = councilSessions.Where(x => x.Name.ToUpper().Trim() == model.name.ToUpper().Trim());
            if (checkIfExist.Count() > 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Name: {model.name} Already exist", Title = "Council Session", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            var checkActive = councilSessions.Where(x => x.IsActive == true);

            if (checkActive.Count() > 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "  You cannot Add A new Session,there is currently an Active Session Runing ", Title = "Council Session", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));

            }
            var councilSession = new CouncilSession()
            {
                Name = model.name,
                StartDate = model.startDate,
                 EndDate = model.endDate,
                IsActive = true,
                CreatedBy = 1,
                DateCreated = DateTime.Now,
                IsDeleted = false

            };

            await _councilSession.CreatAsync(councilSession);

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Name: {model.name} added Successfully", Title = "Council Session", Type = NotificationsType.success });
            return RedirectToAction(nameof(Index));

        }

        public JsonResult Edit(long Id)
        {

            var councilSession  = _councilSession.GetAll()
                .Where(x => x.Id == Id)
                .Select(x => new CouncilSessionViewModel()
                {
                    Id = x.Id,
                    name = x.Name,
                    startDate = x.StartDate,
                    endDate = x.EndDate,
                   

                }).FirstOrDefault();
            return Json(councilSession);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CouncilSessionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var councilSession = _councilSession.GetById(model.Id);
                if (councilSession == null)
                {
                    return NotFound();
                }
                else
                {
                    var councilSessions = _councilSession.GetAll();
                    var checkIfExist = councilSessions.Where(x => x.Name.ToUpper() == model.name.ToUpper() && x.Id != model.Id);
                    if (checkIfExist.Count() > 0)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"NAME: {model.name} Already exist", Title = "Council Session", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(Index));
                    }

                    councilSession.Name = model.name;
                    councilSession.StartDate = model.startDate;
                    councilSession.EndDate = model.endDate;

                    councilSession.UpdatedBy = long.Parse(_authUser.UserId);
                    councilSession.DateUpdated = DateTime.UtcNow;


                    _councilSession.Update(councilSession);

                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Name: {model.name} updated Successfully", Title = "Council Session", Type = NotificationsType.success });

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        public IActionResult Toggle(long Id)
        {
            var councilSession = _councilSession.GetById(Id);

            if (councilSession.IsActive == false)
            {
                var checkIfActiveSession = _councilSession.GetAll().Where(x => x.IsActive == true && x.Id != Id);
                if (checkIfActiveSession.Count() > 0)
                {
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Their is currently an active session, close before opneing another.", Title = "Council Session", Type = NotificationsType.danger });
                    return RedirectToAction(nameof(Index));
                }

            }

            if (councilSession.EndDate > DateTime.Now)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"The End Date for this Session is not Due yet", Title = "Council Session", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }
            _councilSession.Toggle(Id);

            if (councilSession.IsActive == true)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Name: {councilSession.Name} Opened Successfully", Title = "Council Session", Type = NotificationsType.success });
            }
            else
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Name: {councilSession.Name} Closed Successfully", Title = "Council Session", Type = NotificationsType.success });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}