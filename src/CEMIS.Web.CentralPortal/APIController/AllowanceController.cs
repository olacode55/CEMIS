using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemis.Business.Central.Repository;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CEMIS.Web.CentralPortal
{
    [Route("api/Allowance")]
    [ApiController]
    public class AllowanceController : BaseControllerApI
    {
        private readonly IAllowance _allowanceRepo;
        private readonly ICollege _collegeRepository;
        public AllowanceController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IConfiguration configuration,
                               IAllowance allowanceRepo, ICollege collegeRepository) : base(userManager, signInManager, roleManager, configuration)
        {
            _allowanceRepo = allowanceRepo;
            _collegeRepository = collegeRepository;
        }


        [HttpGet]
        [Route("GET")]
        public ResponseData<List<AllowanceViewModel>> GetAllowance(string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<List<AllowanceViewModel>>
                {
                    Message = "Invalid API Key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }
            var res = _allowanceRepo.GetAllAllowanceAPI();
            return res;
        }
    }
}