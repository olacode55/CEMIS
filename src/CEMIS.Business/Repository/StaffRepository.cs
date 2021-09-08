using CEMIS.Business.Interface;
using CEMIS.Business.Repository;
using CEMIS.Data;
using CEMIS.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CEMIS.Business
{
    public class StaffRepository : IStaff
    {
        private IRepository<TeachingStaff> _staffRepo;
        private IRepository<APIRequestLog> _apiRequestRepo;
        private IRepository<Certificate> _CertificateRepo;
        private IConfiguration _configration;
        private readonly ICertificate _certificate;
        private readonly IRepository<StaffDueForPromotionAllowance> _staffDueforPromotionAllowance;
        private IRepository<StaffAllowance> _staffAllowanceRepo;
        private readonly IStaffAllowance _Staffallowance;
        private readonly IAuthUser _authUser;
        private IRepository<Allowance> _allowance;
        private readonly IStaffDueForPromotionAllowance _staffDueForPromotion;
        private readonly IBasicSalary _basicSalary;
        private readonly IStaffCategory _staffCategory;
        private readonly IStaffRank _staffRank;

        public StaffRepository(IRepository<TeachingStaff> staffRepo, IRepository<APIRequestLog> apiRequestRepo,  IAuthUser authUser,
            IRepository<StaffDueForPromotionAllowance> staffDueforPromotionAllowance, IRepository<StaffAllowance>  staffAllowanceRepo,
            IBasicSalary basicSalary, IConfiguration configration, IRepository<Certificate> CertificateRepo, ICertificate certificate,IStaffRank staffRank,
            IStaffAllowance Staffallowance, IRepository<Allowance> allowance, IStaffCategory staffCategory, IStaffDueForPromotionAllowance staffDueForPromotion)
        {
            _staffRepo = staffRepo;
            _apiRequestRepo = apiRequestRepo;
            _CertificateRepo = CertificateRepo;
            _configration = configration;
            _certificate = certificate;
            _staffDueforPromotionAllowance = staffDueforPromotionAllowance;
            _staffAllowanceRepo = staffAllowanceRepo;
            _Staffallowance = Staffallowance;
            _authUser = authUser;
            _allowance = allowance;
            _staffDueForPromotion = staffDueForPromotion;
            _basicSalary = basicSalary;
            _staffCategory = staffCategory;
            _staffRank = staffRank;
        }
        public List<TeachingStaff> GetAllTeachingStaff()
        {
            return _staffRepo.All().Where(m => m.IsDeleted == false && m.IsActive == true && m.IsRetired==false).ToList();
        }
        public  bool CreateTeachingStaff(TeachingStaffViewModel model, bool LogRequest)
        {
                try
                {

                var basicsalary = _basicSalary.GetBasicSalarysById(Convert.ToInt32(model.GradeLevel), Convert.ToInt32 (model.step));
                var staffcategory = _staffCategory.GetStaffCategory(long.Parse(model.staffCategory));
                var staffrank = _staffRank.GetPrincipal(long.Parse(model.staffRank));
                var staff = new TeachingStaff
                    {
                        FirstName = model.FirstName,
                        MiddleName = model.MiddleName,
                        LastName = model.Lastname,
                        Gender = model.gender,
                        LecturerGrade = Convert.ToInt32(model.LecturerGrade),
                        MainAdminRole = Convert.ToInt32(model.MainAdminRole),
                        DateOfFirstAppointment = model.DateOfFirstAppointment,
                        DateOfCurrentAppointment = model.DateOfCurrentAppointment,
                        AcademicQualification = model.AcademicQualification,
                        AcademicQualificationCertNo = model.AcademicQualificationCertNo,
                        TeachingQualification = model.TeachingQualification,
                        TeachingQualificationCertNo = model.TeachingQualificationCertNo,
                        StaffFileNo = model.StaffFileNo,
                        SourceOfSalary = model.SourceOfSalary,
                        DateOfBirth = model.DateOfBirth,
                        YearOfFirstAppointment = model.YearOfFirstAppointment,
                        YearOfPresentAppointment = model.YearOfPresentAppointment,
                        YearOfPostingToCollege = model.YearOfPostingToCollege,
                        SubjectOfQualification = model.SubjectOfQualification,
                        AreaOfSpecialization = model.AreaOfSpecialization,
                        MainSubjectTaught = model.MainSubjectTaught,
                        TeachingType = model.TeachingType,
                        InServiceTraining = model.InServiceTraining,
                        Staffcategory =Convert.ToInt32( model.staffCategory),
                        Staffrank = Convert.ToInt32(model.staffRank),
                        Stafftype = model.staffType,
                        GradeLevel = Convert.ToInt32(model.GradeLevel),
                        Step = Convert.ToInt32(model.step),
                        Basicsalary = Convert.ToInt32(basicsalary.Id),
                        StaffCategoryCode = staffcategory.Code,
                        DueForPromotion= model.DueForPromotion,
                        RetiredDate = model.retiredDate,
                        GradeLevelPromotion = Convert.ToInt32(model.gradeLevelPromotion),
                        StepPromotion = Convert.ToInt32(model.stepPromotion),
                        BasicsalaryPromotion = model.basicsalaryPromotion,
                        AwardingInstitutionforHighestQualification = model.awardingInstitutionforHighestQualification,
                        AwardingInstitutionforHighestTeachingQualification = model.awardingInstitutionforHighestTeachingQualification,
                        Departments = model.department, 
                        IsSynched = false,
                        IsDeleted = false,
                        IsActive = true,
                        DateCreated = DateTime.Now,
                        CreatedBy= long.Parse(_authUser.UserId),
                         
            };
                if (staffrank == true)
                {
                    staff.OfficerStatus = "Principal Officer";
                }
                else
                {
                    staff.OfficerStatus = " Non Principal Officers";
                }

                if (LogRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                        string url = _configration.GetSection("BaseAPIURl").Value + "staff";
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Post,
                            Synched = false,
                            Url = url
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    _staffRepo.Create(staff);

                if (model.Certificates.Any())
                {
                    var certs = model.Certificates.Where(x => !String.IsNullOrEmpty(x.Name));
                    foreach (var cert in certs)
                    {
                        Certificate cetificate = new Certificate()
                        {
                            Name = cert.Name,
                            Url = cert.FilePath,
                            StaffId = staff.Id,
                            IsActive = true,
                            IsDeleted = false,
                            DateCreated = DateTime.Now,
                            CreatedBy= long.Parse(_authUser.UserId),
                        };
                        _CertificateRepo.Create(cetificate);
                    }

                   
                }
               

                if (model.StaffAllowances.Any())
                {
                    var allowances = model.StaffAllowances.Where(x => !String.IsNullOrEmpty(x.name) && x.amount >= 0);
                    var all = _allowance.Filter(x=> x.IsBasicSalary==true).FirstOrDefault();

                    StaffAllowance staffs = new StaffAllowance()
                    {
                        Name = all.Name,
                        Amount =basicsalary.Amount,
                        AllowanceId = all.Id,
                        StaffId= staff.Id,
                        IsBasicSalary = true,
                        IsActive = true,
                        IsDeleted = false,
                        DateCreated = DateTime.Now,
                        CreatedBy = long.Parse(_authUser.UserId),

                    };
                    _staffAllowanceRepo.Create(staffs);

                    foreach (var allowance in allowances)
                    {
                        StaffAllowance staffAllowance = new StaffAllowance()
                        {
                            Name = allowance.name,
                            Amount = allowance.amount,
                            AllowanceId = allowance.AllowanceId,
                            StaffId = staff.Id,
                            IsActive = true,
                            IsBasicSalary = false,
                            IsDeleted = false,
                            DateCreated= DateTime.Now,
                            CreatedBy= long.Parse(_authUser.UserId),
                        };
                       _staffAllowanceRepo.Create(staffAllowance);

                    }


                }


                if (model.staffDueForPromotions.Any())
                {
                    var allowances = model.staffDueForPromotions.Where(x => !String.IsNullOrEmpty(x.name) && x.amount >= 0);
                    foreach (var allowance in allowances)
                    {
                        StaffDueForPromotionAllowance staffAllowance = new StaffDueForPromotionAllowance()
                        {
                            Name = allowance.name,
                            Amount = allowance.amount,
                            AllowanceId = allowance.AllowanceId,
                            StaffId = staff.Id,
                            IsActive = true,
                            IsDeleted = false,
                            DateCreated = DateTime.Now,
                            CreatedBy = long.Parse(_authUser.UserId),
                        };
                        _staffDueforPromotionAllowance.Create(staffAllowance);
                    }


                }
            }
                catch (Exception ex)
                {


                }
            
            return true;
        }



        public TeachingStaff GetTeachingStaffById(long Id)
        {
            var staff = _staffRepo.Find(Id);
            return staff;
        }
        public bool UpdateTeachingStaff(TeachingStaffViewModel model, bool LogRequest)
        {
          
                var basicsalary = _basicSalary.GetBasicSalarysById(Convert.ToInt32(model.GradeLevel), Convert.ToInt32(model.step));
                var staffcategory = _staffCategory.GetStaffCategory(long.Parse(model.staffCategory));
                var staffrank = _staffRank.GetPrincipal(long.Parse(model.staffRank));
            try
                {
                    var staff = _staffRepo.Find(model.Id);
                        staff.FirstName = model.FirstName;
                        staff.MiddleName = model.MiddleName;
                        staff.LastName = model.Lastname;
                        staff.Gender = model.gender;
                        staff.LecturerGrade = Convert.ToInt32(model.LecturerGrade);
                        staff.MainAdminRole = Convert.ToInt32(model.MainAdminRole);
                        staff.DateOfFirstAppointment = model.DateOfFirstAppointment;
                        staff.DateOfCurrentAppointment = model.DateOfCurrentAppointment;
                        staff.AcademicQualification = model.AcademicQualification;
                        staff.AcademicQualificationCertNo = model.AcademicQualificationCertNo;
                        staff.TeachingQualification = model.TeachingQualification;
                        staff.TeachingQualificationCertNo = model.TeachingQualificationCertNo;
                        staff.StaffFileNo = model.StaffFileNo;
                        staff.SourceOfSalary = model.SourceOfSalary;
                        staff.DateOfBirth = model.DateOfBirth;
                        staff.YearOfFirstAppointment = model.YearOfFirstAppointment;
                        staff.YearOfPresentAppointment = model.YearOfPresentAppointment;
                        staff.YearOfPostingToCollege = model.YearOfPostingToCollege;
                        staff.SubjectOfQualification = model.SubjectOfQualification;
                        staff.AreaOfSpecialization = model.AreaOfSpecialization;
                        staff.MainSubjectTaught = model.MainSubjectTaught;
                        staff.TeachingType = model.TeachingType;
                        staff.InServiceTraining = model.InServiceTraining;
                        staff.Staffcategory = Convert.ToInt32(model.staffCategory);
                        staff.Staffrank = Convert.ToInt32(model.staffRank);
                        staff.Stafftype = model.staffType;
                        staff.GradeLevel = Convert.ToInt32(model.GradeLevel);
                        staff.Step = Convert.ToInt32(model.step);
                        staff.Basicsalary = Convert.ToInt32(basicsalary.Id);
                        staff.DueForPromotion = model.DueForPromotion;
                        staff.StaffCategoryCode = staffcategory.Code;
                        staff.GradeLevelPromotion = Convert.ToInt32(model.gradeLevelPromotion);
                        staff.StepPromotion = Convert.ToInt32(model.stepPromotion);
                        staff.BasicsalaryPromotion = model.basicsalaryPromotion;
                        staff.Departments = model.department;
                        staff.RetiredDate = model.retiredDate;
                        staff.AwardingInstitutionforHighestQualification = model.awardingInstitutionforHighestQualification;
                        staff.AwardingInstitutionforHighestTeachingQualification = model.awardingInstitutionforHighestTeachingQualification;
                        staff.IsSynched = model.IsSynched;
                        staff.IsDeleted = false;
                        staff.IsActive = true;
                        staff.DateUpdated = DateTime.Now;
                        staff.CreatedBy = long.Parse(_authUser.UserId);
                        if (staffrank==true)
                          {
                           staff.OfficerStatus = "Principal Officer";

                             }
                         else
                        {
                         staff.OfficerStatus = " Non Principal Officers";
                        }
                _staffRepo.Update(staff);
                    if (LogRequest)
                    {
                        var data = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                        var apiRequestLog = new APIRequestLog
                        {
                            Data = data,
                            RequestType = HTTPRequestType.Put,
                            Synched = false,
                            Url = _configration.GetSection("BaseAPIURl").Value + "/staff"
                        };
                        _apiRequestRepo.Create(apiRequestLog);
                    }
                    if (model.Certificates.Any())
                    {
                        _certificate.DeleteCertificate(staff.Id);
                    }
                    if (model.Certificates.Any())
                    {
                        var certs = model.Certificates.Where(x => !String.IsNullOrEmpty(x.Name));
                        foreach (var cert in certs)
                        {
                            Certificate cetificate = new Certificate()
                            {
                                Name = cert.Name,
                                Url = cert.FilePath,
                                StaffId = staff.Id,
                                IsActive = true,
                                IsDeleted = false,
                                DateUpdated = DateTime.Now,
                                UpdatedBy = long.Parse(_authUser.UserId),
                            };
                            _CertificateRepo.Create(cetificate);
                        }

                    }

              
                if (model.StaffAllowances.Any())
                    {
                        _Staffallowance.DeleteStaffAllowance(staff.Id);

                    }
                    if (model.StaffAllowances.Any())
                    {
                        var allowances = model.StaffAllowances.Where(x => !String.IsNullOrEmpty(x.name) && x.amount >= 0);
                        foreach (var allowance in allowances)
                        {
                            StaffAllowance staffAllowance = new StaffAllowance()
                            {
                                Name = allowance.name,
                                Amount = allowance.amount,
                                AllowanceId = allowance.AllowanceId,
                                StaffId = staff.Id,
                                IsActive = true,
                                IsDeleted = false,
                                UpdatedBy = long.Parse(_authUser.UserId),
                                DateUpdated = DateTime.Now,
                                DateCreated = DateTime.Now,

                            };
                            _staffAllowanceRepo.Create(staffAllowance);
                        }
                    }
                var all = _allowance.Filter(x => x.IsBasicSalary == true).FirstOrDefault();

                StaffAllowance staffs = new StaffAllowance()
                {
                    Name = all.Name,
                    Amount = basicsalary.Amount,
                    AllowanceId = all.Id,
                    StaffId = staff.Id,
                    IsBasicSalary = true,
                    IsActive = true,
                    IsDeleted = false,
                    DateCreated = DateTime.Now,
                    CreatedBy = long.Parse(_authUser.UserId),

                };
                _staffAllowanceRepo.Create(staffs);

                //var datas = _staffAllowanceRepo.Filter(x => x.IsBasicSalary == true && x.StaffId == staff.Id).FirstOrDefault();
                //datas.Amount = basicsalary.Amount;
                //datas.IsBasicSalary = true;
                //datas.DateCreated = DateTime.Now;
                //datas.DateUpdated = DateTime.Now;
                //_staffAllowanceRepo.Update(datas);


                if (model.staffDueForPromotions.Any())
                        {
                            _staffDueForPromotion.DeleteStaffDueForPromotionAllowance(staff.Id);

                        }
                        if (model.staffDueForPromotions.Any())
                        {
                            var P_allowances = model.staffDueForPromotions.Where(x => !String.IsNullOrEmpty(x.name) && x.amount >= 0);
                            foreach (var allowance in P_allowances)
                            {
                                StaffDueForPromotionAllowance staffAllowance = new StaffDueForPromotionAllowance()
                                {
                                    Name = allowance.name,
                                    Amount = allowance.amount,
                                    AllowanceId = allowance.AllowanceId,
                                    StaffId = staff.Id,
                                    IsActive = true,
                                    IsDeleted = false,
                                    UpdatedBy = long.Parse(_authUser.UserId),
                                    DateUpdated = DateTime.Now,
                                    DateCreated = DateTime.Now,
                                };
                                _staffDueforPromotionAllowance.Create(staffAllowance);
                            }
                        }
                   
                }
                catch (Exception ex)
                {

                }
            
            return true;
        }

        //public ResponseData<TeachingStaffViewModel> DeleteTeachingStaff(long Id, bool LogRequest)
        //{
        //    ResponseData<TeachingStaff> resp;
        //    using (var transaction = new TransactionScope())
        //    {
        //        try
        //        {
        //            var staff = GetTeachingStaffById(Id);
        //            staff.IsDeleted = true;
        //            staff.IsActive = false;

        //            _staffRepo.Update(staff);

        //            if (LogRequest)
        //            {
        //                var data = Newtonsoft.Json.JsonConvert.SerializeObject(staff);
        //                var apiRequestLog = new APIRequestLog
        //                {
        //                    Data = data,
        //                    RequestType = HTTPRequestType.Put,
        //                    Synched = false,
        //                    Url = _configration.GetSection("BaseAPIURl").Value + "staff"
        //                };
        //                _apiRequestRepo.Create(apiRequestLog);
        //            }
        //            transaction.Complete();

        //            resp = new ResponseData<TeachingStaff>
        //            {
        //                Message = "Staff deleted successfully",
        //                RespCode = "00",
        //                IsSuccessful = true
        //            };

        //            return resp;
        //        }
        //        catch (Exception ex)
        //        {
        //            return new ResponseData<TeachingStaff>
        //            {
        //                Message = "Operation failed",
        //                RespCode = "04",
        //                IsSuccessful = false
        //            };
        //        }
        //    }
        //}

        public TeachingStaff GetTeachingStaffById(string staffno)
        {
            var staff = _staffRepo.Filter(a => a.StaffFileNo == staffno).FirstOrDefault();
            return staff;

        }

        public void RetireStaff(long Id)
        {
            var staff = _staffRepo.Find(Id);
            staff.IsRetired = true;
            _staffRepo.Update(staff);

        }
    }
}
