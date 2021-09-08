using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemis.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CEMIS.Web.CentralPortal.Controllers
{
    //[Authorize(Roles = "student")]
    public class StudentController : BaseController
    {
        private readonly IStudent _studentRepository;
        private readonly IResult _resultRepository;
        private readonly IAcademicSession _academicSessionRepo;

        public StudentController(UserManager<User> userManager, RoleManager<Role> roleManager, IStudent studentRepository,IResult resultRepository, SignInManager<User> signInManager,
                             IConfiguration configuration, IHttpContextAccessor accessor, IActivityLog logActivityRepo,
                             IActionContextAccessor actionContextAccessor , IAcademicSession academicSessionRepo) : base(userManager, signInManager, roleManager, configuration, accessor, actionContextAccessor, logActivityRepo)
        {
            _studentRepository = studentRepository;
            _resultRepository = resultRepository;
            _academicSessionRepo = academicSessionRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            var studentId = GetUserName();
            var data = _studentRepository.GetStudentProfile(studentId);
            return View(data.FirstOrDefault());
        }

        public IActionResult Result()
        {
            //var studentId = GetUserName();
            var data = new List<StudentResultViewModel>();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Result( int sessionId, int level, int semester)
        {
            var studentId = GetUserName();
            var data = _resultRepository.GetStudentResult(studentId, sessionId, level, semester);
            return View(data);
        }

        public JsonResult GetStudentSession()
        {
            var studentId = GetUserName();
            var data = _academicSessionRepo.GetStudentSession(studentId);
            return Json(data);
        }
    }
}