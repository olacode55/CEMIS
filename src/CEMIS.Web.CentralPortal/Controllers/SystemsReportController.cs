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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.CentralPortal.Controllers
{
    public class SystemsReportController : BaseController
    {
        private ISystemsReport _systemsReportRepository;
        private IRepository<User> _userRepository;
        public SystemsReportController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IHttpContextAccessor accessor, IActivityLog logActivityRepo,
                               IActionContextAccessor actionContextAccessor , ISystemsReport systemsReportRepository , IRepository<User> userRepository) : base(userManager, signInManager,
                               roleManager, configuration, accessor, actionContextAccessor, logActivityRepo)
        {
            _systemsReportRepository = systemsReportRepository;
            _userRepository = userRepository;
        }
        public IActionResult AuditReport()
        {
            
            var model = new List<ActivityLogViewModel>();
            UserViewBags();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AuditReport(AuditReportFilterVM auditFilterVM)
        {
            string msg = "Record found";
            //UserViewBags();
            var auditData = _systemsReportRepository.AuditReport(auditFilterVM);

            if (auditData.Count() == 0)
            {
                msg = "No record found";
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = msg, Title = "Report", Type = NotificationsType.Danger });
                LogActivity(msg, auditFilterVM).ConfigureAwait(true);
                return RedirectToAction("AuditReport");
            }
            LogActivity(msg, auditFilterVM).ConfigureAwait(true);
            return View(auditData);
        }

        public void UserViewBags()
        {
            var users = _userRepository.All().Where(x => x.UserType == (byte)Utility.UserType.Admin).Select(x => new ModelViewBagDTO()
            {
                Id = x.Id,
                Value = x.Firstname + " " + x.Lastname

            }).ToList();

            ViewBag.UserName = new SelectList(users, "Id", "Value");
        }
    }
}