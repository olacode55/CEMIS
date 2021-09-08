using CEMIS.Business.Central.Interface;
using CEMIS.Business.Central.Repository;
using CEMIS.Data.Central;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Cemis.Data.Central.Entities;
using System.Net.Http;
using System.IO;

namespace CEMIS.Business.Central.Repository
{
    public class StaffRepository : IStaff
    {
        private IRepository<TeachingStaff> _staffRepo;
        private IRepository<Allowance> _allowancesRepo;
        private IRepository<Certificate> _certificateRepo;
        private IConfiguration _configration;
        private readonly IRepository<StaffGradeLevel> _staffGradelevelRepo;
        private readonly IRepository<TeachingStaffAdminRole> _staffAdminRoleRepo;
        private readonly IRepository<StaffAllowance> _staffAllowanceRepo;
        private readonly IRepository<StaffDueForPromotionallowance> _staffPromotionallowanceRepo;

        public StaffRepository(IRepository<TeachingStaff> staffRepo, IConfiguration configration , IRepository<StaffGradeLevel> staffGradelevelRepo , IRepository<TeachingStaffAdminRole> staffAdminRoleRepo ,
                               IRepository<Allowance> allowancesRepo, IRepository<Certificate> certificateRepo , IRepository<StaffAllowance> staffAllowanceRepo , IRepository<StaffDueForPromotionallowance> staffPromotionallowanceRepo)
        {
            _staffRepo = staffRepo;
            _configration = configration;
            _staffGradelevelRepo = staffGradelevelRepo;
            _staffAdminRoleRepo = staffAdminRoleRepo;
            _allowancesRepo = allowancesRepo;
            _certificateRepo = certificateRepo;
            _staffAllowanceRepo = staffAllowanceRepo;
            _staffPromotionallowanceRepo = staffPromotionallowanceRepo;
        }

