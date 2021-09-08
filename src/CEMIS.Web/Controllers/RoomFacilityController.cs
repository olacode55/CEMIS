using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CEMIS.Business;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Web.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CEMIS.Web.Controllers
{
    [Authorize]
    public class RoomFacilityController : BaseController
    {

        private readonly IRoomFacility _roomFacilityRepository;
        public RoomFacilityController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                                    IConfiguration configuration, IRoomFacility roomFacilityRepository) : base(userManager, signInManager,
                                    roleManager, configuration)
        {
            _roomFacilityRepository = roomFacilityRepository;

        }
        public IActionResult Index()
        {
            var settings = _roomFacilityRepository.GetRoomSettings();
            return View(settings);
        }

        [HttpPost]
        public IActionResult Update(IFormCollection formCollection)
        {
            _roomFacilityRepository.UpdateRoomFacility(formCollection);

            return RedirectToAction("index");
        }



        public JsonResult GetRoomSetting()
        {
            var roomCount = _roomFacilityRepository.GetClassRoomCount();
            string html = Webutilities.GenerateClassRoom(roomCount);

            return Json(html);
        }

    }
}