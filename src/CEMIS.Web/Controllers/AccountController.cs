using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using CEMIS.Data.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using CEMIS.Web.Utilities;

namespace CEMIS.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //private readonly IToastNotification _toastNotification;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //private readonly IRepository<User> _UserRepo;
        private readonly ISeedingManagementService _seed;
        private readonly ILogger<AccountController> _logger;
        private readonly IPasswordService _passwordService;
        private readonly IUserManagementServices _userService;
        private readonly IMessageManagementService _messageManagement;
        private readonly IMailManagementService _mail;
        private readonly IAuthUser _auth;

        public AccountController(UserManager<User> userManager, SignInManager<User> SignInManager,
            //IRepository<User> UserRepo,
            ISeedingManagementService seed, ILogger<AccountController> logger, IPasswordService passwordService, IUserManagementServices userService,
            IMessageManagementService messageManagement, IMailManagementService mail, IAuthUser auth)
        {
            _userManager = userManager;
            _signInManager = SignInManager;
            //_UserRepo = UserRepo;
            _seed = seed;
            _logger = logger;
            _passwordService = passwordService;
            _userService = userService;
            _messageManagement = messageManagement;
            _mail = mail;
            _auth = auth;
        }
        [HttpGet]
        //[Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
           // await _seed.AutoSeedGlobalAdmin();
            //Clear the existing external cookie to ensure clean login process
            //if (HttpContext.Session.IsAvailable)
            //{
            //    await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            //    HttpContext.Session.Clear();
            //}
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        //[Route("Login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.username = model.username.ToLower().Trim();
            var auser = await _userManager.FindByNameAsync(model.username);
            if (auser == null)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Invalid Username !", Title = "User Account", Type = NotificationsType.danger });

               _logger.LogError(string.Format("Invalid Username [{0}]", model.username));
                return View(model);
            }
            //else if (!(await _userManager.IsEmailConfirmedAsync(auser)))
            //{
            //    return View();
            //}
            //else if (model.username != "admin")
            //{
            //    //do some stufss
            //    return RedirectToLocal(returnUrl);
            //}

       var fsdgsd  =     await _userManager.UpdateSecurityStampAsync(auser);
            var result = await _signInManager.PasswordSignInAsync(model.username, model.password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {

                if (auser.IsFirstLogin == false)
                {
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "This is your first login kindly change your password to contniue!", Title = "User Account", Type = NotificationsType.info });
                    return RedirectToAction("ChangePassword", "Account");
                }

                _logger.LogError("Login successful");
                return RedirectToAction("Index", "Dashboard");
            }

            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                
                ModelState.AddModelError(string.Empty, "Invalid login Attempt");
                return View(model);
            }
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _signInManager.SignOutAsync();
            HttpContext.Response.Cookies.Delete(".AspNet.ApplicationCookie");

            return RedirectToAction("Login");
        }
        public IActionResult Lockout()
        {
            return View();
        }
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        //
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword(ForgetPasswordViewModel model)
        {
            ViewData["ReturnUrl"] = model.returnUrl;
            if (!String.IsNullOrEmpty(model.username))
            {
                var aspUser = await _userManager.FindByNameAsync(model.username);
                if (aspUser == null || !(await _userManager.IsEmailConfirmedAsync(aspUser)))
                {
                    // this.AddNotification("Please your email or username is not valid.", NotificationType.ERROR);
                    return RedirectToAction("ForgotPasswordConfirmation", "account");
                }
                var userInfo = await _userService.GetUser(aspUser.Id);
                //Validate User in the Password Table
                var defpassword = await _passwordService.GetUserDefaultPassword(userInfo.AppUserId);
                if (defpassword == null)
                {
                    // this.AddNotification("Sorry you do not have any valid password that could be reset please contact the system administartor for support.", NotificationType.WARNING);
                    return RedirectToAction("login", "account");
                }
                //Password Generator
                string generatePassword;
                //Password Requirements
                var passwrule = _userManager.Options.Password;
                //Generate Password for User
                generatePassword = PasswordGenerator.CreateRandom(passwrule.RequiredLength, passwrule.RequireUppercase, passwrule.RequireDigit, passwrule.RequireLowercase);
                var code = await _userManager.GeneratePasswordResetTokenAsync(aspUser);
                //Mail Webservice
                var mails = await _mail.SendPasswordResetEmail(aspUser.Email, aspUser.UserName, generatePassword);
                if (mails == 0)
                {
                    var result = await _userManager.ResetPasswordAsync(aspUser, code, generatePassword);
                    if (result.Succeeded)
                    {
                        UsersPasswordHistObject passwordModel = new UsersPasswordHistObject();
                        passwordModel.Id = aspUser.Id;
                        passwordModel.DateCreated = DateTime.Now;
                        passwordModel.PwdEncrypt = aspUser.PasswordHash;
                         _passwordService.CreateUserOldPassword(passwordModel);
                        User xmodel = await _userManager.FindByIdAsync(aspUser.Id.ToString());
                        await _userManager.UpdateAsync(xmodel);
                        //this.AddNotification($"New Password was successfully set.\n NOTE: New password will be valid for {TimespanDat} days before prompting for reset.", NotificationType.SUCCESS);
                        //this.AddNotification("An email notification has been sent to your email box!", NotificationType.SUCCESS);
                        return RedirectToAction("ForgotPasswordConfirmation", "account");
                    }
                    AddErrors(result);
                }
            }
            // this.WebUtility("password reset was unsuccessful due to network unavailability to send email, please try again later!", NotificationType.ERROR);
            return RedirectToAction("login", "account");
        }
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(long userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (userId.ToString() == null || code == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            //Session["tabId"] = 2;
            if (result.Succeeded)
            {
                ViewData["confirmStat"] = "OK";
            }
            else
            {
                ViewData["confirmStat"] = "EX";
            }

            return View();
        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            // var user = new User();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GetCurrentUserAsync();
            var userid = long.Parse(_auth.UserId);
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                user.IsFirstLogin = true;
                UsersObject usersObject = new UsersObject
                {
                    Password = user.PasswordHash,
                    UserName = user.UserName,
                    FirstName=user.Firstname,
                    MiddleName = user.Middlename,
                    LastName =  user.Lastname,
                    Email = user.Email,
                    IsFirstLogin = user.IsFirstLogin,
                    AppUserId = user.Id
                };
                var update = await _userService.UpdateUserAsync(usersObject, usersObject.AppUserId);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = " Password change was successful ", Title = "User Account", Type = NotificationsType.success });
                return RedirectToAction("Index", "Dashboard");
               
            };
            AddErrors(result);
            return View(model);

        }
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(long userCode, string code)
        {
            if (code == null)
                return View("Error");
            ResetPasswordViewModel model = new ResetPasswordViewModel();
            model.userCode = userCode;
            model.Code = code;
            return View(model);
        }
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //var UserId = model.userCode;
            var user = await _userManager.FindByIdAsync(model.userCode.ToString());
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            //check here if password exist b4
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                UsersPassword passwordModel = new UsersPassword();
                passwordModel.UserId = user.Id;
                passwordModel.DateCreated = DateTime.Now;
                passwordModel.PwdEncrypt = model.Password;
                await _passwordService.CreateUserDefaultPassword(passwordModel);
                User xmodel = await _userManager.FindByIdAsync(user.Id.ToString());
                await _userManager.UpdateAsync(xmodel);
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        #endregion
    }
}





