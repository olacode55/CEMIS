using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Data.Utilities;
using CEMIS.Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CEMIS.Utility.ViewModel;
using Newtonsoft.Json;
using CEMIS.Web.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEMIS.Web.Controllers
{
   [Authorize]
    public class RoleController : Controller
    {
        private readonly IRoleService _accountRepo;
        private readonly ILogger<RoleController> _logger;
        public RoleController(IRoleService accountRepo, ILogger<RoleController> logger)
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
        public async Task<IActionResult> Create([FromForm] RoleDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(model);
            }
            // var user = User.Identity.IsAuthenticated ? User.Identity.Name : "Anonymous";
            var create = await _accountRepo.CreateRoleAsync(model);
            //if result does not return 1 as string , display error to user
            if (!string.IsNullOrEmpty(create) && create != "1")
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Unable to Create Role", Title = "Roles", Type = NotificationsType.warning });
                return RedirectToAction(nameof(Index));
            }
            //else redirect back to Course grid 
            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Role was  Created Successfully", Title = "Roles", Type = NotificationsType.success });
            return RedirectToAction(nameof(Index));
           
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
                //this.AddNotification(ResponseErrorMessageUtility.RecordNotSaved, NotificationType.WARNING);
                return RedirectToAction(nameof(Index));
            }
            //else redirect back to Institution grid 
            //this.AddNotification(ResponseSuccessMessageUtility.RecordSaved, NotificationType.SUCCESS);
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
        public async Task<IActionResult> RemoveRole([Bind("roleid")] RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var asign = await _accountRepo.RemoveRole(model);
                if (!string.IsNullOrEmpty(asign) && asign != "1")
                {
                    //this.AddNotification(ResponseErrorMessageUtility.RecordNotSaved, NotificationType.WARNING);
                    return RedirectToAction(nameof(Index));
                }
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Role was removed Successfully", Title = "Roles", Type = NotificationsType.success });

                // this.AddNotification($"Application Role: {RoleName}, {Chkbx.Count()} associated User(s) was removed Successfully", NotificationType.SUCCESS);
                return RedirectToAction(nameof(Index));
            }
            // this.AddNotification($"Bad Request", NotificationType.ERROR);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
