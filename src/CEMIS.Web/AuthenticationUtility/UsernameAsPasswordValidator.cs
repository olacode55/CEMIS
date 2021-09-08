using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace CEMIS.Web.AuthenticationUtility
{
    public class UsernameAsPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : IdentityUser<long>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            if (string.Equals(user.UserName, password, StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "UsernameAsPassword",
                    Description = "You cannot use your username as your password"
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
