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
    public class ProgramController : BaseController
    {
        private readonly IProgram _programRepo;

        public ProgramController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IHttpContextAccessor accessor, IActivityLog logActivityRepo,
                               IActionContextAccessor actionContextAccessor, IProgram programRepo) : base(userManager, signInManager,
                                   roleManager, configuration, accessor, actionContextAccessor, logActivityRepo)
        {
            _programRepo = programRepo;
        }
        public JsonResult GetProgrambyCollegeId(int collegeId)
        {
            var data = _programRepo.GetProgramByCollegeId(collegeId);

            return Json(data);
        }
    }
}