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
    public class AnalyticsController : BaseController
    {

        private readonly IAnalytics _analyticsRepo;
        public AnalyticsController(UserManager<User> userManager , RoleManager<Role> roleManager , SignInManager<User> signInManager , IConfiguration configuration,
                                   IHttpContextAccessor accessor, IActivityLog logActivityRepo,IActionContextAccessor actionContextAccessor, IAnalytics analyticsRepo)
                                   : base(userManager , signInManager , roleManager , configuration, accessor, actionContextAccessor, logActivityRepo)
        {
            _analyticsRepo = analyticsRepo;
        }


        [HttpGet]
        
        public JsonResult GetDashBoardAnalytics()
        {
            var facilityNo = _analyticsRepo.CollegeAnalyticsByFacilityNumber();
            var staffNo = _analyticsRepo.CollegeAnalyticsByStaffNumber();

            var dashboardAnalytics = new DashBoardAnalyticsModel
            {
                FacilityAnalytics = facilityNo,
                TeachingStaffAnalytics = staffNo
            };

            return Json(dashboardAnalytics);
        }

    }
}