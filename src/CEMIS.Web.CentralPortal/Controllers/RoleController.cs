using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.CentralPortal;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Http;
using Cemis.Business.Central.Interface;
using Newtonsoft.Json;
using CEMIS.Web.CentralPortal.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEMIS.Web.Central.Portal
{
    [Authorize]
    public class RoleController : BaseController
    {
        private readonly IRoleService _accountRepo;
        private readonly ILogger<RoleController> _logger;
        public RoleController(UserManager<User> userManager, RoleManager<Role> roleManager, IRoleService accountRepo, ILogger<RoleController> logger, SignInManager<User> signInManager, 
                             IConfiguration configuration, IHttpContextAccessor accessor, IActivityLog logActivityRepo,
                             IActionContextAccessor actionContextAccessor) : base(userManager, signInManager, roleManager, configuration, accessor, actionContextAccessor, logActivityRepo)
        {
            _accountRepo = accountRepo;
            _logger = logger;
        }
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
        #region Role
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView();
        }
        /// <summary>
        /// Create New Role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        // [Route("createrole")]
        public async Task<JsonResult> Create([FromForm] RoleDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(model);
            }

            // var user = User.Identity.IsAuthenticated ? User.Identity.Name : "Anonymous";
            var create = await _accountRepo.CreateRoleAsync(model);
            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Role created Successfully", Title = "Create Role", Type = NotificationsType.Success });
            await LogActivity("Role created Successfully", model);

            return new JsonResult(new { });
        }
        /// <summary>
        /// Retrieve All Active Roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getallroles")]
        public async Task<IActionResult> Index()
        {
            var roles = await _accountRepo.GetAllRolesAsync();
            return View(roles);
        }
        /// <summary>
        /// Retrieve Assigned and Un-Assigned Users to a Particular Role
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [HttpGet("getassignedandunassigneduserstorole")]
        public async Task<IActionResult> GetAssignedAndUnassignedUsersToRole(long roleid)
        {
            var getData = await _accountRepo.GetAssignedAndUnAssignedUserToRole(roleid);
            return View(getData);
        }
        /// <summary>
        /// Retrieve Single Role
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [HttpGet("getrole")]
        public async Task<IActionResult> GetRole(long id)
        {
            var getData = await _accountRepo.GetRole(id);
            return PartialView("_GetRolePartial", getData);
        }
        /// <summary>
        /// Retrieve Single Role
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> UpdateRole(long roleId)
        {
            var getData = await _accountRepo.GetRole(roleId);
            return PartialView("_UpdateRolePartial", getData);
        }
        /// <summary>
        /// Update Role
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRole([Bind("roleid,rolename,roledesc")]RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //pass the values to be created to the service
            RoleDTO rolemodel = new RoleDTO
            {
                rolename = model.rolename,
                roledesc = model.roledesc,
            };
            var update = await _accountRepo.UpdateRoleAsync(rolemodel, model.roleid);
            //if result does not return 1 as string , display error to user
            if (!string.IsNullOrEmpty(update) && update != "1")
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Operation failed", Title = "Create Role", Type = NotificationsType.Danger });
                await LogActivity("Operation failed", model);

                return RedirectToAction(nameof(Index));
            }

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Role updated Successfully", Title = "Update Role", Type = NotificationsType.Success });
            await LogActivity("Role updated Successfully", model);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Assign_user2_role(long id)
        {
            var u2role = await _accountRepo.GetAssignedAndUnAssignedUserToRole(id);
            return View("assign_user2_role", u2role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(nameof(PermissionEnum.AddRoleToPermission))]
        public async Task<IActionResult> Assign_user2_role([Bind("Chkbx,RoleId,RoleName")] long[] Chkbx, long RoleId, string RoleName)
        {
            if (ModelState.IsValid)
            {
                var asign = await _accountRepo.AssignUsersToRole(RoleId, Chkbx);
                if (!string.IsNullOrEmpty(asign) && asign != "1")
                {
                    //  this.AddNotification(ResponseErrorMessageUtility.RecordNotSaved, NotificationType.WARNING);
                    return RedirectToAction("assign_user2_role", new { id = RoleId });
                }
                //this.AddNotification($"Application Role: {RoleName}, {Chkbx.Count()} associated Users was added Successfully", NotificationType.SUCCESS);
                return RedirectToAction("assign_user2_role", new { id = RoleId });
            }
            // this.AddNotification($"Bad Request", NotificationType.ERROR);
            return RedirectToAction("assign_user2_role", new { id = RoleId });
        }
        //[Authorize(nameof(PermissionEnum.RemoveUserRole))]
        [HttpGet]
        public async Task<IActionResult> RemoveRole(long roleId)
        {
            var perroles = await _accountRepo.GetRole(roleId);
            return PartialView("_DeleteRole", perroles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(nameof(PermissionEnum.RemoveUserRole))]
        public async Task<IActionResult> RemoveRole([Bind("roleid,rolename,roledesc")] RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var asign = await _accountRepo.RemoveRole(model);
                if (!string.IsNullOrEmpty(asign) && asign != "1")
                {
                    //this.AddNotification(ResponseErrorMessageUtility.RecordNotSaved, NotificationType.WARNING);
                    return RedirectToAction(nameof(Index));
                }
                // this.AddNotification($"Application Role: {RoleName}, {Chkbx.Count()} associated User(s) was removed Successfully", NotificationType.SUCCESS);
                return RedirectToAction(nameof(Index));
            }
            // this.AddNotification($"Bad Request", NotificationType.ERROR);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
