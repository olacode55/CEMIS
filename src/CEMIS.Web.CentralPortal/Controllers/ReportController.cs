using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemis.Business.Central.Interface;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility;
using CEMIS.Utility.CentralReportFilterVM;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.CentralPortal.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.CentralPortal.Controllers
{
    [Authorize]
    public class ReportController : BaseController
    {
        private readonly IReport _reportRepository;
        private readonly ICollege _collegeRepo;
        private readonly IAcademicSession _sessionRepo;
        public ReportController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IHttpContextAccessor accessor, IActivityLog logActivityRepo,
                               IActionContextAccessor actionContextAccessor, IReport reportRepository, ICollege collegeRepo, IAcademicSession sessionRepo) : base(userManager, signInManager,
                               roleManager, configuration, accessor, actionContextAccessor, logActivityRepo)
        {
            _reportRepository = reportRepository;
            _collegeRepo = collegeRepo;
            _sessionRepo = sessionRepo;
        }

        public IActionResult Index()
        {
            
            return View();
        }


        public IActionResult TeachingStaff()
        {
            CollegeViewBags();
            MainAdminRoleViewBags();
            var model = new List<TeachingStaffViewModel>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TeachingStaff(TeachingStaffReportVM teachingStaffVM)
        {
            string msg = "Record found";
            CollegeViewBags();
            MainAdminRoleViewBags();
            var teachingstaffs = _reportRepository.TeachingStaff(teachingStaffVM);

            if(teachingstaffs.Count() == 0)
            {
                msg = "No record found";
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = msg, Title = "Report", Type = NotificationsType.Danger });
                LogActivity(msg, teachingStaffVM).ConfigureAwait(true);
                return RedirectToAction("TeachingStaff");
            }
            LogActivity(msg, teachingStaffVM).ConfigureAwait(true);
            return View(teachingstaffs);
        }

        public IActionResult StudentReport()
        {
            CollegeViewBags();
            var model = new List<StudentViewModel>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StudentReport(StudenReporttFilterVM studentFilterVM)
        {
            string msg = "Record found";
            CollegeViewBags();
            MainAdminRoleViewBags();
            var student = _reportRepository.StudentReport(studentFilterVM);

            if (student.Count() == 0)
            {
                msg = "No record found";
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = msg, Title = "Report", Type = NotificationsType.Danger });
                LogActivity(msg, studentFilterVM).ConfigureAwait(true);
                return RedirectToAction("StudentReport");
            }

            LogActivity(msg, studentFilterVM).ConfigureAwait(true);
            return View(student);
        }
        public IActionResult CollegeLeadershipReport()
        {
            CollegeViewBags();
            var model = new List<CollegeLeadershipViewModel>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CollegeLeadershipReport(LeadershipReportFilterVM leadershipFilterVM)
        {
            string msg = "Record found";
            CollegeViewBags();
            var report = _reportRepository.CollegeLeadership(leadershipFilterVM);
            if (report.Count() == 0)
            {
                msg = "No record found";
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = msg, Title = "Report", Type = NotificationsType.Danger });
                LogActivity(msg, leadershipFilterVM).ConfigureAwait(true);
                return RedirectToAction("CollegeLeadershipReport");
            }

            LogActivity(msg, leadershipFilterVM).ConfigureAwait(true);
            return View(report);
        }

        public IActionResult CollegeFacilityReport()
        {
            CollegeViewBags();
            var model = new List<CollegeFacilityVM>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CollegeFacilityReport(FacilityReportFilter facilityReportFilter)
        {
            string msg = "Record found";
            CollegeViewBags();
            var report = _reportRepository.CollegeFacility(facilityReportFilter);

            if (report.Count() == 0)
            {
                msg = "No record found";
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = msg, Title = "Report", Type = NotificationsType.Danger });
                LogActivity(msg, facilityReportFilter).ConfigureAwait(true);
                return RedirectToAction("CollegeLeadershipReport");
            }
            LogActivity(msg, facilityReportFilter).ConfigureAwait(true);
            return View(report);
        }

        public IActionResult CollegeInformationReport()
        {
            var model = new List<College>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CollegeInformationReport(string collegeName)
        {
            string msg = "Record found";
            var report = _reportRepository.CollegeInformation(collegeName);

            if (report.Count() == 0)
            {
                msg = "No record found";
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = msg, Title = "Report", Type = NotificationsType.Danger });
                LogActivity(msg, collegeName).ConfigureAwait(true);
                return RedirectToAction("CollegeLeadershipReport");
            }
            LogActivity(msg, collegeName).ConfigureAwait(true);
            return View(report);
        }

        public IActionResult ViewCollegeDetails(long collegeId)
        {
            var collegeSummary = _reportRepository.GetCollegeSummary(collegeId);
            LogActivity("View", collegeId).ConfigureAwait(true);
            return View("CollegeInformationDetails", collegeSummary);

        }

        public IActionResult CollegeProgramReport()
        {
            CollegeViewBags();
            var model = new List<ProgramViewModel>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CollegeProgramReport(ProgramReportFilterVM programFilterVM)
        {
            string msg = "Record found";
            var report = _reportRepository.CollegePrograme(programFilterVM);

            if (report.Count() == 0)
            {
                msg = "No record found";
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = msg, Title = "Report", Type = NotificationsType.Danger });
                LogActivity(msg, programFilterVM).ConfigureAwait(true);
                return RedirectToAction("CollegeProgramReport");
            }

            LogActivity(msg, programFilterVM).ConfigureAwait(true);
            return View(report);
        }


        public IActionResult CollegeCourseReport()
        {
            CollegeViewBags();
            var model = new List<CourseOfferedDTO>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CollegeCourseReport(CourseReportFilterVM courseFilterVM)
        {
            string msg = "Record found";
            var report = _reportRepository.CollegeCourseReport(courseFilterVM);

            if (report.Count() == 0)
            {
                msg = "No record found";
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = msg, Title = "Report", Type = NotificationsType.Danger });
                LogActivity(msg, courseFilterVM).ConfigureAwait(true);
                return RedirectToAction("CollegeCourseReport");
            }

            LogActivity(msg, courseFilterVM).ConfigureAwait(true);
            return View(report);
        }



        public IActionResult StudentResultReport()
        {
            CollegeViewBags();
            var model = new List<ResultViewModel>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StudentResultReport(ResultReportFilterVM resultFilterVM)
        {
            string msg = "Record found";
            var report = _reportRepository.StudentResultReport(resultFilterVM);

            if (report.Count() == 0)
            {
                msg = "No record found";
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = msg, Title = "Report", Type = NotificationsType.Danger });
                LogActivity(msg, resultFilterVM).ConfigureAwait(true);
                return RedirectToAction("StudentResultReport");
            }

            LogActivity(msg, resultFilterVM).ConfigureAwait(true);
            return View(report);
        }



        public IActionResult CouncilMemberReport()
        {
            CollegeViewBags();
            var model = new List<CouncilMemberViewModel>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CouncilMemberReport(CommitteeMembersFilterVM committeeFilterVM)
        {
            string msg = "Record found";
            var report = _reportRepository.CouncilMembersReport(committeeFilterVM);

            if (report.Count() == 0)
            {
                msg = "No record found";
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = msg, Title = "Report", Type = NotificationsType.Danger });
                LogActivity(msg, committeeFilterVM).ConfigureAwait(true);
                return RedirectToAction("CouncilMemberReport");
            }

            LogActivity(msg, committeeFilterVM).ConfigureAwait(true);
            return View(report);
        }


        public IActionResult CommitteeMemberReport()
        {
            CollegeViewBags();
            var model = new List<CommitteMemberViewModel>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CommitteeMemberReport(CommitteeMembersFilterVM committeeFilterVM)
        {
            string msg = "Record found";
            var report = _reportRepository.CommitteeMembersReport(committeeFilterVM);

            if (report.Count() == 0)
            {
                msg = "No record found";
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = msg, Title = "Report", Type = NotificationsType.Danger });
                LogActivity(msg, committeeFilterVM).ConfigureAwait(true);
                return RedirectToAction("CommitteeMemberReport");
            }

            LogActivity(msg, committeeFilterVM).ConfigureAwait(true);
            return View(report);
        }


        public JsonResult GetSessionbyCollegeId(int collegeId)
        {
            var data = _sessionRepo.GetSessionByCollegeId(collegeId);

            return Json(data);
        }

        private void CollegeViewBags()
        {
            var users = _collegeRepo.GetAllColleges().Select(x => new ModelViewBagDTO()
            {
                Id = x.Id,
                Value = x.Name

            }).ToList();

            ViewBag.College = new SelectList(users, "Id", "Value");
        }

        private void MainAdminRoleViewBags()
        {
            var users = _collegeRepo.GetAllAminRoles().Select(x => new ModelViewBagDTO()
            {
                Id = x.Id,
                Value = x.Name

            }).ToList();

            ViewBag.MainAdminRole = new SelectList(users, "Id", "Value");
        }
    }
}