using System;
using System.Collections.Generic;
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
using Microsoft.Extensions.Configuration;

namespace CEMIS.Web.Controllers
{
    [Authorize]
    public class CollegeLeadershipController : BaseController
    {
        private readonly ICollegeLeadership _collegeLeadership;
        private readonly ICouncilSession _councilSession;

        public CollegeLeadershipController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, ICollegeLeadership collegeLeadership, ICouncilSession councilSession) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _collegeLeadership = collegeLeadership;
            _councilSession = councilSession;
        }
        public IActionResult Index()
        {
            var collegeleadership = _collegeLeadership.GetAllcollegeLeadership();
           
            return View(collegeleadership);
        }
        public IActionResult Create()
        {
            ViewBag.Session = _councilSession.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CollegeLeadershipViewModel collegeLeadership)
        {
            if (collegeLeadership.Id > 0)
            {
                _collegeLeadership.UpdateCollegeLeadership(collegeLeadership, true);
            }
            else
            {
                _collegeLeadership.CreateCollegeLeadership(collegeLeadership, true);
            }
            //this.AddNotification(ResponseSuccessMessageUtility.RecordSaved, NotificationType.SUCCESS);
            return RedirectToAction("index");
        }
        public IActionResult Manage(long Id)
        {
            ViewBag.Session = _councilSession.GetAll();
            var collegeLeadership = _collegeLeadership.GetCollegeLeadershipById(Id);
            CollegeLeadershipViewModel college = new CollegeLeadershipViewModel();
            var sessionname = _councilSession.GetById(Convert.ToInt32(collegeLeadership.Session));
            college.DateOfBirth = collegeLeadership.DateOfBirth;
            college.Role = collegeLeadership.Role;
            college.DateLeft = collegeLeadership.DateLeft;
            college.Session = collegeLeadership.Session.ToString();
            college.Name = collegeLeadership.Name;
            college.CouncilMemberPhone1 = collegeLeadership.CouncilMemberPhone1;
            college.CouncilMemberPhone2 = collegeLeadership.CouncilMemberPhone2;
            college.CouncilMemberEmail = collegeLeadership.CouncilMemberEmail;
            college.CouncilMemberPostalAddress = collegeLeadership.CouncilMemberPostalAddress;
            college.DateAppointed = collegeLeadership.DateAppointed;
            return View("Create", college);
            
        }

        public IActionResult Delete(long Id)
        {
            _collegeLeadership.DeleteCollegeLeadership(Id, true);
           // this.AddNotification(ResponseSuccessMessageUtility.RecordDeleted, NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }
    }
}