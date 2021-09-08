using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Data.Utilities;
using CEMIS.Data.ViewModel;
using CEMIS.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Newtonsoft.Json;
using CEMIS.Business;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEMIS.Web.Controllers
{
   [Authorize]
    public class UserController : Controller
    {
       // private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
       // private const string RecoveryCodesKey = nameof(RecoveryCodesKey);
        private readonly UserManager<User> _userManager;
        private IUserManagementServices _userService;
        private readonly RoleManager<Role> _roleManager;
        private readonly IPasswordService _passwordService;
        private readonly IMessageManagementService _messageService;
        private readonly ILogger<UserController> _logger;
        private readonly IRoleService _roleService;
        private readonly IMailManagementService _mailService;
        private readonly IStaff _staffRepository;

        public UserController(UserManager<User> userManager, IUserManagementServices userService,IRoleService roleService,
            RoleManager<Role> roleManager, IPasswordService passwordService, IMessageManagementService messageService, IMailManagementService mailService, IStaff staffRepository,
            ILogger<UserController> logger)
        {
            _userManager = userManager;
            _userService = userService;
            _roleManager = roleManager;
            _passwordService = passwordService;
            _messageService = messageService;
            _logger = logger;
            _roleService = roleService;
            _staffRepository = staffRepository;
            _mailService = mailService;
        }
        //Get Current User logged in
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public async Task<IActionResult> Users()
        {
            var IsAuthenticated = User.Identity.IsAuthenticated;
            var all_users = await _userService.GetUsers();
            return View("users", all_users);
        }
        public IActionResult AddUser()
        {
          var roles = _roleManager.Roles.Select(x =>
          new SelectListItem
          {
              Value = x.Id.ToString(),
              Text = x.Name
          });
            return PartialView("_CreateUser", new UsersObject { Roles = roles });
        }

     
            public async Task<IActionResult> CheckforStaffId(string staffid)
            {
                var staff =  _staffRepository.GetTeachingStaffById(staffid);
            return Json(staff, new Newtonsoft.Json.JsonSerializerSettings());


        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser([Bind("UserName,LastName,FirstName,MiddleName,Email,RoleId,StaffID")]UsersObject model)
        {
              var roles = _roleManager.Roles.Select(x =>
               new SelectListItem
                {
               Value = x.Id.ToString(),
               Text = x.Name
                  });
             
            if (string.IsNullOrEmpty(model.FirstName) && model.FirstName == null || string.IsNullOrEmpty(model.LastName) && model.LastName == null)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "FirstName or LastName Cannot be Empty! Kindly provide your Staff Number to enable populate your Details", Title = "Update Profile", Type = NotificationsType.warning });
                return RedirectToAction(nameof(AddUser));
            }
            var firstname = model.FirstName;
            var firstnamevalue = firstname.Substring(0,1);
            model.UserName = firstnamevalue + model.LastName;
            if (!ModelState.IsValid)
            {
                var fetchdata = await _userService.GetUsers();
                var userId = fetchdata.Where(x => x.UserName.ToLower().Trim() == model.UserName.ToLower().Trim())
                .Select(p => p.UserName);
                if (userId.Contains(model.UserName.ToLower().Trim()))
                {
                    TempData["Notification"] = JsonConvert.SerializeObject( new Notification { Message = "Username already exist on the system!", Title = "Update Profile", Type = NotificationsType.success });
                    return RedirectToAction(nameof(AddUser));
                }
                //Password Management
                var passwordModel = new UsersPassword();
                //Password Generator
                string generatePassword;
                //Password Requirements
                var passwrule = _userManager.Options.Password;
                //Generate Password for User
                //  generatePassword = PasswordGenerator.CreateRandom(passwrule.RequiredLength, passwrule.RequireUppercase, passwrule.RequireDigit, passwrule.RequireLowercase);
                generatePassword = "P@ssw0rd";
                model.Password = generatePassword;
                model.UserName = model.UserName.ToLower(); //Updated @version 1.2.5.26
                var DNow = DateTime.Now;
                DateTime currentTime = DateTime.Now;
                DateTime x30MinsLater = currentTime.AddMinutes(30);
                var appuser = new User { Email = model.Email, UserName = model.UserName.ToLower(), EmailConfirmed = false,StaffID = model.StaffID, IsActive=true,TwoFactorEnabled = false, PwdExpiryDate = x30MinsLater , Lastname=model.LastName,Middlename=model.MiddleName,Firstname=model.FirstName };
                var result = await _userManager.CreateAsync(appuser, model.Password);
                if (result.Succeeded)
                {
                    //Find Role in Database
                    var ApplicationRole = await _roleManager.FindByIdAsync(model.RoleId);
                    var userrole = await _userManager.AddToRoleAsync(appuser, ApplicationRole.Name);
                    if (userrole.Succeeded)
                    {
                        model.AppUserId = appuser.Id;
                        model.IsActive = true;
                        passwordModel.ForcePwdChange = true;
                        passwordModel.LastLogin = DateTime.Now;
                        passwordModel.PwdEncrypt = model.Password;
                        passwordModel.UserId = model.AppUserId;
                        passwordModel.IsActive = true;
                        await _passwordService.CreateUserDefaultPassword(passwordModel);
                        //Callback Url to confirm Email Address
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(appuser);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { UserId = appuser.Id, code }, protocol: Request.Scheme);
                        //Mail Webservice
                        var mail =  await _mailService.SendWelcomeEmail(model.Email, model.UserName, model.Password, callbackUrl);
                        if (mail == 1001)
                        {
                            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Due to network unavailability, the email notification could not be sent at this time!", Title = "User Account", Type = NotificationsType.warning });
                            _logger.LogWarning(ResponseErrorMessageUtility.MailNotSent);
                            return RedirectToAction(nameof(Users));
                        }
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Username Successfully Created. Kindly login into your email to comfirm Registration !", Title = "User Profile", Type = NotificationsType.success });
                        return RedirectToAction("AddUser", "User");
                    }
                }
            }
            return View(model);
        }
        public IActionResult User_details(long id)
        {
            var roles = _roleManager.Roles.Select(x =>
               new SelectListItem
               {
                   Value = x.Id.ToString(),
                   Text = x.Name
               });
            var user = _userService.GetUser(id);
            return View("user_details", user);
        }
        public  async Task <IActionResult> Userupdate(long appUserId)
        {
            var roles = _roleManager.Roles.Select(x =>
               new SelectListItem
               {
                   Value = x.Id.ToString(),
                   Text = x.Name
               });

            var user = await _userService.GetUser(appUserId);
            user.Roles = roles;
            return PartialView("_EditUser", user);
        }
        //For Regulator
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Userupdate([Bind("UserName,LastName,FirstName,MiddleName,AppUserId,Email,RoleId,StaffID")]UsersObject model)
        {

            var roles = _roleManager.Roles.Select(x =>
               new SelectListItem
               {
                   Value = x.Id.ToString(),
                   Text = x.Name
               });
            if (!ModelState.IsValid)
            {
                var DNow = DateTime.Now;
               // model.UserName = model.UserName.ToLower().Trim(); 
               //Go to Identity Table and Perform update too
                var ApddIdentity = await _userManager.FindByIdAsync(model.AppUserId.ToString());
                ApddIdentity.Email = model.Email;
                ApddIdentity.NormalizedEmail = model.Email;
                ApddIdentity.UserName = model.UserName;
                ApddIdentity.Firstname = model.FirstName;
                ApddIdentity.Lastname = model.LastName;
                ApddIdentity.StaffID = model.StaffID;
                ApddIdentity.Middlename = model.MiddleName;
                var userroles = await _roleService.GetAllRolesAsync();
                foreach (var item in userroles)
                {
                    var role = await _roleManager.FindByIdAsync(item.roleid.ToString());
                   await _userManager.RemoveFromRoleAsync(ApddIdentity, role.Name);
                }
                foreach (var item in model.RoleId)
                {
                    var _role = await _roleManager.FindByIdAsync(item.ToString());
                  await  _userManager.AddToRoleAsync(ApddIdentity, _role.Name);
                }
                var identityupdate = await _userManager.UpdateAsync(ApddIdentity);
                if (identityupdate.Succeeded)
                {
                 
                    var update = await _userService.UpdateUserAsync(model,model.AppUserId);
                    if (update)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification  { Message = "profile was successfully updated!", Title = "User Account", Type = NotificationsType.success });
                        return RedirectToAction(nameof(Users));
                    }
                    //this.AddNotification($"{model.LastName}, {model.FirstName} {model.MiddleName} profile was successfully updated!", NotificationType.SUCCESS);
                    return RedirectToAction(nameof(Users));
                }
                TempData["Notification"] = JsonConvert.SerializeObject (new Notification { Message = "profile was not successfully updated!", Title = "User Account", Type = NotificationsType.warning });
                //_logger.LogWarning(EventsLoggings.UPDATE_ERROR_ITEM_CODE, $"{EventsLoggings.UPDATE_ERROR_MESSAGE}{model.LastName}", model);
                return RedirectToAction(nameof(Users));

            }
            return View(model);
        }
        public  async Task<IActionResult> Activate_user(long? appUserId)
        {
            if (appUserId.HasValue && appUserId.Value > 0)
            {
                var user = await _userService.GetUser(appUserId.Value);
                return PartialView("_activate_user", user);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activate_user([Bind("AppUserId")] UsersObject model)
        {
            if (!ModelState.IsValid)
            {
                model.IsActive = true;
                var activate = await _userService.ActivateUserProtected(model.AppUserId, model.IsActive);
                if (activate)
                {
                    return RedirectToAction(nameof(Users));
                }
                _logger.LogError(ResponseErrorMessageUtility.RecordNotSaved);
                return RedirectToAction(nameof(Users));
            }
            _logger.LogError(ResponseErrorMessageUtility.RecordNotSaved);
            return RedirectToAction(nameof(Users));
        }
        public async Task<IActionResult> Deactivate_user(long? appUserId)
        {
            if (appUserId.HasValue && appUserId.Value > 0)
            {
                var user = await _userService.GetUser(appUserId.Value);
                return PartialView("_deactivate_user", user);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate_user([Bind("AppUserId")] UsersObject model)
        {
            if (!ModelState.IsValid)
            {
                var getuser = await _userService.GetUser(model.AppUserId);
                if (User.Identity.IsAuthenticated && User.Identity.Name == getuser.UserName)
                {
                    //_logger.LogError(EventsLoggings.ERROR_DEACTIVATION_CODE, $"{EventsLoggings.ERROR_DEACTIVATION_MESSAGE}{model.UserName}", model);
                    TempData["Notification"] = JsonConvert.SerializeObject (new Notification { Message = "Sorry you cannot deactivate your own account! Thanks", Title = "User Account", Type = NotificationsType.danger });
                    
                }
                //Added @version 1.0.0.0
                model.IsActive = false;
                var deactivate = await _userService.ActivateUserProtected(model.AppUserId, model.IsActive);
                if (deactivate)
                {
                    //_logger.LogInformation(EventsLoggings.SUCCESS_ACTIVATION_CODE, $"{EventsLoggings.SUCCESS_ACTIVATION_MESSAGE}{model.UserName}", model);
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "account was successfully  deactivated ! Thanks", Title = "User Account", Type = NotificationsType.success });
                    //this.AddNotification($"User: <strong>{model.UserName}</strong> was successfully de-activated", NotificationType.SUCCESS);
                    return RedirectToAction(nameof(Users));
                }
            }
            return RedirectToAction(nameof(Users));
        }
    }

}