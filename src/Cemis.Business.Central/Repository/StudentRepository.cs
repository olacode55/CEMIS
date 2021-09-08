using Cemis.Business.Central.Interface;
using Cemis.Data.Central.Entities;
using CEMIS.Business.Central.Interface;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using CEMIS.Data.Central;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Cemis.Business.Central.Repository
{

    public class StudentRepository : IStudent
    {
        private IConfiguration _configration;
        private IRepository<Student> _studentRepository;
        private IRepository<StudentLog> _studentLogRepository;
        private IRepository<College> _collegeRepository;
        private IRepository<PreviousEducation> _previousEducationRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private IUserManagementServices _userService;
        private readonly IMailManagementService _mailService;
        private readonly IPasswordService _passwordService;
        private appContextCentral _context;

        public StudentRepository(IRepository<Student> studentRepository, IRepository<PreviousEducation> previousEducationRepository
                                 , IRepository<College> collegeRepository, UserManager<User> userManager, IPasswordService passwordService,
                                 RoleManager<Role> roleManager, IUserManagementServices userService, IConfiguration configration,
                                 IMailManagementService mailService, IRepository<StudentLog> studentLogRepository , appContextCentral context)
        {
            _context = context;
            _mailService = mailService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configration = configration;
            _userService = userService;
            _studentRepository = studentRepository;
            _collegeRepository = collegeRepository;
            _passwordService = passwordService;
            _studentLogRepository = studentLogRepository;
            _previousEducationRepository = previousEducationRepository;
        }
        public ResponseData<Student> CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudent()
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(long Id)
        {
            throw new NotImplementedException();
        }


        public StudentRegistrationDTO ValidateStudent(string studentId, string registrationPin)
        {
            var student = _studentRepository.All().FirstOrDefault(m => m.StudentId == studentId && m.RegistrationPin == registrationPin);

            if (student != null)
            {


                if (student.IsRegistered)
                {
                    return new StudentRegistrationDTO { ErrorMessage = $"Student with ID - { studentId} and Registration Pin - { registrationPin} has registered on the the system. Click on login to login into the application" };

                }


                var college = _collegeRepository.All().FirstOrDefault(m => m.Id == student.CollegeID);
                return new StudentRegistrationDTO
                {
                    CollegeName = college.Name,
                    //StudentName = student.OtherNames,
                    EmailAddress = student.EmailAddress,
                    PhoneNumber = student.TelephoneNumber,
                    RegistrationPin = student.RegistrationPin,
                    StudentId = student.StudentId,
                    ErrorMessage = string.Empty
                };

            }


            return new StudentRegistrationDTO { ErrorMessage = $"Student with ID - { studentId} and Registration Pin - { registrationPin}does not exist" };
        }


        public async Task<ResponseData<StudentRegistrationDTO>> StudentRegistration(StudentRegistrationDTO studentRegDTO, string callback)
        {
            try
            {
                //using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {


                    var student = _studentRepository.All().FirstOrDefault(m => m.StudentId == studentRegDTO.StudentId && m.RegistrationPin == studentRegDTO.RegistrationPin);
                    if (student == null)
                    {
                        return new ResponseData<StudentRegistrationDTO>
                        {
                            Message = "Invalid Student Id and Registration Pin ",
                            RespCode = "00",
                            IsSuccessful = false
                        };
                    }


                    student.EmailAddress = studentRegDTO.EmailAddress;
                    student.TelephoneNumber = studentRegDTO.PhoneNumber;
                    student.IsRegistered = true;
                    


                    var fetchdata = await _userService.GetUsers();
                    var userId = fetchdata.Where(x => x.UserName.ToLower().Trim() == studentRegDTO.StudentId.ToLower().Trim())
                   .Select(p => p.UserName);
                    if (userId.Contains(studentRegDTO.StudentId.ToLower().Trim()))
                    {

                        return new ResponseData<StudentRegistrationDTO>
                        {
                            Message = "Username already exist on the system",
                            RespCode = "00",
                            IsSuccessful = false
                        };
                    }
                    var passwordModel = new UsersPassword();

                    DateTime currentTime = DateTime.Now;
                    DateTime x30MinsLater = currentTime.AddMonths(6);
                    var appuser = new User { Email = studentRegDTO.EmailAddress, UserName = studentRegDTO.StudentId.ToLower(), EmailConfirmed = true, TwoFactorEnabled = false, PwdExpiryDate = x30MinsLater, Lastname = studentRegDTO.LastName, Firstname = studentRegDTO.FirstName, UserType = (byte)UserType.Student };
                    var result = await _userManager.CreateAsync(appuser, studentRegDTO.Password);
                    if (result.Succeeded)
                    {

                        var ApplicationRole = await _roleManager.FindByNameAsync("student");
                        var userrole = await _userManager.AddToRoleAsync(appuser, ApplicationRole.Name);
                        if (userrole.Succeeded)
                        {
                            passwordModel.ForcePwdChange = false;
                            passwordModel.LastLogin = DateTime.Now;
                            passwordModel.PwdEncrypt = studentRegDTO.Password;
                            passwordModel.UserId = appuser.Id;
                            passwordModel.IsActive = true;

                            await _passwordService.CreateUserDefaultPassword(passwordModel);
                            //Callback Url to confirm Email Address
                            var code = await _userManager.GenerateEmailConfirmationTokenAsync(appuser);
                            callback = callback.Replace("404", appuser.Id.ToString());
                            callback = callback.Replace("%7Bcode%7D", code);

                            //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { UserId = appuser.Id, code }, protocol: Request.Scheme);
                            //Mail Webservice
                            var mail = await _mailService.SendWelcomeEmail(studentRegDTO.EmailAddress, studentRegDTO.StudentId, studentRegDTO.Password, callback);
                            if (mail == 1001)
                            {

                            }

                            _studentRepository.Update(student);
                            //scope.Complete();
                        return new ResponseData<StudentRegistrationDTO>
                            {
                                Message = "Student user created successfully",
                                RespCode = "00",
                                IsSuccessful = true
                            };
                        }

                        return new ResponseData<StudentRegistrationDTO>
                        {
                            Message = "Operation failed",
                            RespCode = "00",
                            IsSuccessful = false
                        };
                    }
                    return new ResponseData<StudentRegistrationDTO>
                    {
                        Message = "Operation failed",
                        RespCode = "00",
                        IsSuccessful = false
                    };
                }
               
            //}
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<StudentRegistrationDTO>
                {
                    Message = "Operation failed",
                    RespCode = "00",
                    IsSuccessful = false
                };
            }




        }


        public ResponseData<Student> PushStudentDetails(StudentViewModel studentVM, long collegeID)
        {
            ResponseData<Student> resp;
            var studentDetail = _studentRepository.All().FirstOrDefault(x => x.SourceID == studentVM.Id && x.CollegeID == collegeID);

            try
            {
                var previousEducation = new List<PreviousEducation>();
                if (studentDetail == null)
                {
                    //Image img = System.Drawing.Image.FromStream();

                    //img.Save(System.IO.Path.GetTempPath() + "\\myImage.Jpeg", ImageFormat.Jpeg);

                    var student = new Student
                    {
                        DOB = studentVM.DOB,
                        POB = studentVM.POB,
                        CollegeID = collegeID,
                        SourceID = studentVM.Id,
                        Surname = studentVM.Surname,
                        CreatedBy = studentVM.CreatedBy,
                        Gender = studentVM.Gender,
                        HomeTown = studentVM.HomeTown,
                        IsActive = studentVM.IsActive,
                        IsDeleted = studentVM.IsDeleted,
                        DateCreated = studentVM.DateCreated,
                        DateUpdated = studentVM.DateUpdated,
                        ApplicationRef = studentVM.AppRefNumber,
                        ContactAddress = studentVM.ContactAddress,
                        Disability = studentVM.Disability,
                        District = studentVM.District,
                        FirstChoiceCollege = studentVM.FirstChoiceCollege,
                        FirstChoiceProgram = studentVM.FirstChoiceProgram,
                        LanguagesSpoken = studentVM.LanguagesSpoken,
                        MaritalStatus = studentVM.MaritalStatus,
                        OtherNames = studentVM.OtherNames,
                        ParentParticulars = studentVM.ParentParticulars,
                        Region = studentVM.Region,
                        Religion = studentVM.Religion,
                        Result = studentVM.Result,
                        SecondChoiceCollege = studentVM.SecondChoiceCollege,
                        SecondChoiceProgram = studentVM.SecondChoiceProgram,
                        TelephoneNumber = studentVM.TelephoneNumber,
                        ThirdChoiceCollege = studentVM.ThirdChoiceCollege,
                        ThreeChoiceProgram = studentVM.ThreeChoiceProgram,
                        UpdatedBy = studentVM.UpdatedBy,
                        DateFetched = DateTime.Now,
                        StudentId = studentVM.StudentId,
                        DropOutComment = studentVM.DropOutComment,
                        ProgramSourceId = studentVM.ProgramId,
                        RegistrationPin = studentVM.RegistrationPin
                        // Passport = studentVM.PassportStream.Name
                    };


                    previousEducation = studentVM.previousEducations.Select(x => new PreviousEducation
                    {
                        CollegeID = collegeID,
                        DateCreated = x.DateCreated,
                        DateUpdated = x.DateUpdated,
                        CreatedBy = x.CreatedBy,
                        FromDate = x.FromDate,
                        StudentID = student.Id,
                        OfficeHeld = x.OfficeHeld,
                        School = x.School,
                        ToDate = x.ToDate,
                        SourceID = x.Id,
                        IsActive = x.IsActive,
                        UpdatedBy = x.UpdatedBy,
                        IsDeleted = x.IsDeleted,
                        DateFetched = DateTime.Now
                    }).ToList();

                    using (var scope = new TransactionScope())
                    {
                        _studentRepository.Create(student);
                        _previousEducationRepository.Create(previousEducation);
                        scope.Complete();

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _configration.GetSection("StudentPassportUploadPath").Value + "\\" + collegeID);
                        {
                            Directory.CreateDirectory(path);
                        }

                        using (FileStream data = new FileStream(Path.Combine(path, studentVM.Passport), FileMode.Create, FileAccess.Write))
                        {
                            studentVM.File.CopyToAsync(data);
                        }

                    }

                    resp = new ResponseData<Student>
                    {
                        Message = "Data created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }
                studentDetail.ContactAddress = studentVM.ContactAddress;
                studentDetail.DateUpdated = studentVM.DateUpdated;
                studentDetail.Disability = studentVM.Disability;
                studentDetail.District = studentVM.District;
                studentDetail.DOB = studentVM.DOB;
                studentDetail.FirstChoiceCollege = studentVM.FirstChoiceCollege;
                studentDetail.FirstChoiceProgram = studentVM.FirstChoiceProgram;
                studentDetail.Gender = studentVM.Gender;
                studentDetail.HomeTown = studentVM.HomeTown;
                studentDetail.IsActive = studentVM.IsActive;
                studentDetail.IsDeleted = studentVM.IsDeleted;
                studentDetail.LanguagesSpoken = studentVM.LanguagesSpoken;
                studentDetail.MaritalStatus = studentVM.MaritalStatus;
                studentDetail.OtherNames = studentVM.OtherNames;
                studentDetail.ParentParticulars = studentVM.ParentParticulars;
                studentDetail.POB = studentVM.POB;
                studentDetail.Region = studentVM.Region;
                studentDetail.Religion = studentVM.Religion;
                studentDetail.Result = studentVM.Result;
                studentDetail.SecondChoiceCollege = studentVM.SecondChoiceCollege;
                studentDetail.SecondChoiceProgram = studentVM.SecondChoiceProgram;
                studentDetail.Surname = studentVM.Surname;
                studentDetail.TelephoneNumber = studentVM.TelephoneNumber;
                studentDetail.ThirdChoiceCollege = studentVM.ThirdChoiceCollege;
                studentDetail.ThreeChoiceProgram = studentVM.ThreeChoiceProgram;
                studentDetail.UpdatedBy = studentVM.UpdatedBy;
                studentDetail.DateFetched = DateTime.Now;
                studentDetail.StudentId = studentVM.StudentId;
                studentDetail.DropOutComment = studentVM.DropOutComment;
                studentDetail.ProgramSourceId = studentVM.ProgramId;


                previousEducation = studentVM.previousEducations.Select(x => new PreviousEducation
                {
                    CollegeID = collegeID,
                    DateCreated = x.DateCreated,
                    DateUpdated = x.DateUpdated,
                    CreatedBy = x.CreatedBy,
                    FromDate = x.FromDate,
                    StudentID = studentDetail.Id,
                    OfficeHeld = x.OfficeHeld,
                    School = x.School,
                    ToDate = x.ToDate,
                    SourceID = x.Id,
                    IsActive = x.IsActive,
                    UpdatedBy = x.UpdatedBy,
                    IsDeleted = x.IsDeleted,
                    DateFetched = DateTime.Now
                }).ToList();

                using (var scope = new TransactionScope())
                {
                    _studentRepository.Update(studentDetail);

                    var existingStudentRecord = _previousEducationRepository.All().FirstOrDefault(x => x.StudentID == studentDetail.Id);

                    if (existingStudentRecord != null)
                    {
                        _previousEducationRepository.Delete(existingStudentRecord);
                    }
                    _previousEducationRepository.Create(previousEducation);
                    scope.Complete();


                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _configration.GetSection("StudentPassportUploadPath").Value + "\\" + collegeID);
                    if (!System.IO.Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (FileStream data = new FileStream(Path.Combine(path, studentVM.Passport), FileMode.Create, FileAccess.Write))
                    {
                        studentVM.File.CopyTo(data);
                        //studentVM.File.Dispose();
                        //studentVM.File.CopyToAsync(data);
                    }
                }

                resp = new ResponseData<Student>
                {
                    Message = "Data Updated successfully",
                    RespCode = "00",
                    IsSuccessful = true
                };
                return resp;

            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<Student>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
        }



        public ResponseData<StudentLogViewModel> PushStudentLog(StudentLogViewModel studentLogVM, long collegeID)
        {
            ResponseData<StudentLogViewModel> resp;
            var studentLog = _studentLogRepository.All().FirstOrDefault(x => x.SourceID == studentLogVM.Id && x.CollegeID == collegeID);

            try
            {
                if (studentLog == null)
                {

                    var studentlog = new StudentLog
                    {
                        CollegeID = collegeID,
                        SourceID = studentLogVM.Id,
                        DateFetched = DateTime.Now,
                        Level = studentLogVM.Level,
                        Surename = studentLogVM.Surname,
                        IsActive = studentLogVM.IsActive,
                        IsDeleted = studentLogVM.IsDeleted,
                        UpdatedBy = studentLogVM.UpdatedBy,
                        CreatedBy = studentLogVM.CreatedBy,
                        StudentId = studentLogVM.StudentId,
                        OtherNames = studentLogVM.OtherNames,
                        DateCreated = studentLogVM.DateCreated,
                        DateUpdated = studentLogVM.DateUpdated,
                        AppRefNumber = studentLogVM.AppRefNumber,
                        ProgramSourceId = studentLogVM.ProgramId,
                        AcademicSessionSourceId = studentLogVM.AcademicSessionId,
                    };




                    _studentLogRepository.Create(studentlog);

                    

                    resp = new ResponseData<StudentLogViewModel>
                    {
                        Message = "Data created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };

                    return resp;
                }

                studentLog.DateFetched = DateTime.Now;
                studentLog.Level = studentLogVM.Level;
                studentLog.Surename = studentLogVM.Surname;
                studentLog.IsActive = studentLogVM.IsActive;
                studentLog.IsDeleted = studentLogVM.IsDeleted;
                studentLog.UpdatedBy = studentLogVM.UpdatedBy;
                studentLog.StudentId = studentLogVM.StudentId;
                studentLog.OtherNames = studentLogVM.OtherNames;
                studentLog.DateUpdated = studentLogVM.DateUpdated;
                studentLog.AppRefNumber = studentLogVM.AppRefNumber;
                studentLog.ProgramSourceId = studentLogVM.ProgramId;
                studentLog.AcademicSessionSourceId = studentLogVM.AcademicSessionId;


                _studentLogRepository.Update(studentLog);

                  

                resp = new ResponseData<StudentLogViewModel>
                {
                    Message = "Data Updated successfully",
                    RespCode = "00",
                    IsSuccessful = true
                };
                return resp;

            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<StudentLogViewModel>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };
            }
        }

        public List<StudentProfileViewModel> GetStudentProfile(string studentId)
        {
            try {
                var student = _context.Student.FirstOrDefault(x => x.StudentId == studentId);
                var connectionString = _context.Database.GetDbConnection().ConnectionString;
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    DataTable dt = new DataTable();
                    var details = new List<StudentProfileViewModel>();

                    SqlCommand cmd = new SqlCommand("GetStudentProfile", myCon);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.Parameters.AddWithValue("@CollegeId", student.CollegeID);

                    cmd.CommandType = CommandType.StoredProcedure;
                    myCon.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {

                        var obj = new StudentProfileViewModel()
                        {
                            Id = (long)dr["Id"],
                            CollegeName = dr["CollegeName"].ToString(),
                            ApplicationRef = dr["ApplicationRef"].ToString(),
                            ContactAddress = dr["ContactAddress"].ToString(),
                            District = dr["ContactAddress"].ToString(),
                            DOB = (DateTime)dr["DOB"],
                            Gender = (Gender)Convert.ToByte(dr["Gender"]),
                            HomeTown = dr["HomeTown"].ToString(),
                            LanguagesSpoken = dr["LanguagesSpoken"].ToString(),
                            Level = dr["Level"].ToString(),
                            MaritalStatus = dr["MaritalStatus"].ToString(),
                            OtherName = dr["OtherNames"].ToString(),
                            POB = dr["POB"].ToString(),
                            Passport = dr["Passport"].ToString(),
                            Program = dr["Program"].ToString(),
                            Region = dr["Region"].ToString(),
                            Religion = dr["Religion"].ToString(),
                            Session = dr["Session"].ToString(),
                            StudentId = dr["StudentId"].ToString(),
                            Surname = dr["Surname"].ToString(),
                            TelephoneNumber = dr["TelephoneNumber"].ToString(),
                        };

                        if(obj.Passport != string.Empty)
                        {
                            obj.Passport = "/" + _configration.GetSection("StudentPassportUploadPath").Value + "/" + obj.Id + "/" + obj.Passport;

                        }
                        details.Add(obj);
                    }

                    myCon.Close();
                    return details;
                }
            } catch(Exception ex)
            {
               
                ErrorLogManager.Error(ex);
                return new List<StudentProfileViewModel>();
            }
           
        }

        
    }
}
