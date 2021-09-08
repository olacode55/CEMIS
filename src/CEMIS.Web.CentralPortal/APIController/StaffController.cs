using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CEMIS.Utility;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility.ViewModel;

namespace CEMIS.Web.CentralPortal
{
    [Route("api/CollegeStaff")]
    [ApiController]
    public class StaffController : BaseControllerApI
    {
        private readonly IStaff _staffRepository;
        private readonly ICollege _collegeRepository;
        public StaffController( UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IConfiguration configuration,
                               IStaff staffRepository , ICollege collegeRepository) : base( userManager,signInManager, roleManager , configuration)
        {
            _staffRepository = staffRepository;
            _collegeRepository = collegeRepository;
        }

        // POST api/values
       
        [HttpPost]
        [Route("Push")]
        public ResponseData<TeachingStaff> PushCollegeStaff(CollegeStaffViewModel teachingstaff , string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if(college == null)
            {
                return new ResponseData<TeachingStaff>
                {
                    Message="Invalid API Key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }
            var res = _staffRepository.PushCollegeStaff(teachingstaff , college.Id);
            return res;
        }

        }
}