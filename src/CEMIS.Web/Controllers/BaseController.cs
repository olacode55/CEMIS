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
using CEMIS.Data.Entities;

namespace CEMIS.Web.Controllers
{


    public abstract class BaseController : Controller
    {
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;
        protected readonly RoleManager<Role> _roleManager;
        protected IConfiguration _configuration;
        protected readonly ILogger _logger;



        public BaseController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }

        protected void CreateViewBagParams()
        {
            ViewBag.IsUpdate = false;
            ViewBag.ModalTitle = "Add";
            ViewBag.ButtonAction = "Save";
            ViewBag.PostAction = "Create";
            ViewBag.ImageProperty = "fileinput-new";
            ViewBag.ImageProperty2 = "fileinput-new";
            ViewBag.ButtonActionCss = "btn btn-primary";
            ViewBag.ButtonActionAddIcon = "fa fa-plus-circle";
            ViewBag.ButtonActionCloseIcon = "fa fa-plus-circle";
        }
        protected void EditViewBagParams()
        {
            ViewBag.IsUpdate = true;
            ViewBag.ModalTitle = "Edit";
            ViewBag.ButtonAction = "Update";
            ViewBag.PostAction = "Edit";
        }
        protected void EditViewBagParams(string imageUrl)
        {
            ViewBag.IsUpdate = true;
            ViewBag.ModalTitle = "Edit";
            ViewBag.ButtonAction = "Update";
            ViewBag.PostAction = "Edit";
            ViewBag.ImageProperty = string.IsNullOrEmpty(imageUrl) ? "fileinput-new" : "fileinput-exists";
            ViewBag.ImageProperty2 = "fileinput-exists";
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
