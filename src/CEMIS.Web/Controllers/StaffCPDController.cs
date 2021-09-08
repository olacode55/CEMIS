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
    public class StaffCPDController : BaseController
    {
        private readonly IStaffCPDAssesment _staffCPD;
        private readonly IStaff _staff;
        private readonly IAcademicSession _academicSession;

        public StaffCPDController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, IStaffCPDAssesment staffCPD, IStaff staff, IAcademicSession academicSession) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _staffCPD = staffCPD;
            _staff = staff;
            _academicSession = academicSession;
        }
        public IActionResult Index()
        {
            var staffCPDAssesments = _staffCPD.GetAllStaffCPDAssesment();
            var staff = _staff.GetAllTeachingStaff();
            var academicSession = _academicSession.GetAll();
            var query = from sa in staffCPDAssesments
                        join acs in academicSession on sa.SessionId equals acs.Id
                        join s in staff on sa.StaffId equals s.Id into sts
                        from st in sts.DefaultIfEmpty()
                        select new StaffCPDAssesmentViewModel
                        {
                            Id = sa.Id,
                            StaffId = sa.StaffId,
                            Filename = sa.FileName,
                            Fullname = st.FirstName + " " + st.MiddleName + " " + st.LastName,
                            SessionId = sa.SessionId,
                            Session = acs.AcademicPeriod,
                            Semester = sa.Semester,
                            FormType = sa.FormType,
                            Date = sa.Date


                        };



            return View(query);
        }
        public IActionResult Create()
        {
            ViewBag.Staff = _staff.GetAllTeachingStaff().Select(x => new SelectListItem
            {
                Text = x.FirstName + " " + x.MiddleName + " " + x.LastName,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.Session = _academicSession.GetAcademicSessionList();
            var model = new StaffCPDAssesmentViewModel()
            {

            };

            return PartialView("_Create", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StaffCPDAssesmentViewModel staffCPDAssesment)
        {


            if (staffCPDAssesment.File == null)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "File cannot be empty!", Title = "Staff Assememnt", Type = NotificationsType.info });
                return RedirectToAction("Index");
            }
            //var extension = Path.GetExtension(staffCPDAssesment.File.FileName);
            var size = staffCPDAssesment.File.Length;
            //if (!extension.ToLower().Equals(".pdf") && !extension.ToLower().Equals(".jpg"))
            //{
            //    TempData["Notification"] = JsonConvert.SerializeObject(new Notification {   Message = $"File Format: {extension} is not valid.",Title = "Staff Assememnt", Type = NotificationsType.info });
            //    return RedirectToAction("Index");
            //}
            if (size > (5 * 1024 * 1024))
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"File Size: {size} is bigger than 5MB.", Title = "Staff Assememnt", Type = NotificationsType.info });
                return RedirectToAction("Index");

            }

            if (staffCPDAssesment.Id > 0)
            {
                _staffCPD.UpdateStaffCPDAssesment(staffCPDAssesment, true);
            }
            else
            {
                _staffCPD.CreateStaffCPDAssesment(staffCPDAssesment, true);
            }
            //this.AddNotification(ResponseSuccessMessageUtility.RecordSaved, NotificationType.SUCCESS);
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
            _staffCPD.DeleteStaffCPDAssesment(Id);
            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Staff CPD Removed Successfully", Title = "Staff Assememnt", Type = NotificationsType.info });

            return RedirectToAction("Index");
        }
    }
}