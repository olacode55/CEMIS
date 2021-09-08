using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cemis.Business.Central.Interface;
using Cemis.Data.Central.Entities;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEMIS.Web.CentralPortal.Controllers
{
    [Authorize]
    public class DashBoardController : BaseController
    {
        private readonly appContextCentral _context;
        private readonly IReport _report;

        public DashBoardController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, appContextCentral context, IHttpContextAccessor accessor, IActivityLog logActivityRepo,
                               IActionContextAccessor actionContextAccessor, IReport report) : base(userManager, signInManager,
                               roleManager, configuration, accessor, actionContextAccessor, logActivityRepo)
        {
            _context = context;
            _report = report;
        }
        
        
        
        
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            CollegeSummary report;
            var dashboardHistory = _report.getDashBoardHistory(CurrentUser);
            report = _report.FetchStaffDashBoardReport();
            if (dashboardHistory == null)
            {
                
                report.CollegeIncr = DashBoardStatus.Increases;
                report.FacilityIncr = DashBoardStatus.Increases;
                report.LeadershipIncr = DashBoardStatus.Increases;
                report.TeachingstaffIncr = DashBoardStatus.Increases;
                report.ClassroomIncr = DashBoardStatus.Increases;

                var dashboard = new DashboardHistory
                {
                    CollegeCount = report.College,
                    CollegeLeadershipCount = report.Leadership,
                    FacilityCount = report.Facility,
                    TeachingStaffCOunt = report.Teachingstaff,
                    ClassRoomCount = report.Classroom,
                    UserID = CurrentUser
                };

                _report.UpdateDashboardHistory(dashboard);
            }
            else
            {
                report.CollegeIncr = report.College > dashboardHistory.CollegeCount ? DashBoardStatus.Increases : report.College < dashboardHistory.CollegeCount ? DashBoardStatus.Decrease : DashBoardStatus.Equals;
                report.FacilityIncr = report.Facility > dashboardHistory.FacilityCount ? DashBoardStatus.Increases : report.Facility < dashboardHistory.FacilityCount ? DashBoardStatus.Decrease : DashBoardStatus.Equals;
                report.LeadershipIncr = report.Leadership > dashboardHistory.CollegeLeadershipCount ? DashBoardStatus.Increases : report.Leadership < dashboardHistory.CollegeLeadershipCount ? DashBoardStatus.Decrease : DashBoardStatus.Equals;
                report.TeachingstaffIncr = report.Teachingstaff > dashboardHistory.TeachingStaffCOunt ? DashBoardStatus.Increases : report.Teachingstaff < dashboardHistory.TeachingStaffCOunt ? DashBoardStatus.Decrease : DashBoardStatus.Equals;
                report.ClassroomIncr = report.Classroom > dashboardHistory.ClassRoomCount ? DashBoardStatus.Increases : report.Classroom < dashboardHistory.ClassRoomCount ? DashBoardStatus.Decrease : DashBoardStatus.Equals;

                dashboardHistory.CollegeCount = report.College;
                dashboardHistory.FacilityCount = report.Facility;
                dashboardHistory.CollegeLeadershipCount = report.Leadership;
                dashboardHistory.TeachingStaffCOunt = report.Teachingstaff;
                dashboardHistory.ClassRoomCount = report.Classroom;

                _report.UpdateDashboardHistory(dashboardHistory);
            }
            
            return View(report);
        }

        //[Authorize(Roles = "Student")]
        public IActionResult StudentDashboard()
        {
            int collgeId = 0;
            var studentId = GetUserName();
            var student =_context.Student.FirstOrDefault(x => x.StudentId == studentId);
            var report = _report.FetchStudentDashBoardReport(student.CollegeID);
            //var collegeId = GetCollgeID();
            return View(report);
        }
    }
}
