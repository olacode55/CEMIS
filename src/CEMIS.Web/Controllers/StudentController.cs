using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO.Compression;
using CEMIS.Business.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;
using OfficeOpenXml;
using CEMIS.Utility;
using CEMIS.Web.Utilities;

namespace CEMIS.Web.Controllers
{

    [Authorize]
    public class StudentController : BaseController
    {
        private readonly IStudent _studentRepository;
        private readonly IProgram _programRepository;
        private readonly IResult _resultRepository;
        private readonly IAcademicSession _academicSessionRepository;
        private readonly ILevel _levelRepository;
        private readonly ICourse _courseRepository;
        private readonly ICollege _collegeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAuthUser _authUser;
        private readonly CancellationToken cancellationToken;

        public StudentController(IStudent studentRepository, IProgram programRepository, IResult resultRepository,
            IAcademicSession academicSessionRepository, ILevel levelRepository, ICourse courseRepository,
            ICollege collegeRepository, IHostingEnvironment hostingEnvironment, IAuthUser authUser,
            UserManager<User> userManager, IConfiguration configuration,
            SignInManager<User> signInManager, RoleManager<Role> roleManager)
            : base(userManager, signInManager, roleManager, configuration)
        {
            _studentRepository = studentRepository;
            _programRepository = programRepository;
            _resultRepository = resultRepository;
            _academicSessionRepository = academicSessionRepository;
            _levelRepository = levelRepository;
            _courseRepository = courseRepository;
            _collegeRepository = collegeRepository;
            _hostingEnvironment = hostingEnvironment;
            _authUser = authUser;
        }
        public IActionResult Index()
        {
            var model = new StudentFormViewModel();

            ViewBag.Program = _programRepository.GetProgramList();
            ViewBag.AcademicSession = _academicSessionRepository.GetAcademicSessionList();

            return View(model);

        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(StudentFormViewModel model)
        {
            ViewBag.Program = _programRepository.GetProgramList();
            ViewBag.AcademicSession = _academicSessionRepository.GetAcademicSessionList();

            if (model.AcademicSessionId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Sesseion Not selected", Title = "Student Upload", Type = NotificationsType.danger });
                return View("Index", model);
            }

            if (model.ProgramId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Program Not selected", Title = "Student Upload", Type = NotificationsType.danger });
                return View("Index", model);
            }

            ViewBag.Program = _programRepository.GetProgramList();
            ViewBag.AcademicSession = _academicSessionRepository.GetAcademicSessionList();


            var students = _studentRepository.GetStudentsBySessionAndProgram(model.ProgramId, model.AcademicSessionId)
                .Select(x => new StudentViewModel
                {
                    Id = x.Id,
                    AppRefNumber = x.AppRefNumber,
                    Surname = x.Surname,
                    OtherNames = x.OtherNames,
                    ContactAddress = x.ContactAddress,
                    Disability = x.Disability,
                    District = x.District,
                    DOB = x.DOB,
                    Gender = x.Gender,
                    HomeTown = x.HomeTown,
                    IsActive = x.IsActive,
                    IsDeleted = x.IsDeleted,
                    LanguagesSpoken = x.LanguagesSpoken,
                    MaritalStatus = x.MaritalStatus,
                    POB = x.POB,
                    //previousEducationsViewModel = x.previousEducations,
                    //Passport = x.Passport,
                    Region = x.Region,
                    Religion = x.Religion,
                    Result = x.Result,
                    FirstChoiceCollege = x.FirstChoiceCollege,
                    FirstChoiceProgram = x.FirstChoiceProgram,
                    SecondChoiceCollege = x.SecondChoiceCollege,
                    SecondChoiceProgram = x.SecondChoiceProgram,
                    ThirdChoiceCollege = x.ThirdChoiceCollege,
                    ThreeChoiceProgram = x.ThreeChoiceProgram,
                    ParentParticulars = x.ParentParticulars,
                    TelephoneNumber = x.TelephoneNumber,
                    CreatedBy = x.CreatedBy,
                    DateCreated = x.DateCreated,
                    DateUpdated = x.DateUpdated,
                    UpdatedBy = x.UpdatedBy
                }).ToList();


            if (students == null)
            {
                model.Students = new List<StudentViewModel>();
            }
            else
            {
                model.Students = students;
            }


            return View(model);


        }

        public IActionResult RouteToIndex(long Id)
        {
            var details = _studentRepository.GetStudentById(Id);
            var model = new StudentFormViewModel();
            model.ProgramId = details.ProgramId;
            model.AcademicSessionId = details.AcademicSessionId;
            return RedirectToAction("Index", model);
        }

        public IActionResult StudentDetail(string AppRefNumber)
        {

            if (!string.IsNullOrEmpty(AppRefNumber))
            {
                var student = _studentRepository.GetStudentByRef(AppRefNumber);
                if (student == null)
                {
                    return NotFound();
                }

                var model = new StudentViewModel();

                model.Id = student.Id;
                model.AppRefNumber = student.AppRefNumber;
                model.RegistrationPin = student.RegistrationPin;
                model.Surname = student.Surname;
                model.OtherNames = student.OtherNames;
                model.ContactAddress = student.ContactAddress;
                model.Disability = student.Disability;
                model.District = student.District;
                model.DOB = student.DOB;
                model.Gender = student.Gender;
                model.HomeTown = student.HomeTown;
                model.IsActive = student.IsActive;
                model.IsDeleted = student.IsDeleted;
                model.LanguagesSpoken = student.LanguagesSpoken;
                model.MaritalStatus = student.MaritalStatus;
                model.POB = student.POB;
                //model.previousEducationsViewModel = student.previousEducations;
                model.Passport = Path.Combine(@"/StudentPhotos/" + student.Passport);
                model.Region = student.Region;
                model.Religion = student.Religion;
                model.Result = student.Result;
                model.FirstChoiceCollege = student.FirstChoiceCollege;
                model.FirstChoiceProgram = student.FirstChoiceProgram;
                model.SecondChoiceCollege = student.SecondChoiceCollege;
                model.SecondChoiceProgram = student.SecondChoiceProgram;
                model.ThirdChoiceCollege = student.ThirdChoiceCollege;
                model.ThreeChoiceProgram = student.ThreeChoiceProgram;
                model.ParentParticulars = student.ParentParticulars;
                model.TelephoneNumber = student.TelephoneNumber;
                model.CreatedBy = student.CreatedBy;
                model.DateCreated = student.DateCreated;
                model.DateUpdated = student.DateUpdated;
                model.UpdatedBy = student.UpdatedBy;

                return View(model);
            }
            else
            {
                return NotFound();
            }


        }

        public IActionResult EditStudent(long Id)
        {
            var student = _studentRepository.GetStudentById(Id);
            if (student == null)
            {
                return NotFound();
            }

            var model = new StudentViewModel();

            model.Id = student.Id;
            model.AppRefNumber = student.AppRefNumber;
            model.Surname = student.Surname;
            model.OtherNames = student.OtherNames;
            model.ContactAddress = student.ContactAddress;
            model.Disability = student.Disability;
            model.District = student.District;
            model.DOB = student.DOB;
            model.Gender = student.Gender;
            model.HomeTown = student.HomeTown;
            model.IsActive = student.IsActive;
            model.IsDeleted = student.IsDeleted;
            model.LanguagesSpoken = student.LanguagesSpoken;
            model.MaritalStatus = student.MaritalStatus;
            model.POB = student.POB;
            //model.previousEducationsViewModel = student.previousEducations;
            model.Passport = Path.Combine(@"/StudentPhotos/" + student.Passport);
            model.Region = student.Region;
            model.Religion = student.Religion;
            model.Result = student.Result;
            model.FirstChoiceCollege = student.FirstChoiceCollege;
            model.FirstChoiceProgram = student.FirstChoiceProgram;
            model.SecondChoiceCollege = student.SecondChoiceCollege;
            model.SecondChoiceProgram = student.SecondChoiceProgram;
            model.ThirdChoiceCollege = student.ThirdChoiceCollege;
            model.ThreeChoiceProgram = student.ThreeChoiceProgram;
            model.ParentParticulars = student.ParentParticulars;
            model.TelephoneNumber = student.TelephoneNumber;
            model.CreatedBy = student.CreatedBy;
            model.DateCreated = student.DateCreated;
            model.DateUpdated = student.DateUpdated;
            model.UpdatedBy = student.UpdatedBy;

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EditStudent(StudentViewModel model)
        {
            var student = _studentRepository.GetStudentById(model.Id);
            if (student == null)
            {
                return NotFound();
            }

            student.Surname = model.Surname;
            student.OtherNames = model.OtherNames;
            student.ContactAddress = model.ContactAddress;
            student.Disability = model.Disability;
            student.District = model.District;
            student.DOB = model.DOB;
            student.Gender = model.Gender;
            student.HomeTown = model.HomeTown;
            student.LanguagesSpoken = model.LanguagesSpoken;
            student.MaritalStatus = model.MaritalStatus;
            student.POB = model.POB;
            student.Region = model.Region;
            student.Religion = model.Religion;
            student.FirstChoiceCollege = model.FirstChoiceCollege;
            student.FirstChoiceProgram = model.FirstChoiceProgram;
            student.SecondChoiceCollege = model.SecondChoiceCollege;
            student.SecondChoiceProgram = model.SecondChoiceProgram;
            student.ThirdChoiceCollege = model.ThirdChoiceCollege;
            student.ThreeChoiceProgram = model.ThreeChoiceProgram;
            student.ParentParticulars = model.ParentParticulars;
            student.TelephoneNumber = model.TelephoneNumber;
            student.DateUpdated = DateTime.Now;
            student.UpdatedBy = long.Parse(_authUser.UserId);
            //student.Result = model.Result;
            // Change Photo
            if (model.File != null && model.File.Length > 0)
            {
                var extension = Path.GetExtension(model.File.FileName);
                if (extension.ToUpper() == ".JPG")
                {
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    string uploadDir = Path.Combine(webRootPath + @"/StudentPhotos");
                    var fileName = model.AppRefNumber + extension;//Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    model.File.CopyToAsync(new FileStream(path, FileMode.Create));
                    student.Passport = fileName;
                }
                else
                {
                    return View(model);
                }
            }


            _studentRepository.UpdateStudent(student);




            return RedirectToAction("StudentDetail", "Student", new { AppRefNumber = model.AppRefNumber });
        }

        public IActionResult StudentDropout(string AppRefNumber)
        {



            var student = _studentRepository.GetStudentByRef(AppRefNumber);
            if (student == null)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"No Record found", Title = "Student Dropout", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            var model = new StudentDropOutViewModel();

            model.Id = student.Id;
            model.AppRefNumber = student.AppRefNumber;
            model.RegistrationPin = student.RegistrationPin;
            model.Surname = student.Surname;
            model.OtherNames = student.OtherNames;
            model.Gender = student.Gender;
            model.IsActive = student.IsActive;
            model.IsDeleted = student.IsDeleted;
            model.CreatedBy = student.CreatedBy;
            model.DateCreated = student.DateCreated;
            model.DateUpdated = student.DateUpdated;
            model.UpdatedBy = student.UpdatedBy;

            return View(model);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult StudentDropout(StudentDropOutViewModel model)
        {
            if (string.IsNullOrEmpty(model.DropOutComment))
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Please provide reason for student drop out", Title = "Student Dropout", Type = NotificationsType.danger });
                return RedirectToAction("StudentDropout", "Student", model.AppRefNumber);
            }

            var student = _studentRepository.GetStudentById(model.Id);

            student.IsActive = false;
            student.DropOutComment = model.DropOutComment;

            _studentRepository.UpdateStudent(student);

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Student Droped Out successfully", Title = "Student Dropout", Type = NotificationsType.success });
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateStudentRecord(StudentViewModel model)
        {

            return RedirectToAction("StudentDetail", new { model.AppRefNumber });
        }

        public IActionResult Upload()
        {
            ViewBag.Program = _programRepository.GetProgramList();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Upload(StudentFileUpload model)
        {


            var studentRecords = model.StudentRecords;
            var studentPhotos = model.StudentPhotos;

            if (model.AcademicSessionId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Sesseion Not selected", Title = "Student Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            if (model.ProgramId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Program Not selected", Title = "Student Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            if (studentRecords == null)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Student record File is empty", Title = "Student Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }

            if (studentPhotos == null)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Student photo File is empty", Title = "Student Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }




            if (studentRecords != null)
            {
                var studentRecordsStream = studentRecords.OpenReadStream();
                using (StreamReader data = new StreamReader(studentRecordsStream))
                {
                    string json = data.ReadToEnd();
                    var studentData = JsonConvert.DeserializeObject<List<StudentViewModel>>(json);

                    if (studentData == null)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"No record found on the student file uploaded", Title = "Studen Setup", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(Index));
                    }


                    if (studentData != null)
                    {
                        var collegeCode = "";
                        var collegeDetails = _collegeRepository.GetCollegeSummary();
                        if (collegeDetails != null)
                        {
                            collegeCode = Webutilities.GetInitialCharacter(collegeDetails.Name);
                        }
                        else
                        {
                            collegeCode = "CCOE";
                        }


                        foreach (var item in studentData)
                        {
                            var appRef = _studentRepository.GetStudentByRef(item.AppRefNumber);

                            var registrationPin = Webutilities.GenerateRegPin(collegeCode);

                            if (appRef == null)
                            {
                                var student = new Student();

                                student.AppRefNumber = item.AppRefNumber;
                                student.Surname = item.Surname;
                                student.OtherNames = item.OtherNames;
                                student.ContactAddress = item.ContactAddress;
                                student.Disability = item.Disability;
                                student.District = item.District;
                                student.DOB = item.DOB;
                                student.Gender = item.Gender;
                                student.HomeTown = item.HomeTown;
                                student.IsActive = item.IsActive;
                                student.IsDeleted = item.IsDeleted;
                                student.LanguagesSpoken = item.LanguagesSpoken;
                                student.MaritalStatus = item.MaritalStatus;
                                student.POB = item.POB;
                                student.Region = item.Region;
                                student.Religion = item.Religion;
                                student.Result = item.Result;
                                student.FirstChoiceCollege = item.FirstChoiceCollege;
                                student.FirstChoiceProgram = item.FirstChoiceProgram;
                                student.SecondChoiceCollege = item.SecondChoiceCollege;
                                student.SecondChoiceProgram = item.SecondChoiceProgram;
                                student.ThirdChoiceCollege = item.ThirdChoiceCollege;
                                student.ThreeChoiceProgram = item.ThreeChoiceProgram;
                                student.ParentParticulars = item.ParentParticulars;
                                student.TelephoneNumber = item.TelephoneNumber;
                                student.Level = 1;
                                student.ProgramId = model.ProgramId;
                                student.AcademicSessionId = model.AcademicSessionId;
                                student.CreatedBy = long.Parse(_authUser.UserId);
                                student.DateCreated = item.DateCreated;
                                student.Passport = item.AppRefNumber + ".jpg"; //item.Passport;
                                student.RegistrationPin = registrationPin;
                                student.IsActive = true;
                                student.IsDeleted = false;


                                await _studentRepository.AddStudentAsync(student);


                                foreach (var prevEdu in item.previousEducations)
                                {
                                    var previousEdu = new PreviousEducation();
                                    previousEdu.School = prevEdu.School;
                                    previousEdu.FromDate = prevEdu.FromDate;
                                    previousEdu.ToDate = prevEdu.ToDate;
                                    previousEdu.OfficeHeld = prevEdu.OfficeHeld;
                                    previousEdu.StudentID = student.Id;
                                    previousEdu.IsDeleted = false;
                                    previousEdu.IsActive = true;
                                    previousEdu.DateCreated = DateTime.Now;
                                    previousEdu.CreatedBy = long.Parse(_authUser.UserId);

                                    await _studentRepository.AddStudentPreviousEdu(previousEdu);

                                }
                            }
                            else
                            {
                                appRef.AppRefNumber = item.AppRefNumber;
                                appRef.Surname = item.Surname;
                                appRef.OtherNames = item.OtherNames;
                                appRef.ContactAddress = item.ContactAddress;
                                appRef.Disability = item.Disability;
                                appRef.District = item.District;
                                appRef.DOB = item.DOB;
                                appRef.Gender = item.Gender;
                                appRef.HomeTown = item.HomeTown;
                                appRef.IsActive = item.IsActive;
                                appRef.IsDeleted = item.IsDeleted;
                                appRef.LanguagesSpoken = item.LanguagesSpoken;
                                appRef.MaritalStatus = item.MaritalStatus;
                                appRef.POB = item.POB;
                                appRef.Region = item.Region;
                                appRef.Religion = item.Religion;
                                appRef.Result = item.Result;
                                appRef.FirstChoiceCollege = item.FirstChoiceCollege;
                                appRef.FirstChoiceProgram = item.FirstChoiceProgram;
                                appRef.SecondChoiceCollege = item.SecondChoiceCollege;
                                appRef.SecondChoiceProgram = item.SecondChoiceProgram;
                                appRef.ThirdChoiceCollege = item.ThirdChoiceCollege;
                                appRef.ThreeChoiceProgram = item.ThreeChoiceProgram;
                                appRef.ParentParticulars = item.ParentParticulars;
                                appRef.TelephoneNumber = item.TelephoneNumber;
                                appRef.Level = 1;
                                appRef.ProgramId = model.ProgramId;
                                appRef.AcademicSessionId = model.AcademicSessionId;
                                appRef.DateCreated = item.DateCreated;
                                appRef.DateUpdated = item.DateUpdated;
                                appRef.UpdatedBy = long.Parse(_authUser.UserId);
                                appRef.Passport = item.AppRefNumber + ".jpg"; //item.Passport;
                                appRef.IsActive = true;
                                appRef.IsDeleted = false;

                                _studentRepository.UpdateStudent(appRef);

                                var getPreviousEdu = _studentRepository.GetPreviousEducations(appRef.Id);
                                if (getPreviousEdu.Count() > 0)
                                {
                                    foreach (var record in getPreviousEdu)
                                    {
                                        _studentRepository.DeletPreviousEducation(record);
                                    }

                                }

                                foreach (var prevEdu in item.previousEducations)
                                {
                                    var previousEdu = new PreviousEducation();
                                    previousEdu.School = prevEdu.School;
                                    previousEdu.FromDate = prevEdu.FromDate;
                                    previousEdu.ToDate = prevEdu.ToDate;
                                    previousEdu.OfficeHeld = prevEdu.OfficeHeld;
                                    previousEdu.StudentID = appRef.Id;
                                    previousEdu.IsDeleted = false;
                                    previousEdu.IsActive = true;
                                    previousEdu.DateCreated = DateTime.Now;
                                    previousEdu.CreatedBy = long.Parse(_authUser.UserId);

                                    await _studentRepository.AddStudentPreviousEdu(previousEdu);

                                }
                            }
                        }

                    }

                }

            }

            if (studentPhotos != null)
            {
                var uploadtime = DateTime.Now.ToString("yyyyMMddHHmmss");
                // var studentPhotosStream = studentPhotos.OpenReadStream();

                //var currentdir = Directory.GetCurrentDirectory();
                var webRootPath = _hostingEnvironment.WebRootPath;

                string folder = Path.Combine(webRootPath + @"/StudentPhotos");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                //Put in a temp folder for processing
                var filename = uploadtime + Path.GetExtension(studentPhotos.FileName);
                using (FileStream data = new FileStream(Path.Combine(folder, filename), FileMode.Create))
                {
                    await studentPhotos.CopyToAsync(data);
                }

                //Now Perform the extraction 
                ZipFile.ExtractToDirectory(Path.Combine(folder + @"/" + filename), folder, true);

                //Delete the zip file

            }


            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Uploaded Successfully", Title = "Student Upload", Type = NotificationsType.success });

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ExistingStudent()
        {
            var model = new ExistingStudentFormViewModel();
            ViewBag.Program = _programRepository.GetProgramList();
            ViewBag.AcademicSession = _academicSessionRepository.GetAcademicSessionList();
            ViewBag.Level = _levelRepository.GetLevelList();

            return View(model);
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult ExistingStudent(ExistingStudentFormViewModel model)
        {
            ViewBag.Program = _programRepository.GetProgramList();
            ViewBag.AcademicSession = _academicSessionRepository.GetAcademicSessionList();
            ViewBag.Level = _levelRepository.GetLevelList();

            if (model.AcademicSessionId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Sesseion Not selected", Title = "Student Upload", Type = NotificationsType.danger });
                return View("ExistingStudent", model);
            }

            if (model.ProgramId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Program Not selected", Title = "Student Upload", Type = NotificationsType.danger });
                return View("ExistingStudent", model);
            }

            if (model.LevelId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Level Not selected", Title = "Student Upload", Type = NotificationsType.danger });
                return View("ExistingStudent", model);
            }



            var activeStudent = _studentRepository.GetAll();
            var existingStudents = _studentRepository.GetExistingStudents(model.AcademicSessionId, model.ProgramId, model.LevelId);
            if (existingStudents == null)
            {
                model.Students = new List<ExistingSudentViewModel>();
            }
            else
            {
                model.Students = (from es in existingStudents
                                  join acs in activeStudent on es.StudentId equals acs.StudentId
                                  where acs.IsActive = true
                                  select new ExistingSudentViewModel()
                                  {
                                      Id = acs.Id,
                                      AppRefNumber = acs.AppRefNumber,
                                      StudentId = acs.StudentId,
                                      Surename = acs.Surname,
                                      OtherNames = acs.OtherNames,
                                      AcademicSessionId = es.AcademicSessionId,
                                      ProgramId = es.ProgramId,
                                      LevelId = es.LevelId,
                                      IsActive = es.IsActive,
                                  }).ToList();
            }


            return View(model);


        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> ExistingStudentUpload(ExistingStudentFileUpload model)
        {


            if (model.AcademicSessionId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Sesseion Not selected", Title = "Student Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(ExistingStudent));
            }

            if (model.ProgramId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Program Not selected", Title = "Student Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(ExistingStudent));
            }

            if (model.LevelId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Level Not selected", Title = "Student Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(ExistingStudent));
            }



            var studentRecords = model.StudentRecords;

            if (studentRecords == null || studentRecords.Length <= 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Level Not selected", Title = "Student Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(ExistingStudent));
            }

            if (!Path.GetExtension(studentRecords.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Invalid File Format. Use The template provided", Title = "Student Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(ExistingStudent));
            }

            var list = new List<StudentLog>();

            using (var stream = new MemoryStream())
            {
                await studentRecords.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    if (rowCount < 2)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"No record found", Title = "Student Upload", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(ExistingStudent));
                    }

                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (model.LevelId == 1)
                        {
                            list.Add(new StudentLog
                            {

                                AppRefNumber = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                StudentId = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                Surename = worksheet.Cells[row, 3].Value.ToString().Trim(),
                                OtherNames = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                AcademicSessionId = model.AcademicSessionId,
                                ProgramId = model.ProgramId,
                                LevelId = model.LevelId,
                                CreatedBy = long.Parse(_authUser.UserId),
                                DateCreated = DateTime.UtcNow,
                                IsActive = true,
                                IsDeleted = false,
                                IsSynched =false

                            });
                        }
                        else
                        {
                            list.Add(new StudentLog
                            {

                                //AppRefNumber = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                StudentId = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                Surename = worksheet.Cells[row, 3].Value.ToString().Trim(),
                                OtherNames = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                AcademicSessionId = model.AcademicSessionId,
                                ProgramId = model.ProgramId,
                                LevelId = model.LevelId,
                                CreatedBy = long.Parse(_authUser.UserId),
                                DateCreated = DateTime.UtcNow,
                                IsActive = true,
                                IsDeleted = false,
                                IsSynched=false

                            });
                        }

                    }
                }
            }



            if (model.LevelId == 1)
            {
                //Check if student Exist in Admission List
                foreach (var item in list)
                {
                    var getAppRef = item.AppRefNumber;
                    if (string.IsNullOrEmpty(getAppRef))
                    {

                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Applicant reference No cannot be null for {item.Surename + " " + item.OtherNames} ", Title = "Student Upload", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(ExistingStudent));
                    }


                    var checkAdmissionList = _studentRepository.GetStudentByRef(item.AppRefNumber);
                    if (checkAdmissionList == null)
                    {

                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"{item.AppRefNumber} not in Admission List", Title = "Student Upload", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(ExistingStudent));
                    }
                }

                //Update student Id  in Admission List
                foreach (var item in list)
                {
                    var student = _studentRepository.GetStudentByRef(item.AppRefNumber);
                    student.StudentId = item.StudentId;

                    _studentRepository.UpdateStudent(student);

                }

                //Create or update existing student in StudentLog
                foreach (var data in list)
                {

                    var CheckIfStudentExist = _studentRepository.CheckExistingStudentIfExist(data.AppRefNumber, data.AcademicSessionId, data.ProgramId, data.LevelId);

                    if (CheckIfStudentExist == null)
                    {
                        _studentRepository.AddExistingStudent(data);
                    }
                    else
                    {
                        _studentRepository.UpdateExistingStudent(data);
                    }
                }
            }
            else
            {
                foreach (var data in list)
                {
                    //Check if student Exist in Previous Level List

                    var previousLevel = data.LevelId - 1;
                    var checkPreviousLevelList = _studentRepository.GetExistingStudentByStudentID(data.StudentId, data.ProgramId, previousLevel);
                    if (checkPreviousLevelList == null)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Student {data.Surename + " " + data.OtherNames} not in Previous Level", Title = "Student Upload", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(ExistingStudent));
                    }
                }

                //Create or Update Existing Student
                foreach (var student in list)
                {
                    var CheckIfStudentExist = _studentRepository.CheckExistingStudentIfExistByStudentID(student.StudentId, student.AcademicSessionId, student.ProgramId, student.LevelId);

                    if (CheckIfStudentExist == null)
                    {
                        _studentRepository.AddExistingStudent(student);
                    }
                    else
                    {
                        _studentRepository.UpdateExistingStudent(student);
                    }
                }

            }

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Uploaded Successfully", Title = "Student Upload", Type = NotificationsType.success });
            return RedirectToAction(nameof(ExistingStudent));
        }


        public IActionResult Result()
        {
            var model = new ResultFormViewModel();
            ViewBag.Program = _programRepository.GetProgramList();
            ViewBag.AcademicSession = _academicSessionRepository.GetAcademicSessionList();
            ViewBag.Level = _levelRepository.GetLevelList();
            ViewBag.Course = _courseRepository.GetCourseList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Result(ResultFormViewModel model)
        {
            ViewBag.Program = _programRepository.GetProgramList();
            ViewBag.AcademicSession = _academicSessionRepository.GetAcademicSessionList();
            ViewBag.Level = _levelRepository.GetLevelList();
            ViewBag.Course = _courseRepository.GetCourseList();

            if (model.AcademicSessionId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Sesseion Not selected", Title = "Result Upload", Type = NotificationsType.danger });
                return View("Result", model);

            }

            if (model.ProgramId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Program Not selected", Title = "Result Upload", Type = NotificationsType.danger });
                return View("Result", model);
            }

            if (model.LevelId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Level Not selected", Title = "Result Upload", Type = NotificationsType.danger });
                return View("Result", model);
            }

            if (model.Semester == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Semester Not selected", Title = "Result Upload", Type = NotificationsType.danger });
                return View("Result", model);
            }

            if (model.CourseId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course Not selected", Title = "Result Upload", Type = NotificationsType.danger });
                return View("Result", model);
            }

            //var resultForm = new ResultFormViewModel();
            var result = _resultRepository.GetResultByFilterByCourse(model.AcademicSessionId, model.ProgramId, model.LevelId, model.CourseId).ToList();
            var student = _studentRepository.GetAll();
            var studentLog = _studentRepository.GetExistingStudents(model.AcademicSessionId, model.ProgramId, model.LevelId);
            var course = _courseRepository.GetAll();
            var program = _programRepository.GetAllPrograms();
            var academicSession = _academicSessionRepository.GetAll();
            var level = _levelRepository.GetAll();

            var resultData = (from sl in studentLog
                              join s in student on sl.StudentId equals s.StudentId
                              join p in program on sl.ProgramId equals p.Id
                              join ss in academicSession on sl.AcademicSessionId equals ss.Id
                              join l in level on sl.LevelId equals l.Id
                              join c in course on p.Id equals c.ProgramId
                              join r in result on sl.StudentId equals r.StudentId into srl
                              from sResultList in srl.DefaultIfEmpty()
                              where sl.AcademicSessionId == model.AcademicSessionId && sl.ProgramId == model.ProgramId
                              && sl.LevelId == model.LevelId && c.Id == model.CourseId
                              select new ResultViewModel()
                              {
                                  StudentName = s.Surname + " " + s.OtherNames,
                                  StudentId = s.StudentId,
                                  Course = c.CourseCode + " - " + c.CourseTitle,
                                  Session = ss.AcademicPeriod,
                                  Program = p.Name,
                                  Level = l.Name,
                                  Grade = sResultList?.Grade ?? "N/A",
                                  Score = sResultList?.Score ?? "N/A",


                              }).ToList();



            model.Result = resultData;


            return View(model);
        }

        [HttpGet]
        public IActionResult GetCourseByProgram(long LevelId, long ProgramId, Semester Semester)
        {
            var data = _courseRepository.GetCourseByFilter(ProgramId, LevelId, Semester).Select(x => new SelectListItem()
            {
                Text = x.CourseCode + " - " + x.CourseTitle,
                Value = x.Id.ToString()
            }).ToList();

            return new JsonResult(data);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> ResultUpload(ResultFileUploadViewModel model)
        {
            var model2 = new ResultFormViewModel();
            model2.AcademicSessionId = model.AcademicSessionId;
            model2.LevelId = model.LevelId;
            model2.ProgramId = model.ProgramId;
            model2.Semester = model.Semester;
            model2.CourseId = model.CourseId;


            if (model.AcademicSessionId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Academic Sesseion Not selected", Title = "Result Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Result));

            }

            if (model.ProgramId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Program Not selected", Title = "Result Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Result));
            }

            if (model.LevelId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Level Not selected", Title = "Result Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Result));
            }

            if (model.Semester == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Semester Not selected", Title = "Result Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Result));
            }

            if (model.CourseId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Course Not selected", Title = "Result Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Result));
            }

            var studentResultFile = model.StudentResultFile;

            if (studentResultFile == null || studentResultFile.Length <= 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Result file is Empty", Title = "Result Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Result));
            }

            if (!Path.GetExtension(studentResultFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Invalid File Format, Use template provided", Title = "Result Upload", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Result));
            }

            var list = new List<Result>();

            using (var stream = new MemoryStream())
            {
                await studentResultFile.CopyToAsync(stream, cancellationToken);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    if (rowCount < 2)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"No Record Found in the uploaded file", Title = "Result Upload", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(Result));
                    }

                    for (int row = 2; row <= rowCount; row++)
                    {
                        list.Add(new Result
                        {
                            StudentId = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            Score = worksheet.Cells[row, 5].Value.ToString().Trim(),
                            Grade = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            AcademicSessionId = model.AcademicSessionId,
                            ProgramId = model.ProgramId,
                            LevelId = model.LevelId,
                            CourseId = model.CourseId,
                            CreatedBy = long.Parse(_authUser.UserId),
                            DateCreated = DateTime.UtcNow,
                            IsActive = true,
                            IsDeleted = false,
                            IsSynched = false,

                        });
                    }
                }
            }

            //get all student for that level
            var studentLog = _studentRepository.GetExistingStudents(model.AcademicSessionId, model.ProgramId, model.LevelId);

            foreach (var item in list)
            {
                //Check if student Exist in the List of student for that Level
                var checkData = studentLog.Where(x => x.StudentId == item.StudentId).ToList();


                if (checkData.Count < 1)
                {
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"{item.StudentId} not in student List for this level", Title = "Result Upload", Type = NotificationsType.danger });
                    return RedirectToAction(nameof(Result));
                }
            }

            //Create or Update Student result
            foreach (var data in list)
            {
                var checkIfResulExist = _resultRepository.GetResultByFilterAppRefNo(data.AcademicSessionId, data.ProgramId, data.LevelId, data.CourseId, data.StudentId);

                if (checkIfResulExist == null)
                {
                    _resultRepository.Create(data);
                }
                else
                {
                    checkIfResulExist.Grade = data.Grade;
                    checkIfResulExist.Score = data.Score;
                    checkIfResulExist.DateUpdated = DateTime.Now;
                    checkIfResulExist.UpdatedBy = long.Parse(_authUser.UserId);

                    _resultRepository.Update(checkIfResulExist);
                }
            }


            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Uploaded Successfully", Title = "Result Upload", Type = NotificationsType.success });
            return RedirectToAction("Result");
        }

        public IActionResult GraduatingStudent()
        {
            ViewBag.Program = _programRepository.GetProgramList();
            var model = new GraduatingStudentFormViewModel();

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult GraduatingStudent(GraduatingStudentFormViewModel model)
        {
            ViewBag.Program = _programRepository.GetProgramList();

            if (model.ProgramId == 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Program Not selected", Title = "Graduating Student", Type = NotificationsType.danger });
                return View("GraduatingStudent", model);
            }

            var student = _studentRepository.GetAll();
            var studentLog = _studentRepository.GetAllExistingStudents();
            var program = _programRepository.GetAllPrograms();
            var academicSession = _academicSessionRepository.GetAll();
            var level = _levelRepository.GetAll();

            var graduationList = (from sl in studentLog
                                  join s in student on sl.StudentId equals s.StudentId
                                  join p in program on s.ProgramId equals p.Id
                                  join a in academicSession on s.AcademicSessionId equals a.Id
                                  where sl.LevelId == 4 && s.ProgramId == model.ProgramId
                                  select new GraduatingStudentViewModel()
                                  {
                                      Id = s.Id,
                                      AppRefNo = s.AppRefNumber,
                                      StudentId = s.StudentId,
                                      Surname = s.Surname,
                                      OtherName = s.OtherNames,
                                      Program = p.Name,
                                      SessionAdmited = a.AcademicPeriod,
                                      IsGraduated = s.IsGraduated

                                  }).ToList();

            model.GradautionList = graduationList;




            return View(model);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Graduate(GraduatingStudentFormViewModel model)
        {
            foreach (var item in model.GradautionList)
            {
                var student = _studentRepository.GetStudentById(item.Id);
                student.IsGraduated = item.IsGraduated;
                student.UpdatedBy = long.Parse(_authUser.UserId);
                student.DateUpdated = DateTime.Now;

                _studentRepository.UpdateStudent(student);
            }


            return RedirectToAction(nameof(GraduatingStudent));
        }

        public IActionResult DropoutList()
        {
            var student = _studentRepository.GetDropoutStudents();
            //var studentLog = _studentRepository.GetExistingStudents(model.AcademicSessionId, model.ProgramId, model.LevelId);
            var program = _programRepository.GetAllPrograms();
            var academicSession = _academicSessionRepository.GetAll();
            var level = _levelRepository.GetAll();

            var dropoutStudents = (from s in student
                                   join p in program on s.ProgramId equals p.Id
                                   join a in academicSession on s.AcademicSessionId equals a.Id
                                   select new DropoutStudentViewModel
                                   {
                                       StudentId = s.StudentId,
                                       Surname = s.Surname,
                                       OtherName = s.OtherNames,
                                       Program = p.Name,
                                       SessionAdmited = a.AcademicPeriod,
                                       ReasonForDropout = s.DropOutComment,

                                   }).ToList();



            return View(dropoutStudents);
        }
    }
}