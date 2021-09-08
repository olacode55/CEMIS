
using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Utility.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CEMIS.Utility.ViewModel.DashBoardViewModel;

namespace Cemis.Business.Repository
{
    public class ReportRepository : IReport
    {
        private readonly appContext _context;

        public ReportRepository(appContext context)
        {
            _context = context;
        }

        public CollegeSumaryReportDto FetchStaffDashBoardReport()
        {
            int staffnumberofsynched = (from p in _context.TeachingStaff
                         where p.IsSynched == true
                         select p).Count();
            int staffnumberofpending = (from p in _context.TeachingStaff
                                   where p.IsSynched == false
                                   select p).Count();
            int collegesynched = (from p in _context.Colleges
                                 where p.IsSynched == true
                                 select p).Count();
            int collegepending = (from p in _context.Colleges
                                 where p.IsSynched == false
                                  select p).Count();
            int leadershipsynched = (from p in _context.CollegeLeadership
                                     where p.IsSynched == true
                                     select p).Count();
            int leadershippending = (from p in _context.CollegeLeadership
                                     where p.IsSynched == false
                                     select p).Count();

            CollegeSumaryReportDto collegeSumary = new CollegeSumaryReportDto
            {
                StaffNoSynched = staffnumberofsynched,
                staffNumberPending = staffnumberofpending,
                CollegeNoSynched = collegesynched,
                CollegeNumberPending = collegepending,
                LeadershipNoSynched = leadershipsynched,
                LeaderShipNumberPending = leadershippending


            };
            return collegeSumary;

        }
    }
}