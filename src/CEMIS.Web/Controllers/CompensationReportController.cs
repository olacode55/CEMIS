using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEMIS.Web.Controllers
{
    public class CompensationReportController : BaseController
    {
        private readonly ICompensationReport _compensation;

        public CompensationReportController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, ICompensationReport compensation) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _compensation = compensation;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
           ViewBag.Month = Enumerable.Range(1, 12).Select(i => new { I = i, M = DateTimeFormatInfo.CurrentInfo.GetMonthName(i) });
            var ddlYear = new List<int>();
            for (int i = 2010; i <= DateTime.Today.Year; i++)
            {
                ddlYear.Add(i);
            }
            ViewBag.Year = ddlYear;

            return View();
        }
        public IActionResult CommitCompensation(string month, string year)
        {
            if (string.IsNullOrEmpty(month) || string.IsNullOrEmpty(year))
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "An Error has ocuured!", Title = "Compensation Report", Type = NotificationsType.danger });
                return RedirectToAction("GetCompensation");
                //View("index");
            }
            var _report = _compensation.CheckCompensation(month, year);
            if (_report != null)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Compensation Report Already Generated for this Month and Year!", Title = "Compensation Report", Type = NotificationsType.danger });
                return RedirectToAction("Index");
            }
            _compensation.CommitCompensationReport(month, year);
            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Compensation Report Commited Successfully!", Title = "Compensation Report", Type = NotificationsType.success });
            return RedirectToAction("Index");
        }
            public IActionResult GetCompensation(string month, string year)
        {
            if (string.IsNullOrEmpty(month) || string.IsNullOrEmpty(year))
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "An Error has ocuured!", Title = "Compensation Report", Type = NotificationsType.danger });
                return RedirectToAction("Index");
                    //View("index");
            }

            //var _report = _compensation.CheckCompensation(month, year);
            //if (_report != null)
            //{
            //    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Compensation Report Already Generated for this Month and Year!", Title = "Compensation Report", Type = NotificationsType.danger });
            //    return RedirectToAction("Index");
            //}

            var report = _compensation.GetCompensation(month, year);

            var ReportDic = new Dictionary<string, List<CompensationReportViewModel>>();

            var parentAllownce = report.Where(x => x.ParentId.GetValueOrDefault() == 0).ToList();

            foreach (var item in parentAllownce)
            {
                var childrenAllowance = report.Where(x => x.ParentId == item.AllowanceId).ToList();
                ReportDic.Add(item.Name, childrenAllowance);
            }
            ViewBag.Month = month;
            ViewBag.Year = year;
            return View(ReportDic);
           
        }
    }
}
