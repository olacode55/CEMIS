using Cemis.Data.Central.Entities;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility;
using CEMIS.Utility.CentralReportFilterVM;
using CEMIS.Utility.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Cemis.Business.Central.Repository
{
    public class ReportRepository : IReport
    {
        private appContextCentral _context;
        private IRepository<DashboardHistory> _dashboardHisRepo;
        public ReportRepository(appContextCentral context , IRepository<DashboardHistory> dashboardHisRepo)
        {
            _context = context;
            _dashboardHisRepo = dashboardHisRepo;
        }

        public List<TeachingStaffViewModel> TeachingStaff(TeachingStaffReportVM teachingReportStaffVM)
        {
            teachingReportStaffVM.name = teachingReportStaffVM.name == null ? string.Empty : teachingReportStaffVM.name;
            teachingReportStaffVM.fileNo = teachingReportStaffVM.fileNo == null ? string.Empty : teachingReportStaffVM.fileNo;
            // grade = grade == null ? string.Empty : grade;
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {

                DataTable dt = new DataTable();
                List<TeachingStaffViewModel> details = new List<TeachingStaffViewModel>();

                SqlCommand cmd = new SqlCommand("GetTeachingStaffReport", myCon);
                cmd.Parameters.AddWithValue("@Name", teachingReportStaffVM.name);
                cmd.Parameters.AddWithValue("@Collegeid", teachingReportStaffVM.collegeId);
                cmd.Parameters.AddWithValue("@FileNo", teachingReportStaffVM.fileNo);
                cmd.Parameters.AddWithValue("@Grade", teachingReportStaffVM.grade);
                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    TeachingStaffViewModel obj = new TeachingStaffViewModel
                    {
                        Id = (long)dr["Id"],
                        CollegeID = (long)dr["CollegeID"],
                        AcademicQualification = dr["AcademicQualification"].ToString(),
                        MainAdminRole = dr["MainAdminRole"].ToString(),
                        AcademicQualificationCertNo = dr["AcademicQualificationCertNo"].ToString(),
                        DateOfBirth = (DateTime)dr["DateOfBirth"],
                        DateOfCurrentAppointment = (DateTime)dr["DateOfCurrentAppointment"],
                        AreaOfSpecialization = dr["AreaOfSpecialization"].ToString(),
                        DateOfFirstAppointment = (DateTime)dr["DateOfFirstAppointment"],
                        gender = (Gender)dr["Gender"],
                        LecturerGrade = dr["LecturerGrade"].ToString(),
                        GradeLevel = dr["GradeLevel"].ToString(),
                        InServiceTraining = dr["InServiceTraining"].ToString(),
                        MainSubjectTaught = dr["MainSubjectTaught"].ToString(),
                        FirstName = dr["Name"].ToString(),
                        SourceOfSalary = (SourceOfIncome)dr["SourceOfSalary"],
                        StaffFileNo = dr["StaffFileNo"].ToString(),
                        SubjectOfQualification = dr["SubjectOfQualification"].ToString(),
                        TeachingQualification = dr["TeachingQualification"].ToString(),
                        TeachingQualificationCertNo = dr["TeachingQualificationCertNo"].ToString(),
                        TeachingType = (TeachingType) dr["TeachingType"],
                        YearOfFirstAppointment = dr["YearOfFirstAppointment"].ToString(),
                        YearOfPostingToCollege = dr["YearOfPostingToCollege"].ToString(),
                        YearOfPresentAppointment = dr["YearOfPresentAppointment"].ToString(),
                        College = dr["College"].ToString()
                    };
                    details.Add(obj);
                }
                myCon.Close();

                return details;
            }
        }

        public List<CollegeLeadershipViewModel> CollegeLeadership(LeadershipReportFilterVM leadershipFilterVM)
        {
            leadershipFilterVM.name = leadershipFilterVM.name == null ? string.Empty : leadershipFilterVM.name;
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                DateTime? date = null;
                DataTable dt = new DataTable();
                List<CollegeLeadershipViewModel> details = new List<CollegeLeadershipViewModel>();

                SqlCommand cmd = new SqlCommand("GetCollegeLeadershipReport", myCon);
                cmd.Parameters.AddWithValue("@Name", leadershipFilterVM.name);
                cmd.Parameters.AddWithValue("@Collegeid", leadershipFilterVM.collegeId);
                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    
                    CollegeLeadershipViewModel obj = new CollegeLeadershipViewModel();
                    obj.Id = (long)dr["Id"];
                    obj.CollegeID = (long)dr["CollegeID"];
                    obj.CouncilMember = dr["CouncilMember"].ToString();
                    obj.CouncilMemberEmail = dr["CouncilMemberEmail"].ToString();
                    obj.CouncilMemberPhone1 = dr["CouncilMemberPhone1"].ToString();
                    obj.CouncilMemberPhone2 = dr["CouncilMemberPhone2"].ToString();
                    obj.CouncilMemberPostalAddress = dr["CouncilMemberPostalAddress"].ToString();
                    obj.CouncilMemberSponsor =  (Sponspor)Convert.ToInt32(dr["CouncilMemberSponsor"].ToString());
                    //obj.CouncilMemberSponsorGovernment = dr["CouncilMemberSponsorGovernment"].ToString();
                    obj.DateAppointed = Convert.ToDateTime(dr["DateAppointed"].ToString());
                    obj.DateLeft = dr["DateLeft"].ToString() != ""  ? Convert.ToDateTime(dr["DateLeft"].ToString()) : date;
                    obj.DateOfBirth = (DateTime)dr["DateOfBirth"];
                    obj.Gender = (Gender)dr["Gender"];
                    obj.Name = dr["Name"].ToString();
                    obj.Role = (Postion) dr["Role"];
                    obj.College = dr["College"].ToString();
                    details.Add(obj);
                }

                myCon.Close();
                return details;
            }

        }



        public List<CollegeFacilityVM> CollegeFacility(FacilityReportFilter facilityReportFilter)
        {
            facilityReportFilter.facility = facilityReportFilter.facility == null ? string.Empty : facilityReportFilter.facility;
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {

                DataTable dt = new DataTable();
                List<CollegeFacilityVM> details = new List<CollegeFacilityVM>();

                SqlCommand cmd = new SqlCommand("GetCollegeFacilityReport", myCon);
                cmd.Parameters.AddWithValue("@Facility", facilityReportFilter.facility);
                cmd.Parameters.AddWithValue("@Collegeid", facilityReportFilter.collegeId);
                cmd.Parameters.AddWithValue("@Seating", facilityReportFilter.seating);
                cmd.Parameters.AddWithValue("@Condition", facilityReportFilter.condition);
                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    CollegeFacilityVM obj = new CollegeFacilityVM();
                    obj.Id = (long)dr["Id"];
                    obj.Name = dr["Name"].ToString();
                    obj.DisabilityAccess = (DisabilityAccessAvailability)Convert.ToByte(dr["DisabilityAccess"]);
                    obj.FacilityType = dr["FacilityType"].ToString();
                    obj.FloorMaterial = (FloorMaterial)Convert.ToByte(dr["FloorMaterial"]);
                    obj.LengthInMeters = Convert.ToInt32(dr["LengthInMeters"]);
                    obj.PresentCondition = (ClassRoomCondition)Convert.ToByte(dr["PresentCondition"]);
                    obj.RoofMaterial = (RoofMaterial)Convert.ToByte(dr["RoofMaterial"]);
                    obj.Seatings = (SeatAvailability)Convert.ToByte(dr["Seatings"]);
                    obj.WidthInMeters = Convert.ToInt32(dr["WidthInMeters"]);
                    obj.YearOfConstruction = dr["YearOfConstruction"].ToString();

                    obj.College = dr["College"].ToString();
                    details.Add(obj);
                }

                myCon.Close();
                return details;
            }
        }



        public List<StudentViewModel> StudentReport(StudenReporttFilterVM studentFilterVM)
        {
            studentFilterVM.studentName = studentFilterVM.studentName == null ? string.Empty : studentFilterVM.studentName;
            studentFilterVM.studentRef = studentFilterVM.studentRef == null ? string.Empty : studentFilterVM.studentRef;
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                var details = new List<StudentViewModel>();

                SqlCommand cmd = new SqlCommand("GetStudentReport", myCon);
                cmd.Parameters.AddWithValue("@StudentName", studentFilterVM.studentName);
                cmd.Parameters.AddWithValue("@Collegeid", studentFilterVM.collegeId);
                cmd.Parameters.AddWithValue("@StudentRef", studentFilterVM.studentRef);
                cmd.Parameters.AddWithValue("@Gender", studentFilterVM.gender);

                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new StudentViewModel();
                    obj.Id = (long)dr["Id"];
                    obj.StudentId = dr["StudentId"].ToString();
                    obj.ContactAddress = dr["ContactAddress"].ToString();
                    obj.Disability = dr["Disability"].ToString();
                    obj.District = dr["District"].ToString();
                    obj.DOB = (DateTime)dr["DOB"];
                    obj.College = dr["Name"].ToString();
                    obj.FirstChoiceCollege = dr["FirstChoiceCollege"].ToString();
                    obj.FirstChoiceProgram = dr["FirstChoiceProgram"].ToString();
                    obj.Gender = (Gender)dr["Gender"];
                    obj.HomeTown = dr["HomeTown"].ToString();
                    obj.LanguagesSpoken = dr["LanguagesSpoken"].ToString();
                    obj.MaritalStatus = dr["MaritalStatus"].ToString();
                    obj.OtherNames = dr["OtherNames"].ToString();
                    obj.Region = dr["Region"].ToString();
                    obj.Religion = dr["Religion"].ToString();
                    obj.SecondChoiceCollege = dr["SecondChoiceCollege"].ToString();
                    obj.SecondChoiceProgram = dr["SecondChoiceProgram"].ToString();
                    obj.TelephoneNumber = dr["TelephoneNumber"].ToString();
                    obj.ThirdChoiceCollege = dr["ThirdChoiceCollege"].ToString();
                    obj.ThreeChoiceProgram = dr["ThreeChoiceProgram"].ToString();
                    details.Add(obj);
                }
                myCon.Close();

                return details;
            }
        }


        public List<ProgramViewModel> CollegePrograme(ProgramReportFilterVM programFilterVM)
        {
            programFilterVM.program = programFilterVM.program == null ? string.Empty : programFilterVM.program;
            string isActive = programFilterVM.status == (int)ProgramStatus.Active ? "true" : programFilterVM.status == (int)ProgramStatus.Inactive ? "false" : string.Empty;

            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                var details = new List<ProgramViewModel>();

                SqlCommand cmd = new SqlCommand("GetCollegeProgramReport", myCon);
                cmd.Parameters.AddWithValue("@program", programFilterVM.program);
                cmd.Parameters.AddWithValue("@Collegeid", programFilterVM.collegeId);
                cmd.Parameters.AddWithValue("@Status", isActive);
                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    var obj = new ProgramViewModel();
                    obj.Id = (long)dr["Id"];
                    obj.Name = dr["Name"].ToString();
                    obj.DateCreated = (DateTime)dr["DateCreated"];
                    obj.IsActive = (bool)dr["IsActive"];
                    obj.IsDeleted = (bool)dr["IsDeleted"];
                    obj.College = dr["College"].ToString();
                    details.Add(obj);
                }

                myCon.Close();
                return details;
            }
        }

        public List<College> CollegeInformation(string name)
        {
            name = name == null ? string.Empty : name;
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {

                DataTable dt = new DataTable();
                List<College> details = new List<College>();

                SqlCommand cmd = new SqlCommand("GetCollegeInformationReport", myCon);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    College obj = new College();
                    obj.Id = (long)dr["Id"];
                    obj.GIS = dr["GIS"].ToString();
                    obj.Name = dr["Name"].ToString();
                    obj.Email = dr["Email"].ToString();
                    obj.Phone = dr["Phone"].ToString();
                    obj.Address = dr["Address"].ToString();
                    obj.VicePrincipalEmail = dr["VicePrincipalEmail"].ToString();
                    obj.VicePrincipalPhone = dr["VicePrincipalPhone"].ToString();
                    obj.PrincipalEmail = dr["PrincipalEmail"].ToString();
                    obj.PrincipalPhone = dr["PrincipalPhone"].ToString();


                    details.Add(obj);
                }

                myCon.Close();
                return details;
            }
        }

        public CollegeFormDataViewModel GetCollegeSummary(long collegeID)
        {


            var collegeSummary = _context.Colleges.FirstOrDefault(x => x.Id == collegeID);
            var formData = new CollegeFormDataViewModel();


            formData.Name = collegeSummary.Name;
            formData.Address = collegeSummary.Address;
            formData.Email = collegeSummary.Email;
            formData.Phone = collegeSummary.Phone;
            formData.GIS = collegeSummary.GIS;
            formData.ServiceOfferedId = collegeSummary.ServiceOfferedId;
            formData.SecretaryCount = collegeSummary.SecretaryCount;
            formData.DriversCount = collegeSummary.DriversCount;
            formData.HandymenCount = collegeSummary.HandymenCount;
            formData.CleanerCount = collegeSummary.CleanerCount;
            formData.SecurityGuardCount = collegeSummary.SecurityGuardCount;
            formData.PrincipalName = collegeSummary.PrincipalName;
            formData.PrincipalEmail = collegeSummary.PrincipalEmail;
            formData.PrincipalPhone = collegeSummary.PrincipalPhone;
            formData.VicePrincipalName = collegeSummary.VicePrincipalName;
            formData.VicePrincipalEmail = collegeSummary.VicePrincipalEmail;
            formData.VicePrincipalPhone = collegeSummary.VicePrincipalPhone;
            formData.ICTSystemName = collegeSummary.ICTSystemName;
            formData.ICTSystemEmail = collegeSummary.ICTSystemEmail;
            formData.ICTSystemPhone = collegeSummary.ICTSystemPhone;
            formData.AdminOfficerName = collegeSummary.AdminOfficerName;
            formData.AdminOfficerEmail = collegeSummary.AdminOfficerEmail;
            formData.AdminOfficerPhone = collegeSummary.AdminOfficerPhone;

            formData.CollegeFacility = _context.CollegeFacility.Where(x => x.CollegeID == collegeID).Take(10)
                .Select(x => new CollegeFacilityViewModel
                {
                    Name = x.Name,
                    FacilityTypeCentral = x.FacilityType,
                    YearOfConstruction = x.YearOfConstruction,
                    //Number = x.Number
                }).ToList();

            var classRoomData = _context.CollegeClassRoomData.FirstOrDefault(x => x.CollegeId == collegeID);
            if (classRoomData != null)
            {
                formData.ClassRoomCount = classRoomData.ClassRoomCount;
                formData.StaffRoomCount = classRoomData.StaffRoomCount;
                formData.OfficeCount = classRoomData.OfficeCount;
                formData.LibraryCount = classRoomData.LibraryCount;
                formData.LaboratoryCount = classRoomData.LaboratoryCount;
                formData.StoreRoomCount = classRoomData.StoreRoomCount;
                formData.OthersCount = classRoomData.OthersCount;
                // formData.IsClassHeldOutside = classRoomData.IsClassHeldOutside;
            }

            formData.CollegeClassRoomInfo = _context.CollegeClassRoomInfo
                .Where(x => x.CollegeId == collegeID)
                 .Select(x => new CollegeClassRoomInfoViewModel
                 {
                     YearOfConstruction = x.YearOfConstruction,
                     PresentCondition = (ClassRoomCondition)x.PresentCondition,
                     LengthInMeters = x.LengthInMeters,
                     WidthInMeters = x.WidthInMeters,
                     FloorMaterial = (FloorMaterial)x.FloorMaterial,
                     WallMaterial = (WallMaterial)x.WallMaterial,
                     RoofMaterial = (RoofMaterial)x.RoofMaterial,
                     Seatings = (SeatAvailability)x.Seatings,
                     DisabilityAccess = (DisabilityAccessAvailability)x.DisabilityAccess,
                 }).ToList();


            //var classRoomInfo = _context.CollegeClassRoomInfo.Where(x => x.CollegeId == collegeID).SingleOrDefault();
            //if (classRoomData != null)
            //{
            //    formData.YearOfConstruction = classRoomInfo.YearOfConstruction;
            //    formData.PresentCondition = classRoomInfo.PresentCondition;
            //    formData.LengthInMeters = classRoomInfo.LengthInMeters;
            //    formData.WidthInMeters = classRoomInfo.WidthInMeters;
            //    formData.FloorMaterial = classRoomInfo.FloorMaterial;
            //    formData.WallMaterial = classRoomInfo.WallMaterial;
            //    formData.RoofMaterial = classRoomInfo.RoofMaterial;
            //    formData.Seatings = classRoomInfo.Seatings;
            //    formData.DisabilityAccess = classRoomInfo.DisabilityAccess;
            //}



            return formData;

        }

        public DashboardHistory getDashBoardHistory(long userId)
        {
           return _dashboardHisRepo.All().FirstOrDefault(x => x.UserID == userId);
        }

        public void UpdateDashboardHistory(DashboardHistory dashboard)
        {
            if (dashboard.ID == 0)
                _dashboardHisRepo.Create(dashboard);
            else
                _dashboardHisRepo.Update(dashboard);
        }


        public CollegeSummary FetchStaffDashBoardReport()
        {

            int teachingstaff = _context.TeachingStaff.Count();
            int college = _context.Colleges.Count();
            int leadership = _context.CollegeLeadership.Count();
            int facility = _context.CollegeFacility.Count();
            int classroom = _context.CollegeClassRoomInfo.Count();



            CollegeSummary collegeSumary = new CollegeSummary
            {
                Teachingstaff = teachingstaff,
                College = college,
                Leadership = leadership,
                Facility = facility,
                Classroom = classroom,
                
            };
            return collegeSumary;


        }


        public CollegeSummary FetchStudentDashBoardReport(long collgeID)
        {
            var student = _context.Student.Where(x => x.CollegeID == collgeID);
            int studentCount = student.Count();
            int registeredStudent = student.Where(x => x.IsRegistered == true).Count();
            int courses = _context.CourseOffered.Where(x => x.CollegeID == collgeID).Count();
            int program = _context.ServiceOffered.Where(x => x.CollegeID == collgeID).Count();



            CollegeSummary collegeSumary = new CollegeSummary
            {
              NoOfCoursesOffered = courses,
              StudentCount = studentCount,
              RegisteredStudentCount = registeredStudent,
              NoOfProgramsOffered = program


            };
            return collegeSumary;


        }


        public List<CourseOfferedDTO> CollegeCourseReport(CourseReportFilterVM courseFilterVM)
        {
            courseFilterVM.courseTitle = courseFilterVM.courseTitle == null ? string.Empty : courseFilterVM.courseTitle;
            courseFilterVM.courseCode = courseFilterVM.courseCode == null ? string.Empty : courseFilterVM.courseCode;
            string isActive = courseFilterVM.status == (int)ProgramStatus.Active ? "true" : courseFilterVM.status == (int)ProgramStatus.Inactive ? "false" : string.Empty;

            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                var details = new List<CourseOfferedDTO>();

                SqlCommand cmd = new SqlCommand("GetCollegeCoursesReport", myCon);
                cmd.Parameters.AddWithValue("@CourseTitle", courseFilterVM.courseTitle);
                cmd.Parameters.AddWithValue("@CourseCode", courseFilterVM.courseCode);
                cmd.Parameters.AddWithValue("@ProgramId", courseFilterVM.programId);
                cmd.Parameters.AddWithValue("@Collegeid", courseFilterVM.collegeId);
                cmd.Parameters.AddWithValue("@Status", isActive);
                cmd.Parameters.AddWithValue("@OptionId", courseFilterVM.optionId);
                cmd.Parameters.AddWithValue("@SemesterId", courseFilterVM.semesterId);
                cmd.Parameters.AddWithValue("@Level", courseFilterVM.Level.ToString());
                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    var obj = new CourseOfferedDTO();
                    obj.Id = (long)dr["Id"];
                    obj.CollegeName = dr["CollegeName"].ToString();
                    obj.CourseCode = dr["CourseCode"].ToString();
                    obj.CourseTitle = dr["CourseTitle"].ToString();
                    obj.ProgramName = dr["ProgramName"].ToString();
                    obj.Semester = (Semester)dr["Semester"];
                    obj.Credit = (byte)dr["Credit"];
                    obj.Level = dr["Level"].ToString();
                    obj.DateCreated = (DateTime)dr["DateCreated"];
                    obj.IsActive = (bool)dr["IsActive"];
                    obj.Option = (CourseOption)dr["Option"];
                    details.Add(obj);
                }

                myCon.Close();
                return details;
            }
        }


        public List<ResultViewModel> StudentResultReport(ResultReportFilterVM resultFilterVM)
        {
            resultFilterVM.studentId = resultFilterVM.studentId == null ? string.Empty : resultFilterVM.studentId;
            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            { 
                DataTable dt = new DataTable();
                var details = new List<ResultViewModel>();

                SqlCommand cmd = new SqlCommand("GetCollegeExaminationReport", myCon);
                cmd.Parameters.AddWithValue("@ProgramId", resultFilterVM.programId);
                cmd.Parameters.AddWithValue("@CourseId", resultFilterVM.courseId);
                cmd.Parameters.AddWithValue("@SemesterId", resultFilterVM.semesterId);
                cmd.Parameters.AddWithValue("@CollegeId", resultFilterVM.collegeId);
                cmd.Parameters.AddWithValue("@Level", resultFilterVM.level.ToString());
                cmd.Parameters.AddWithValue("@StudentId ", resultFilterVM.studentId);
                cmd.Parameters.AddWithValue("@SessionId ", resultFilterVM.sessionId);

                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    var obj = new ResultViewModel();
                    obj.Id = (long)dr["Id"];
                    obj.College = dr["College"].ToString();
                    obj.Course = dr["Course"].ToString();
                    obj.Program = dr["Program"].ToString();
                    obj.Score = dr["Score"].ToString(); 
                    obj.Grade = dr["Grade"].ToString();
                    obj.Level = dr["Level"].ToString(); 
                    obj.Session = dr["Session"].ToString();
                    obj.StudentName = dr["StudentName"].ToString();
                    details.Add(obj);
                }

                myCon.Close();
                return details;
            }
        }

        public List<CommitteMemberViewModel> CommitteeMembersReport(CommitteeMembersFilterVM committeeMemberVM)
        {
            committeeMemberVM.MemberName = committeeMemberVM.MemberName == null ? string.Empty : committeeMemberVM.MemberName;

            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                var details = new List<CommitteMemberViewModel>();

                SqlCommand cmd = new SqlCommand("GetCommitteeMembersReport", myCon);
                cmd.Parameters.AddWithValue("@MemberName", committeeMemberVM.MemberName);
                cmd.Parameters.AddWithValue("@CollegeId", committeeMemberVM.CollgeId);
                cmd.Parameters.AddWithValue("@Position", committeeMemberVM.Position);
                cmd.Parameters.AddWithValue("@SessionId", committeeMemberVM.SessionId);

                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    var obj = new CommitteMemberViewModel();
                    obj.Id = (long)dr["Id"];
                    obj.committeMemberName = dr["committeMemberName"].ToString();
                    obj.committeMemberPosition = (Postion)dr["committeMemberPosition"];
                    obj.committeName = dr["committeName"].ToString();
                    obj.IsActive = (bool)dr["IsActive"];
                    obj.SessionEndDate = (DateTime)dr["SessionEndDate"];
                    obj.SessionStartDate = (DateTime)dr["SessionStartDate"];
                    obj.sessionName = dr["sessionName"].ToString();
                    obj.DateCreated = (DateTime)dr["DateCreated"];
                    obj.CollegeName = dr["CollegeName"].ToString();
                    details.Add(obj);
                }

                myCon.Close();
                return details;
            }
        }


        public List<CouncilMemberViewModel> CouncilMembersReport(CommitteeMembersFilterVM committeeMemberVM)
        {
            committeeMemberVM.MemberName = committeeMemberVM.MemberName == null ? string.Empty : committeeMemberVM.MemberName;

            var connectionString = _context.Database.GetDbConnection().ConnectionString;
            using (SqlConnection myCon = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                var details = new List<CouncilMemberViewModel>();

                SqlCommand cmd = new SqlCommand("GetCouncilMembersReport", myCon);
                cmd.Parameters.AddWithValue("@MemberName", committeeMemberVM.MemberName);
                cmd.Parameters.AddWithValue("@CollegeId", committeeMemberVM.CollgeId);
                cmd.Parameters.AddWithValue("@Position", committeeMemberVM.Position);
                cmd.Parameters.AddWithValue("@SessionId", committeeMemberVM.SessionId);

                cmd.CommandType = CommandType.StoredProcedure;
                myCon.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new CouncilMemberViewModel();
                    obj.Id = (long)dr["Id"];
                    obj.councilMemberName = dr["councilMemberName"].ToString();
                    obj.councilMemberPosition = (Postion)dr["councilMemberPosition"];
                    obj.IsActive = (bool)dr["IsActive"];
                    obj.SessionEndDate = (DateTime)dr["SessionEndDate"];
                    obj.SessionStartDate = (DateTime)dr["SessionStartDate"];
                    obj.sessionName = dr["sessionName"].ToString();
                    obj.DateCreated = (DateTime)dr["DateCreated"];
                    obj.CollegeName = dr["CollegeName"].ToString();
                    details.Add(obj);
                }

                myCon.Close();
                return details;
            }
        }

    }

}

