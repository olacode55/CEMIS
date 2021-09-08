using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEMIS.Business.Repository
{
    public class LevelRepository : ILevel
    {
        private readonly IRepository<Level> _levelRepo;

        public LevelRepository(IRepository<Level> levelRepo, IConfiguration _configuration)
        {
            _levelRepo = levelRepo;
        }

        public List<Level> GetAll()
        {
            return _levelRepo.All().Where(x => x.IsActive == true && x.IsDeleted == false).ToList();
        }
        public IEnumerable<SelectListItem> GetLevelList()
        {
            return _levelRepo.All()
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
        }
    }
}
