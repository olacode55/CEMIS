using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business;
using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.Controllers
{
    [Authorize]
    public class CollegeCPDController : BaseController
    {
        private readonly ICollegeCPDAssesment _collegeCPD;
        private readonly ICollege _college;
        private readonly IAcademicSession _academicSession;

        public CollegeCPDController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, ICollegeCPDAssesment collegeCPD, ICollege college, IAcademicSession academicSession) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _collegeCPD = collegeCPD;
            _college = college;
            _academicSession = academicSession;
        }
        public IActionResult Index()
        {
            var collegeCPDAssesments = _collegeCPD.GetAllCollegeCPDAssesment();
            var colleges = _college.GetAllColleges();
            var academicSession = _academicSession.GetAll();
            var query = from ca in collegeCPDAssesments
                        join acs in academicSession on ca.SessionId equals acs.Id
                        join c in colleges on ca.CollegeID equals c.Id into cts
                        from ct in cts.DefaultIfEmpty()
                        select new CollegeCPDAssesmentViewModel
                        {
                            Id = ca.Id,
                            CollegeID = ca.CollegeID,
                            Filename = ca.FileName,
                            CollegeName = ct.Name,
                            SessionId = ca.SessionId,
                            Session = acs.AcademicPeriod,
                            Semester = ca.Semester,
                            FormType = ca.FormType,
                            Date = ca.Date

                        };
            return View(query);
        }
        public IActionResult Create()
        {
            ViewBag.College = _college.GetAllColleges().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            ViewBag.Session = _academicSession.GetAcademicSessionList();
            var model = new CollegeCPDAssesmentViewModel();
            return PartialView("_Create", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CollegeCPDAssesmentViewModel collegeCPDAssesment)
        {
            if (collegeCPDAssesment.File == null)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "File cannot be empty!", Title = "College Assememnt", Type = NotificationsType.info });
                return RedirectToAction("Index");
            }
            // var extension = Path.GetExtension(staffCPDAssesment.File.FileName);
            var size = collegeCPDAssesment.File.Length;
            //if (!extension.ToLower().Equals(".pdf") && !extension.ToLower().Equals(".jpg"))
            //{
            //    TempData["Notification"] = JsonConvert.SerializeObject(new Notification {   Message = $"File Format: {extension} is not valid.",Title = "Staff Assememnt", Type = NotificationsType.info });
            //    return RedirectToAction("Index");
            //}
            if (size > (5 * 1024 * 1024))
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"File Size: {size} is bigger than 5MB.", Title = "College Assememnt", Type = NotificationsType.info });
                return RedirectToAction("Index");

            }

            if (collegeCPDAssesment.Id == 0)
            {
                _collegeCPD.CreateCollegeCPDAssesment(collegeCPDAssesment, true);
            }
            return RedirectToAction("index");
        }
        //public IActionResult Manage(long Id)
        //{
        //    ViewBag.Staff = _staff.GetAllTeachingStaff().Select(x => new SelectListItem
        //    {
        //        Text = x.FirstName + " " + x.MiddleName + " " + x.LastName,
        //        Value = x.Id.ToString()
        //    }).ToList();
        //    var staffCPDs = _staffCPD.GetStaffCPDAssesmentById(Id);
        //    CollegeLeadershipViewModel college = new CollegeLeadershipViewModel();

        //    return View("Create", staffCPDs);

        //}

        public IActionResult Delete(long Id)
        {
            _collegeCPD.DeleteCollegeCPDAssesment(Id);
            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"College CPD Removed Successfully", Title = "College Assememnt", Type = NotificationsType.info });

            return RedirectToAction("Index");
        }
    }
}