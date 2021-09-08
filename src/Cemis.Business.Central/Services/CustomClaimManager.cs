using CEMIS.Data.Central;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cemis.Business.Central.Services
{
    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
    {
        public MyUserClaimsPrincipalFactory(
            UserManager<User> userManager,IOptions<IdentityOptions> optionsAccessor): base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserType", user.UserType.ToString() ));
            identity.AddClaim(new Claim("UserName", user.UserName));

            return identity;
        }

        public  async Task<ClaimsIdentity> AddStudentClaim(User user , long CollegeID)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("CollegeID", user.UserType.ToString()));
            return identity;
        }
    }
}
