using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemis.Business.Central.Interface;
using CEMIS.Data.Central;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace CEMIS.Web.CentralPortal.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICourse _courseRepository;
        public CourseController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration , IHttpContextAccessor accessor, IActivityLog logActivityRepo,
                               IActionContextAccessor actionContextAccessor, ICourse courseRepository) : 
                               base(userManager, signInManager,roleManager, configuration, accessor, actionContextAccessor, logActivityRepo)
        {
            _courseRepository = courseRepository;
        }
        public JsonResult GetCoursesByProgramId(int collegeId , int programId )
        {
            var data = _courseRepository.GetCoursesByProgramId(programId , collegeId);

            return Json(data);
        }
    }
}