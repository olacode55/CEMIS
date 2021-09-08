using CEMIS.Business.Interface;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly appContext _context;
        private readonly IAuthUser _authUser;
        private readonly ILogger<RoleService> _logger;
        public RoleService(RoleManager<Role> roleManager, UserManager<User> userManager,
            ILogger<RoleService> logger, appContext context, IAuthUser authUser)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
            _authUser = authUser;
            _logger = logger;
        }
        public async Task<IEnumerable<RoleViewModel>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.Select(x => new RoleViewModel
            {
                roleid = x.Id,
                rolename = x.Name,
                roledesc = x.RoleDesc
            }).ToListAsync();
        }

        public async Task<string> UpdateRoleAsync(RoleDTO obj, long id)
        {
            string status = "";
            //var userid = long.Parse(_authUser.UserId);
            try
            {
                //Check if record exist not as same id
                var checkexist = await _context.Roles
                  .AnyAsync(x => x.Id != id &&
                   (x.Name == obj.rolename));
                if (checkexist == false)
                {
                    var state = await _context.Roles
                   .FirstOrDefaultAsync(x => x.Id == id);
                    state.Name = obj.rolename;
                    state.RoleDesc = obj.roledesc;
                    state.ModifiedBy = 1;
                    state.LastModified = DateTime.Now;
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        status = "1";
                        return status;
                    }
                    else
                    {
                        status = ResponseErrorMessageUtility.RecordNotSaved;
                        return status;
                    }
                }
                status = string.Format(ResponseErrorMessageUtility.RecordNotFound);
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                status = ResponseErrorMessageUtility.RecordNotSaved;
                return status;
            }
        }

        public async Task<string> RemoveUsersFromRole(long roleId, long[] userIds)
        {
            string status = "";
            try
            {
                if (userIds.Count() > 0)
                {
                    var data = userIds.Select(x => new UserRole
                    {
                        RoleId = roleId,
                        UserId = x,
                    }).ToList();
                    _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted);
                    _context.UserRoles.RemoveRange(data);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        status = "1";
                        return status;
                    }
                    else
                    {
                        status = ResponseErrorMessageUtility.RecordNotSaved;
                        return status;
                    }
                }
                status = string.Format(ResponseErrorMessageUtility.RecordNotFound);
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                status = ResponseErrorMessageUtility.RecordNotSaved;
                return status;
            }
        }
        public async Task<string> AssignUsersToRole(long roleId, long[] userIds)
        {
            string status = "";
            try
            {
                //First Prepare entry
                var data = userIds.Select(x => new UserRole
                {
                    RoleId = roleId,
                    UserId = x,
                }).ToList();
                //Check if UserRole exist
                var checkexist = await _context.UserRoles.Select(x => new UserRole
                {
                    RoleId = roleId,
                    UserId = x.UserId,
                }).ToListAsync();
                var final = data.Except(checkexist);
                if (final.Count() > 0)
                {
                    var prepfinal = final.Select(x => new UserRole
                    {
                        RoleId = roleId,
                        UserId = x.UserId,
                        LastModified = DateTime.Now,
                        ModifiedBy = _authUser.Name,
                    });
                    _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
                    _context.UserRoles.AddRange(data);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        status = "1";
                        return status;
                    }
                    else
                    {
                        status = ResponseErrorMessageUtility.RecordNotSaved;
                        return status;
                    }
                }
                status = string.Format(ResponseErrorMessageUtility.RecordNotFound);
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                status = ResponseErrorMessageUtility.RecordNotSaved;
                return status;
            }
        }
        public async Task<RoleCollectionViewModel> GetAssignedAndUnAssignedUserToRole(long Id)
        {
            var userId = long.Parse(_authUser.UserId);

            RoleCollectionViewModel rolecolllection = new RoleCollectionViewModel();
            try
            {
                rolecolllection.roleid = Id;
                rolecolllection.rolename = _context.Roles.FirstOrDefault(x => x.Id == Id).Name;
                //UnAssigned Users Across the User Table
                List<UsersObject> list1 = new List<UsersObject>();
                var rolemembers = await (from a in _context.Users
                                         where a.Id != userId
                                         && !(from userrole in _context.UserRoles
                                              where userrole.RoleId == Id
                                              select userrole.UserId).Contains(a.Id)
                                         select new UsersObject
                                         {
                                             AppUserId = a.Id,
                                             LastName = a.Lastname,
                                             FirstName = a.Firstname,
                                             MiddleName = a.Middlename,
                                         }).ToListAsync();
                //foreach (var item in rolemembers)
                //{
                //    UsersObject entity1 = new UsersObject
                //    {
                //        AppUserId = item.AppuserId,
                //        LastName = item.Lastname,
                //        FirstName = item.Firstname,
                //        MiddleName = item.Middlename,
                //    };
                //    list1.Add(entity1);
                //}
                rolecolllection.unassignedusers = rolemembers;
                //Get Users on the system that are Assigned to Role
                List<UsersObject> list2 = new List<UsersObject>();
                var rolemembers2 = (from user in _context.Users
                                    join uroles in _context.UserRoles on user.Id equals uroles.UserId
                                    where uroles.RoleId == Id
                                    select user).ToList();
                foreach (var item2 in rolemembers2)
                {
                    UsersObject entity1 = new UsersObject
                    {
                        AppUserId = item2.Id,
                        LastName = item2.Lastname,
                        FirstName = item2.Firstname,
                        MiddleName = item2.Middlename,
                    };
                    list2.Add(entity1);
                }
                rolecolllection.assignedusers = list2.ToList();
                return rolecolllection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> CreateRoleAsync(RoleDTO model)
        {
            string status = "";
            //var userid = long.Parse(_authUser.UserId);

            //var user = _context.Users.FirstOrDefault(x => x.UserName == username);

            try
            {
                //Check if Role exist
                var checkexist = await _context.Roles.AnyAsync(x => x.Name == model.rolename);
                if (checkexist == false)
                {
                    Role newrole = new Role
                    {
                        Name = model.rolename,
                        NormalizedName = model.rolename.ToUpper().Replace(" ", ""),
                        IsSuperUser = false,
                        RoleDesc = model.roledesc,
                        IsActive = true,
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now,
                        LastModified = null,
                        ModifiedBy = 1,
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    };
                    var result = await _roleManager.CreateAsync(newrole);
                    if (result.Succeeded)
                    {
                        status = "1";
                        return status;
                    }
                    else
                    {
                        status = ResponseErrorMessageUtility.RecordNotSaved;
                        return status;
                    }
                }
                status = string.Format(ResponseErrorMessageUtility.RecordNotFound);
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                status = ResponseErrorMessageUtility.RecordNotSaved;
                return status;
            }
        }

        public async Task<RoleViewModel> GetRole(long roleId)
        {
          //  var userid = long.Parse(_authUser.UserId);
            try
            {
                //Check if record exist not as same id
                var checkexist = await (from a in _context.Roles
                                        where a.Id == roleId && a.IsActive == true
                                        select new RoleViewModel
                                        {
                                            roleid = a.Id,
                                            rolename = a.Name,
                                            roledesc = a.RoleDesc,
                                            issuperuser = a.IsSuperUser,
                                        }).FirstOrDefaultAsync();
                return checkexist;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }

        }

        public async Task<string> RemoveRole(RoleViewModel model)
        {
            string status = "";
           // var userid = long.Parse(_authUser.UserId);

            //var user = _context.Users.FirstOrDefault(x => x.UserName == username);

            try
            {
                //Check if Role exist
                var checkexist = await _context.Roles.Where(x => x.Id == model.roleid).FirstOrDefaultAsync();
                if (checkexist !=null )
                { 
                    var result = await _roleManager.DeleteAsync(checkexist);
                    if (result.Succeeded)
                    {
                        status = "1";
                        return status;
                    }
                    else
                    {
                        status = ResponseErrorMessageUtility.RecordNotSaved;
                        return status;
                    }
                }
                status = string.Format(ResponseErrorMessageUtility.RecordNotFound);
                return status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                status = ResponseErrorMessageUtility.RecordNotSaved;
                return status;
            }
        }
    }
}


