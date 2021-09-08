using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CEMIS.Data;
using Newtonsoft.Json;
using CEMIS.Data.Central;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using CEMIS.Utility.Util;
using Cemis.Business.Central.Interface;

namespace CEMIS.Web.CentralPortal
{


    public abstract class BaseController : Controller
    {
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;
        protected readonly RoleManager<Role> _roleManager;
        protected IConfiguration _configuration;
        protected readonly ILogger _logger;
        protected IHttpContextAccessor _accessor;
        protected IActivityLog _logActivityRepo;
        protected IActionContextAccessor _actionContextAccessor;



        public BaseController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration configuration , IHttpContextAccessor accessor,
                              IActionContextAccessor actionContextAccessor , IActivityLog logActivityRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _accessor = accessor;
            _actionContextAccessor = actionContextAccessor;
            _logActivityRepo = logActivityRepo;

        }

        protected long GetCurrentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
           return Convert.ToInt64(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value);
            //return User.Identity.GetUserId<Int64>();
        }

        protected long GetUserType()
        {
            ClaimsPrincipal currentUser = this.User;
            return Convert.ToInt64(currentUser.FindFirst("UserType").Value);
            //return User.Identity.GetUserId<Int64>();
        }
        protected long GetCollgeID()
        {
            ClaimsPrincipal currentUser = this.User;
            return Convert.ToInt64(currentUser.FindFirst("CollegeID").Value);
            //return User.Identity.GetUserId<Int64>();
        }

        protected string GetUserName()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst("UserName").Value;
            //return User.Identity.GetUserId<Int64>();
        }
        


        public long CurrentUser { get { return Convert.ToInt64(this.User.FindFirst(ClaimTypes.NameIdentifier).Value); } }

        protected async Task LogActivity(string description, object record)
        {
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] address = ipHostEntry.AddressList;
            string ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
           
            
            await _logActivityRepo.CreateActivityLog(description, GetContollerName() , GetActionName(), CurrentUser, record, ip);
        }

        public string GetContollerName()
        {
            return _actionContextAccessor.ActionContext.RouteData.Values["controller"].ToString();
        }
        public string GetActionName()
        {
            return _actionContextAccessor.ActionContext.RouteData.Values["action"].ToString();
        }

        public static String EncryptID(long ID)
        {
            try
            {
                String EcryptedApplicantID = Crypto.EncryptPlainTextToCipherText(ID.ToString());
                EcryptedApplicantID = EcryptedApplicantID.Replace("/", "~");
                EcryptedApplicantID = EcryptedApplicantID.Replace("\\", "`");
                return EcryptedApplicantID;
            }
            catch (Exception)
            {
                // Common.WriteLog(ex);
                return null;
            }

        }

        public static Int32 DecryptID(String ID)
        {
            try
            {
                ID = ID.Replace("~", "/");
                ID = ID.Replace("`", "\\");
                Int32 DecryptedApplicantID = Convert.ToInt32(Crypto.DecryptCipherTextToPlainText(ID));
                return DecryptedApplicantID;
            }
            catch (Exception)
            {
                //Common.WriteLog(ex);
                return 0;
            }
        }

        public object Message
        {
            get
            {
                return ViewData["Message"];
            }
            set
            {
                ViewData["Message"] = value;
            }

        }


    }
}
