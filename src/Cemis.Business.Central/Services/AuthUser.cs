using CEMIS.Business.Central.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CEMIS.Business.Central.Services
{
    public class AuthUser : IAuthUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        public bool Authenticated => _accessor.HttpContext.User.Identity.IsAuthenticated;

        public string UserId => _accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        public string IPAddress => _accessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public string OS()
        {
            throw new NotImplementedException();
        }

        public string OSVersion()
        {
            throw new NotImplementedException();
        }
    }
}

