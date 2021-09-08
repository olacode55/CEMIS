using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business.Interface;
using CEMIS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEMIS.Web.Controllers
{
   [Authorize]
    public class DashboardController : Controller
    {
        private readonly appContext _context;
        private readonly IReport _report;

        public DashboardController(appContext context, IReport report)
        {

            _context = context;
            _report = report;

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var user = User.Identity.IsAuthenticated;
            var report = _report.FetchStaffDashBoardReport();

            return View(report);
        }
    }
}
