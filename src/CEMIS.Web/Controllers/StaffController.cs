using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Data.ViewModel;
using CEMIS.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using CEMIS.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Headers;
using CEMIS.Utility.Util;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using CEMIS.Web.Utilities;

namespace CEMIS.Web.Controllers
{

    [Authorize]
    public class StaffController : BaseController
    {
        private readonly IStaff _staffRepository;
        private readonly IMainAdminRole _mainAdminRole;
        private readonly IStaffGradeLevel _staffGradeLevel;
        private IHostingEnvironment _hostingEnvironment;
        private readonly IStaffCategory _staffCategory;
        private readonly IStaffRank _staffRank;
        private readonly IGradeLevel _gradeLevel;
        private readonly ICertificate _certificate;
        private readonly IStaffType _staffType;
        private readonly ISelectFactory _selectListFactory;
        private readonly IDepartment _department;
        private readonly IBasicSalary _basicSalary;
        private readonly IAllowance _allowanceRepo;
        private readonly IStaffAllowance _staffAllowance;
        private readonly IStaffDueForPromotionAllowance _staffDueForPromotion;

        public StaffController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration, ISelectFactory selectListFactory, IStaffDueForPromotionAllowance staffDueForPromotion,
                               IStaffAllowance staffAllowance, IAllowance allowanceRepo, IDepartment department, IBasicSalary basicSalary,
                               IStaffCategory staffCategory,  IGradeLevel gradeLevel, ICertificate certificate, IStaffRank staffRank, IStaffType staffType,
                               IStaff staffRepository, IMainAdminRole mainAdminRole, IStaffGradeLevel staffGradeLevel, IHostingEnvironment hostingEnvironment) 
            : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _staffRepository = staffRepository;
            _mainAdminRole = mainAdminRole;
            _staffGradeLevel = staffGradeLevel;
            _hostingEnvironment = hostingEnvironment;
            _staffCategory = staffCategory;
            _staffRank = staffRank;
            _gradeLevel = gradeLevel;
            _certificate = certificate;
            _staffType = staffType;
            _selectListFactory = selectListFactory;
            _department = department;
            _basicSalary = basicSalary;
            _allowanceRepo = allowanceRepo;
            _staffAllowance = staffAllowance;
            _staffDueForPromotion = staffDueForPromotion;
        }
        public IActionResult Index()
        {
            var staff = _staffRepository.GetAllTeachingStaff();
            return View(staff);
        }

        [HttpGet]
        public IActionResult FindStaffCategory(long stafftypeid)
        {
            var category = _staffCategory.GetStaffCategoryById(stafftypeid).Select(categorys => new
            {
                id = categorys.Id,
                name = categorys.Name

            });
            //category

            return new JsonResult(category);
        }

        [HttpGet]
        public IActionResult GetBasicSalary(int gradelevel, int step)
        {
            var basicSalary = _basicSalary.GetBasicSalarysById(gradelevel, step).Amount;
            //category

            return new JsonResult(basicSalary);
        }

        public ActionResult GetAllowance()
        {
            var allowance = _allowanceRepo.GetAllAllowance(); //get list of allowance object
            return Json(allowance, new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpGet]
        public IActionResult FindStaffRank(long staffcategoryid)
        {
            var rank = _staffRank.GetStaffRankById(staffcategoryid).Select(Ranks => new
            {
                id = Ranks.Id,
                name = Ranks.Name
            });
            return new JsonResult(rank);
        }


        [HttpGet]
        public IActionResult FindStaffStep(int Level)
        {
            var rank = _gradeLevel.GetStep(Level);
               
            //category

            return new JsonResult(rank);
        }
        public IActionResult Create()
        {

            var adminlists = new List<string>();
            var model = new TeachingStaffViewModel();
            model.DateOfBirth = DateTime.Today;
            model.DateOfCurrentAppointment = DateTime.Today;
            model.DateOfFirstAppointment = DateTime.Today;
            var DueForPromotionOptions = _selectListFactory.GetBooleanSelectList(true);
            ViewBag.StaffType = _staffType.GetAllStaffType();
            ViewBag.AdminRoles = _mainAdminRole.GetAllAdminRole().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString(), Selected= adminlists.Contains(u.Id.ToString()) }).ToList();
            ViewBag.Department = _department.GetAllDepartment();
            ViewBag.Staffgradelevel = _staffGradeLevel.GetAllStaffGradeLevel();
            ViewBag.GradeLevel = _gradeLevel.GetAllGradeLevel();
            ViewBag.DueForPromotion = new SelectList(DueForPromotionOptions, "Value", "Text", "false");
            var sc = _staffCategory.GetStaffCategoryId(0);
            ViewBag.staffCategory = sc;
            var sr = _staffRank.GetStaffRankId(0);
            ViewBag.staffRank = sr;
          
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(TeachingStaffViewModel model)
        {

            model.Certificates = Uploads;
            model.StaffAllowances = Allowance;
            model.staffDueForPromotions = P_Allowance;
            if (model.Id > 0)
            {
                _staffRepository.UpdateTeachingStaff(model, true);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Staff Updated Successfully!", Title = "Staff Module", Type = NotificationsType.success });

            }
            else
            {
                _staffRepository.CreateTeachingStaff(model, true);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Staff Added Successfully!", Title = "Staff Module", Type = NotificationsType.success });

            }
            Uploads = null;
            Allowance = null;
            P_Allowance = null;
            return RedirectToAction("Index");
        }

        public IActionResult RetireStaff(long Id )
        {
            try
            {
                var staff = _staffRepository.GetTeachingStaffById(Id);
                if (staff.RetiredDate <= DateTime.Now)
                {
                    _staffRepository.RetireStaff(Id);
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Staff Retired Successfully!", Title = "Staff Module", Type = NotificationsType.success });
                    return RedirectToAction("Index");

                }
                else
                {
                    staff.IsRetired = false;
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Staff Retirement Date  is not Due Yet!", Title = "Staff Module", Type = NotificationsType.info });
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex )
            {

                throw ex ;
            }
         
        }
        public IActionResult Manage(long Id)
        {

            try
            {
                var adminlists = new List<string>();

                var DueForPromotionOptions = _selectListFactory.GetBooleanSelectList(true);
                ViewBag.AdminRoles = _mainAdminRole.GetAllAdminRole().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString(), Selected = adminlists.Contains(u.Id.ToString()) }).ToList();
                ViewBag.Staffgradelevel = _staffGradeLevel.GetAllStaffGradeLevel();
                ViewBag.StaffType = _staffType.GetAllStaffType();
                ViewBag.Department = _department.GetAllDepartment();
                ViewBag.GradeLevel = _gradeLevel.GetAllGradeLevel();
                var staff = _staffRepository.GetTeachingStaffById(Id);
                var sc = _staffCategory.GetStaffCategoryId(staff.Staffcategory);
                ViewBag.staffCategory = sc;
                var sr = _staffRank.GetStaffRankId(staff.Staffrank);
                ViewBag.staffRank = sr;
                var step = _gradeLevel.GetStep(staff.GradeLevel);
                ViewBag.Step = new SelectList(step, staff.Step);//step;

                var basicsalary = _basicSalary.GetBasicSalarysById(staff.GradeLevel, staff.Step);
                TeachingStaffViewModel teachingStaff = new TeachingStaffViewModel
                {
                    Id = staff.Id,
                    FirstName = staff.FirstName,
                    MiddleName = staff.MiddleName,
                    Lastname = staff.LastName,
                    gender = staff.Gender,
                    LecturerGrade = staff.LecturerGrade.ToString(),
                    MainAdminRole = staff.MainAdminRole.ToString(),
                    DateOfFirstAppointment = staff.DateOfFirstAppointment,
                    DateOfCurrentAppointment = staff.DateOfCurrentAppointment,
                    AcademicQualification = staff.AcademicQualification,
                    AcademicQualificationCertNo = staff.AcademicQualificationCertNo,
                    TeachingQualification = staff.TeachingQualification,
                    TeachingQualificationCertNo = staff.TeachingQualificationCertNo,
                    StaffFileNo = staff.StaffFileNo,
                    SourceOfSalary = staff.SourceOfSalary,
                    DateOfBirth = staff.DateOfBirth,
                    YearOfFirstAppointment = staff.YearOfFirstAppointment,
                    YearOfPresentAppointment = staff.YearOfPresentAppointment,
                    YearOfPostingToCollege = staff.YearOfPostingToCollege,
                    SubjectOfQualification = staff.SubjectOfQualification,
                    AreaOfSpecialization = staff.AreaOfSpecialization,
                    MainSubjectTaught = staff.MainSubjectTaught,
                    TeachingType = staff.TeachingType,
                    InServiceTraining = staff.InServiceTraining,
                    staffCategory = staff.Staffcategory.ToString(),
                    staffRank = staff.Staffrank.ToString(),
                    staffType = staff.Stafftype,
                    GradeLevel = staff.GradeLevel.ToString(),
                    step = staff.Step.ToString(),
                    retiredDate = staff.RetiredDate,
                    basicSalary = Convert.ToInt32(basicsalary.Amount),
                    gradeLevelPromotion = staff.GradeLevelPromotion,
                    stepPromotion = staff.StepPromotion.ToString(),
                    basicsalaryPromotion = staff.BasicsalaryPromotion,
                    awardingInstitutionforHighestQualification = staff.AwardingInstitutionforHighestQualification,
                    awardingInstitutionforHighestTeachingQualification = staff.AwardingInstitutionforHighestTeachingQualification,
                    department = staff.Departments,

                };
                ViewBag.DueForPromotion = new SelectList(DueForPromotionOptions, "Value", "Text", staff.DueForPromotion.ToString());
                return View("Create", teachingStaff);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        //public IActionResult Delete(long Id)
        //{
        //    _staffRepository.DeleteTeachingStaff(Id , true);
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public IActionResult GetUploads(long StaffId)
        {
            var uploads = _certificate.GetCertificateById(StaffId).Select(x=> new CertificatesViewModel {
                FilePath = x.Url,
                Name = x.Name,
                Id= x.Id,

            }).ToList() ;
            Uploads = uploads;
            var resp = new
            {
                Success = true,
                Data = uploads
            };
            return new JsonResult(resp);
        }


        [HttpGet]
        public IActionResult GetAllowances(long StaffId)

        {
            var allowance = _staffAllowance.GetStaffAllowanceById(StaffId).Where(x=> x.IsBasicSalary==false).Select(x => new StaffAllowanceViewModel
            {
                name = x.Name,
                amount = x.Amount,
                AllowanceId = x.AllowanceId,
                Id = x.Id,

            }).ToList();
            Allowance = allowance;
            var resp = new
            {
                Success = true,
                Data = allowance
            };
            return new JsonResult(resp);
        }

        [HttpGet]
        public IActionResult P_GetAllowances(long StaffId)

        {
            var allowance = _staffDueForPromotion.GetStaffDueForPromotionAllowanceById(StaffId).Select(x => new StaffDueForPromotionViewModel
            {
                name = x.Name,
                amount = x.Amount,
                AllowanceId = x.AllowanceId,
                Id = x.Id,

            }).ToList();
           P_Allowance  = allowance;
            var resp = new
            {
                Success = true,
                Data = allowance
            };
            return new JsonResult(resp);
        }
        public List<CertificatesViewModel> Uploads
        {
            get
            {
                var _uploads = new List<CertificatesViewModel>();
                if (HttpContext.Session.Get<List<CertificatesViewModel>>("StaffUploads") != null)
                {
                    _uploads = HttpContext.Session.Get<List<CertificatesViewModel>>("StaffUploads");
                }

                return _uploads;
            }
            set
            {
                HttpContext.Session.Set("StaffUploads", value);
            }
        }

        public List<StaffDueForPromotionViewModel> P_Allowance
        {
            get
            {
                var _p_allowances = new List<StaffDueForPromotionViewModel>();
                if (HttpContext.Session.Get<List<StaffDueForPromotionViewModel>>("P_StaffAllowance") != null)
                {
                    _p_allowances = HttpContext.Session.Get<List<StaffDueForPromotionViewModel>>("P_StaffAllowance");
                }

                return _p_allowances;
            }
            set
            {
                HttpContext.Session.Set("P_StaffAllowance", value);
            }
        }

        public List<StaffAllowanceViewModel> Allowance
        {
            get
            {
                var _allowances = new List<StaffAllowanceViewModel>();
                if (HttpContext.Session.Get<List<StaffAllowanceViewModel>>("StaffAllowance") != null)
                {
                    _allowances = HttpContext.Session.Get<List<StaffAllowanceViewModel>>("StaffAllowance");
                }

                return _allowances;
            }
            set
            {
                HttpContext.Session.Set("StaffAllowance", value);
            }
        }

        public ActionResult RemoveAllowances(int index)
        {
            if (Allowance.Any())
            {
                var _allowance = Allowance;
                _allowance.RemoveAt(index);

                Allowance = _allowance;
                return this.Content("Success");
            }

            return this.Content("Fail");
        }

        public ActionResult RemoveP_Allowances(int index)
        {
            if (P_Allowance.Any())
            {
                var P_allowance = P_Allowance;
                P_allowance.RemoveAt(index);

                P_Allowance = P_allowance;
                return this.Content("Success");
            }

            return this.Content("Fail");
        }

        public ActionResult RemoveUpload( int index)
        {
            if (Uploads.Any())
            {
                var _uploads = Uploads;
                _uploads.RemoveAt(index);

                Uploads = _uploads;
                return this.Content("Success");
            }

            return this.Content("Fail");
        }
        [HttpPost]
        public ActionResult OnPostUpload(string Name, IFormFile FileUpload)
        {
            if (!string.IsNullOrEmpty(Name) && FileUpload != null)
            {

                var _uplaods = Uploads;

                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                string fileName = ContentDispositionHeaderValue.Parse(FileUpload.ContentDisposition).FileName.Trim('"');
                string fullPath = Path.Combine(newPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    FileUpload.CopyTo(stream);
                }

                var _upload = new CertificatesViewModel()
                {
                    FilePath = FileUpload.FileName,
                    Name = Name
                };

                _uplaods.Add(_upload);
                Uploads = _uplaods;
                return this.Content("Success");
            }
            return this.Content("Fail");
        }

        [HttpPost]
        public ActionResult OnPostStaffAlowance(string Name, decimal Amount)
        {
            if (!string.IsNullOrEmpty(Name) && Amount >= 0)
            {

                var _allowances = Allowance;


                var allowanceid = _allowanceRepo.GetAllowanceId(Name);
                
                var _allowance = new StaffAllowanceViewModel()
                {
                    name = Name,
                    amount = Amount,
                    AllowanceId = allowanceid.Id
                };
                
                _allowances.Add(_allowance);
               Allowance = _allowances;
                return this.Content("Success");
            }
            return this.Content("Fail");
        }

        [HttpPost]
        public ActionResult PromotionStaffAlowance(string Name, decimal Amount)
        {
            if (!string.IsNullOrEmpty(Name) && Amount >= 0)
            {

                var p_allowances = P_Allowance;


                var p_allowanceid = _allowanceRepo.GetAllowanceId(Name);
                var p_allowance = new StaffDueForPromotionViewModel()
                {
                    name = Name,
                    amount = Amount,
                    AllowanceId = p_allowanceid.Id
                };

                p_allowances.Add(p_allowance);
                P_Allowance = p_allowances;
                return this.Content("Success");
            }
            return this.Content("Fail");
        }
    }
}

    
