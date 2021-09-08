
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
    public class CouncilSessionController : BaseController
    {
        private readonly ICouncilSession _councilSessionRepository;
        public CouncilSessionController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IHttpContextAccessor accessor, IActivityLog logActivityRepo,
                               IActionContextAccessor actionContextAccessor, ICouncilSession councilSessionRepository) :
                               base(userManager, signInManager, roleManager, configuration, accessor, actionContextAccessor, logActivityRepo)
        {
            _councilSessionRepository = councilSessionRepository;
        }
        public JsonResult GetSessionByCollegeId(int collegeId)
        {
            var data = _councilSessionRepository.GetCouncilSessionByCollegeId(collegeId);

            return Json(data);
        }
    }
}