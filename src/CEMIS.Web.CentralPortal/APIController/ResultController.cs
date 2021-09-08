using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemis.Business.Central.Interface;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CEMIS.Web.CentralPortal.APIController
{
    [Route("api/Result")]
    [ApiController]
    public class ResultController : BaseControllerApI
    {
        private readonly IResult _resultRepository;
        private readonly ICollege _collegeRepository;
        public ResultController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IConfiguration configuration
                              , ICollege collegeRepository, IResult resultRepository) : base(userManager, signInManager, roleManager, configuration)
        {
            _resultRepository = resultRepository;
            _collegeRepository = collegeRepository;
        }


        [HttpPost]
        [Route("Push")]
        public ResponseData<ResultViewModel> PushStudentResult(ResponseData<ResultViewModel> resultVM, string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<ResultViewModel>
                {
                    Message = "Invalid API key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }
             var res = _resultRepository.PushStudentResult(resultVM.Data, college.Id);
            return res;

        }
    }
}