using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using CEMIS.Business;
using CEMIS.Business.Interface;
using CEMIS.Data;
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
    public class CourseController : BaseController
    {
        private readonly ICourse _courseRepo;
        private readonly IProgram _programRepo;
        private readonly ILevel _levelRepo;
        private readonly IAuthUser _authUser;
        private readonly ICollege _collegeRepository;
        private IRepository<TrackCollegeChanges> _trackCollegeChangesRepo;

        public CourseController(ICourse courseRepo, IProgram programRepo, ILevel levelRepo, IAuthUser authUser, UserManager<User> userManager, IConfiguration configuration,
            SignInManager<User> signInManager, RoleManager<Role> roleManager, ICollege collegeRepository, IRepository<TrackCollegeChanges> trackCollegeChangesRepo)
            : base(userManager, signInManager, roleManager, configuration)
        {
            _courseRepo = courseRepo;
            _programRepo = programRepo;
            _levelRepo = levelRepo;
            _authUser = authUser;
            _collegeRepository = collegeRepository;
            _trackCollegeChangesRepo = trackCollegeChangesRepo;
        }
        public IActionResult Index()
        {
            var model = new CourseFormViewModel();
            ViewBag.Program = _programRepo.GetProgramList();
            ViewBag.Level = _levelRepo.GetLevelList();
            return View(model);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(CourseFormViewModel model)
        {
            if (model.ProgramId < 1 || model.LevelId < 1)
            {
                ViewBag.Program = _programRepo.GetProgramList();
                ViewBag.Level = _levelRepo.GetLevelList();
                return View(model);
            }
            else
            {
                ViewBag.Program = _programRepo.GetProgramList();
                ViewBag.Level = _levelRepo.GetLevelList();
                //byte semester =Convert.ToByte(model.Semester);
                var courses = _courseRepo.GetCourseByFilter(model.ProgramId, model.LevelId, model.Semester).Select(x => new CourseViewModel()
                {
                    Id = x.Id,
                    CourseCode = x.CourseCode,
                    CourseTitle = x.CourseTitle,
                    Credit = x.Credit,
                    Option = x.Option,
                    ProgramId = x.ProgramId,
                    LevelId = x.LevelId,
                    Semester = x.Semester,
                    IsActive = x.IsActive

                }).ToList();
                if (courses.Count() == 0)
                {
                    model.Courses = new List<CourseViewModel>();
                }
                else
                {
                    model.Courses = courses;
                }


                return View(model);
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CourseViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            var courses = _courseRepo.GetAll().Where(x => x.ProgramId == model.ProgramId && x.LevelId == model.LevelId);
            var checkCourseCode = courses.Where(x => x.CourseCode.ToUpper() == model.CourseCode.ToUpper());
            var checkCourseTitle = courses.Where(x => x.CourseTitle.ToUpper() == model.CourseTitle.ToUpper());

            if (checkCourseCode.Count() > 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course Code: {model.CourseCode} already exist", Title = "Course Setup", Type = NotificationsType.info });
                return RedirectToAction(nameof(Index));
            }
            if (checkCourseTitle.Count() > 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course Title: {model.CourseTitle} already exist", Title = "Course Setup", Type = NotificationsType.info });
                return RedirectToAction(nameof(Index));
            }

            var course = new Course()
            {
                CourseCode = model.CourseCode,
                CourseTitle = model.CourseTitle,
                Credit = model.Credit,
                Option = model.Option,
                ProgramId = model.ProgramId,
                LevelId = model.LevelId,
                Semester = model.Semester,
                IsActive = true,
                CreatedBy = long.Parse(_authUser.UserId),
                DateCreated = DateTime.UtcNow,
                IsDeleted = false

            };

            var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.Courses);
            module.HasChanged = true;

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _courseRepo.CreatAsync(course).ConfigureAwait(false);

                _trackCollegeChangesRepo.Update(module);
                _collegeRepository.UpdateCollegeIsSynced(1);
                scope.Complete();
            }

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course code: {model.CourseCode} created successfully", Title = "Course Setup", Type = NotificationsType.success });
            return RedirectToAction(nameof(Index));

        }

        public JsonResult Edit(long Id)
        {

            var course = _courseRepo.GetAll()
                .Where(x => x.Id == Id)
                .Select(x => new CourseViewModel()
                {
                    Id = x.Id,
                    CourseCode = x.CourseCode,
                    CourseTitle = x.CourseTitle,
                    Credit = x.Credit,
                    Option = x.Option,
                    ProgramId = x.ProgramId,
                    LevelId = x.LevelId,
                    Semester = x.Semester,

                }).FirstOrDefault();

            return Json(course);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var course = _courseRepo.GetById(model.Id);
                if (course == null)
                {
                    return NotFound();
                }
                else
                {

                    var courses = _courseRepo.GetAll().Where(x => x.ProgramId == model.ProgramId && x.LevelId == model.LevelId && x.Id != course.Id);
                    var checkCourseCode = courses.Where(x => x.CourseCode.ToUpper() == model.CourseCode.ToUpper());
                    var checkCourseTitle = courses.Where(x => x.CourseTitle.ToUpper() == model.CourseTitle.ToUpper());

                    if (checkCourseCode.Count() > 0)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course Code: {model.CourseCode} already exist", Title = "Course Setup", Type = NotificationsType.info });
                        return RedirectToAction(nameof(Index));
                    }
                    if (checkCourseTitle.Count() > 0)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course Title: {model.CourseTitle} already exist", Title = "Course Setup", Type = NotificationsType.info });
                        return RedirectToAction(nameof(Index));
                    }

                    course.CourseCode = model.CourseCode;
                    course.CourseTitle = model.CourseTitle;
                    course.Credit = model.Credit;
                    course.Option = model.Option;
                    course.ProgramId = model.ProgramId;
                    course.LevelId = model.LevelId;
                    course.Semester = model.Semester;
                    course.UpdatedBy = long.Parse(_authUser.UserId);
                    course.DateUpdated = DateTime.UtcNow;


                    var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.Courses);
                    module.HasChanged = true;

                    using (var scope = new TransactionScope())
                    {
                        _courseRepo.Update(course);
                        _collegeRepository.UpdateCollegeIsSynced(1);
                        _trackCollegeChangesRepo.Update(module);
                        scope.Complete();
                    }


                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course code: {model.CourseCode} Updated successfully", Title = "Course Setup", Type = NotificationsType.success });
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        public IActionResult Toggle(long Id)
        {
            var course = _courseRepo.GetById(Id);

            if (course == null)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course Not Found", Title = "Course Setup", Type = NotificationsType.info });
                return RedirectToAction(nameof(Index));
            }

            if (course.IsActive == true)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course deactivated successfully", Title = "Course Setup", Type = NotificationsType.success });
            }
            else
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course activated successfully", Title = "Course Setup", Type = NotificationsType.success });
            }

            var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.Courses);
            module.HasChanged = true;

            using (var scope = new TransactionScope())
            {
                _courseRepo.Toggle(Id);
                _collegeRepository.UpdateCollegeIsSynced(1);
                _trackCollegeChangesRepo.Update(module);
                scope.Complete();
            }

            if (course.IsActive == true)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course deactivated successfully", Title = "Course Setup", Type = NotificationsType.success });
            }
            else
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course activated successfully", Title = "Course Setup", Type = NotificationsType.success });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}