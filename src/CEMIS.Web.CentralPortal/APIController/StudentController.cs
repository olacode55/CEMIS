using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cemis.Business.Central.Interface;
using Cemis.Data.Central.Entities;
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
    [Route("api/student")]
    [ApiController]
    public class StudentController : BaseControllerApI
    {
        private readonly IStudent _studentRepository;
        private readonly ICollege _collegeRepository;
        public StudentController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IConfiguration configuration
                              , ICollege collegeRepository , IStudent studentRepository) : base(userManager, signInManager, roleManager, configuration)
        {
            _studentRepository = studentRepository;
            _collegeRepository = collegeRepository;
        }

        [HttpPost]
        [Route("Push")]
        public ResponseData<Student> PushStudentDetails([FromForm] StudentViewModel studentVM, string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<Student>
                {
                    Message = "Invalid API key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }
            var res = _studentRepository.PushStudentDetails(studentVM , college.Id);
            return res;

        }


        [HttpPost]
        [Route("PushStudentLog")]
        public ResponseData<StudentLogViewModel> PushStudentProgressLog(ResponseData<StudentLogViewModel> studentlogVM, string APIKey)
        {
            var college = _collegeRepository.GetCollegeByAPIKey(APIKey);
            if (college == null)
            {
                return new ResponseData<StudentLogViewModel>
                {
                    Message = "Invalid API key",
                    IsSuccessful = false,
                    RespCode = "03"
                };
            }
            var res = _studentRepository.PushStudentLog(studentlogVM.Data, college.Id);
            return res;

        }

    }
}