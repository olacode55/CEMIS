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
    public class CouncilSessionRepository : ICouncilSession
    {
        private readonly IRepository<CouncilSession> _CouncilSessionRepo;

        public CouncilSessionRepository(IRepository<CouncilSession> CouncilSessionRepo)
        {
            _CouncilSessionRepo = CouncilSessionRepo;
        }
        public async Task CreatAsync(CouncilSession model)
        {
            await _CouncilSessionRepo.CreateAsync(model);
        }

        public void Delete(long Id)
        {
            var data = _CouncilSessionRepo.Find(Id);
            _CouncilSessionRepo.Delete(data);
        }

        //public IEnumerable<SelectListItem> GetAcademicSessionList()
        //{
        //    var academicSession = _academicSessionRepo.All()
        //      .Where(x => x.IsDeleted == false)
        //      .Select(x => new SelectListItem
        //      {
        //          Text = x.AcademicPeriod,
        //          Value = x.Id.ToString()
        //      }).ToList();

        //    return academicSession;
        //}

        public List<CouncilSession> GetAll()
        {
            return _CouncilSessionRepo.All()
                .Where(x => x.IsDeleted == false && x.IsActive== true )
                .ToList();
        }

        public CouncilSession GetById(long Id)
        {
            return _CouncilSessionRepo.Find(Id);
        }

        public void Update(CouncilSession model)
        {
            _CouncilSessionRepo.Update(model);
        }

        public void Toggle(long Id)
        {
            var academicSession = _CouncilSessionRepo.Find(Id);

            if (academicSession.IsActive == true)
            {
                academicSession.IsActive = false;
            }
            else
            {
                academicSession.IsActive = true;
            }

            _CouncilSessionRepo.Update(academicSession);

        }
    }
}
