using CEMIS.Business.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CEMIS.Data;
using CEMIS.Data.Entities;

namespace CEMIS.Business.Services
{
    public class SeedingManagementService : ISeedingManagementService
    {
        private readonly appContext _context;
        private RoleManager<Role> _rolemanager;
        private readonly UserManager<User> _usermanager;

        public SeedingManagementService(appContext context, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _context = context;
            _rolemanager = roleManager;
            _usermanager = userManager;
        }

        public async Task AutoSeedGlobalAdmin()
        {
            try
            {
                var user = await _usermanager.FindByNameAsync("admin");
                if (user == null)
                {
                    var testUser = new User
                    {
                        UserName = "admin",
                        Email = "admin@cemis.com",
                        EmailConfirmed = true,
                        CreatedBy = 0,
                        DateCreated = DateTime.Now,
                        NormalizedUserName = "admin@cemis.com".ToUpper(),
                        TwoFactorEnabled = false,
                        ForcePwdChange = false,
                        PwdExpiryDate = DateTime.Now.AddYears(1000),
                        LockoutEnabled = false,
                        PhoneNumber = "NIL",
                    };
                    await _usermanager.CreateAsync(testUser, "P@ssw0rd");



                    //Add role for user
                    var adminRole = await _rolemanager.FindByNameAsync("GlobalAdmin");
                    if (adminRole == null)
                    {
                        var NewadminRole = new Role
                        {
                            Name = "GlobalAdmin",
                            RoleDesc = "This is the Global Administrative Role",
                            ModifiedBy = 0,
                            LastModified = DateTime.Now,
                            CreatedBy = 0,
                            IsSuperUser = true,
                            CreatedDate = DateTime.Now,
                            IsActive = true,
                        };
                        await _rolemanager.CreateAsync(NewadminRole);



                        //Add to user role
                        //BtUserRole btUserRole = new BtUserRole
                        //{
                        //    RoleId = NewadminRole.Id,
                        //    UserId = testUser.Id,
                        //    //ModifiedBy = "System",
                        //    //LastModified = DateTime.Now
                        //};



                        await _usermanager.AddToRoleAsync(testUser, NewadminRole.Name);
                        //_context.UserRoles.Add(btUserRole);



                        //var newrec = new TCoreUser()
                        //{
                        //    AppuserId = testUser.Id,
                        //    Firstname = "System",
                        //    Lastname = "Administrator",
                        //    LastModified = null,
                        //    CreatedDate = DateTime.Now,
                        //    CreatedBy = "Admin",
                        //    ModifiedBy = null,
                        //    UserCategory = "R",
                        //    IsActive = true,
                        //    Nationality = null
                        //};
                        //_context.TCoreUser.Add(newrec);
                        //await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}



