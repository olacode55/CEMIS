using Cemis.Data.Central.Entities;
using CEMIS.Data.Central;
using CEMIS.Utility.CentralReportFilterVM;
using CEMIS.Utility.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Central.Interface
{
    public interface IReport
    {
        List<CollegeLeadershipViewModel> CollegeLeadership(LeadershipReportFilterVM leadershipFilterVM);
        List<TeachingStaffViewModel> TeachingStaff(TeachingStaffReportVM teachingReportStaffVM);
        List<CollegeFacilityVM> CollegeFacility(FacilityReportFilter facilityReportFilter);
        List<College> CollegeInformation(string name);
        CollegeSummary FetchStaffDashBoardReport();
        CollegeSummary FetchStudentDashBoardReport(long collgeID);
        List<StudentViewModel> StudentReport(StudenReporttFilterVM studentFilterVM);
        List<ProgramViewModel> CollegePrograme(ProgramReportFilterVM programFilterVM);
        CollegeFormDataViewModel GetCollegeSummary(long collegeID);
        List<CourseOfferedDTO> CollegeCourseReport(CourseReportFilterVM courseFilterVM);
        List<ResultViewModel> StudentResultReport(ResultReportFilterVM resultFilterVM);
        List<CommitteMemberViewModel> CommitteeMembersReport(CommitteeMembersFilterVM committeeMemberVM);
        List<CouncilMemberViewModel> CouncilMembersReport(CommitteeMembersFilterVM committeeMemberVM);

        DashboardHistory getDashBoardHistory(long userId);
        void UpdateDashboardHistory(DashboardHistory dashboard);
    }
}
