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
    public class AcademicSessionRepository : IAcademicSession
    {
        private readonly IRepository<AcademicSession> _academicSessionRepo;

        public AcademicSessionRepository(IRepository<AcademicSession> AcademicSessionRepo)
        {
            _academicSessionRepo = AcademicSessionRepo;
        }
        public async Task CreatAsync(AcademicSession model)
        {
            await _academicSessionRepo.CreateAsync(model);
        }

        public void Delete(long Id)
        {
            var data = _academicSessionRepo.Find(Id);
            _academicSessionRepo.Delete(data);
        }

        public IEnumerable<SelectListItem> GetAcademicSessionList()
        {
            var academicSession = _academicSessionRepo.All()
              .Where(x => x.IsDeleted == false && x.IsActive == true)
              .Select(x => new SelectListItem
              {
                  Text = x.AcademicPeriod,
                  Value = x.Id.ToString()
              }).ToList();

            return academicSession;
        }

        public List<AcademicSession> GetAll()
        {
            return _academicSessionRepo.All()
                .Where(x => x.IsDeleted == false)
                .ToList();
        }

        public AcademicSession GetById(long Id)
        {
            return _academicSessionRepo.Find(Id);
        }

        public void Update(AcademicSession model)
        {
            _academicSessionRepo.Update(model);
        }

        public void Toggle(long Id)
        {
            var academicSession = _academicSessionRepo.Find(Id);

            if (academicSession.IsActive == true)
            {
                academicSession.IsActive = false;
            }
            else
            {
                academicSession.IsActive = true;
            }

            _academicSessionRepo.Update(academicSession);

        }
    }
}
