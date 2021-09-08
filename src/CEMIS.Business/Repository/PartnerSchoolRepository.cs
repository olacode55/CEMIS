using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Repository
{
    public class PartnerSchoolRepository : IPartnerSchool
    {
        private readonly IRepository<PartnerSchool> _partnerSchoolRepo;

        public PartnerSchoolRepository(IRepository<PartnerSchool> PartnerSchoolRepo)
        {
            _partnerSchoolRepo = PartnerSchoolRepo;
        }
        public async Task CreatAsync(PartnerSchool model)
        {
            await _partnerSchoolRepo.CreateAsync(model);
        }

        public void Delete(long Id)
        {
            var data = _partnerSchoolRepo.Find(Id);
            _partnerSchoolRepo.Delete(data);
        }

        public List<PartnerSchool> GetAll()
        {
            return _partnerSchoolRepo.All()
                .Where(x => x.IsDeleted == false)
                .ToList();


        }

        public PartnerSchool GetById(long Id)
        {
            return _partnerSchoolRepo.Find(Id);
        }

        public IEnumerable<SelectListItem> GetPartnerSchoolList()
        {
            var partnerSchools = _partnerSchoolRepo.All()
             .Where(x => x.IsDeleted == false)
             .Select(x => new SelectListItem
             {
                 Text = x.Name,
                 Value = x.Id.ToString()
             }).ToList();

            return partnerSchools;
        }

        public void Toggle(long Id)
        {
            var partnerSchool = _partnerSchoolRepo.Find(Id);

            if (partnerSchool.IsActive == true)
            {
                partnerSchool.IsActive = false;
            }
            else
            {
                partnerSchool.IsActive = true;
            }

            _partnerSchoolRepo.Update(partnerSchool);
        }

        public void Update(PartnerSchool model)
        {
            _partnerSchoolRepo.Update(model);
        }
    }
}
