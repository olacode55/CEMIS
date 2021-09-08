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
using CEMIS.Data.Central;


namespace CEMIS.Web.CentralPortal
{
   
        public class BaseControllerApI : ControllerBase
        {
            protected readonly UserManager<User> _userManager;
            protected readonly SignInManager<User> _signInManager;
            protected readonly RoleManager<Role> _roleManager;
            protected IConfiguration _configuration;
            protected readonly ILogger _logger;

            public BaseControllerApI()
            {

            }

            public BaseControllerApI(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration configuration)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _roleManager = roleManager;
                _configuration = configuration;
            }

           
        }
    }
