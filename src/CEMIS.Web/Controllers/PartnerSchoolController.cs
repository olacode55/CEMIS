using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility.ViewModel;
using CEMIS.Web.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CEMIS.Web.Controllers
{
    public class PartnerSchoolController : BaseController
    {
        private readonly IPartnerSchool _partnerSchool;
        private readonly IAuthUser _authUser;

        public PartnerSchoolController(IPartnerSchool partnerSchool, IAuthUser authUser, UserManager<User> userManager, IConfiguration configuration,
            SignInManager<User> signInManager, RoleManager<Role> roleManager)
            : base(userManager, signInManager, roleManager, configuration)
        {
            _partnerSchool = partnerSchool;
            _authUser = authUser;
        }

        public IActionResult Index()
        {
            var partnerSchools = _partnerSchool.GetAll().Select(x => new PartnerSchoolViewModel()
            {
                Name = x.Name,
                HeadTeacher = x.HeadTeacher,
                Address = x.Address,
                CreatedBy = x.CreatedBy,
                DateCreated = x.DateCreated,
                DateUpdated = x.DateUpdated,
                Id = x.Id,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                IsSynched = x.IsSynched,
                NoOfMantees = x.NoOfMantees,
                Phone = x.Phone,
                UpdatedBy = x.UpdatedBy
            }).ToList();


            return View(partnerSchools);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PartnerSchoolViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PartnerSchoolViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            var partnerSchools = _partnerSchool.GetAll();


            var checkIfExist = partnerSchools.Where(x => x.Name.ToUpper() == model.Name.ToUpper());
            if (checkIfExist.Count() > 0)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Partner School: {model.Name} Already exist", Title = "Partner School", Type = NotificationsType.danger });
                return RedirectToAction(nameof(Index));
            }



            var partnerSchool = new PartnerSchool()
            {
                Name = model.Name,
                Address = model.Address,
                HeadTeacher = model.HeadTeacher,
                NoOfMantees = model.NoOfMantees,
                Phone = model.Phone,
                IsSynched = false,
                IsActive = true,
                CreatedBy = long.Parse(_authUser.UserId),
                DateCreated = DateTime.Now,
                IsDeleted = false

            };

            await _partnerSchool.CreatAsync(partnerSchool);

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Partner School: {model.Name} created Successfully", Title = "Partner School", Type = NotificationsType.success });
            return RedirectToAction(nameof(Index));

        }

        public JsonResult Edit(long Id)
        {

            var partnerSchool = _partnerSchool.GetAll()
                .Where(x => x.Id == Id)
                .Select(x => new PartnerSchoolViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    HeadTeacher = x.HeadTeacher,
                    NoOfMantees = x.NoOfMantees,
                    Phone = x.Phone,


                }).FirstOrDefault();
            return Json(partnerSchool);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PartnerSchoolViewModel model)
        {
            if (ModelState.IsValid)
            {
                var partnerSchool = _partnerSchool.GetById(model.Id);
                if (partnerSchool == null)
                {
                    return NotFound();
                }
                else
                {
                    var partnerSchools = _partnerSchool.GetAll();
                    var checkIfExist = partnerSchools.Where(x => x.Name.ToUpper() == model.Name.ToUpper() && x.Id != model.Id);
                    if (checkIfExist.Count() > 0)
                    {
                        TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Partner Schools: {model.Name} Already exist", Title = "Partner School", Type = NotificationsType.danger });
                        return RedirectToAction(nameof(Index));
                    }


                    partnerSchool.Name = model.Name;
                    partnerSchool.Address = model.Address;
                    partnerSchool.HeadTeacher = model.HeadTeacher;
                    partnerSchool.NoOfMantees = model.NoOfMantees;
                    partnerSchool.Phone = model.Phone;
                    partnerSchool.UpdatedBy = long.Parse(_authUser.UserId);
                    partnerSchool.DateUpdated = DateTime.UtcNow;


                    _partnerSchool.Update(partnerSchool);

                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Partner School: {model.Name} updated Successfully", Title = "Partner School", Type = NotificationsType.success });

                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        public IActionResult Toggle(long Id)
        {
            var partnerSchool = _partnerSchool.GetById(Id);


            _partnerSchool.Toggle(Id);


            if (partnerSchool.IsActive == true)
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Partner School: {partnerSchool.Name} Deactivated Successfully", Title = "Partner School", Type = NotificationsType.success });
            }
            else
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Partner School: {partnerSchool.Name} Activated Successfully", Title = "Partner School", Type = NotificationsType.success });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}