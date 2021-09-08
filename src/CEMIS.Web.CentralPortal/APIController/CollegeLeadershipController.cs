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
using Cemis.Data.Central.Entities;

namespace CEMIS.Web.CentralPortal
{
    [Route("api/CollegeLeadership")]
    [ApiController]
    public class CollegeLeadershipController : BaseControllerApI
    {
        private readonly ICollegeLeadership _collegeLeadershipRepository;
        private readonly ICollege _collegeRepository;
        public CollegeLeadershipController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IConfiguration configuration,
                               ICollegeLeadership collegeLeadershipRepository, ICollege collegeRepository) : base(userManager, signInManager, roleManager, configuration)
        {
            _collegeLeadershipRepository = collegeLeadershipRepository;
            _collegeRepository = collegeRepository;
        }

        // POST api/values

        [HttpPost]
        [Route("PushCollegeLeaders")]
        public ResponseData<CollegeLeadership> PushCollegeLeadership(CollegeLeadershipViewModel collegeLeadership, string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<CollegeLeadership>
                {
                    Message = "Invalid API key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }

                var res = _collegeLeadershipRepository.PushCollegeLeadership(collegeLeadership, college.Id);
                return res;

            
            
        }


        [HttpPost]
        [Route("PushCouncilSessions")]
        public ResponseData<CouncilSessionViewModel> PushCollegeCouncilSession(ResponseData<CouncilSessionViewModel> councilMemberVM, string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<CouncilSessionViewModel>
                {
                    Message = "Invalid API key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }

            var res = _collegeLeadershipRepository.PushCouncilSession(councilMemberVM.Data, college.Id);
            return res;



        }


        [HttpPost]
        [Route("PushCouncilMembers")]
        public ResponseData<CouncilMember> PushCollegeCouncilMembers(CouncilMemberViewModel councilMemberVM, string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<CouncilMember>
                {
                    Message = "Invalid API key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }

            var res = _collegeLeadershipRepository.PushCollegeCouncilMembers(councilMemberVM, college.Id);
            return res;



        }

        [HttpPost]
        [Route("PushCommitee")]
        public ResponseData<CommitteViewModel> PushCommitee(CommitteViewModel CommiteeVM, string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<CommitteViewModel>
                {
                    Message = "Invalid API key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }
            var res = _collegeLeadershipRepository.PushCommitee(CommiteeVM, college.Id);
            return res;
        }

        [HttpPost]
        [Route("PushCommiteeMembers")]
        public ResponseData<CommitteMemberViewModel> PushCommiteeMembers(CommitteMemberViewModel CommiteeMemberVM, string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<CommitteMemberViewModel>
                {
                    Message = "Invalid API key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }
            var res = _collegeLeadershipRepository.PushComiteeMembers(CommiteeMemberVM, college.Id);
            return res;
        }


       

    }
}