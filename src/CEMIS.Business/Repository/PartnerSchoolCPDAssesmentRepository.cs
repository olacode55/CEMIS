using CEMIS.Business.Interface;
using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Repository
{
    public class PartnerSchoolCPDAssesmentRepository : IPartnerSchoolCPDAssesment
    {
        private readonly IRepository<PartnerSchoolCPDAssesment> _partnerSchoolCPDAssesmentRepo;

        public PartnerSchoolCPDAssesmentRepository(IRepository<PartnerSchoolCPDAssesment> partnerSchoolCPDAssesmentRepo)
        {
            _partnerSchoolCPDAssesmentRepo = partnerSchoolCPDAssesmentRepo;
        }

        public async Task CreateAsync(PartnerSchoolCPDAssesment model)
        {
            await _partnerSchoolCPDAssesmentRepo.CreateAsync(model);
        }

        public void Delete(long Id)
        {
            var data = GetById(Id);

            data.IsDeleted = true;
            data.IsActive = false;
            _partnerSchoolCPDAssesmentRepo.Update(data);
            //_partnerSchoolCPDAssesmentRepo.Delete(data);
        }

        public IEnumerable<PartnerSchoolCPDAssesment> GetAll()
        {
            return _partnerSchoolCPDAssesmentRepo.All().Where(x => x.IsDeleted == false && x.IsActive == true).ToList();
        }

        public PartnerSchoolCPDAssesment GetById(long Id)
        {
            return _partnerSchoolCPDAssesmentRepo.Find(Id);
        }
    }
}
