using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CEMIS.Business;
using CEMIS.Data;
using CEMIS.Data.Entities;
using CEMIS.Data.ViewModel;
using CEMIS.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using CEMIS.Business.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net.Http.Headers;
using CEMIS.Utility.Util;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CEMIS.Web.Controllers
{

    [Authorize]
    public class CommitteController : BaseController
    {
       
        private readonly ICommittee _committe;

        public CommitteController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,
                               IConfiguration configuration,  ICommittee committe) : base(userManager, signInManager,
                               roleManager, configuration)
        {
            _committe = committe;
        }
        public IActionResult Index()
        {
            var committes = _committe.GetAllCommitte();
            return View(committes);
        }
        public IActionResult Edit(long Id)
        {
            var committes = _committe.GetCommitteById(Id);
            return PartialView("_Create", committes);

        }
        public IActionResult Create()
        {
            var model = new CommitteViewModel();
            return PartialView("_Create", model);
        }
        [HttpPost]
        public ActionResult Create(CommitteViewModel model)
        {
           
            if (model.Id > 0)
            {
                _committe.UpdateCommitte(model, true);
            }
            else
            {
                _committe.CreateCommitte(model, true);
            }
          
            return RedirectToAction("Index");
        }
     

        //public IActionResult Delete(long Id)
        //{
        //    _staffRepository.DeleteTeachingStaff(Id , true);
        //    return RedirectToAction("Index");
        //}
       
        }
    }
