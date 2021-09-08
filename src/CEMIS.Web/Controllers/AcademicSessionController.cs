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
    public class AcademicSessionController : BaseController
    {
        private readonly IAcademicSession _academicSession;
        private readonly IAuthUser _authUser;

        public AcademicSessionController(IAcademicSession academicSession, IAuthUser authUser, UserManager<User> userManager, IConfiguration configuration,
            SignInManager<User> signInManager, RoleManager<Role> roleManager)
            : base(userManager, signInManager, roleManager, configuration)
        {
            _academicSession = academicSession;
            _authUser = authUser;
        }
        public IActionResult Index()
        {
            var academicSession = _academicSession.GetAll()
                .Select(x => new AcademicSessionViewModel()
                {
                    Id = x.Id,
                    AcademicPeriod = x.AcademicPeriod,
                    FirstSemesterEndDate = x.FirstSemesterEndDate,
                    FirstSemesterStartDate = x.FirstSemesterStartDate,
                    SecondSemesterStartDate = x.SecondSemesterStartDate,
                    SecondSemesterEndDate = x.SecondSemesterEndDate,
                    IsActive = x.IsActive == false ? "0" : "1"
                }).OrderByDescending(x => x.AcademicPeriod).ToList();

            return View(academicSession);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new AcademicSessionViewModel();
            model.FirstSemesterStartDate = DateTime.Today;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AcademicSessionViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            var academicSessions = _academicSession.GetAll();
            var checkIfActive = academicSessions.Where(x => x.IsActive == true);
            if (checkIfActive.Count() > 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"You currently have an active academic session", Title = "Program Setup", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            var checkIfExist = academicSessions.Where(x => x.AcademicPeriod.ToUpper() == model.AcademicPeriod.ToUpper());
            if (checkIfExist.Count() > 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Period: {model.AcademicPeriod} Already exist", Title = "Program Setup", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            if (model.FirstSemesterEndDate < model.FirstSemesterStartDate)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"First semester end date cannot be less than first Semester start date", Title = "Program Setup", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            if (model.SecondSemesterEndDate < model.SecondSemesterStartDate)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Second semester end date cannot be less than second Semester start date", Title = "Program Setup", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            if (model.SecondSemesterStartDate < model.FirstSemesterEndDate)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Second semester start date cannot be less than first Semester end date", Title = "Program Setup", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }


            var AcademiSession = new AcademicSession()
            {
                AcademicPeriod = model.AcademicPeriod,
                FirstSemesterStartDate = model.FirstSemesterStartDate,
                FirstSemesterEndDate = model.FirstSemesterEndDate,
                SecondSemesterStartDate = model.SecondSemesterStartDate,
                SecondSemesterEndDate = model.SecondSemesterEndDate,
                IsActive = true,
                CreatedBy = long.Parse(_authUser.UserId),
                DateCreated = DateTime.Now,
                IsDeleted = false

            };

            await _academicSession.CreatAsync(AcademiSession);

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Period: {model.AcademicPeriod} added Successfully", Title = "Program Setup", Type = NotificationsType.success });
            return RedirectToAction(nameof(Index));

        }

        public JsonResult Edit(long Id)
        {

            var academicSession = _academicSession.GetAll()
                .Where(x => x.Id == Id)
                .Select(x => new AcademicSessionViewModel()
                {
                    Id = x.Id,
                    AcademicPeriod = x.AcademicPeriod,
                    FirstSemesterEndDate = x.FirstSemesterEndDate.Date,
                    FirstSemesterStartDate = x.FirstSemesterStartDate.Date,
                    SecondSemesterEndDate = x.SecondSemesterEndDate.Date,
                    SecondSemesterStartDate = x.SecondSemesterStartDate.Date

                }).FirstOrDefault();
            return Json(academicSession);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AcademicSessionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var AcademiSession = _academicSession.GetById(model.Id);
                if (AcademiSession == null)
                {
                    return NotFound();
                }
                else
                {
                    var academicSessions = _academicSession.GetAll();
                    var checkIfExist = academicSessions.Where(x => x.AcademicPeriod.ToUpper() == model.AcademicPeriod.ToUpper() && x.Id != model.Id);
                    if (checkIfExist.Count() > 0)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Period: {model.AcademicPeriod} Already exist", Title = "Program Setup", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(Index));
                    }
                    if (model.FirstSemesterEndDate < model.FirstSemesterStartDate)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"First semester end date cannot be less than first Semester start date", Title = "Program Setup", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(Index));
                    }

                    if (model.SecondSemesterEndDate < model.SecondSemesterStartDate)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Second semester end date cannot be less than second Semester start date", Title = "Program Setup", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(Index));
                    }

                    if (model.SecondSemesterStartDate < model.FirstSemesterEndDate)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Second semester start date cannot be less than first Semester end date", Title = "Program Setup", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(Index));
                    }

                    AcademiSession.AcademicPeriod = model.AcademicPeriod;
                    AcademiSession.FirstSemesterStartDate = model.FirstSemesterStartDate;
                    AcademiSession.FirstSemesterEndDate = model.FirstSemesterEndDate;
                    AcademiSession.SecondSemesterStartDate = model.SecondSemesterStartDate;
                    AcademiSession.SecondSemesterEndDate = model.SecondSemesterEndDate;
                    AcademiSession.UpdatedBy = long.Parse(_authUser.UserId);
                    AcademiSession.DateUpdated = DateTime.UtcNow;


                    _academicSession.Update(AcademiSession);

                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Period: {model.AcademicPeriod} updated Successfully", Title = "Program Setup", Type = NotificationsType.success });

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        public IActionResult Toggle(long Id)
        {
            var academicSession = _academicSession.GetById(Id);

            if (academicSession.IsActive == false)
            {

                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Sorry you cannot re-open a closed academic session ", Title = "Program Setup", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));

                //var checkIfActiveSession = _academicSession.GetAll().Where(x => x.IsActive == true && x.Id != Id);
                //if (checkIfActiveSession.Count() > 0)
                //{
                //    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Their is currently an active session, close before opneing another.", Title = "Program Setup", Type = NotificationsType.danger });
                //    return RedirectToAction(nameof(Index));
                //}

            }

            if (academicSession.SecondSemesterEndDate <= DateTime.Now)
            {
                _academicSession.Toggle(Id);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Period: {academicSession.AcademicPeriod} Closed Successfully", Title = "Program Setup", Type = NotificationsType.success });
            }
            else
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic session cannot be closed when second semester end date has not been reached.", Title = "Program Setup", Type = NotificationsType.danger });
            }

            //if (academicSession.IsActive == true)
            //{
            //    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Period: {academicSession.AcademicPeriod} Opened Successfully", Title = "Program Setup", Type = NotificationsType.success });
            //}
            //else
            //{
            //    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Period: {academicSession.AcademicPeriod} Closed Successfully", Title = "Program Setup", Type = NotificationsType.success });
            //}

            return RedirectToAction(nameof(Index));
        }
    }
}