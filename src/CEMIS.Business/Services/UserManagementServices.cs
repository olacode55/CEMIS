using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Data.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEMIS.Utility.ViewModel;
namespace CEMIS.Business.Services
{
    public class UserManagementServices : IUserManagementServices
    {

        private IRepository<User> _instUserRepository;

        private appContext _context;
        private IConfiguration _configura;
        private readonly IAuthUser _authUser;
        private readonly UserManager<User> _userManager;

        public appContext Context { get; }

        public UserManagementServices(IRepository<User> instUserRepository, appContext context,
           IConfiguration configura, IAuthUser authUser, UserManager<User> userManager)
        {
            _instUserRepository = instUserRepository;
            _context = context;
            _configura = configura;
            _authUser = authUser;
            _userManager = userManager;

        }
        #region Users Services
        public async Task<IEnumerable<UsersObject>> GetUsers()
        {
            var users = new List<UsersObject>();

            //var roles = await _userManager.GetRolesAsync(user);
            try
            {
                var fetchdata = await _context.Users.Where(x => x.Isdeleted == false).ToListAsync();
                if (fetchdata != null || fetchdata.Count() != 0)
                {
                    foreach (var user in fetchdata)
                    {
                        //var RoleID = user.Roles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).FirstOrDefault();
                        var roles = await _userManager.GetRolesAsync(user);
                        var role = roles.Any() ? roles[0] : string.Empty;

                        var userItem = new UsersObject
                        {
                            AppUserId = user.Id,
                            FirstName = user.Firstname,
                            LastName = user.Lastname,
                            MiddleName = user.Middlename,
                            Email = user.Email,
                            UserName = user.UserName,
                            StaffID= user.StaffID,
                            Rolename = role,
                            IsActive = user.IsActive
                        };
                        users.Add(userItem);
                       
                    }
                }
                return users;
            }
           
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<UsersObject> GetUser(long appUserId)
        {
            try
            {
                var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == appUserId);
                //var roleid = await _context.UserRoles.Where(x => x.UserId == appUserId).Select(x=> x.RoleId).ToList();
                var roles = await _userManager.GetRolesAsync(entity);
                var role = roles.Any() ? roles[0] : string.Empty;
                UsersObject obj = new UsersObject
                {
                    AppUserId = entity.Id,
                    Email = entity.Email,
                    FirstName = entity.Firstname,
                    DateUpdated = entity.DateModeified,
                    LastName = entity.Lastname,
                    MiddleName = entity.Middlename,
                    CreatedBy = entity.CreatedBy,
                    DateCreated = entity.DateCreated,
                    UserName = entity.UserName,
                    Password = entity.PasswordHash,
                    StaffID = entity.StaffID,
                    Rolename = role,
                    RoleIDs = _context.UserRoles.Where(x => x.UserId == appUserId).Select(x => x.RoleId).ToList(),
                

            };
                return obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<bool> CreateUserAsync(UsersObject obj)
        {
            try
            {
                if (obj.Email != null)
                {

                    User instance = new User
                    {
                        Firstname = obj.FirstName,
                        Email = obj.Email
                    };

                    var result = await _userManager.CreateAsync(instance);
                    if (result.Succeeded)
                    {
                        return true;

                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<bool> UpdateUserAsync(UsersObject obj, long id)
        {
            try
            {
               
                var userID = long.Parse(_authUser.UserId);
                var fetchdata = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

                fetchdata.Id = id;
                fetchdata.Email = obj.Email;
                fetchdata.Lastname = obj.LastName;
                fetchdata.Firstname = obj.FirstName;
                fetchdata.DateModeified = DateTime.Now;
                fetchdata.Middlename = obj.MiddleName;
                fetchdata.StaffID = obj.StaffID;
                fetchdata.IsFirstLogin = obj.IsFirstLogin;
                fetchdata.ModifiedBy = userID;
                fetchdata.UserName = obj.UserName;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> ActivateUserProtected(long Id, bool status)
        {
            try
            {
               // var userID = long.Parse(_authUser.UserId);
                var fetchdata = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
                fetchdata.Id = Id;
                fetchdata.IsActive = status;
                fetchdata.DateModeified = DateTime.Now;
                fetchdata.ModifiedBy = 1;

                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion
    }
}
