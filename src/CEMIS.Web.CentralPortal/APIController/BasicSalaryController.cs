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
    [Route("api/BasicSalary")]
    [ApiController]
    public class BasicSalaryController : BaseControllerApI
    {
        private readonly IBasicSalary _basicSalaryRepo;
        private readonly ICollege _collegeRepository;
        public BasicSalaryController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IConfiguration configuration,
                               IBasicSalary basicSalaryRepo, ICollege collegeRepository) : base(userManager, signInManager, roleManager, configuration)
        {
            _basicSalaryRepo = basicSalaryRepo;
            _collegeRepository = collegeRepository;
        }

        // POST api/values

        [HttpGet]
        [Route("GET")]
        public ResponseData<List<BasicSalaryViewModel>> GetTeachingStaffBasic(string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<List<BasicSalaryViewModel>>
                {
                    Message = "Invalid API Key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }
            var res = _basicSalaryRepo.GetAllBasicSalaryAPI();
            return res;
        }

    }
}

