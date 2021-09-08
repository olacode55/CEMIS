using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using CEMIS.Utility;
using CEMIS.Utility.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CEMIS.Business.Repository
{
    public class ProgramRepostory : IProgram
    {
        private readonly IRepository<Program> _programRepo;
        private readonly IAuthUser _authUser;
        private IRepository<TrackCollegeChanges> _trackCollegeChangesRepo;
        private readonly ICollege _collegeRepository;

        public ProgramRepostory(IRepository<Program> programRepo, IAuthUser authUser, IConfiguration _configuration, IRepository<TrackCollegeChanges> trackCollegeChangesRepo
                                , ICollege collegeRepository)
        {
            _programRepo = programRepo;
            _authUser = authUser;
            _collegeRepository = collegeRepository;
            _trackCollegeChangesRepo = trackCollegeChangesRepo;
        }
        public void Create(ProgramViewModel model)
        {
            var program = new Program()
            {
                Name = model.Name,
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                CreatedBy = long.Parse(_authUser.UserId),
                IsDeleted = false,

            };

            var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.Programs);
            module.HasChanged = true;

            using (var scope = new TransactionScope())
            {
                _programRepo.Create(program);
                _collegeRepository.UpdateCollegeIsSynced(1);
                _trackCollegeChangesRepo.Update(module);
                scope.Complete();
            }

        }

        public void Delete(long Id)
        {
            var program = _programRepo.Find(Id);
            program.IsDeleted = true;
            program.IsActive = false;

            var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.Programs);
            module.HasChanged = true;

            using (var scope = new TransactionScope())
            {
                _programRepo.Update(program);
                _collegeRepository.UpdateCollegeIsSynced(1);
                _trackCollegeChangesRepo.Update(module);
                scope.Complete();
            }


        }

        public void Toggle(long Id)
        {
            var program = _programRepo.Find(Id);

            if (program.IsActive == true)
            {
                program.IsActive = false;
                program.UpdatedBy = long.Parse(_authUser.UserId);
                program.DateUpdated = DateTime.Now;
            }
            else
            {
                program.IsActive = true;
                program.UpdatedBy = long.Parse(_authUser.UserId);
                program.DateUpdated = DateTime.Now;
            }


            var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.Programs);
            module.HasChanged = true;

            using (var scope = new TransactionScope())
            {
                _programRepo.Update(program);
                _collegeRepository.UpdateCollegeIsSynced(1);
                _trackCollegeChangesRepo.Update(module);
                scope.Complete();
            }

        }

        public List<ProgramViewModel> GetAllPrograms()
        {
            var program = _programRepo.All()
                .Where(x => x.IsDeleted == false)
                .Select(x => new ProgramViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive

                }).ToList();

            return program;
        }

        public ProgramViewModel GetProgramById(long Id)
        {
            var program = _programRepo.All()
                .Where(x => x.Id == Id)
                .Select(x => new ProgramViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive

                }).FirstOrDefault();

            return program;
        }

        public IEnumerable<SelectListItem> GetProgramList()
        {
            var programList = _programRepo.All()
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            return programList;
        }

        public void Update(ProgramViewModel model)
        {
            var program = _programRepo.Find(model.Id);
            if (program != null)
            {
                program.Name = model.Name;
                program.UpdatedBy = long.Parse(_authUser.UserId);
                program.DateUpdated = DateTime.Now;
                var module = _trackCollegeChangesRepo.All().FirstOrDefault(x => x.ModuleID == (int)CollegeModule.Programs);
                module.HasChanged = true;

                using (var scope = new TransactionScope())
                {
                    _programRepo.Update(program);
                    _collegeRepository.UpdateCollegeIsSynced(1);
                    _trackCollegeChangesRepo.Update(module);
                    scope.Complete();
                }
            }
        }
    }
}
