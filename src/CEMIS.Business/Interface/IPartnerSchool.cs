using CEMIS.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CEMIS.Business.Interface
{
    public interface IPartnerSchool
    {
        List<PartnerSchool> GetAll();

        PartnerSchool GetById(long Id);

        Task CreatAsync(PartnerSchool model);

        void Update(PartnerSchool model);

        void Delete(long Id);

        IEnumerable<SelectListItem> GetPartnerSchoolList();

        void Toggle(long Id);
    }
}
