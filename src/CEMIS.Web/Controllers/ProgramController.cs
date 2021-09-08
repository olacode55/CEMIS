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
    public class ProgramController : BaseController
    {
        private readonly IProgram _programRepository;

        public ProgramController(IProgram programRepository, UserManager<User> userManager, IConfiguration configuration,
            SignInManager<User> signInManager, RoleManager<Role> roleManager)
            : base(userManager, signInManager, roleManager, configuration)
        {
            _programRepository = programRepository;
        }
        public IActionResult Index()
        {

            var program = _programRepository.GetAllPrograms();
            return View(program);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProgramViewModel model)
        {
            string message;

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var programs = _programRepository.GetAllPrograms();
            var checkIfExist = programs.Where(x => x.Name.ToUpper() == model.Name.ToUpper()).ToList();



            if (model.Id > 0)
            {
                checkIfExist = checkIfExist.Where(x => x.Id != model.Id).ToList();
                if (checkIfExist.Count() > 0)
                {
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Program with the name: {model.Name} already exist", Title = "Program Setup", Type = NotificationsType.warning });
                    return RedirectToAction("index");
                }

                _programRepository.Update(model);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Program Updated Successfully!", Title = "Program Setup", Type = NotificationsType.success });
            }
            else
            {

                if (checkIfExist.Count() > 0)
                {
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Program with the name: {model.Name} already exist", Title = "Program Setup", Type = NotificationsType.warning });
                    return RedirectToAction("index");
                }
                _programRepository.Create(model);
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = "Program Created Successfully!", Title = "Program Setup", Type = NotificationsType.success });
            }


            return RedirectToAction("index");
        }

        public JsonResult Manage(long Id)
        {

            var program = _programRepository.GetProgramById(Id);
            return Json(program);

        }


        public IActionResult Delete(long Id)
        {

            _programRepository.Delete(Id);

            TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Deleted Successfully", Title = "Program Setup", Type = NotificationsType.success });
            return RedirectToAction("Index");
        }


        public IActionResult Toggle(long Id)
        {
            var program = _programRepository.GetProgramById(Id);

            if (program != null)
            {
                _programRepository.Toggle(Id);

                if (program.IsActive == true)
                {
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Diactivated Successfull", Title = "Program Setup", Type = NotificationsType.success });
                }
                else
                {
                    TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Activated Successfull", Title = "Program Setup", Type = NotificationsType.success });
                }
                return RedirectToAction("Index", "Program");
            }
            else
            {
                TempData["Notification"] = JsonConvert.SerializeObject(new Notification { Message = $"Program Not Found", Title = "Program Setup", Type = NotificationsType.danger });
                return RedirectToAction("Index", "Program");
            }


        }
    }
}