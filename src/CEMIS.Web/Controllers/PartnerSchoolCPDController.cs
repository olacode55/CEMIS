using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.Controllers
{
    public class PartnerSchoolCPDController : BaseController
    {
        private readonly IPartnerSchoolCPDAssesment _partnerSchoolCPDAssesment;
        private readonly IPartnerSchool _partnerSchool;
        private readonly IAuthUser _authUser;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAcademicSession _academicSessionRepository;

        public PartnerSchoolCPDController(IPartnerSchoolCPDAssesment partnerSchoolCPDAssesment, IPartnerSchool partnerSchool,
            IAuthUser authUser, IHostingEnvironment hostingEnvironment, UserManager<User> userManager, IConfiguration configuration,
            IAcademicSession academicSessionRepository, SignInManager<User> signInManager, RoleManager<Role> roleManager)
            : base(userManager, signInManager, roleManager, configuration)
        {
            _partnerSchoolCPDAssesment = partnerSchoolCPDAssesment;
            _partnerSchool = partnerSchool;
            _authUser = authUser;
            _hostingEnvironment = hostingEnvironment;
            _academicSessionRepository = academicSessionRepository;
        }
        public IActionResult Index()
        {
            ViewBag.ParternSchools = _partnerSchool.GetPartnerSchoolList();
            ViewBag.AcademicSession = _academicSessionRepository.GetAcademicSessionList();
            ViewBag.FormType = _academicSessionRepository.GetAcademicSessionList();
            var partnerSchoolCPDAssessments = _partnerSchoolCPDAssesment.GetAll();
            var partnerSchools = _partnerSchool.GetAll();
            var academicSession = _academicSessionRepository.GetAll();

            var model = (from psa in partnerSchoolCPDAssessments
                         join ps in partnerSchools on psa.PartnerSchoolId equals ps.Id
                         join acs in academicSession on psa.AcademicYearId equals acs.Id
                         select new PartnerSchoolCPDAssesmentViewModel()
                         {
                             Id = psa.Id,
                             PartnerSchool = ps.Name,
                             FileName = psa.FileName,
                             FilePath = psa.FilePath,
                             AcademicYearId = psa.Id,
                             AcademicYear = acs.AcademicPeriod,
                             Semester = psa.Semester,
                             FormType = psa.FormType,
                             Date = psa.Date.Date,



                         }).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.ParternSchools = _partnerSchool.GetPartnerSchoolList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PartnerSchoolCPDAssesmentViewModel model)
        {
            if (model.PartnerSchoolId < 1)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Partner School not selected", Title = "Partner School CPD", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            if (model.AcademicYearId < 1)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic year not selected", Title = "Partner School CPD", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            //if (model.FormType == "")
            //{
            //    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"File Not Selected", Title = "Partner School CPD", Type = NotificationsType.danger });
            //    return RedirectToAction(nameof(Index));
            //}

            if (model.File == null || model.File.Length == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"File Not Selected", Title = "Partner School CPD", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            if (model.File.Length > (5 * 1028 * 1028))
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"File should not be more than 5MB", Title = "Partner School CPD", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            string fileName = "";
            string uploadDir = "";

            if (model.File != null && model.File.Length > 0)
            {
                var extension = Path.GetExtension(model.File.FileName);
                var webRootPath = _hostingEnvironment.WebRootPath;
                uploadDir = Path.Combine(webRootPath + @"/Upload/PartnerSchoolCPD");

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                fileName = Path.GetFileNameWithoutExtension(model.File.FileName) + "_" + DateTime.UtcNow.ToString("yyyymmssfff") + extension;
                var path = Path.Combine(uploadDir, fileName);
                await model.File.CopyToAsync(new FileStream(path, FileMode.Create));

            }

            var partnerSchoolCPDAssesment = new PartnerSchoolCPDAssesment()
            {
                FileName = fileName,
                FilePath = @"/Upload/PartnerSchoolCPD/" + fileName,
                PartnerSchoolId = model.PartnerSchoolId,
                FormType = model.FormType,
                AcademicYearId = model.AcademicYearId,
                Date = model.Date.Date,
                Semester = model.Semester,
                IsActive = true,
                IsDeleted = false,
                CreatedBy = long.Parse(_authUser.UserId),
                DateCreated = DateTime.Now,
                IsSynched = false
            };
            await _partnerSchoolCPDAssesment.CreateAsync(partnerSchoolCPDAssesment);

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Created Successfully", Title = "Partner School CPD", Type = NotificationsType.success });
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(long Id)
        {
            //var webRootPath = _hostingEnvironment.WebRootPath;
            //var data = _partnerSchoolCPDAssesment.GetById(Id);
            //var fullPath = webRootPath + data.FilePath;

            //System.IO.File.Delete(fullPath);

            _partnerSchoolCPDAssesment.Delete(Id);

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Deleted Successfully", Title = "Partner School CPD", Type = NotificationsType.success });
            return RedirectToAction(nameof(Index));
        }

    }
}