        public ResponseData<TeachingStaff> PushCollegeStaff(CollegeStaffViewModel teachingStaff, long collegeID)
        {
           // Allowance staffAllowance = null;
            
            ResponseData<TeachingStaff> resp;
            var staffDetails = _staffRepo.All().FirstOrDefault(x => x.SourceID == teachingStaff.Id && x.CollegeID == collegeID);

            var mainAdminRole = _staffAdminRoleRepo.All().FirstOrDefault(x => x.Code == teachingStaff.MainAdminRoleCode && x.IsActive == true && x.IsDeleted == false);
            var gradeLevel = _staffGradelevelRepo.All().FirstOrDefault(x => x.Code == teachingStaff.GradeLevelCode && x.IsDeleted == false && x.IsActive == true);
            var grade =  _staffAdminRoleRepo.All().FirstOrDefault(x => x.Code == teachingStaff.LecturerGradeCode && x.IsActive == true && x.IsDeleted == false);

            var lectureGradeLevelId = gradeLevel == null ? 0 : gradeLevel.Id;
            var mainAdminRoleId = mainAdminRole == null ? 0 : mainAdminRole.Id;
            var gradeId = grade == null ? 0 : grade.Id;
            try
            {
                if (staffDetails == null)
                {
                    var teachingStaffModel = new TeachingStaff {
                    CollegeID = collegeID,
                    SourceID = teachingStaff.Id,
                    DateFetched = DateTime.Now,
                    AcademicQualification = teachingStaff.AcademicQualification,
                    MainSubjectTaught = teachingStaff.MainSubjectTaught,
                    AcademicQualificationCertNo = teachingStaff.AcademicQualificationCertNo,
                    AreaOfSpecialization = teachingStaff.AreaOfSpecialization,
                    DateCreated = teachingStaff.DateCreated,
                    DateOfBirth = teachingStaff.DateOfBirth,
                    DateOfCurrentAppointment = teachingStaff.DateOfCurrentAppointment,
                    DateOfFirstAppointment = teachingStaff.DateOfFirstAppointment,
                    DateUpdated = teachingStaff.DateUpdated,
                    IsDeleted = teachingStaff.IsDeleted,
                    CreatedBy = teachingStaff.CreatedBy,
                    Gender = teachingStaff.Gender,
                    GradeLevel = lectureGradeLevelId,
                    SourceOfSalary = teachingStaff.SourceOfSalary,
                    StaffFileNo = teachingStaff.StaffFileNo,
                    InServiceTraining = teachingStaff.InServiceTraining,
                    SubjectOfQualification = teachingStaff.SubjectOfQualification,
                    IsActive = teachingStaff.IsActive,
                    LecturerGrade = gradeId,
                    MainAdminRole = mainAdminRoleId,
                    TeachingQualification = teachingStaff.TeachingQualification,
                    Name = teachingStaff.FirstName + " " + teachingStaff.LastName,
                    TeachingQualificationCertNo = teachingStaff.TeachingQualificationCertNo,
                    TeachingType = teachingStaff.TeachingType,
                    UpdatedBy = teachingStaff.UpdatedBy,
                    YearOfFirstAppointment = teachingStaff.YearOfFirstAppointment,
                    YearOfPostingToCollege = teachingStaff.YearOfPostingToCollege,
                    YearOfPresentAppointment = teachingStaff.YearOfPresentAppointment,
                    DueForPromotion = teachingStaff.DueForPromotion,
                    RetiredDate = teachingStaff.RetiredDate,
                    
                    StaffCategory = teachingStaff.StaffCategory,
                    StaffRank = teachingStaff.StaffRank,
                    StaffType = teachingStaff.StaffType,
                    Step = teachingStaff.Step,
                    StepPromotion = teachingStaff.StepPromotion,
                    GradeLevelPromotion = teachingStaff.GradeLevelPromotion,
                    BasicSalary = teachingStaff.BasicSalary,
                    BasicSalaryPromotion = teachingStaff.BasicSalaryPromotion,
                    IsRetired = teachingStaff.IsRetired,
                    StaffCategoryCode = teachingStaff.StaffCategoryCode,
                    Department = teachingStaff.Department,

                    };

                    

                   

                    using (var scope = new TransactionScope())
                    {
                        _staffRepo.Create(teachingStaffModel);

                        //if(staffAllowance != null)
                        //{
                        //    staffAllowance.StaffId = teachingStaffModel.Id;
                        //    _allowancesRepo.Create(staffAllowance);
                        //}


                        if (teachingStaff.Certificates != null && teachingStaff.Certificates.Count > 0)
                        {
                            var staffCertificate = new List<Certificate>();
                            foreach (var certificateVM in teachingStaff.Certificates)
                            {
                                var bytes = Convert.FromBase64String(certificateVM.Image);
                                var fileSteam = new StreamContent(new MemoryStream(bytes));
                                var fileName = Guid.NewGuid().ToString() +certificateVM.NameAndExtention.ToString().Substring(certificateVM.NameAndExtention.IndexOf('.') + 0);


                                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _configration.GetSection("TeachingStaffCertificateUploadPath").Value + "\\" + collegeID);
                                {
                                    Directory.CreateDirectory(path);
                                }

                                using (FileStream data = new FileStream(Path.Combine(path, fileName), FileMode.Create, FileAccess.Write))
                                {
                                    fileSteam.CopyToAsync(data);
                                }
                                var certificate = new Certificate
                                {
                                    CollegeID = collegeID,
                                    //CreatedBy = teachingStaff.CreatedBy,
                                    //DateCreated = teachingStaff.DateCreated,
                                    DateFetched = DateTime.Now,
                                    Name = certificateVM.Name,
                                    Url = fileName,
                                    StaffId = teachingStaffModel.Id

                                };

                               

                                staffCertificate.Add(certificate);
                            }
                       
                            
                            _certificateRepo.Create(staffCertificate);
                        }

                        if (teachingStaff.Allowances != null)
                        {
                          var staffAll =  teachingStaff.Allowances.Select(x => new StaffAllowance
                            {
                                Amount = x.Amount,
                                CollegeID = collegeID,
                                CreatedBy = x.CreatedBy,
                                DateCreated = x.DateCreated,
                                DateFetched = DateTime.Now,
                                DateUpdated = x.DateUpdated,
                                SourceID = x.Id,
                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                Name = x.Name,
                                StaffId = teachingStaffModel.Id,
                                SourceStaffId = teachingStaff.Id,
                                UpdatedBy = x.UpdatedBy
                            }).ToList();

                            var existingstaffAll = _staffAllowanceRepo.All().ToList();
                            _staffAllowanceRepo.Delete(existingstaffAll);
                            _staffAllowanceRepo.Create(staffAll);
                        }

                        if (teachingStaff.AllowancePromotionVM != null)
                        {
                            var staffPromotionAllowance =teachingStaff.Allowances.Select(x => new StaffDueForPromotionallowance
                            {
                                Amount = x.Amount,
                                CollegeID = collegeID,
                                CreatedBy = x.CreatedBy,
                                DateCreated = x.DateCreated,
                                DateFetched = DateTime.Now,
                                DateUpdated = x.DateUpdated,
                                SourceID = x.Id,
                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                Name = x.Name,
                                StaffId = teachingStaffModel.Id,
                                SourceStaffId = teachingStaff.Id,
                                UpdatedBy = x.UpdatedBy
                            }).ToList();
                            var existingPromoStaffAll = _staffPromotionallowanceRepo.All().ToList();
                            _staffPromotionallowanceRepo.Delete(existingPromoStaffAll);
                            _staffPromotionallowanceRepo.Create(staffPromotionAllowance);
                        }

                        scope.Complete();
                    }
                    resp = new ResponseData<TeachingStaff>
                    {
                        Message = "College staff created successfully",
                        RespCode = "00",
                        IsSuccessful = true
                    };
                    return resp;
                }


                staffDetails.AcademicQualification = teachingStaff.AcademicQualification;
                staffDetails.AcademicQualificationCertNo = teachingStaff.AcademicQualificationCertNo;
                staffDetails.AreaOfSpecialization = teachingStaff.AreaOfSpecialization;
                staffDetails.DateOfBirth = teachingStaff.DateOfBirth;
                staffDetails.DateOfCurrentAppointment = teachingStaff.DateOfCurrentAppointment;
                staffDetails.DateOfFirstAppointment = teachingStaff.DateOfFirstAppointment;
                staffDetails.DateUpdated = teachingStaff.DateUpdated;
                staffDetails.Gender = teachingStaff.Gender;
                staffDetails.GradeLevel = lectureGradeLevelId;
                staffDetails.InServiceTraining = teachingStaff.InServiceTraining;
                staffDetails.IsActive = teachingStaff.IsActive;
                staffDetails.IsDeleted = teachingStaff.IsDeleted;
                staffDetails.LecturerGrade = gradeId;
                staffDetails.MainAdminRole = mainAdminRoleId;
                staffDetails.MainSubjectTaught = teachingStaff.MainSubjectTaught;
                staffDetails.Name = teachingStaff.Name;
                staffDetails.SourceOfSalary = teachingStaff.SourceOfSalary;
                staffDetails.StaffFileNo = teachingStaff.StaffFileNo;
                staffDetails.SubjectOfQualification = teachingStaff.SubjectOfQualification;
                staffDetails.TeachingQualification = teachingStaff.TeachingQualification;
                staffDetails.TeachingQualificationCertNo = teachingStaff.TeachingQualificationCertNo;
                staffDetails.TeachingType = teachingStaff.TeachingType;
                staffDetails.UpdatedBy = teachingStaff.UpdatedBy;
                staffDetails.YearOfFirstAppointment = teachingStaff.YearOfFirstAppointment;
                staffDetails.YearOfPostingToCollege = teachingStaff.YearOfPostingToCollege;
                staffDetails.YearOfPresentAppointment = teachingStaff.YearOfPresentAppointment;
                staffDetails.DateFetched = DateTime.Now;
                staffDetails.DueForPromotion = teachingStaff.DueForPromotion;
                staffDetails.RetiredDate = teachingStaff.RetiredDate;
                staffDetails.BasicSalary = teachingStaff.BasicSalary;
                staffDetails.BasicSalaryPromotion = teachingStaff.BasicSalaryPromotion;
                staffDetails.StaffCategory = teachingStaff.StaffCategory;
                staffDetails.StaffRank = teachingStaff.StaffRank;
                staffDetails.StaffType = teachingStaff.StaffType;
                staffDetails.Step = teachingStaff.Step;
                staffDetails.StepPromotion = teachingStaff.StepPromotion;
                staffDetails.GradeLevelPromotion = teachingStaff.GradeLevelPromotion;
                staffDetails.IsRetired = teachingStaff.IsRetired;
                staffDetails.StaffCategoryCode = teachingStaff.StaffCategoryCode;
                staffDetails.Department = teachingStaff.Department;






                using (var scope = new TransactionScope()) {
                    _staffRepo.Update(staffDetails);

                  //  _allowancesRepo.Delete(x => x.StaffId == staffDetails.Id && x.CollegeID == collegeID);
                    _certificateRepo.Delete(x => x.StaffId == staffDetails.Id && x.CollegeID == collegeID);

                   // _allowancesRepo.Create(staffAllowance);

                    if (teachingStaff.Certificates != null && teachingStaff.Certificates.Count > 0)
                    {
                        var staffCertificate = new List<Certificate>();
                        foreach (var certificateVM in teachingStaff.Certificates)
                        {

                            var bytes = Convert.FromBase64String(certificateVM.Image);
                            var fileSteam = new StreamContent(new MemoryStream(bytes));
                            var fileName = Guid.NewGuid().ToString()  + certificateVM.Name.ToString().Substring(certificateVM.Name.IndexOf('.') + 0);


                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _configration.GetSection("TeachingStaffCertificateUploadPath").Value + "\\" + collegeID);
                            {
                                Directory.CreateDirectory(path);
                            }

                            using (FileStream data = new FileStream(Path.Combine(path, fileName), FileMode.Create, FileAccess.Write))
                            {
                                fileSteam.CopyToAsync(data);
                            }
                            var certificate = new Certificate
                            {
                                CollegeID = collegeID,
                                DateFetched = DateTime.Now,
                                Name = certificateVM.Name,
                                Url = fileName,
                                StaffId = staffDetails.Id

                            };

                            staffCertificate.Add(certificate);
                        }

                        _certificateRepo.Create(staffCertificate);
                    }

                    if (teachingStaff.Allowances != null)
                    {
                        var staffAll = teachingStaff.Allowances.Select(x => new StaffAllowance
                        {
                            Amount = x.Amount,
                            CollegeID = collegeID,
                            CreatedBy = x.CreatedBy,
                            DateCreated = x.DateCreated,
                            DateFetched = DateTime.Now,
                            DateUpdated = x.DateUpdated,
                            SourceID = x.Id,
                            IsActive = x.IsActive,
                            IsDeleted = x.IsDeleted,
                            Name = x.Name,
                            StaffId = staffDetails.Id,
                            SourceStaffId = teachingStaff.Id,
                            UpdatedBy = x.UpdatedBy
                        }).ToList();

                        var existingstaffAll = _staffAllowanceRepo.All().ToList();
                        _staffAllowanceRepo.Delete(existingstaffAll);
                        _staffAllowanceRepo.Create(staffAll);
                    }

                    if (teachingStaff.AllowancePromotionVM != null)
                    {
                        var staffPromotionAllowance = teachingStaff.Allowances.Select(x => new StaffDueForPromotionallowance
                        {
                            Amount = x.Amount,
                            CollegeID = collegeID,
                            CreatedBy = x.CreatedBy,
                            DateCreated = x.DateCreated,
                            DateFetched = DateTime.Now,
                            DateUpdated = x.DateUpdated,
                            SourceID = x.Id,
                            IsActive = x.IsActive,
                            IsDeleted = x.IsDeleted,
                            Name = x.Name,
                            StaffId = staffDetails.Id,
                            SourceStaffId = teachingStaff.Id,
                            UpdatedBy = x.UpdatedBy
                        }).ToList();
                        var existingPromoStaffAll = _staffPromotionallowanceRepo.All().ToList();
                        _staffPromotionallowanceRepo.Delete(existingPromoStaffAll);
                        _staffPromotionallowanceRepo.Create(staffPromotionAllowance);
                    }

                    scope.Complete();
                }

                

                resp = new ResponseData<TeachingStaff>
                {
                    Message = "College Staff Updated successfully",
                    RespCode = "00",
                    IsSuccessful = true
                };
                return resp;
            }
            catch (Exception ex)
            {
                ErrorLogManager.Error(ex);
                return new ResponseData<TeachingStaff>
                {
                    Message = "Operation failed",
                    RespCode = "04",
                    IsSuccessful = false
                };

            }
        }
    }
}
