using CEMIS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Interface
{
    public interface IPartnerSchoolCPDAssesment
    {
        IEnumerable<PartnerSchoolCPDAssesment> GetAll();

        PartnerSchoolCPDAssesment GetById(long Id);

        Task CreateAsync(PartnerSchoolCPDAssesment model);

        void Delete(long Id);


    }
}
