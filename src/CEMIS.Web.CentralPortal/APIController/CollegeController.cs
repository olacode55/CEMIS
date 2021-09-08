using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business.Central.Interface;
using CEMIS.Data.Central;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CEMIS.Utility;
using Cemis.Data.Central.Model;
using CEMIS.Utility.ViewModel;
using Cemis.Data.Central.Entities;

namespace CEMIS.Web.CentralPortal
{
    [Route("api/College")]
    [ApiController]
    public class CollegeController : BaseControllerApI
    {
        private readonly ICollegeLeadership _collegeLeadershipRepository;
        private readonly ICollege _collegeRepository;
        public CollegeController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IConfiguration configuration,
                               ICollegeLeadership collegeLeadershipRepository, ICollege collegeRepository) : base(userManager, signInManager, roleManager, configuration)
        {
            _collegeLeadershipRepository = collegeLeadershipRepository;
            _collegeRepository = collegeRepository;
        }

        // POST api/values

        [HttpPost]
        [Route("PushCollegeInformation")]
        public ResponseData<College> PushCollegeInformation(CollegeDTO collegeVM, string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<College>
                {
                    Message = "Invalid API key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }
           var res = _collegeRepository.PushCollegeInformtion(collegeVM, college);
            return res;
        }


        [HttpPost]
        [Route("PushSession")]
        public ResponseData<AcademicSession> PushCollegeSession(AcademicSessionViewModel sessionVM, string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<AcademicSession>
                {
                    Message = "Invalid API key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }
            var res = _collegeRepository.SessionInformtion(sessionVM, college);
            return res;
        }

      



    }


   

}
